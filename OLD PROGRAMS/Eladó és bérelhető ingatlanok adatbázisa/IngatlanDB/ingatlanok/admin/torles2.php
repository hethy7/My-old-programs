<?php
include "../mysqli_burkolo.php";
include "../ucfirst_magyar.php";
include "../setting.php";

session_start();

if (!isset($_SESSION["login"])) header("Location: ".$_SESSION["url"]);

$id=$_GET["id"];
$ingatlan = DB_getrows("SELECT ingatlan_id, szandek, tipus, telepules, datum
FROM ikinalat, iszandek, itipus, itelepules
WHERE szandek_sz = szandek_id AND tipus_sz = tipus_id AND telepules_sz = telepules_id
AND ingatlan_id = ".$id."");

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
						<li><a href="modositas.php"><b>Ingatlan módosítás</b></a></li>
						<li class="aktOldal"><a href="torles.php"><b>Ingatlan törlés</b></a></li>
						<li><a href="login/logout.php"><b>Kijelentkezés</b></a></li>
					</ul>
				</div>
				
				<div id="doboz3">
					<div id="resz">
						<h2> Ingatlan törlés </h2>
					</div>
					
					<?php print'
					<form method="post" action="adminos/delete.php?id='.$ingatlan[0]["ingatlan_id"].'">';
					?>
						<span> Biztosan törölni szeretné a következő ingatlant? </span>
						<div id="inglista">
								<table>	
									<tr>
										<th> Ingatlan ID </th>
										<th> Szándék </th>
										<th> Típus </th>
										<th> Település </th>
										<th> Dátum </th>
									</tr>
									
									<?php
									if ($ingatlan[0]["tipus"]=="ház") $tipus = "Családi ház";
									else $tipus = mb_ucfirst($ingatlan[0]["tipus"]);
									
									$datum = date_create($ingatlan[0]["datum"]);
									$datum = date_format($datum, 'Y.m.d');
									
									print '
									<tr>
										<td> '.$ingatlan[0]["ingatlan_id"].' </td>
										<td> '.ucfirst($ingatlan[0]["szandek"]).' </td>
										<td> '.$tipus.' </td>
										<td> '.$ingatlan[0]["telepules"].' </td>
										<td> '.$datum.' </td>
									</tr>';
									?>
					
								</table>
						</div>	
						<input type="radio" name="szandek" value="1" checked="checked" /> igen
						<input type="radio" name="szandek" value="2" /> nem
						<div>
							<input type="submit" name="torol" class="btn" id="torol" value="Törlés" />
						</div>
					</form>
				</div>
			</div>
				
		</div>
	</body>
</html>