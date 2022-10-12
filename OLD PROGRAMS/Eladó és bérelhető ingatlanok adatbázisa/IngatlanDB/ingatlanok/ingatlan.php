<?php
include "mysqli_burkolo.php";
include "ucfirst_magyar.php";
include "setting.php";

$id=$_GET["id"];
$ingatlan = DB_getrows("
SELECT szandek, tipus, telepules, megye, ar, ev, alapt, telekt, jelleg, komfort, szoba, leiras, datum, nev
FROM ikinalat, iszandek, itipus, itelepules, ijelleg, ikomfort, admin
WHERE szandek_sz = szandek_id AND tipus_sz = tipus_id AND telepules_sz = telepules_id 
AND jelleg_sz = jelleg_id AND komfort_sz = komfort_id AND admin_sz = admin_id AND ingatlan_id = ".$id."
");

$kep = DB_getrows("
SELECT kepek FROM ikepek
WHERE ingatlan_sz_kep = ".$id." AND kepek LIKE '%1.jpg'
");

$kepek = DB_getrows("
SELECT kepek FROM ikepek 
WHERE ingatlan_sz_kep = ".$id." AND kepek NOT LIKE '%1.jpg'
");

$felsz = DB_getrows("
SELECT felszereltseg FROM ifelszereltseg, if_kapcsolat 
WHERE ingatlan_sz_fel = ".$id." AND felszereltseg_sz = felszereltseg_id
");

$felszereltseg =  array("víz" => false, "gáz" => false, "villany" => false, "központi fűtés" => false,
						"pince" => false, "csatorna" => false, "garázs" => false);
						
foreach($felsz as $val => $ertek){
	$felszereltseg[$ertek["felszereltseg"]] = true;
}

DB_close();
?>

<!DOCTYPE html>
<html>
	<head>
	<title>Eladó és bérelhető ingatlanok</title>
	<link href="kepek/ingatlan.ico" rel="icon" type="image/x-icon" />
	<meta http-equiv="Content-Type" content="text/html; charset="UTF-8">
	<link rel="stylesheet" href="alap1.css">
	<link rel="stylesheet" href="slimbox/css/slimbox2.css" type="text/css" media="screen" />
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
	<script type="text/javascript" src="slimbox/js/slimbox2.js"></script>
	</head>
	<body>
		<div id="fejlec">
			<img id="logo" src="kepek/ingatlankep.png" alt="ingatlanos kép">	
			<div id="menu" >
				<ul>
					<li><a href="index.php"><b>Főoldal</b></a></li>
					<?php
					if ($ingatlan[0]["szandek"]=="eladó"){
						$a= 'class="aktOldal"'; $b=''; }
					else{ $a= ''; $b='class="aktOldal"'; }
					print '
					<li '.$a.'><a href="elado.php"><b>Eladó ingatlanok</b></a></li>
					<li '.$b.'><a href="kiado.php"><b>Kiadó ingatlanok</b></a></li>';
					?>
					<li><a href="elerhetoseg.php"><b>Elérhetőségeink</b></a></li>
				</ul>
			</div>	
		</div>
	
		<div id="tartalom">
			<div id="resz2">
				<h2> 
				<?php 
					print ucfirst($ingatlan[0]["szandek"])." ".
					$ingatlan[0]["tipus"].", ".$ingatlan[0]["telepules"]; 
				?> 
				</h2>
			</div>
			<hr>
			
			<div id=ingatlanInfo>
				<div id=ingatlanLeiras>
				<?php
				print $ingatlan[0]["leiras"];
				?>
				</div>
			
				<div id=ingatlanKepek>
					<?php 
					print '
					<a href="'.$kep[0]["kepek"].'" rel="lightbox-cats" 
					title="'.ucfirst($ingatlan[0]["szandek"])." ".$ingatlan[0]["tipus"].", ".$ingatlan[0]["telepules"].'">
						<img src="'.$kep[0]["kepek"].'" alt="Click!">
					</a>';
					?>
					<div id=tobbiKep>
						<?php
						foreach($kepek as $kep){
						print '
						<a href="'.$kep["kepek"].'" rel="lightbox-cats" 
						title="'.ucfirst($ingatlan[0]["szandek"])." ".$ingatlan[0]["tipus"].", ".$ingatlan[0]["telepules"].'">
							<img src="'.$kep["kepek"].'" alt="Click!">
						</a>';
						}
						?>
					</div>
				</div>
				
				<div id=ingatlanAdatok>
					<ul>
						<li>
							<span> Település: </span>
							<?php print $ingatlan[0]["telepules"]; ?>
						</li>
						<li>
							<span> Megye: </span>
							<?php print $ingatlan[0]["megye"]; ?>
						</li>
						<li>
							<span> Típus: </span>
							<?php 
							if ($ingatlan[0]["tipus"]=="ház") print "Családi ház";
							else print mb_ucfirst($ingatlan[0]["tipus"]); 
							?>
						</li>
						<li>
							<span> Ár: </span>
							<?php 
							$ar = number_format($ingatlan[0]["ar"], 0 , ' , ' ,  ' ');
							print $ar;
							if ($ingatlan[0]["szandek"]=="eladó") print " Ft";
							else print " Ft/hó";
							?>
						</li>
						<li>
							<span> Épitkezési év: </span>
							<?php
							if ($ingatlan[0]["ev"]==0) print "Nincs";
							else print $ingatlan[0]["ev"];
							?>
						</li>
						<li>
							<span> Alapterület: </span>
							<?php print $ingatlan[0]["alapt"]." m²"; ?>
						</li>
						<li>
							<span> Telekterület: </span>
							<?php print $ingatlan[0]["telekt"]." m²"; ?>
						</li>
						<li>
							<span> Jelleg: </span>
							<?php print ucfirst($ingatlan[0]["jelleg"]); ?>
						</li>
						<li>
							<span> Komfort: </span>
							<?php print mb_ucfirst($ingatlan[0]["komfort"]); ?>
						</li>
						<li>
							<span> Szobák: </span>
							<?php 
							if ($ingatlan[0]["szoba"]==0) print "Nincs";
							else print $ingatlan[0]["szoba"]; 
							?>
						</li>
						
						<?php
						foreach($felszereltseg as $val => $van){
							print '
							<li>
								<span> '.ucfirst($val).': </span>';
							if ($van==true)	print " Van </li>";
							else print " Nincs </li>";
						}
						?>
						
						<li>
							<span> Feltöltés dátuma: </span>
							<?php 
							$datum = date_create($ingatlan[0]["datum"]);
							print date_format($datum, 'Y.m.d'); 
							?>
						</li>
						<li>
							<span> Feltöltötte: </span>
							<?php print $ingatlan[0]["nev"]; ?>
						</li>
					</ul>
				</div>				
			</div>			
		</div>
	
	</body>
</html>