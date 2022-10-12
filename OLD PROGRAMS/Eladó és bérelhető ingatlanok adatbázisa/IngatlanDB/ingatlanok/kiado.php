<?php
include "mysqli_burkolo.php";
include "ucfirst_magyar.php";
include "setting.php";

session_start();

$parancs = 
"SELECT ingatlan_id, szandek, tipus, telepules, ar, alapt, telekt, szoba, datum, kepek 
FROM ikinalat, iszandek, itipus, itelepules, ikepek 
WHERE szandek_sz = szandek_id AND tipus_sz = tipus_id AND telepules_sz = telepules_id 
AND ingatlan_sz_kep = ingatlan_id AND kepek LIKE '%1.jpg' AND szandek = 'kiadó'";

//keresés
if (isset($_POST["keres"])){
	//törli az akt. sessiont
	if (isset($_SESSION["kereseshez"]) && isset($_SESSION["kereses"])){
		unset($_SESSION["kereseshez"]);
		unset($_SESSION["kereses"]);
	}
	//településre
	if (isset($_POST["telepules"]) && ($_POST["telepules"] != "")){
		$telepules = " AND telepules = '".mb_ucfirst($_POST["telepules"])."'";
		$_SESSION["kereseshez"]["telepules"] = $telepules;
		$_SESSION["kereses"]["telepules"] = $_POST["telepules"];
	}
	//típusra
	if (isset($_POST["tipus"]) && ($_POST["tipus"] != "0")){
		$tipus = " AND tipus = '".$_POST["tipus"]."'";
		$_SESSION["kereseshez"]["tipus"] = $tipus;
		$_SESSION["kereses"]["tipus"] = $_POST["tipus"];
	}
	//szobára
	if (isset($_POST["szoba"]) && ($_POST["szoba"] != "0")){
		if (($_POST["szoba"] > "0") && ($_POST["szoba"] != "5"))
			$szoba =  " AND szoba = ".$_POST["szoba"];
		else $szoba =  " AND szoba >= ".$_POST["szoba"];
		$_SESSION["kereseshez"]["szoba"] = $szoba;
		$_SESSION["kereses"]["szoba"] = $_POST["szoba"];
	}
	//területre
	if (isset($_POST["terulet"]) && $_POST["terulet"] != "0"){
		switch ($_POST["terulet"]){
		case 1 : $terulet = " AND alapt BETWEEN 0 AND 100"; break;
		case 2 : $terulet = " AND alapt BETWEEN 100 AND 150"; break;
		case 3 : $terulet = " AND alapt BETWEEN 150 AND 200"; break;
		case 4 : $terulet = " AND alapt BETWEEN 200 AND 300"; break;
		case 5 : $terulet = " AND alapt >= 300"; break;
		}
		$_SESSION["kereseshez"]["terulet"] = $terulet;
		$_SESSION["kereses"]["terulet"] = $_POST["terulet"];
	}
	//árra
	if (isset($_POST["min"]) && isset($_POST["max"]) && ($_POST["min"] != "") && ($_POST["max"] != "")){
	$min = $_POST["min"]*1000;
	$max = $_POST["max"]*1000;
	$ertek = " AND ar BETWEEN ".$min." AND ".$max;
	$_SESSION["kereseshez"]["ertek"] = $ertek;
	$_SESSION["kereses"]["min"] = $_POST["min"];
	$_SESSION["kereses"]["max"] = $_POST["max"];
	}
	else{ 
		if (isset($_POST["min"]) && ($_POST["min"] != "")){
			$min = $_POST["min"]*1000;
			$ertek = " AND ar >= ".$min;
			$_SESSION["kereseshez"]["ertek"] = $ertek;
			$_SESSION["kereses"]["min"] = $_POST["min"];
		}
		if (isset($_POST["max"]) && ($_POST["max"] != "")){
			$max = $_POST["max"]*1000;
			$ertek = " AND ar <= ".$max;
			$_SESSION["kereseshez"]["ertek"] = $ertek;
			$_SESSION["kereses"]["max"] = $_POST["max"];
		}
	}
}

