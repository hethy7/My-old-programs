<?php
include "../mysqli_burkolo.php";
include "../ucfirst_magyar.php";
include "../setting.php";

session_start();

if (!isset($_SESSION["login"])) header("Location: ".$_SESSION["url"]);

$ingatlanok = DB_getrows("SELECT ingatlan_id, szandek, tipus, telepules, datum
FROM ikinalat, iszandek, itipus, itelepules
WHERE szandek_sz = szandek_id AND tipus_sz = tipus_id AND telepules_sz = telepules_id
ORDER BY ingatlan_id ASC");

//oldalszamok
if (isset($_GET["osz"])) $osz = $_GET["osz"];
else $osz = 1;

define("db", 14);
$n=count($ingatlanok);
$m=$n%db;
if($m!=0) $m=1;
$oszn=floor($n/db)+$m;

DB_CLOSE();
?>

<!DOCTYPE html>
<html>
	<head>
	<title>Eladó és bérelhető ingatlanok</title>
	<link href="kepek/ingatlan.ico" rel="icon" type="image/x-icon" />
	<meta http-equiv="Content-Type" content="text/html; charset="UTF-8">
	<link rel="stylesheet" href="alap2.css">
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
					</div>
					
					<div id="inglista">
							<table>	
								<tr id="nelkul">
									<th> Ingatlan ID </th>
									<th> Szándék </th>
									<th> Típus </th>
									<th> Település </th>
									<th> Dátum </th>
									<th> </th>
								</tr>
								
								<?php
								if ($n!=0){
									if ($osz == $oszn) $m=db-($osz*db-$n);
									else $m=db;
									
									for($i=0; $i<$m; $i++){
										$j=($osz-1)*db+$i;
										
										if ($ingatlanok[$j]["tipus"]=="ház") $tipus = "Családi ház";
										else $tipus = mb_ucfirst($ingatlanok[$j]["tipus"]);
										
										$datum = date_create($ingatlanok[$j]["datum"]);
										$datum = date_format($datum, 'Y.m.d');
										
										print '
										<tr>
											<td> '.$ingatlanok[$j]["ingatlan_id"].' </td>
											<td> '.ucfirst($ingatlanok[$j]["szandek"]).' </td>
											<td> '.$tipus.' </td>
											<td> '.$ingatlanok[$j]["telepules"].' </td>
											<td> '.$datum.' </td>
											<td> <a class="mod" href="modositas2.php?id='
												.$ingatlanok[$j]["ingatlan_id"].'"> Módosítás </a> </td>
										</tr>';
									}
								}?>
								
							</table>
					</div>

					<div id=oldalsz>
						<div id="oldalak">
						<?php
						for($i=1; $i<=$oszn; $i++){
							if($i==$osz) print '<b> '.$i.' </b>';
							else print '<a href="modositas.php?osz='.$i.'"> '.$i.' </a>';
						}
						?>
						</div>
					</div>
				</div>
			
			</div>	
		</div>
	</body>
</html>