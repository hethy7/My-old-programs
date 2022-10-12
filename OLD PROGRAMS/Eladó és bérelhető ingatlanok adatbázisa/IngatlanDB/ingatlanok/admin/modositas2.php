<?php
include "../mysqli_burkolo.php";
include "../ucfirst_magyar.php";
include "../setting.php";

session_start();

if (!isset($_SESSION["login"])) header("Location: ".$_SESSION["url"]);

if (isset($_GET["id"])){	
	$id = $_GET["id"];
	$ingatlan = DB_getrow("SELECT szandek_sz, tipus_sz, telepules, megye, 
	jelleg_sz, szoba, komfort_sz, ev, alapt, telekt, leiras, ar, datum
	FROM ikinalat, itelepules
	WHERE telepules_sz = telepules_id AND ingatlan_id =".$id, 0);
	
	$szandek = $ingatlan["szandek_sz"];
	$tipus = $ingatlan["tipus_sz"];
	$telepules = $ingatlan["telepules"];
	$megye = $ingatlan["megye"];
	$jelleg = $ingatlan["jelleg_sz"];
	$szoba = $ingatlan["szoba"];
	$komfort = $ingatlan["komfort_sz"];
	$ev = $ingatlan["ev"];
	$alapt = $ingatlan["alapt"];
	$telekt = $ingatlan["telekt"];
	$leiras = $ingatlan["leiras"];
	$ar = $ingatlan["ar"];
	$datum = $ingatlan["datum"];
	
	$kiemeltek = DB_getcolumn("SELECT ingatlan_sz_kie FROM kiemelt", "ingatlan_sz_kie");
	if (in_array($id, $kiemeltek)) $kiemelt = true;
	
	$felszereltseghez = DB_getcolumn("SELECT felszereltseg_sz FROM if_kapcsolat WHERE ingatlan_sz_fel=".$id." ORDER BY felszereltseg_sz ASC", "felszereltseg_sz");		
	$felszereltseg = array();
	if (isset($felszereltseghez) && $felszereltseghez){
		for ($i=0; $i<7; $i++){
			if (in_array($i+1,$felszereltseghez)) $felszereltseg[$i] = true;
		}
	}
}

if ($sess = isset($_GET["sess"]))
	if (isset($_SESSION["adatok"])){
		//ingatlan id
		$id = $_SESSION["adatok"]["id"];
		//szándék
		$szandek = $_SESSION["adatok"]["szandek"];
		//kiemelt ellenőrzés
		if (isset($_SESSION["adatok"]["kiemelt"])) $kiemelt = true;
		//típus
		$tipus = $_SESSION["adatok"]["tipus"];
		//megye ellenőrzés
		if (isset($_SESSION["adatok"]["megye"])) $megye = $_SESSION["adatok"]["megye"];
		//telepulés ellenőrzés
		if (isset($_SESSION["adatok"]["telepules"])) $telepules = $_SESSION["adatok"]["telepules"];
		//alapterület ellenőrzés
		if (isset($_SESSION["adatok"]["alapt"])) $alapt = $_SESSION["adatok"]["alapt"];
		//telekterület ellenőrzés
		if (isset($_SESSION["adatok"]["telekt"])) $telekt = $_SESSION["adatok"]["telekt"];
		//jelleg
		$jelleg = $_SESSION["adatok"]["jelleg"];
		//komfort
		$komfort = $_SESSION["adatok"]["komfort"];
		//szoba ellenőrzés
		if (isset($_SESSION["adatok"]["szoba"])) $szoba = $_SESSION["adatok"]["szoba"];
		//építkezési ellenőrzés
		if (isset($_SESSION["adatok"]["ev"])) $ev = $_SESSION["adatok"]["ev"];
		//felszereltség ellenőrzés
		if (isset($_SESSION["adatok"]["felszereltseg"])){
			$felszereltseg = array();
			for ($i=0; $i<7; $i++){
				if (in_array($i+1,$_SESSION["adatok"]["felszereltseg"])) $felszereltseg[$i] = true;
			}
		}
		//leiras ellenőrzés
		if (isset($_SESSION["adatok"]["leiras"])) $leiras = $_SESSION["adatok"]["leiras"];
		//ár ellenőrzés
		if (isset($_SESSION["adatok"]["ar"])) $ar = $_SESSION["adatok"]["ar"];
		//dátum ellenőrzés
		if (isset($_SESSION["adatok"]["datum"])) $datum = $_SESSION["adatok"]["datum"];
	}
else if (isset($_SESSION["adatok"])) unset($_SESSION["adatok"]);

//adatbázisban lévő képek
$kepek = DB_getcolumn("SELECT kepek FROM ikepek WHERE ingatlan_sz_kep = ".$id, "kepek");

DB_CLOSE();
?>

<!DOCTYPE html>
<html>
	<head>
	<title>Eladó és bérelhető ingatlanok</title>
	<link href="kepek/ingatlan.ico" rel="icon" type="image/x-icon" />
	<meta http-equiv="Content-Type" content="text/html; charset="UTF-8">
	<link rel="stylesheet" href="alap2.css">
	<script src="num_formatting/jquery-2.2.3.min.js"></script>
	<script src="num_formatting/jquery.number.min.js"></script>
	</head>
	<body>
		<div id="tartalom">
			<div id="felso">
				<span id="cim"> Adminisztráció - Ingatlanok </span>
			</div>
			<div id="doboz2">
				<div id="menu" >
					<ul>
						<li><a href="fooldal.php"><b>Főoldal</b></a></li>
						<li><a href="felvetel.php"><b>Ingatlan felvétel</b></a></li>
						<li class="aktOldal"><a href="modositas.php"><b>Ingatlan módosítás</b></a></li>
						<li><a href="torles.php"><b>Ingatlan törlés</b></a></li>
						<li><a href="login/logout.php"><b>Kijelentkezés</b></a></li>
					</ul>
				</div>
				
				<div id="doboz3">
					<div id="resz">
						<h2> Ingatlan módosítás </h2>
						<span> Ingatlan #<?php print $id; ?> </span>
					</div>
					
					<div id="adaturlap">
						<form method="post" action="adminos/update.php?id=<?php print $id; ?>" enctype="multipart/form-data">
							<table>								
								<tr>
									<td> <span class="bevitel">
											<b> Szándék </b>
											<?php if(isset($szandek) && ($szandek==2)) print '
											<input type="radio" name="szandek" value="1" /> eladó
											<input type="radio" name="szandek" value="2" checked="checked" /> kiadó';
											else print'
											<input type="radio" name="szandek" value="1" checked="checked" /> eladó
											<input type="radio" name="szandek" value="2" /> kiadó'; ?>
											<div class="kiemelt"> <input type="checkbox" name="kiemelt" 
												<?php if(isset($kiemelt)) print 'checked="checked"'; ?> /> kiemelt </div> 
										</span> 
									</td>
									<td> <span class="bevitel">
											<b> Típus </b>					
											<select name="tipus">
												<option value="1" <?php if(isset($tipus) && ($tipus==1)) print 'selected="selected"'; ?> > Ház </option>
												<option value="2" <?php if(isset($tipus) && ($tipus==2)) print 'selected="selected"'; ?> > Lakás </option>
												<option value="3" <?php if(isset($tipus) && ($tipus==3)) print 'selected="selected"'; ?> > Üzleti </option>
												<option value="4" <?php if(isset($tipus) && ($tipus==4)) print 'selected="selected"'; ?> > Telek </option>
												<option value="5" <?php if(isset($tipus) && ($tipus==5)) print 'selected="selected"'; ?> > Mezőgazdasági </option>
											</select>
										</span> 
									</td>
									<td rowspan="8" id="kepekre">
										<div id="info">
											<b> Az ingatlan képei </b>
											<div> Legalább egy kép feltöltése kötelező! </br>
															Támogatott fájlformátumok: JPEG JPG PNG </br>
															Maximális fájlméret: 2MB 
											</div>
										</div>
										
										<div class="kepek"> 1.kép <input type="file" id="files1" name="kepek[]" /> </div>								
										<div class="kepek"> 2.kép <input type="file" id="files2" name="kepek[]" /> </div>
										<div class="kepek"> 3.kép <input type="file" id="files3" name="kepek[]" /> </div>
										<div class="kepek"> 4.kép <input type="file" id="files4" name="kepek[]" /> </div>
										<div class="kepek"> 5.kép <input type="file" id="files5" name="kepek[]" /> </div>
										<div class="kepek"> 6.kép <input type="file" id="files6" name="kepek[]" /> </div>
										<div class="kepek"> 7.kép <input type="file" id="files7" name="kepek[]" /> </div>
										<div class="kepek"> 8.kép <input type="file" id="files8" name="kepek[]" /> </div>			
										
										<div id="kephely">
										<?php for($i=1; $i<=8; $i++){
											$j = $i-1;
											if (isset($kepek[$j])) $src = "../".$kepek[$j];
											else $src = "kepek/no_image.png";
											print '
											<img class="image" id="image'.$i.'" src="'.$src.'"/>
											<script>
											document.getElementById("files'.$i.'").onchange = function () {
												var reader = new FileReader();

												reader.onload = function (e) {
													// get loaded data and render thumbnail.
													document.getElementById("image'.$i.'").src = e.target.result;
												};

												// read the image file as a data URL.
												reader.readAsDataURL(this.files[0]);
											};
											</script>';
										} ?>
										</div>
										
										<div id="keptorol">
											Képtörlés
										<?php if (isset($kepek)){
												$n = count($kepek);
												for ($i=1; $i<=8; $i++)
													if ($i == 1) print ' <input class="single-checkbox" type="checkbox" name="torolheto[]" value="'.$i.'" disabled="disabled" /> '.$i;
													else print ' <input class="single-checkbox" type="checkbox" name="torolheto[]" value="'.$i.'" /> '.$i;
											}
										?>
										</div>
									</td>
								</tr>
								<tr>
									<td> <span class="bevitel">
											<b> Település </b>					
											<?php if (isset($telepules)) print '<input type="text" name="telepules" value="'.$telepules.'" />';
													else if ($sess) print '<input type="text" name="telepules" value="" /> <label class="kotelezo"> ** </label>';
														else print '<input type="text" name="telepules" value="" />'; ?>
										</span> 
									</td>
									<td>
										<span class="bevitel">
											<b> Megye </b>
											<?php if (isset($megye)) print '<input type="text" name="megye" value="'.$megye.'" />';
													else if ($sess) print '<input type="text" name="megye" value="" /> <label class="kotelezo"> ** </label>'; 
														else print '<input type="text" name="megye" value="" />'; ?>
										</span>
									</td>
								</tr>
								<tr>
									<td> <span class="bevitel">
											<b> Jelleg </b>					
											<select name="jelleg">
												<option value="1" <?php if(isset($jelleg) && ($jelleg==1)) print 'selected="selected"'; ?> > Téglaépület</option>
												<option value="2" <?php if(isset($jelleg) && ($jelleg==2)) print 'selected="selected"'; ?> > Faház </option>
												<option value="3" <?php if(isset($jelleg) && ($jelleg==3)) print 'selected="selected"'; ?> > Beépítetlen terület </option>
												<option value="4" <?php if(isset($jelleg) && ($jelleg==4)) print 'selected="selected"'; ?> > Külterület </option>
												<option value="5" <?php if(isset($jelleg) && ($jelleg==5)) print 'selected="selected"'; ?> > Erdő </option>
												<option value="6" <?php if(isset($jelleg) && ($jelleg==6)) print 'selected="selected"'; ?> > Szántó </option>
												<option value="7" <?php if(isset($jelleg) && ($jelleg==7)) print 'selected="selected"'; ?> > Külterületi szántó </option>
											</select>
										</span> 
									</td>
									<td> <span class="bevitel">
											<b> Szoba </b>					
											<?php if (isset($szoba)) print '<input class="number" type="text" name="szoba" value="'.$szoba.'" size="10" />';			
													else if ($sess) print '<input class="number" type="text" name="szoba" value="" size="10" /> <label class="kotelezo"> ** </label>'; 
														else print '<input class="number" type="text" name="szoba" value="" size="10" />'; ?>
										</span>
									</td>
								</tr>
								<tr>
									<td> <span class="bevitel">
											<b> Komfort </b>					
											<select name="komfort">
												<option value="1" <?php if(isset($komfort) && ($komfort==1)) print 'selected="selected"'; ?> > Összkomfort</option>
												<option value="2" <?php if(isset($komfort) && ($komfort==2)) print 'selected="selected"'; ?> > Komfortos </option>
												<option value="3" <?php if(isset($komfort) && ($komfort==3)) print 'selected="selected"'; ?> > Félkomfort </option>
												<option value="4" <?php if(isset($komfort) && ($komfort==4)) print 'selected="selected"'; ?> > Komfort nélküli </option>
												<option value="5" <?php if(isset($komfort) && ($komfort==5)) print 'selected="selected"'; ?> > Szükséglakás </option>
												<option value="6" <?php if(isset($komfort) && ($komfort==6)) print 'selected="selected"'; ?> > Közművesített </option>
												<option value="7" <?php if(isset($komfort) && ($komfort==7)) print 'selected="selected"'; ?> > Közművek nélküli </option>
											</select>
										</span> 
									</td>
									<td> <span class="bevitel">
											<b> Építkezési év </b>					
											<?php if (isset($ev)) print '<input class="year" type="text" name="ev" value="'.$ev.'" size="10" />';			
													else if ($sess) print '<input class="year" type="text" name="ev" value="" size="10" /> <label class="kotelezo"> ** </label>'; 
														else print '<input class="year" type="text" name="ev" value="" size="10" />'; ?>
											<script>
											$('input.year').number(true, 0, ',', '');
											</script>
										</span> 
									</td>
								</tr>
								<tr>
									<td> <span class="bevitel">
											<b> Alapterület </b>					
											<?php if (isset($alapt)) print '<input class="number" type="text" name="alapt" value="'.$alapt.'" size="10" /> m²';
													else if ($sess) print '<input class="number" type="text" name="alapt" value="" size="10" /> m² <label class="kotelezo"> ** </label>'; 
														else print '<input class="number" type="text" name="alapt" value="" size="10" /> m²'; ?>
										</span> 
									</td>
									<td> <span class="bevitel">
											<b> Telekterület </b>					
											<?php if (isset($telekt)) print '<input class="number" type="text" name="telekt" value="'.$telekt.'" size="10" /> m²';
													else if ($sess) print '<input class="number" type="text" name="telekt" value="" size="10" /> m² <label class="kotelezo"> ** </label>'; 
														else print '<input class="number" type="text" name="telekt" value="" size="10" /> m²'; ?>
										</span> 
									</td>
								</tr>
								<tr>
									<td colspan="2"> <span class="bevitel">
											<b> Felszereltség </b>
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="1" 
											<?php if(isset($felszereltseg[0]) && ($felszereltseg[0])) print 'checked="checked"'; ?> /> víz </div> 
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="2" 
											<?php if(isset($felszereltseg[1]) && ($felszereltseg[1])) print 'checked="checked"'; ?> /> gáz </div>
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="3" 
											<?php if(isset($felszereltseg[2]) && ($felszereltseg[2])) print 'checked="checked"'; ?> /> villany </div>
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="4" 
											<?php if(isset($felszereltseg[3]) && ($felszereltseg[3])) print 'checked="checked"'; ?> /> központi fűtés </div>
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="5" 
											<?php if(isset($felszereltseg[4]) && ($felszereltseg[4])) print 'checked="checked"'; ?> /> pince </div>
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="6" 
											<?php if(isset($felszereltseg[5]) && ($felszereltseg[5])) print 'checked="checked"'; ?> /> csatorna </div>
											<div class="felsz"> <input type="checkbox" name="felszereltseg[]" value="7" 
											<?php if(isset($felszereltseg[6]) && ($felszereltseg[6])) print 'checked="checked"'; ?> /> garázs </div>
										</span> 
									</td>
								</tr>
								<tr>
									<td class="leiras" colspan="2"> <span class="bevitel">
											<b> Leírás </b>					
											<?php if (isset($leiras)) print '<textarea name="leiras">'.$leiras.'</textarea>';
													else if ($sess) print '<textarea name="leiras"></textarea> <label class="kotelezo"> ** </label>';
														else print '<textarea name="leiras"></textarea>'; ?>		
										</span> 
									</td>									
								</tr>
								<tr>
									<td> <span class="bevitel">
											<b> Ár </b>					
											<?php if (isset($ar)) print '<input class="number" type="text" name="ar" value="'.$ar.'" size="16" /> Ft';				
													else if ($sess) print '<input class="number" type="text" name="ar" value="" size="16" /> Ft <label class="kotelezo"> ** </label>'; 
														else print '<input class="number" type="text" name="ar" value="" size="16" /> Ft'; ?>
											<script>
											$('input.number').number(true, 0, ',', ' ');
											</script>
										</span> 
									</td>
									<td> <span class="bevitel">
											<b> Dátum </b>					
											<?php if (isset($datum)) print '<input type="date" name="datum" value="'.$datum.'" />';
											else if ($sess) print '<input type="date" name="datum" /> <label class="kotelezo"> ** </label>';  
												else print '<input type="date" name="datum" placeholder=" éééé-hh-nn" />'; ?>
										</span> 
									</td>
								</tr>
							</table>
							<input type="submit" name="modosit" class="btn" id="modosit" value="Módosítás" />
							<?php if ($sess) print '<div id="jel"> ** - Kötelező kitöltenie! </div> ' ?>
						</form>
					</div>
					
				</div>			
			</div>
		</div>
	</body>
</html>