if (isset($_GET["sess"])){
	if (isset($_SESSION["kereseshez"]["telepules"])) $parancs .= $_SESSION["kereseshez"]["telepules"];	
	if (isset($_SESSION["kereseshez"]["tipus"])) $parancs .= $_SESSION["kereseshez"]["tipus"];	
	if (isset($_SESSION["kereseshez"]["szoba"])) $parancs .= $_SESSION["kereseshez"]["szoba"];	
	if (isset($_SESSION["kereseshez"]["terulet"])) $parancs .= $_SESSION["kereseshez"]["terulet"];	
	if (isset($_SESSION["kereseshez"]["ertek"])) $parancs .= $_SESSION["kereseshez"]["ertek"];
} 
else if (isset($_SESSION["kereseshez"]) && isset($_SESSION["kereses"])){
		unset($_SESSION["kereseshez"]);
		unset($_SESSION["kereses"]);
	}
	
//rendezés
if (isset($_POST["orderBy"])){
	$rendez = $_POST["orderBy"];
	$_SESSION["rendezes"] = $rendez;
}
else if (isset($_GET["sess"]) && isset($_SESSION["rendezes"])) $rendez = $_SESSION["rendezes"];
	else{ 
		$rendez = "datum DESC";
		if (isset($_SESSION["rendezes"])) unset($_SESSION["rendezes"]);
	}				

$rendezes = " ORDER BY ".$rendez;
$parancs.=$rendezes;

//lekérdezés
$ingatlanok = DB_getrows($parancs);

//oldalszámok
if (isset($_GET["osz"])) $osz = $_GET["osz"];
else $osz = 1;

define("db", 6);
$n=count($ingatlanok);
$m=$n%db;
if($m!=0) $m=1;
$oszn=floor($n/db)+$m;

DB_close();
?>

