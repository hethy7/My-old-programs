<?php
include "../../mysqli_burkolo.php";
include "../../ucfirst_magyar.php";
include "../../setting.php";

session_start();

// ékezetes betűkre
function removeaccent($str){
    $search  = array("á", "é", "í", "ó", "ö", "ő", "ú", "ü", "ű", " ");
    $replace = array("a", "e", "i", "o", "o", "o", "u", "u", "u", "_");
    return str_replace($search, $replace, $str);
}

$mind = true;
if (isset($_POST["feltolt"])){
	$data = array();
	
	//szándék
	$szandek = $_POST["szandek"];
	$data["szandek"] = $szandek;
	
	//kiemelt ellenőrzés
	if (isset($_POST["kiemelt"])){ 
		$kiemelt = true;
		$data["kiemelt"] = $kiemelt;
	}	
		
	//típus
	$tipus = $_POST["tipus"];
	$data["tipus"] = $tipus;
	
	//telepulés ellenőrzés
	if (isset($_POST["telepules"]) && $_POST["telepules"] != ""){ 
		$telepules = mb_ucfirst($_POST["telepules"]);
		$data["telepules"] = $telepules;
	}
	else $mind = false;
	
	//megye ellenőrzés
	if (isset($_POST["megye"]) && $_POST["megye"] != ""){
		$megye = mb_ucfirst($_POST["megye"]);
		$data["megye"] = $megye;
	}
	else $mind = false;
	
	//jelleg
	$jelleg = $_POST["jelleg"];
	$data["jelleg"] = $jelleg;
	
	//szoba ellenőrzés
	if (isset($_POST["szoba"]) && $_POST["szoba"] != ""){
		$szoba = $_POST["szoba"];
		$szoba = str_replace(' ', '', $szoba);
		$data["szoba"] = $szoba;
	}
	else $mind = false;
	
	//komfort
	$komfort = $_POST["komfort"];
	$data["komfort"] = $komfort;
	
	//építkezési év ellenőrzés
	if (isset($_POST["ev"]) && $_POST["ev"] != ""){
		$ev = $_POST["ev"];
		$data["ev"] = $ev;
	}
	else $mind = false;
	
	//alapterület ellenőrzés
	if (isset($_POST["alapt"]) && $_POST["alapt"] != ""){
		$alapt = $_POST["alapt"];
		$alapt = str_replace(' ', '', $alapt);
		$data["alapt"] = $alapt;
	}
	else $mind = false;
	
	//telekterület ellenőrzés
	if (isset($_POST["telekt"]) && $_POST["telekt"] != ""){
		$telekt = $_POST["telekt"];
		$telekt = str_replace(' ', '', $telekt);
		$data["telekt"] = $telekt;
	}
	else $mind = false;
		
	//felszereltség ellenőrzés
	if (isset($_POST["felszereltseg"])){
		$felszereltseg = array();
		$i=1;
        foreach ($_POST["felszereltseg"] as $felsz){        
			$felszereltseg[$i++] = $felsz;
        }
		$data["felszereltseg"] = $felszereltseg;
    }
	
	//leiras ellenőrzés
	if (isset($_POST["leiras"]) && (trim($_POST["leiras"]) != "")){
		$leiras = $_POST["leiras"];
		$data["leiras"] = $leiras;
	}
	else $mind = false;
	
	//ár elleőnzés
	if (isset($_POST["ar"]) && $_POST["ar"] != ""){
		$ar  = $_POST["ar"];
		$ar = str_replace(' ', '', $ar);
		$data["ar"] = $ar;
	}
	else $mind = false;
	
	//dátum ellenőrzés
	if (isset($_POST["datum"]) && $_POST["datum"]){ 
		$datum = $_POST["datum"];
		$data["datum"] = $datum;
	}
	else $mind = false;
	
	//képek ellenőrzése
	if (isset($_FILES)){
		$kepek = array();
		$i=0;
		foreach ($_FILES['kepek']['type'] as $pozicio => $ertek){
			  if (($_FILES['kepek']['error'][$pozicio] == 0) && ($ertek == "image/jpeg" || $ertek == "image/png")) {
					$kepek[$i] = array( "name" => $_FILES['kepek']['name'][$pozicio],
										"tmp_name" => $_FILES['kepek']['tmp_name'][$pozicio],
										"type" => $_FILES['kepek']['type'][$pozicio],
										"size" => $_FILES['kepek']['size'][$pozicio]);
					$i++;
			  }
		}
		if ($i == 0) $mind = false;
	}
	else $mind = false;
} 
else $mind = false;

