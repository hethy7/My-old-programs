<?php
include "mysqli_burkolo.php";
include "setting.php";

$legfriss = DB_getrows("
SELECT ingatlan_id, szandek, tipus, telepules, ar, alapt, telekt, szoba, leiras, datum, kepek
FROM ikinalat, iszandek, itipus, itelepules, ikepek
WHERE szandek_sz = szandek_id AND tipus_sz = tipus_id AND telepules_sz = telepules_id 
AND ingatlan_sz_kep = ingatlan_id AND kepek LIKE '%1.jpg'
ORDER BY datum DESC LIMIT 4
");

$kiemelt = DB_getrows("
SELECT ingatlan_id, szandek, tipus, telepules, ar, alapt, telekt, szoba, kepek 
FROM ikinalat, iszandek, itipus, itelepules, kiemelt, ikepek 
WHERE szandek_sz = szandek_id AND tipus_sz = tipus_id AND telepules_sz = telepules_id 
AND ingatlan_sz_kie = ingatlan_id AND ingatlan_sz_kep = ingatlan_id AND kepek LIKE '%1.jpg'
");

$rkiemlet = array_rand($kiemelt, 3);

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
					<li class="aktOldal"><a href="index.php"><b>Főoldal</b></a></li>
					<li><a href="elado.php"><b>Eladó ingatlanok</b></a></li>
					<li><a href="kiado.php"><b>Kiadó ingatlanok</b></a></li>
					<li><a href="elerhetoseg.php"><b>Elérhetőségeink</b></a></li>
				</ul>
			</div>	
		</div>
	
		<div id="tartalom">
			<div id="doboz1">
				<h2 class="resz1"> Kiemelt ajánlataink </h2>
				
				<?php
				for($i=0; $i<3; $i++){
					
					$ar = number_format($kiemelt[$rkiemlet[$i]]["ar"], 0 , ' , ' ,  ' ');
					
					if ($kiemelt[$rkiemlet[$i]]["szandek"]=="eladó")
						$penz=" Ft";
					else $penz=" Ft/hó";
								
					print '
					<div class="kiemelt1">
						<a href="ingatlan.php?id='.$kiemelt[$rkiemlet[$i]]["ingatlan_id"].'">
							<img class="kiemeltKep" src="'.$kiemelt[$rkiemlet[$i]]["kepek"].'" alt="kiemelt kép">
							<div class="kiemeltSzoveg">
								<div class="kiemeltTitle">
									<h3> '.ucfirst($kiemelt[$rkiemlet[$i]]["szandek"])." ".$kiemelt[$rkiemlet[$i]]["tipus"]
										.", ".$kiemelt[$rkiemlet[$i]]["telepules"].' </h3>
								</div>
								<span class="kiemeltAr"> '.$ar.$penz.'</span>
								<ul>
									<li> Szobák: '.$kiemelt[$rkiemlet[$i]]["szoba"].' </li>
									<li> Alapterület: '.$kiemelt[$rkiemlet[$i]]["alapt"].' m² </li>
									<li> Telekterület: '.$kiemelt[$rkiemlet[$i]]["telekt"].' m² </li>
								</ul>
								<div class="kiemeltReszlet">RÉSZLETEK...</div>
							</div>
						</a>
					</div>';
				}
				?>
				
			</div>
			
			<div id="doboz2">
				<h2 class="resz1"> Legfrissebb ingatlanok </h2>
				
				<?php
				for($i=0; $i<4; $i++){
					
					$ar = number_format($legfriss[$i]["ar"], 0 , ' , ' ,  ' ');
					
					if ($legfriss[$i]["szandek"]=="eladó") $penz=" Ft";
					else $penz=" Ft/hó";
					
					if (strlen($legfriss[$i]["leiras"]) > 220)
						$leiras= substr($legfriss[$i]["leiras"], 0, 220)."...";
					else $leiras = $legfriss[$i]["leiras"];
					
					print '
					<div class="legfrisebb1">
						<a href="ingatlan.php?id='.$legfriss[$i]["ingatlan_id"].'">
							<img class="frissKep" src="'.$legfriss[$i]["kepek"].'" alt="friss kép">
							<div class="frissSzoveg">
								<div class="frissTitle">
									<h3> '.ucfirst($legfriss[$i]["szandek"])." ".$legfriss[$i]["tipus"].
										", ".$legfriss[$i]["telepules"].' </h3>
								</div>
								<span class="frissAr"> '.$ar.$penz.' </span>
								<ul class="frissLista">
									<li> Szobák: '.$legfriss[$i]["szoba"].' </li>
									<li> Alapterület: '.$legfriss[$i]["alapt"].' m² </li>
									<li> Telekterület: '.$legfriss[$i]["telekt"].' m² </li>
								</ul>
								<div class="frissReszlet"> '.$leiras.' </div>
							</div>
						</a>
					</div>';
				}
				?>	
							
			</div>	
		</div>
	</body>
</html>