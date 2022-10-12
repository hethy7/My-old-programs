<?php
include "../../mysqli_burkolo.php";
include "../../setting.php";

$id=$_GET["id"];

if ($_POST["szandek"] == 1){
	//törlés a kiemeltek közül
	DB_query("DELETE FROM kiemelt WHERE ingatlan_sz_kie = ".$id);
	
	//képek régi elérési útjainak törlése
	$regieleresek = DB_getcolumn("SELECT kepek FROM ikepek WHERE ingatlan_sz_kep = ".$id, "kepek");
	$regidb = count($regieleresek);
	for ($i=0; $i<$regidb; $i++)
		if (file_exists("../../".$regieleresek[$i])) unlink("../../".$regieleresek[$i]);
	
	//képek törlése
	DB_query("DELETE FROM ikepek WHERE ingatlan_sz_kep = ".$id);
	
	//felszereltségek törlése
	DB_query("DELETE FROM if_kapcsolat WHERE ingatlan_sz_fel = ".$id);
	
	//törlés a kínálatok közül
	DB_query("DELETE FROM ikinalat WHERE ingatlan_id = ".$id);
}

header("Location: ".$_SESSION["url"]."../torles.php");

DB_CLOSE();
?>