<!DOCTYPE html>
<html>
	<head>
	<title>Eladó és bérelhető ingatlanok</title>
	<link href="kepek/ingatlan.ico" rel="icon" type="image/x-icon" />
	<meta http-equiv="Content-Type" content="text/html; charset="UTF-8">
	<link rel="stylesheet" href="alap1.css">
	</head>
	<body>
		<div id="fejlec">
			<img id="logo" src="kepek/ingatlankep.png" alt="ingatlanos kép">	
			<div id="menu" >
				<ul>
					<li><a href="index.php"><b>Főoldal</b></a></li>
					<li><a href="elado.php"><b>Eladó ingatlanok</b></a></li>
					<li class="aktOldal"><a href="kiado.php"><b>Kiadó ingatlanok</b></a></li>
					<li><a href="elerhetoseg.php"><b>Elérhetőségeink</b></a></li>
				</ul>
			</div>	
		</div>
	
		<div id="tartalom">
			<div id="resz2">
				<h2> Kiadó ingatlanok </h2>
				<span> 
				<?php
				print '('.$n.' db találat)';
				?> 
				</span>
			</div>
			<hr>			
			<div id="rendezes">
				<form action="kiado.php?sess=1" method="post">
					<label for="orderBy"> Rendezés: </label>
					<select name="orderBy" id="orderBy">
						<option value="datum DESC" <?php if($rendez == "datum DESC")  
							print 'selected="true";' ?> > legfrissebb elöl </option>
						<option value="datum ASC" <?php if($rendez == "datum ASC")
							print 'selected="true";' ?> > legrégebbi elöl </option>
						<option value="ar ASC" <?php if($rendez == "ar ASC")
							print 'selected="true";' ?> > legolcsóbb elöl </option>
						<option value="ar DESC" <?php if($rendez == "ar DESC") 
							print 'selected="true";' ?> > legdrágább elöl </option>
					</select>
					<input type="submit" name="rendez" class="gomb" value="Rendezés" />
				</form>
			</div>						
			
			<div id="ingatlanok">
				<?php
				if ($n!=0){
					if ($osz == $oszn) $m=db-($osz*db-$n);
					else $m=db;
					
					for($i=0; $i<$m; $i++){
						$j=($osz-1)*db+$i;
						
						$ar = number_format($ingatlanok[$j]["ar"], 0 , ' , ' ,  ' ');
						
						if ($ingatlanok[$j]["tipus"]=="ház") $tipus = "Családi ház";
						else $tipus = mb_ucfirst($ingatlanok[$j]["tipus"]);
						
						$datum = date_create($ingatlanok[$j]["datum"]);
						$datum = date_format($datum, 'Y.m.d'); 
						
						print '
						<div class="ingatlan">
							<a href="ingatlan.php?id='.$ingatlanok[$j]["ingatlan_id"].'">
								<img class="ingatlanKep" src="'.$ingatlanok[$j]["kepek"].'" 
									alt="ingatlan'.$ingatlanok[$j]["ingatlan_id"].'">
								<div class="ingatlanSzoveg">
									<div class="ingatlanTitle">
										<h2> '.ucfirst($ingatlanok[$j]["szandek"])." ".$ingatlanok[$j]["tipus"].
											", ".$ingatlanok[$j]["telepules"].' </h2>
									</div>
									<span class="ingatlanAr"> '.$ar.' Ft/hó </span>
									<ul class="ingatlanLista">
										<li> Típus: '.$tipus.' </li>';
										
										if($ingatlanok[$j]["szoba"]!=0) print'
										<li> Szobák: '.$ingatlanok[$j]["szoba"].' </li>';
										else print'<li> &nbsp </li>';
										
										print '
										<li> Alapterület: '.$ingatlanok[$j]["alapt"].' m² </li>';
										
										if($ingatlanok[$i]["telekt"]!=0) print'
										<li> Telekterület: '.$ingatlanok[$j]["telekt"].' m² </li>';
										else print'<li> &nbsp </li>';
										
									print '
									</ul>
									<span class="ingatlanDatum"> Feltöltve: 
									<b> '.$datum.' </b>
									</span>
									<div class="ingatlanReszlet"> Részletek >> </div>
								</div>
							</a>
						</div>';
					}
				}
				?>
			</div>	
			
			<div id="kereses">
				<form action="kiado.php?sess=1" method="post">
					<h2> Ingatlan kereső </h2>
					<span class="kereseshez">
						<b> Település: </b>		
						<?php if (isset($_SESSION["kereses"]["telepules"])) 
								print '<input type="text" name="telepules" placeholder="Mind" value='.$_SESSION["kereses"]["telepules"].' />';
							else print '<input type="text" name="telepules" placeholder="Mind" />';
						?>
					</span>
					<span class="kereseshez">
						<b> Típus: </b>
						<select name="tipus">
							<option value="0" <?php if(!isset($_SESSION["kereses"]["tipus"])) 
												print 'selected="selected"'; ?> > Mind </option>
							<option value="ház" <?php if(isset($_SESSION["kereses"]["tipus"]) && ($_SESSION["kereses"]["tipus"] == "ház")) 
													print 'selected="selected"'; ?> > Ház </option>
							<option value="lakás" <?php if(isset($_SESSION["kereses"]["tipus"]) && ($_SESSION["kereses"]["tipus"] == "lakás")) 
													print 'selected="selected"'; ?> > Lakás </option>
							<option value="üzleti" <?php if(isset($_SESSION["kereses"]["tipus"]) && ($_SESSION["kereses"]["tipus"] == "üzleti")) 
													print 'selected="selected"'; ?> > Üzleti </option>
							<option value="telek" <?php if(isset($_SESSION["kereses"]["tipus"]) && ($_SESSION["kereses"]["tipus"] == "telek")) 
													print 'selected="selected"'; ?> > Telek </option>
							<option value="mezőgazdasági" <?php if(isset($_SESSION["kereses"]["tipus"]) && ($_SESSION["kereses"]["tipus"] == "mezőgazdasági")) 
													print 'selected="selected"'; ?> > Mezőgazdasági </option>					
						</select>
					</span>
					<span class="kereseshez">
						<b> Szobák: </b>
						<select name="szoba">
							<option value="0" <?php if(!isset($_SESSION["kereses"]["szoba"])) 
												print 'selected="selected"'; ?> > Mind </option>
							<option value="1" <?php if(isset($_SESSION["kereses"]["szoba"]) && ($_SESSION["kereses"]["szoba"] == "1")) 
													print 'selected="selected"'; ?> > 1 </option>
							<option value="2" <?php if(isset($_SESSION["kereses"]["szoba"]) && ($_SESSION["kereses"]["szoba"] == "2")) 
													print 'selected="selected"'; ?> > 2 </option>
							<option value="3" <?php if(isset($_SESSION["kereses"]["szoba"]) && ($_SESSION["kereses"]["szoba"] == "3")) 
													print 'selected="selected"'; ?> > 3 </option>
							<option value="4" <?php if(isset($_SESSION["kereses"]["szoba"]) && ($_SESSION["kereses"]["szoba"] == "4")) 
													print 'selected="selected"'; ?> > 4 </option>
							<option value="5" <?php if(isset($_SESSION["kereses"]["szoba"]) && ($_SESSION["kereses"]["szoba"] == "5")) 
													print 'selected="selected"'; ?> > 5+ </option>	
						</select>
					</span >
					<span class="kereseshez">
						<b> Terület: </b>
						<select name="terulet">
							<option value="0" <?php if(!isset($_SESSION["kereses"]["terulet"])) 
												print 'selected="selected"'; ?> > Mind </option>
							<option value="1" <?php if(isset($_SESSION["kereses"]["terulet"]) && ($_SESSION["kereses"]["terulet"] == "1")) 
													print 'selected="selected"'; ?> > 0-100 </option>
							<option value="2" <?php if(isset($_SESSION["kereses"]["terulet"]) && ($_SESSION["kereses"]["terulet"] == "2")) 
													print 'selected="selected"'; ?> > 100-150 </option>
							<option value="3" <?php if(isset($_SESSION["kereses"]["terulet"]) && ($_SESSION["kereses"]["terulet"] == "3")) 
													print 'selected="selected"'; ?> > 150-200 </option>	
							<option value="4" <?php if(isset($_SESSION["kereses"]["terulet"]) && ($_SESSION["kereses"]["terulet"] == "4")) 
													print 'selected="selected"'; ?> > 200-300 </option>
							<option value="5" <?php if(isset($_SESSION["kereses"]["terulet"]) && ($_SESSION["kereses"]["terulet"] == "5")) 
													print 'selected="selected"'; ?> > 300+ </option>
						</select> m²
					</span>
					<span class="kereseshez">
						<b> Ár: </b>
						<?php if (isset($_SESSION["kereses"]["min"]))
								print '<input class="ar" type="text" name="min" placeholder="min" value='.$_SESSION["kereses"]["min"].' /> - ';
							else print '<input class="ar" type="text" name="min" placeholder="min" /> - ';
							  if (isset($_SESSION["kereses"]["max"]))
								print '<input class="ar" type="text" name="max" placeholder="max" value='.$_SESSION["kereses"]["max"].' /> ezer Ft';
							else print '<input class="ar" type="text" name="max" placeholder="max" /> ezer Ft';
						?>
					</span>
					<input type="submit" name="keres" class="gomb" id="keres" value="Keresés" />
				</form>
			</div>	

			<div id=oldalsz>
				<div id="oldalak">
				<?php
				for($i=1; $i<=$oszn; $i++){
					if($i==$osz) print '<b> '.$i.' </b>';
					else print '<a href="kiado.php?sess=1&osz='.$i.'" title="oldal'.$i.'"> '.$i.' </a>';
				}
				?>
				</div>
			</div>			
			
		</div>
		
	</body>
</html>