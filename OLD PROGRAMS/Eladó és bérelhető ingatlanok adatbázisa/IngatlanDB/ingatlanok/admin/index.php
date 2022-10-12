<?php
session_start();

$uri_parts = explode('/', $_SERVER['REQUEST_URI']);
$_SESSION["url"] = "http://".$_SERVER["HTTP_HOST"]."/".$uri_parts[1]."/";

?>

<!DOCTYPE html>
<html>
	<head>
	<title>Eladó és bérelhető ingatlanok</title>
	<link href="kepek/ingatlan.ico" rel="icon" type="image/x-icon" />
	<meta http-equiv="Content-Type" content="text/html; charset="UTF-8">
	<link rel="stylesheet" href="alap2.css">
	<script>
	function checkSubmit(e)
	{
	   if(e && e.keyCode == 13)
	   {
		  document.forms[0].submit();
	   }
	}
	</script>
	</head>
	<body>
		<div id="tartalom">
			<div id="felso">
				<span id="cim"> Adminisztráció - Ingatlanok </span>
			</div>
			<div id="doboz">
				<div id="belepes">
					<h1> Adminisztrációs bejelentkezés </h1>
					<div id="urlap">
						<form method="post" action="login/login.php" name="login" id="form-login"
								onKeyPress="return checkSubmit(event)">
							<?php if (isset($_GET["login"]) && $_GET["login"] == 0){ ?>
								<span id="error">Nem megfelelő felhasználónév vagy jelszó!</span>
							<?php } ?>
							<p>
								<label for="adminnev"> Felhasználónév </label>
								<input type="text" name="adminnev" id="adminnev" class="inputbox">
							</p>
							<p>
								<label for="adminkod"> Jelszó </label>
								<input type="password" name="adminkod" id="adminkod" class="inputbox">
							</p>
							<a class="button" onclick="login.submit();"> Belépés </a>
						</form>
					</div>
					<p> Az adminisztrátori felületre való bejelentkezéshez
					érvényes felhasználónevet és jelszót </br> kell megadni.</p>
					<p> <a href="../index.php"> Ugrás a kezdőoldalra </a> </p>
					<img id="lakat" src="kepek/zar.png" alt="lakat">
				</div>
			</div>
		</div>
	</body>
</html>