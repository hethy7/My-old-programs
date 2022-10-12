<?php
include "mysqli_burkolo.php";
include "setting.php";

$adminok = DB_getrows("SELECT nev, email, telefon FROM admin");
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
					<li><a href="index.php"><b>Főoldal</b></a></li>
					<li><a href="elado.php"><b>Eladó ingatlanok</b></a></li>
					<li><a href="kiado.php"><b>Kiadó ingatlanok</b></a></li>
					<li class="aktOldal"><a href="elerhetoseg.php"><b>Elérhetőségeink</b></a></li>
				</ul>
			</div>	
		</div>
	
		<div id="tartalom">
		<h2 class="resz1"> Elérhetőségeink </h2>
		<div class="elerhetoseg">
			<p>
			Amennyiben felkeltettük érdeklődését, kérjük vegye fel a kapcsolatot munkatársainkkal.
			<table id="munkatars">
				<caption> Munkatársaink </caption>
				<tr>
					<th> Név </th>
					<th> Telefonszám </th>
					<th> Email cím </th>
				</tr>

				<?php
				foreach($adminok as $admin){
					print '
					<tr>
						<td> '.$admin["nev"].' </td>
						<td> '.$admin["telefon"].' </td>
						<td> '.$admin["email"].' </td>
					</tr>';
				}
				?>
				
			</table>
			</p>
		
			<p>
			Személyes megbeszélés esetén az alábbi címen vagyunk elérhetőek.
			<div id="cim">			
				<img id="siraly" src="kepek/siraly.png" alt="elérhetőség kép">
				<ul>
					<li> ŠD Čajka - Sirály Kollégium </li>
					<li> Bratislavská cesta 2 </li>
					<li> 945 01 Komárno </li>
					<li> Slovenslo </li>
				</ul>
			</div>
			<script src='https://maps.googleapis.com/maps/api/js?v=3.exp'></script>
			<div class="map">
				<div id='gmap_canvas'>
				</div>
				<div>
					<small><a href="http://embedgooglemaps.com">embed google maps</a></small>
				</div>
				<div>
					<small><a href="http://www.proxysitereviews.com/">proxy sites</a></small>
				</div>
			</div>
			<script type='text/javascript'>
			function init_map(){var myOptions = {zoom:13,center:new google.maps.LatLng(47.7645363,18.09981659999994),mapTypeId: google.maps.MapTypeId.ROADMAP};
			map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);
			marker = new google.maps.Marker({map: map,position: new google.maps.LatLng(47.7645363,18.09981659999994)});
			infowindow = new google.maps.InfoWindow({content:'<strong>ŠD Čajka - Sirály kollégium</strong><br>Bratislavská cesta 2771/2, 945 01 Komárnno<br>'});
			google.maps.event.addListener(marker, 'click', function(){infowindow.open(map,marker);});infowindow.open(map,marker);}google.maps.event.addDomListener(window, 'load', init_map);
			</script>
			</p>
						
		</div>
	
	</body>
</html>