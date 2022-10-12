<?php
include "../../mysqli_burkolo.php";
include "../../setting.php";

$adminok = DB_getrows("SELECT fnev, jelszo, admin_id, nev FROM admin");

DB_close();

session_start();
	
$kod = md5($_POST["adminkod"]);
$login = 0;
	
foreach($adminok as $admin){
	if ($admin["fnev"] == $_POST["adminnev"] && $admin["jelszo"] == $kod){
		$login = 1;		
		$data = array( 	"admin_id" => $admin["admin_id"],
						"admin_nev" =>	$admin["nev"]);				
		break;
	}	
}

if ($login){
    $_SESSION["login"] = $data;
	header("Location: ".$_SESSION["url"]."fooldal.php");
}
else header("Location: ".$_SESSION["url"]."index.php?login=".$login);
?>
