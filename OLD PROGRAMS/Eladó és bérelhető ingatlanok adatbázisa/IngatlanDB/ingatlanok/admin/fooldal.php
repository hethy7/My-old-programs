<?php
session_start();

if (!isset($_SESSION["login"])) header("Location: ".$_SESSION["url"]);
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
						<li class="aktOldal"><a href="fooldal.php"><b>Főoldal</b></a></li>
						<li><a href="felvetel.php"><b>Ingatlan felvétel</b></a></li>
						<li><a href="modositas.php"><b>Ingatlan módosítás</b></a></li>
						<li><a href="torles.php"><b>Ingatlan törlés</b></a></li>
						<li><a href="login/logout.php"><b>Kijelentkezés</b></a></li>
					</ul>
				</div>
				
				<div id="doboz3">
					<div id="udv">
						<h2> <?php print $_SESSION["login"]["admin_nev"]; ?> </h2>
						<span> Üdvözlöm az Ingatlan ajánlatok oldal adminisztrációs felületén! </span>
					</div>		
					
					<span> Az adminisztrációs felületen lehetősége van az új ingatlanok felvételére, illetve a meglévő ingatlanok módosítására vagy törlésére. </span>										
					<div id="funkciok">							
						<div class="func">
							<a href="felvetel.php">
								<img class="funcKep" src="kepek/hozzaad.png" alt="hozzaad">
							</a>
							<p> Ingatlan hozzáadása </p>
						</div>
						<div class="func">
							<a href="modositas.php">
								<img class="funcKep" src="kepek/modosit.png" alt="modosit">
							</a>
							<p> Ingatlan módosítása </p>
						</div>
						<div class="func">
							<a href="torles.php">
								<img class="funcKep" src="kepek/torol.png" alt="torol">
							</a>
							<p> Ingatlan törlése </p>
						</div>
					</div>
				</div>
				
			</div>
		</div>
	</body>
</html>