//ha mindegyik mezőt kitöltöttük
if ($mind){	
	//itelepules táblába
	$telepulesek = DB_getrows("SELECT telepules_id, telepules, megye FROM itelepules");
	$van = false;
	
	foreach ($telepulesek as $telep){
		if (($telep["telepules"] == $telepules) && ($telep["megye"] == $megye)){
			$telepules_id = $telep["telepules_id"];
			$van = true;
			break;
		}
	}
	
	if (!$van){
		DB_query("INSERT INTO itelepules (telepules, megye) VALUES ('".$telepules."', '".$megye."')");
		$telepules_id = DB_insert_id();
	}	
	
	//ikinalat táblába
	DB_query("INSERT INTO ikinalat (szandek_sz, tipus_sz, telepules_sz, ar, ev, alapt, telekt, jelleg_sz, komfort_sz, szoba, leiras, datum, admin_sz) 
			  VALUES ('".$szandek."', '".$tipus."', '".$telepules_id."', '".$ar."', '".$ev."', '".$alapt."', '".$telekt."',
			  '".$jelleg."', '".$komfort."', '".$szoba."', '".$leiras."', '".$datum."', '".$_SESSION["login"]["admin_id"]."')");
	
	//if_kapcsolat táblába
	$kov_id = DB_insert_id();		// a feltöltendő ingatlan id-je
	if (isset($felszereltseg)){
		$n = count($felszereltseg);
		$ifkapcs = "INSERT INTO if_kapcsolat (ingatlan_sz_fel, felszereltseg_sz) VALUES";
	
		foreach($felszereltseg as $poz => $ertek){
			if ($poz != $n) $ifkapcs.= " ('".$kov_id."', '".$ertek."'),";
			else $ifkapcs.= " ('".$kov_id."', '".$ertek."')";
		}
	
	DB_query($ifkapcs);
	}
	
	//kiemelt táblába
	if (isset($kiemelt)) DB_query("INSERT INTO kiemelt (ingatlan_sz_kie) VALUES (".$kov_id.")");
	
	//ikepek táblába
	$eleres="kepek/";
	
	if ($szandek == 1) $eleres .= "elado/";
	else $eleres .= "kiado/";
	
	switch ($tipus){
	case 1: $eleres .= "haz/"; break;
	case 2: $eleres .= "lakas/"; break;
	case 3: $eleres .= "uzleti/"; break;
	case 4: $eleres .= "telek/"; break;
	case 5: $eleres .= "mezogazdasagi/"; break;
	}
	
	$n = count($kepek);
	$kepre = "INSERT INTO ikepek (ingatlan_sz_kep, kepek) VALUES";
	
	for ($i=1; $i<$n; $i++) $kepre .= " ('".$kov_id."', '".$eleres.$kov_id."_".$i.".jpg'),";
	
	$kepre .= " ('".$kov_id."', '".$eleres.$kov_id."_".$n.".jpg')";
	DB_query($kepre);
	
	//KÉPFELTÖLTÉS
	$i=0;
	foreach ($kepek as $kep){
		$types = array("jpg", "jpeg", "png");    // engedélyezett kiterjesztések
		$target = "../../".$eleres;              // végleges hely
		// feltöltés ellenőrzése
		$upload = true;
		$name = removeaccent($kep["name"]);
		// kiterjesztés ellenőrzése
		$tmp = explode(".", $name);
		$ext = strtolower(array_pop($tmp));
		if (!in_array($ext, $types)) $upload = false;
		
		if ($upload){
			$i++;
			//GD képkezelés
			// fájl elérési útja
			$filename = $kep["tmp_name"];	
			// eredeti kép méretei
			$kepmeret = getimagesize($kep["tmp_name"]);
			$kep_w = $kepmeret[0];
			$kep_h = $kepmeret[1];	
			// új kép méretei
			if ($kep_w >= $kep_h){
				$w = 700; 
				$h = 464;
			}
			else {
				$w = 338; 
				$h = 510;
			}
			// egy üres kép létrehozása
			$newimage = imagecreatetruecolor($w, $h);
			// eredeti kép beolvasása
			switch ($ext){
				case "jpg":
				case "jpeg": $oldimage = imagecreatefromjpeg($filename); break; 
				case "png": $oldimage = imagecreatefrompng($filename); break;
			}
			// eredeti kép rámásolása az újra, átméretezve
			imagecopyresampled($newimage, $oldimage, 0, 0, 0, 0, $w, $h, $kep_w, $kep_h);
			// kép mentése
			imagejpeg($newimage, $target.$kov_id."_".$i.".jpg", 100);
		}
	}	
	header("Location: ".$_SESSION["url"]."felvetel.php");
}
else{
	$_SESSION["adatok"] = $data;
	header("Location: ".$_SESSION["url"]."felvetel.php?sess=1");
}	

DB_CLOSE();
?>