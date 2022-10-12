-- phpMyAdmin SQL Dump
-- version 4.1.4
-- http://www.phpmyadmin.net
--
-- Hoszt: 127.0.0.1
-- Létrehozás ideje: 2016. Máj 30. 13:04
-- Szerver verzió: 5.6.15-log
-- PHP verzió: 5.5.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Adatbázis: `ingatlan`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `admin`
--

CREATE TABLE IF NOT EXISTS `admin` (
  `admin_id` tinyint(1) NOT NULL AUTO_INCREMENT,
  `nev` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `fnev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `telefon` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  UNIQUE KEY `admin_id` (`admin_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=4 ;

--
-- A tábla adatainak kiíratása `admin`
--

INSERT INTO `admin` (`admin_id`, `nev`, `fnev`, `jelszo`, `email`, `telefon`) VALUES
(1, 'Héthy Zoltán', 'hethy7', '0659c7992e268962384eb17fafe88364', 'hethy7@gmail.com', '+421 917614600'),
(2, 'Hagyma István', 'hagyma', '138b6f104921a050728d1585e8548c0a', 'hpityu@freemail.hu', '+421 907454647'),
(3, 'Kankula József', 'kankula', '164a1c3059cf85c64b5af50eba715817', 'kankula@gmail.com', '+421 915026524');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ifelszereltseg`
--

CREATE TABLE IF NOT EXISTS `ifelszereltseg` (
  `felszereltseg_id` tinyint(1) NOT NULL AUTO_INCREMENT,
  `felszereltseg` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`felszereltseg_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=9 ;

--
-- A tábla adatainak kiíratása `ifelszereltseg`
--

INSERT INTO `ifelszereltseg` (`felszereltseg_id`, `felszereltseg`) VALUES
(1, 'víz'),
(2, 'gáz'),
(3, 'villany'),
(4, 'központi fűtés'),
(5, 'pince'),
(6, 'csatorna'),
(7, 'garázs');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `if_kapcsolat`
--

CREATE TABLE IF NOT EXISTS `if_kapcsolat` (
  `ingatlan_sz_fel` smallint(5) NOT NULL,
  `felszereltseg_sz` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `if_kapcsolat`
--

INSERT INTO `if_kapcsolat` (`ingatlan_sz_fel`, `felszereltseg_sz`) VALUES
(42, 3),
(1, 6),
(1, 5),
(1, 4),
(1, 3),
(1, 2),
(1, 1),
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(2, 6),
(2, 7),
(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 6),
(3, 7),
(4, 1),
(4, 2),
(4, 3),
(4, 4),
(4, 5),
(4, 6),
(5, 1),
(5, 2),
(5, 3),
(5, 4),
(5, 6),
(6, 1),
(6, 2),
(6, 3),
(6, 4),
(6, 6),
(7, 1),
(7, 2),
(7, 3),
(7, 4),
(7, 5),
(7, 6),
(7, 7),
(8, 1),
(8, 2),
(8, 3),
(8, 4),
(8, 5),
(8, 6),
(8, 7),
(9, 1),
(9, 2),
(9, 3),
(9, 4),
(9, 5),
(9, 6),
(9, 7),
(10, 1),
(10, 2),
(10, 3),
(10, 4),
(10, 6),
(10, 7),
(11, 1),
(11, 2),
(11, 3),
(11, 4),
(11, 6),
(11, 7),
(12, 1),
(12, 2),
(12, 3),
(12, 4),
(12, 6),
(12, 7),
(14, 1),
(14, 3),
(14, 6),
(17, 2),
(17, 1),
(17, 3),
(17, 4),
(17, 6),
(18, 1),
(18, 2),
(18, 3),
(18, 4),
(18, 6),
(19, 1),
(19, 2),
(19, 3),
(19, 4),
(19, 6),
(19, 7),
(20, 1),
(20, 2),
(20, 3),
(20, 4),
(20, 6),
(20, 7),
(21, 1),
(21, 2),
(21, 3),
(21, 4),
(21, 6),
(22, 1),
(22, 2),
(22, 3),
(22, 4),
(22, 6),
(23, 1),
(23, 2),
(23, 3),
(23, 6),
(24, 1),
(24, 2),
(24, 3),
(24, 4),
(24, 6),
(25, 1),
(25, 2),
(25, 3),
(25, 4),
(25, 6),
(26, 1),
(26, 2),
(26, 3),
(26, 4),
(26, 6),
(28, 2),
(29, 1),
(29, 2),
(29, 3),
(29, 6),
(31, 1),
(31, 2),
(31, 3),
(31, 6),
(1, 7),
(40, 6),
(39, 6),
(39, 4),
(39, 3),
(39, 2),
(39, 1),
(40, 5),
(40, 4),
(40, 3),
(40, 2),
(40, 1),
(42, 2),
(42, 1),
(41, 3),
(42, 4),
(42, 5),
(42, 6);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ijelleg`
--

CREATE TABLE IF NOT EXISTS `ijelleg` (
  `jelleg_id` tinyint(1) NOT NULL AUTO_INCREMENT,
  `jelleg` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`jelleg_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=8 ;

--
-- A tábla adatainak kiíratása `ijelleg`
--

INSERT INTO `ijelleg` (`jelleg_id`, `jelleg`) VALUES
(1, 'téglaépület'),
(2, 'faház'),
(3, 'beépítetlen terület'),
(4, 'külterület'),
(5, 'erdő'),
(6, 'szántó'),
(7, 'külterületi szántó');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ikepek`
--

CREATE TABLE IF NOT EXISTS `ikepek` (
  `ingatlan_sz_kep` smallint(5) NOT NULL,
  `kepek` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  UNIQUE KEY `kepek` (`kepek`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ikepek`
--

INSERT INTO `ikepek` (`ingatlan_sz_kep`, `kepek`) VALUES
(1, 'kepek/elado/haz/1_1.jpg'),
(1, 'kepek/elado/haz/1_2.jpg'),
(1, 'kepek/elado/haz/1_3.jpg'),
(1, 'kepek/elado/haz/1_4.jpg'),
(1, 'kepek/elado/haz/1_5.jpg'),
(1, 'kepek/elado/haz/1_6.jpg'),
(2, 'kepek/elado/haz/2_1.jpg'),
(2, 'kepek/elado/haz/2_2.jpg'),
(2, 'kepek/elado/haz/2_3.jpg'),
(2, 'kepek/elado/haz/2_4.jpg'),
(2, 'kepek/elado/haz/2_5.jpg'),
(2, 'kepek/elado/haz/2_6.jpg'),
(3, 'kepek/kiado/haz/3_1.jpg'),
(3, 'kepek/kiado/haz/3_2.jpg'),
(3, 'kepek/kiado/haz/3_3.jpg'),
(3, 'kepek/kiado/haz/3_4.jpg'),
(3, 'kepek/kiado/haz/3_5.jpg'),
(3, 'kepek/kiado/haz/3_6.jpg'),
(3, 'kepek/kiado/haz/3_7.jpg'),
(4, 'kepek/kiado/haz/4_1.jpg'),
(4, 'kepek/kiado/haz/4_2.jpg'),
(4, 'kepek/kiado/haz/4_3.jpg'),
(4, 'kepek/kiado/haz/4_4.jpg'),
(4, 'kepek/kiado/haz/4_5.jpg'),
(4, 'kepek/kiado/haz/4_6.jpg'),
(4, 'kepek/kiado/haz/4_7.jpg'),
(5, 'kepek/elado/haz/5_1.jpg'),
(5, 'kepek/elado/haz/5_2.jpg'),
(5, 'kepek/elado/haz/5_3.jpg'),
(5, 'kepek/elado/haz/5_4.jpg'),
(5, 'kepek/elado/haz/5_5.jpg'),
(5, 'kepek/elado/haz/5_6.jpg'),
(6, 'kepek/elado/haz/6_1.jpg'),
(6, 'kepek/elado/haz/6_2.jpg'),
(6, 'kepek/elado/haz/6_3.jpg'),
(6, 'kepek/elado/haz/6_4.jpg'),
(6, 'kepek/elado/haz/6_5.jpg'),
(6, 'kepek/elado/haz/6_6.jpg'),
(7, 'kepek/kiado/haz/7_1.jpg'),
(7, 'kepek/kiado/haz/7_2.jpg'),
(7, 'kepek/kiado/haz/7_3.jpg'),
(7, 'kepek/kiado/haz/7_4.jpg'),
(7, 'kepek/kiado/haz/7_5.jpg'),
(7, 'kepek/kiado/haz/7_6.jpg'),
(8, 'kepek/elado/haz/8_1.jpg'),
(8, 'kepek/elado/haz/8_2.jpg'),
(8, 'kepek/elado/haz/8_3.jpg'),
(8, 'kepek/elado/haz/8_4.jpg'),
(8, 'kepek/elado/haz/8_5.jpg'),
(8, 'kepek/elado/haz/8_6.jpg'),
(8, 'kepek/elado/haz/8_7.jpg'),
(9, 'kepek/kiado/haz/9_1.jpg'),
(9, 'kepek/kiado/haz/9_2.jpg'),
(9, 'kepek/kiado/haz/9_3.jpg'),
(9, 'kepek/kiado/haz/9_4.jpg'),
(9, 'kepek/kiado/haz/9_5.jpg'),
(9, 'kepek/kiado/haz/9_6.jpg'),
(10, 'kepek/elado/haz/10_1.jpg'),
(10, 'kepek/elado/haz/10_2.jpg'),
(10, 'kepek/elado/haz/10_3.jpg'),
(10, 'kepek/elado/haz/10_4.jpg'),
(10, 'kepek/elado/haz/10_5.jpg'),
(10, 'kepek/elado/haz/10_6.jpg'),
(10, 'kepek/elado/haz/10_7.jpg'),
(10, 'kepek/elado/haz/10_8.jpg'),
(11, 'kepek/kiado/haz/11_1.jpg'),
(11, 'kepek/kiado/haz/11_2.jpg'),
(11, 'kepek/kiado/haz/11_3.jpg'),
(11, 'kepek/kiado/haz/11_4.jpg'),
(11, 'kepek/kiado/haz/11_5.jpg'),
(11, 'kepek/kiado/haz/11_6.jpg'),
(12, 'kepek/elado/haz/12_1.jpg'),
(12, 'kepek/elado/haz/12_2.jpg'),
(12, 'kepek/elado/haz/12_3.jpg'),
(12, 'kepek/elado/haz/12_4.jpg'),
(12, 'kepek/elado/haz/12_5.jpg'),
(12, 'kepek/elado/haz/12_6.jpg'),
(13, 'kepek/elado/haz/13_1.jpg'),
(13, 'kepek/elado/haz/13_2.jpg'),
(13, 'kepek/elado/haz/13_3.jpg'),
(13, 'kepek/elado/haz/13_4.jpg'),
(13, 'kepek/elado/haz/13_5.jpg'),
(13, 'kepek/elado/haz/13_6.jpg'),
(14, 'kepek/elado/haz/14_1.jpg'),
(14, 'kepek/elado/haz/14_2.jpg'),
(14, 'kepek/elado/haz/14_3.jpg'),
(14, 'kepek/elado/haz/14_4.jpg'),
(14, 'kepek/elado/haz/14_5.jpg'),
(14, 'kepek/elado/haz/14_6.jpg'),
(15, 'kepek/kiado/haz/15_1.jpg'),
(15, 'kepek/kiado/haz/15_2.jpg'),
(15, 'kepek/kiado/haz/15_3.jpg'),
(15, 'kepek/kiado/haz/15_4.jpg'),
(16, 'kepek/kiado/haz/16_1.jpg'),
(16, 'kepek/kiado/haz/16_2.jpg'),
(16, 'kepek/kiado/haz/16_3.jpg'),
(16, 'kepek/kiado/haz/16_4.jpg'),
(17, 'kepek/elado/lakas/17_1.jpg'),
(17, 'kepek/elado/lakas/17_2.jpg'),
(17, 'kepek/elado/lakas/17_3.jpg'),
(17, 'kepek/elado/lakas/17_4.jpg'),
(17, 'kepek/elado/lakas/17_5.jpg'),
(17, 'kepek/elado/lakas/17_6.jpg'),
(18, 'kepek/elado/lakas/18_1.jpg'),
(18, 'kepek/elado/lakas/18_2.jpg'),
(18, 'kepek/elado/lakas/18_3.jpg'),
(18, 'kepek/elado/lakas/18_4.jpg'),
(18, 'kepek/elado/lakas/18_5.jpg'),
(18, 'kepek/elado/lakas/18_6.jpg'),
(18, 'kepek/elado/lakas/18_7.jpg'),
(19, 'kepek/kiado/lakas/19_1.jpg'),
(19, 'kepek/kiado/lakas/19_2.jpg'),
(19, 'kepek/kiado/lakas/19_3.jpg'),
(19, 'kepek/kiado/lakas/19_4.jpg'),
(19, 'kepek/kiado/lakas/19_5.jpg'),
(19, 'kepek/kiado/lakas/19_6.jpg'),
(20, 'kepek/elado/lakas/20_1.jpg'),
(20, 'kepek/elado/lakas/20_2.jpg'),
(20, 'kepek/elado/lakas/20_3.jpg'),
(20, 'kepek/elado/lakas/20_4.jpg'),
(20, 'kepek/elado/lakas/20_5.jpg'),
(21, 'kepek/kiado/lakas/21_1.jpg'),
(21, 'kepek/kiado/lakas/21_2.jpg'),
(21, 'kepek/kiado/lakas/21_3.jpg'),
(21, 'kepek/kiado/lakas/21_4.jpg'),
(21, 'kepek/kiado/lakas/21_5.jpg'),
(21, 'kepek/kiado/lakas/21_6.jpg'),
(22, 'kepek/kiado/lakas/22_1.jpg'),
(22, 'kepek/kiado/lakas/22_2.jpg'),
(22, 'kepek/kiado/lakas/22_3.jpg'),
(22, 'kepek/kiado/lakas/22_4.jpg'),
(22, 'kepek/kiado/lakas/22_5.jpg'),
(22, 'kepek/kiado/lakas/22_6.jpg'),
(23, 'kepek/kiado/uzleti/23_1.jpg'),
(23, 'kepek/kiado/uzleti/23_2.jpg'),
(24, 'kepek/kiado/uzleti/24_1.jpg'),
(24, 'kepek/kiado/uzleti/24_2.jpg'),
(25, 'kepek/elado/uzleti/25_1.jpg'),
(25, 'kepek/elado/uzleti/25_2.jpg'),
(25, 'kepek/elado/uzleti/25_3.jpg'),
(26, 'kepek/elado/uzleti/26_1.jpg'),
(26, 'kepek/elado/uzleti/26_2.jpg'),
(26, 'kepek/elado/uzleti/26_3.jpg'),
(27, 'kepek/elado/telek/27_1.jpg'),
(28, 'kepek/kiado/telek/28_1.jpg'),
(28, 'kepek/kiado/telek/28_2.jpg'),
(29, 'kepek/elado/telek/29_1.jpg'),
(29, 'kepek/elado/telek/29_2.jpg'),
(29, 'kepek/elado/telek/29_3.jpg'),
(29, 'kepek/elado/telek/29_4.jpg'),
(30, 'kepek/elado/telek/30_1.jpg'),
(31, 'kepek/kiado/telek/31_1.jpg'),
(31, 'kepek/kiado/telek/31_2.jpg'),
(31, 'kepek/kiado/telek/31_3.jpg'),
(32, 'kepek/kiado/telek/32_1.jpg'),
(32, 'kepek/kiado/telek/32_2.jpg'),
(36, 'kepek/elado/mezogazdasagi/36_1.jpg'),
(35, 'kepek/kiado/mezogazdasagi/35_2.jpg'),
(35, 'kepek/kiado/mezogazdasagi/35_1.jpg'),
(34, 'kepek/kiado/mezogazdasagi/34_2.jpg'),
(34, 'kepek/kiado/mezogazdasagi/34_1.jpg'),
(33, 'kepek/elado/mezogazdasagi/33_1.jpg'),
(36, 'kepek/elado/mezogazdasagi/36_2.jpg'),
(36, 'kepek/elado/mezogazdasagi/36_3.jpg'),
(37, 'kepek/elado/mezogazdasagi/37_1.jpg'),
(38, 'kepek/elado/mezogazdasagi/38_1.jpg'),
(38, 'kepek/elado/mezogazdasagi/38_2.jpg'),
(39, 'kepek/elado/lakas/39_1.jpg'),
(39, 'kepek/elado/lakas/39_2.jpg'),
(39, 'kepek/elado/lakas/39_3.jpg'),
(39, 'kepek/elado/lakas/39_4.jpg'),
(39, 'kepek/elado/lakas/39_5.jpg'),
(40, 'kepek/kiado/lakas/40_1.jpg'),
(40, 'kepek/kiado/lakas/40_2.jpg'),
(40, 'kepek/kiado/lakas/40_3.jpg'),
(40, 'kepek/kiado/lakas/40_4.jpg'),
(40, 'kepek/kiado/lakas/40_5.jpg'),
(40, 'kepek/kiado/lakas/40_6.jpg'),
(40, 'kepek/kiado/lakas/40_7.jpg'),
(41, 'kepek/kiado/telek/41_1.jpg'),
(41, 'kepek/kiado/telek/41_2.jpg'),
(41, 'kepek/kiado/telek/41_3.jpg'),
(41, 'kepek/kiado/telek/41_4.jpg'),
(42, 'kepek/elado/haz/42_4.jpg'),
(42, 'kepek/elado/haz/42_3.jpg'),
(42, 'kepek/elado/haz/42_1.jpg'),
(42, 'kepek/elado/haz/42_2.jpg'),
(42, 'kepek/elado/haz/42_5.jpg'),
(42, 'kepek/elado/haz/42_6.jpg'),
(42, 'kepek/elado/haz/42_7.jpg'),
(42, 'kepek/elado/haz/42_8.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ikinalat`
--

CREATE TABLE IF NOT EXISTS `ikinalat` (
  `ingatlan_id` smallint(5) NOT NULL AUTO_INCREMENT,
  `szandek_sz` tinyint(1) NOT NULL,
  `tipus_sz` tinyint(1) NOT NULL,
  `telepules_sz` tinyint(2) NOT NULL,
  `ar` int(10) NOT NULL,
  `ev` smallint(4) NOT NULL,
  `alapt` smallint(5) NOT NULL,
  `telekt` mediumint(6) NOT NULL,
  `jelleg_sz` tinyint(1) NOT NULL,
  `komfort_sz` tinyint(1) NOT NULL,
  `szoba` tinyint(2) NOT NULL,
  `leiras` text COLLATE utf8_hungarian_ci NOT NULL,
  `datum` date NOT NULL,
  `admin_sz` tinyint(1) NOT NULL,
  PRIMARY KEY (`ingatlan_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=43 ;

--
-- A tábla adatainak kiíratása `ikinalat`
--

INSERT INTO `ikinalat` (`ingatlan_id`, `szandek_sz`, `tipus_sz`, `telepules_sz`, `ar`, `ev`, `alapt`, `telekt`, `jelleg_sz`, `komfort_sz`, `szoba`, `leiras`, `datum`, `admin_sz`) VALUES
(1, 1, 1, 7, 45000000, 2005, 235, 953, 1, 1, 3, 'Komáromban, 2005-ben épült, 3 szoba + nappalis, 235 nm alapterületű, teljesen alápincézett családi ház eladó. A ház földszintje 125 nm, a konyha gépesített, (beépített tűzhellyel, elszívóval, mosogatógéppel, hűtővel). A fürdőszoba, fürdőkáddal, zuhanyzóval, dupla mosdóval felszerelt. Az alsó szinten, mely 110 nm, 6 személyes szauna, zuhanyzó, mosókonyha és konditerem került kialakításra. A ház fűtése padlófűtés, gáz kondenzációs kazánnal és hőtárolós bojlerrel. Az udvar 953 nm, parkosított, részben térkővel burkolt, körbekerített, 50 nm-es kétállásos garázzsal, kerti pavilonnal. Az ingatlan tehermentes, azonnal költözhető, riasztóval, ipari árammal, elektromos kapukkal ellátott.', '2016-04-02', 1),
(2, 1, 1, 2, 21000000, 1983, 120, 1190, 1, 1, 2, 'Fertőszentmiklóson, azonnal költözhető, felújított ház eladó! Fertőszentmiklós város, Soprontól 20, az ausztriai (Pamhagen) határátkelőtől 15 percre található. A ház 1983-ban épült, téglából, betonfödémmel, részben alápincézett (kb. 20 nm pince), a tetőtér igény esetén beépíthető. A ház alapterülete kb. 120 nm + 20 nm terasz, a hasznos lakóterület 96 nm. 2 szoba, amerikai konyhás nappali és fürdő helyiségből áll. A ház 2015-ben teljes felújításra került, új víz, villanybekötés, korszerű gáz cirkófűtés, műanyag nyílászárók, (redőnnyel, szúnyoghálóval), modern fürdőszoba, külső hőszigetelés és színezés készült. Az udvar 1190 nm, bekerített, füvesített, garázzsal. A ház gyors költözéssel eladó!', '2014-12-22', 1),
(3, 1, 1, 3, 32900000, 1989, 200, 1000, 1, 1, 5, 'Petőházán, Ausztriához közel, 5 szoba + nappalis, 2 fürdőszobás ház eladó! A ház 1989-ben épült, téglából, betonfödémmel, hőszigetelt fa nyílászárókkal, betoncseréppel, kétszintes, lakható területe 205 nm. A helyiségek tágasak, világosak, a fűtés padlófűtéssel (gázkazánnal) illetve kandallóval megoldott. Az ingatlanban külön bejáratú 1 szobás lakrész került kialakításra, fürdővel és konyhával. A házhoz 45 nm-es két autónak elegendő garázs is tartozik. Az udvar 1000 nm, bekerített, parkosított, termő gyümölcsfákkal, gondozott pázsittal. Igény esetén bútorozottan eladó!', '2015-10-21', 2),
(4, 2, 1, 9, 600000, 1990, 200, 2549, 1, 1, 5, 'Kazincbarcikában, Miskolctól 24 km-re északra, a Sajó völgyében, 5 szoba + nappalis családi ház, teljes bútorzattal eladó! A ház lakható alapterülete 160 nm, részben alápincézett, kétszintes, téglaépítésű, betonfödémmel, a tetőcseréppel fedett. A fűtés gáz központi fűtés, cserépkályhákkal kiegészítve. 5 külön bejáratú szoba, 65 nm-es nappali-konyha, 2 konyha, 2 fürdőszoba és 2 WC került kialakításra. Az ingatlan több generációnak vagy nagyobb családnak egyaránt alkalmas, igény esetén az egyik lakrész bérbe is adható. A családi házhoz udvarra néző kb. 20 nm-es terasz, hátsó kapubejáró és tárolók is tartoznak. Az udvar 2549 nm, két részre osztott, az első telek 1440 nm, a hátsó telek pedig 1109 nm, akár külön is értékesíthető. Az ingatlan tehermentes, tv-kel, hűtővel, bútorokkal együtt eladó, azonnal költözhető!', '2016-02-25', 3),
(5, 1, 1, 10, 25400000, 1965, 200, 32000, 1, 1, 2, 'Edelényben, családi ház, istállóval, 3,2 hektáros területtel eladó! Miskolctól 25 km-re északra, a Bódva-völgyben a 27-es főút mentén található az ingatlan. Családi ház, istálló és lovasboxok tartoznak a területhez. A ház alapterülete kb. 110 nm, 1966-ban épült 2 szoba + nappali, fürdőszoba, konyha, kamra helyiségből áll. A fűtés gáz központi fűtés és cserépkályha. Az istálló 90 nm-es, vízzel, villannyal ellátott. A fából épített boxok kb. 8 ló elhelyezésére alkalmasak. A házhoz 4356 nm-es bekerített udvar tartozik, ásott kúttal. Az ingatlan bárki által megvásárolható, mivel 22628 nm belterület, további 9836 nm pedig külterületi legelő. (1 hektárig lehet bárkinek földet vásárolni). Az ingatlan azonnal költözhető, tehermentes.', '2015-07-15', 1),
(6, 1, 1, 2, 35000000, 1998, 150, 700, 1, 1, 4, 'Fertőszentmiklóson, napkollektoros, 4 szobás ház, geotermikus fűtéssel eladó! A ház Soprontól 20, az ausztriai (Pamhagen) határátkelőtől 15 percre, csendes utcában található. Az épület téglából épült, műanyag nyílászárókkal, a falak hőszigeteltek, a netto alapterület 150 nm. A házban 3 és fél szoba, nappali, konyha, 3 fürdőszoba került kialakításra, (zuhanyzóval, káddal illetve jakuzzival) a tetőtér beépíthető. Az ingatlan fenntartási költsége nagyon alacsony, a meleg vizet a napkollektorok állítják elő, a fűtés, használati meleg víz vagy akár a hűtés a föld energiáját hasznosítva hőszivattyúval történik. Üzemeltetése nem függ sem időjárástól sem a napszaktól. Az udvar 700 nm, garázzsal, fúrt kúttal. A ház riasztóval felszerelt, a beépített bútorok a vételár részét képezik.', '2016-04-10', 1),
(7, 2, 1, 4, 400000, 1975, 220, 1295, 1, 1, 3, 'Győrtől 2 percre, Győrújfaluban csendes utcában, 2 szintes, részben felújított családi ház eladó! A ház 1975-ben épült, téglából, betonfödémmel, cseréptetővel. A pinceszint 110 nm, tárgyalóval, irodával, mosókonyhával, fürdővel. A lakószint 110 nm, 3 szobával, konyhával, étkezővel, fürdővel. Hőszigetelt műanyag nyílászárók, redőnnyel kerültek beépítésre, újszerű a konyhabútor, megújult a vizesblokk, a fűtés korszerű kondenzációs gázkazánnal és vegyes tüzelésű kályhával is megoldott. Az udvar 1295 nm, saroktelek, széles utcafronttal, 2 garázzsal, kb. 25 nm-es nyitott színnel. A ház teljesen közművesített, költözés gyors határidővel. Hitelben tudok segíteni!', '2016-01-28', 3),
(8, 1, 1, 2, 26000000, 1999, 200, 920, 1, 1, 3, 'Fertőszentmiklós városában, Soprontól 20, az ausztriai határátkelőtől 15 percre, nyugodt utcában található ez az 5 szobás, plusz különálló apartmannal rendelkező családi ház. A lakóház kétszintes, 1998-ban épült téglából, betonfödémmel, külső hőszigeteléssel, gáz központi fűtéssel. A földszinten 2 szoba, konyha-étkező, fürdő (sarokkáddal, zuhanyzóval) külön WC, kamra, kazánház, előszoba helyiség került kialakításra. Az emeleten 3 szoba, konyha, fürdőszoba (szerelvényezés megvan de nincs burkolva) helyiség található. Az ingatlanhoz kb. 30 nm-es külön bejáratú téglából épült lakrész tartozik, 1 szobával, konyhával, fürdővel. Fűtése a főépületről és fatüzelésű kályhával is megoldott. Garázs és még egy autó tárolására alkalmas pajta is van az udvaron. A kert bekerített, konyhakertként hasznosított. Az ingatlan jó állapotú, több generáció együttélésére vagy akár kiadásra is alkalmas. Az ár alkuképes!', '2015-09-30', 2),
(9, 2, 1, 12, 580000, 1995, 240, 1600, 1, 1, 7, 'Jól menő vendégház, a határ mellett! Bánrévén, a szlovák határátkelőtől 2 km-re, rendezett településen található ez a 240 nm-es vendégházzá alakított családi ház. Az épület kétszintes, szintenként külön bejárattal: A földszinten 4 szoba, 3 fürdő, nappali, konyha, az emeleten 3 szoba, 3 fürdő, konyha, nappali került kialakításra. A ház gáz és vegyes tüzelésű központi fűtéssel, sőt szintenként külön kandallóval is fűthető. A házhoz hatalmas, szépen parkosított kert tartozik, garázzsal, kerti faházzal. A vendégház bármikor lakóházzá alakítható, a helyiségek könnyen egybenyithatók, bővíthetők. Akár teljes berendezéssel együtt eladó!', '2015-09-05', 2),
(10, 1, 1, 14, 28900000, 1988, 200, 1200, 1, 1, 4, 'Hajdúszoboszlón, Debrecentől 22 km-re fekvő alföldi településen családi ház eladó. A ház téglaépítésű, 2005-ben felújított, új tetővel, hőszigetelt nyílászárókkal, külső szigeteléssel. Az ingatlan kétszintes, szintenként 110 nm, alsószinten előtér, konyha, nappali, étkező, spájz, fürdőszoba, (zuhanyzóval)szauna és garázs található. Felső szinten 4 szoba, fürdőszoba,(káddal) külön WC és tárolóhelyiség került kialakításra. A házhoz fedett első és napozó hátsó terasz tartozik, kb. 20-20 nm területtel. Az udvar 1200 nm, teljesen bekerített, különálló garázzsal, (elektromos Hörmann ajtóval), kerti faházzal, fúrt kúttal. Az ingatlan kamerával védett, elektromos kapuval, térkövezett udvarral. Igény esetén teljes bútorzattal együtt eladó.', '2014-08-20', 1),
(11, 2, 1, 15, 520000, 2005, 90, 990, 1, 1, 2, 'Egerbe, a főutca mellett 2 szoba + nappalis ház, 25 nm-es terasszal eladó! Az ingatlan 2000-ben épült, 38-as PTH téglából, betonfödémmel, hőszigetelt vakolattal, műanyag ablakokkal, napelemmel. Alapterülete 100 nm, + 25 nm-es garázs tartozik a házhoz, igény esetén a tetőtér beépíthető. A fűtés gáz központi fűtés és fa tüzelésű kandalló, a rezsi alacsony, gáz csak a téli fűtéshez szükséges. A ház teljes berendezéssel eladó, beépített konyhabútor-gépekkel, bútorok, lámpák, szekrények, kerti szerszámok stb. Az udvar rendezett, bekerített, 990 nm, széles utcafronttal, ásott kúttal, kerti faházzal és fatárolóval. A ház tehermentes, azonnal költözhető!', '2015-04-07', 1),
(12, 1, 1, 7, 22000000, 1964, 140, 1756, 1, 1, 4, 'Komáromban, a Fő utcán, 3 + félszobás, részben felújított családi ház eladó! A ház a 60-as években épült, téglából, fa födémmel, cseréptetővel. A felújítás során, a tető új cserép borítást kapott, (fóliázva, lécezve,) korszerű műanyag nyílászárók kerültek beépítésre és a külső hőszigetelés is elkészült, csak a színezés hiányzik. Az ingatlan alapterülete 140 nm, 3 szoba, félszoba, konyha-étkező, fürdőszoba, (zuhanyzóval, káddal), előszoba, kamra helyiségből áll. A fűtés gáz és fa tüzelésű központi fűtés. Az udvar 1756 nm területű, bekerített, garázzsal és kb. 40 nm-es melléképülettel. Az ár alkuképes!', '2015-05-27', 3),
(13, 1, 1, 17, 4200000, 1990, 40, 1060, 2, 4, 1, 'Gödöllőn, Budapesttől 30 km-re, északkeletre, 40 nm-es hétvégi ház eladó! A ház Gödöllő szélén, külterületen található, közmű nincs a telken. Vízellátás, fúrt kúttal lehetséges, villany aggregátorral vagy napkollektorral megoldható. A vezetékes víz és villany hálózat bekötésére jelenleg nincs lehetőség. A telek gondozott, 1060 nm területű, 40 nm lakóterületű faházzal. A ház alápincézett, a földszinten nappali, szoba, konyha, mosdó került kialakításra. Főzés gázpalackkal megoldott. Azonnal birtokba vehető, kertészkedőknek, természet kedvelőknek ideális, az ár alkuképes!', '2015-06-01', 3),
(14, 1, 1, 2, 22000000, 1950, 200, 4200, 1, 2, 3, 'Fertőszentmiklóson, 200 nm-es ház, megosztható, 4200 nm-es telekkel, csodálatos gerendázattal eladó! Soprontól 20, az ausztriai (Pamhagen) határátkelőtől 15 percre található ez a családi ház. A ház az 1950-es években épült, téglából, fafödémmel, cseréptetővel. Szerkezetileg jó állapotú, de felújításra szorul, évek óta lakatlan. Víz, villany, (ipari áram), szennyvíz közművel az ingatlan rendelkezik, jelenleg 3 szoba, konyha, fürdőszoba, WC, előtér helyiségből áll. A ház két lakrészből áll, igény esetén a lakrészek összenyithatók. A házhoz hatalmas magtár és beépíthető tetőtér tartozik, a tetőszerkezet faanyaga jó állapotú, a magtár gerendázata igazi ritkaság. Az udvar 4200 nm, széles és hosszú telek, ásott kúttal, kulturált szomszédokkal.', '2015-04-13', 1),
(15, 2, 1, 17, 110000, 1991, 30, 2208, 1, 4, 1, 'Gödöllőn, bekerített gyümölcsös, kis házzal együtt eladó! A ház Gödöllő szélén, külterületen található, közmű nincs a telken. A víz, villany bekötésére jelenleg nincs lehetőség. A telek gondozott, 2208 nm területű, 30 nm lakóterületű téglaházzal. A ház alápincézett (15 nm) , a földszinten egy nappali-konyha (15 nm) a tetőtérben pedig egy szoba található. Főzés gázpalackkal megoldható, víz fúrt kútból vagy ciszternával, áram aggregátorral vagy napkollektorral lehetséges. Hobbikertnek, nyugalomra vágyóknak ideális, az ár alkuképes!', '2014-02-06', 1),
(16, 2, 1, 17, 45000, 1991, 30, 1439, 2, 4, 1, 'Gödöllőn, közel a fővároshoz, hétvégi ház, gondozott gyümölcsössel eladó! A ház Gödöllő szélén, külterületen található, víz, villany nincs a telken. A közművek bekötésére jelenleg nincs lehetőség. A telek bekerített, 1439 nm területű, kb. 30 nm-es faházzal. A házban egy szoba és konyha található, főzés gázpalackkal megoldható, víz fúrt kútból vagy ciszternával, áram aggregátorral vagy napkollektorral lehetséges. Hétvégi kikapcsolódásra vágyóknak, kertészkedőknek ideális, termő gyümölcsfákkal, teljes berendezéssel együtt eladó!', '2015-04-09', 2),
(17, 1, 2, 3, 16300000, 1965, 110, 60, 1, 1, 3, 'Petőházán, 110 nm-es földszinti lakás, kerttel, azonnal költözhetően eladó! Petőházán, Fertőd mellett, Soprontól 25 km-re, központhoz közeli csendes utcában található a lakás. Az ingatlan kétszintes, 1994-ben teljes felújításra került, téglából épült, a tető cseréppel fedett, hőszigetelt műanyag és fa nyílászárókkal. A földszinten 2 szoba, konyha, spájz, fürdőszoba (káddal), fürdő (zuhanyzóval) külön WC, előtér, hall, az emeleten pedig 1 szoba került kialakításra. Az ingatlan külön mérőórákkal felszerelt, a fűtés gáz cirkó fűtés. Saját, bekerített kb. 60 nm-es udvar tartozik a lakáshoz. Az ingatlan tehermentes, komoly érdeklődés esetén az ár alkuképes!', '2015-09-12', 2),
(18, 1, 2, 3, 14900000, 1961, 81, 100, 1, 1, 2, 'Petőházán, 81 nm-es lakás, udvarral eladó! Fertőd mellett, Fertőszentmiklóstól 2 km-re, Soprontól 25 km-re található a lakás. 3 lakásos társasház szélső lakása, 1961-ben épült, téglából, betonfödémmel, cseréptetővel, a nyílászárók műanyagok, redőnnyel felszerelve. Az ingatlanban 2 szoba, konyha, fürdőszoba (káddal, WC-vel), előszoba, közlekedő, kazánház helyiség került kialakításra. A fűtés gáz központi fűtés. A lakáshoz saját, kb. 100 nm-es kertrész tartozik és 2 tároló. Parkolás a társasház bekerített udvarán lehetséges. Az ingatlan tehermentes, szerkezetileg jó állapotú!', '2014-12-20', 1),
(19, 2, 2, 3, 250000, 1980, 69, 0, 1, 1, 2, 'Sopronhoz közel, egyedi fűtésű, alacsony rezsijű lakás eladó! Petőházán, Fertőd mellett, Ausztriától 10 percre, központhoz közeli utcában található a lakás (vasútállomás, buszmegálló, posta, élelmiszerüzlet, fürdő 300 méterre). A lakás téglaépítésű, műanyag ablakok és bejárati ajtó kerültek beépítésre, redőnyökkel, szúnyoghálóval. Alapterülete 69 nm, 2 szoba, nappali, konyha, fürdőszoba, előszoba helyiségből áll. A fűtés gáz cirkó fűtés, a fogyasztás külön órákkal mérhető. A szobák külön bejáratúak, laminált padlóval burkoltak, az ingatlan frissen festett, azonnal költözhető. Zárt udvar tartozik a társasházhoz és kb. 10 nm-es garázs, mely igény esetén bővíthető, vagy tárolásra is alkalmas. A közös költség 7000 Ft!', '2015-11-21', 2),
(20, 1, 2, 2, 12500000, 1990, 60, 50, 1, 1, 2, 'Fertőszentmiklóson, lakás, kis kerttel, terasszal, garázzsal eladó! Soprontól 20, az ausztriai (Pamhagen) határátkelőtől 15 percre található az ingatlan. A lakás 2 szintes, 60 nm alapterületű, 2 szoba, nappali, (kb. 16 nm-es terasz), konyha, fürdőszoba, külön WC helyiségből áll. A közüzemi fogyasztás külön mérőórákkal mérhető, hőszigetelt fa nyílászárók kerültek beépítésre, a fűtés gáz cirkófűtés. A lakáshoz garázs, közös tárolók és kb. 50 nm-es kert tartozik. Az ingatlan azonnal költözhető, befektetési célra vagy első otthonnak is ideális.', '2016-03-25', 3),
(21, 2, 2, 7, 290000, 2001, 55, 0, 1, 1, 2, 'Komáromban, jó állapotú, I. emeleti lakás, 55 nm alapterülettel és további 18 nm galériával eladó! A lakásban nappali, hálószoba, konyha, fürdőszoba, előszoba valamint a nappaliban 12 nm-es galéria illetve a hálószobában 6 nm galéria került kialakításra. Az ingatlan egyedi mérőórákkal felszerelt, a rezsi nagyon alacsony, a fűtés gáz cirkó fűtés, a nyílászárók műanyagból készültek. A majdnem 4 méteres belmagasság miatt a galériák teljes mértékben használhatók. A lakás szinte teljes bútorzattal együtt eladó, költözés gyors határidővel!', '2015-07-22', 1),
(22, 2, 2, 7, 300000, 2011, 60, 0, 1, 1, 2, 'Komáromban, 60 nm-es téglaépítésű lakás, beépített konyhával eladó! A lakás a szőnyi városrészen, (óvoda, iskola, élelmiszerüzlet, buszmegálló, orvosi rendelő közelében,) található. Az ingatlan külső hőszigeteléssel, műanyag nyílászárókkal épült, az ablakok redőnnyel, szúnyoghálóval felszereltek. 1+fél szoba, nappali, konyha, fürdőszoba, külön WC, háztartási helyiség, előtér helyiség került kialakításra. A lakás tartozéka a konyhabútor beépített gépekkel, valamint igény esetén a képeken látható bútorok nagy része.(szekrények, lámpák, karnisok stb...) A rezsi nagyon alacsony, a fűtés gáz cirkófűtés, a közös költség 5000 ft/hó, minden fogyasztás külön mérőórákkal mérhető. Parkolás a társasház udvarán megoldható, díjmentesen. Költözés gyors határidővel!', '2015-05-15', 1),
(23, 2, 3, 4, 120000, 2010, 32, 0, 1, 1, 0, '500.000-EL OLCSÓBB LETT!!! Győrújfalu frekventált részén eladó egy újszerű, bruttó 32 m2-es üzlethelyiség. Az üzlethelyiség több célú hasznosítása is lehetséges, jelenleg pékségként működik. Több autó parkolása is megoldható. Az ingatlan fűtése gázkonvektorral lehetséges, a meleg víz ellátását villanybojler biztosítja. Eladótér (19 nm), raktár (4nm) és WC (5 nm) helyiségből áll. Az ár alkuképes!', '2016-02-28', 2),
(24, 2, 3, 1, 240000, 1990, 50, 0, 1, 1, 0, 'Sopronban, KIEMELTEN JÖVEDELMEZŐ SZOLÁRIUM SZALON bérleti joga eladó! Forgalmas helyen, bejáratott vendégkörrel, évtizedek óta működik a szolárium, modern gépekkel, (álló és fekvő szoláriummal) teljesen felszerelten kerül eladásra. A bérleti díj nagyon kedvező, csak a gépek értéke kb. 6 MFt.', '2015-03-24', 2),
(25, 1, 3, 7, 100000000, 2005, 400, 1600, 1, 1, 0, 'Komáromban, társasházi lakásokkal körbevett 400 nm-es üzletház egyben vagy akár üzletenként is eladó! Az üzletház két különálló épületből áll, a nagyobb 270 nm alapterületű épület tartalmaz konyhát, kiszolgáló helyiségeket, galériát, illetve büfét (falatozót), valamint egy külön bejáratú üzletet. A kisebb 130 nm alapterületű épületben pedig 4 külön bejáratú üzlethelyiség került kialakításra. A két épület fűtése két gázkazánnal megoldott, minden üzlet rendelkezik külön víz, villany, gáz almérővel. Mindkét épület tetőtere beépíthető, szobák kialakítására előkészített. Az üzlethelyiségek egy része ki van adva, a jelenlegi bérlők havi szinten 2000 eurós bevételt jelentenek. Az összes helyiség kiadásával, a szobák kialakításával ez az összeg többszörösére növelhető. Az ár alkuképes!', '2013-07-23', 1),
(26, 1, 3, 16, 9000000, 1993, 100, 400, 1, 1, 0, 'Kaposvárhoz közel, 8 km-re a 610-es és 61-es utak mentén elterülő Kaposmérő település forgalmas fő utcáján található ez a presszóként, lottózóként működő üzlethelyiség. Az épület alapterülete 100 nm, raktárból, öltöző -mosdóhelyiségből, kiszolgáló helyiségből valamint fedett teraszból áll. Az épület fűtése gáz központi fűtés. A vételárba beletartozik a teljes berendezés, (bárpult, polcok, fagyasztók-hűtők, asztalok). Az épülethez 400 nm-es telek is tartozik, ezáltal az üzlethelyiség befogadóképessége megnövelhető.', '2015-09-12', 1),
(27, 1, 4, 8, 4500000, 0, 5500, 5500, 3, 7, 0, 'Mocsán 800 FT/ nm-es áron, 5500 nm-es belterületi telek eladó! A telek egy helyrajziszámon van, közművekkel ugyan nem rendelkezik, de a közművesítés könnyen megoldható. Víz, villany, csatorna és gáz közmű is van az utcában. Beépítési kötelezettség nem terheli, tehermentes az ingatlan.', '2014-03-16', 1),
(28, 2, 4, 5, 90000, 0, 8035, 8035, 3, 6, 0, 'Csapodon, Soprontól 30 km-re, Pomogyi (Pamhagen) határátkelőtől 25 km-re, 8035 nm-es belterületi telek eladó! A terület szép természeti környezetben, csendes utcában, erdő mellett található, de aszfaltos útról megközelíthető. 2 helyrajzi számból áll, víz és gáz közművel rendelkezik, villany a telek előtt húzódik, a bekötés könnyen megoldható. Beépítési kötelezettség nem terheli! A beépíthetőség 30%.', '2015-07-14', 3),
(29, 1, 4, 7, 4600000, 0, 973, 973, 3, 6, 0, 'Komáromban, közművesített építési telek eladó! A telek 973 nm, két oldalról kerítéssel határolt. Beépíthetősége 30%, földútról megközelíthető. A szomszédos telek is eladó, igény esetén a telek 1944 nm-re növelhető.', '2014-03-18', 1),
(30, 1, 4, 13, 2350000, 0, 846, 846, 3, 7, 0, 'Építési telek, közel az Ukrán határhoz eladó! Tiszabecsen, Fehérgyarmattól 28 km-re, az urán-magyar államhatár melett építési telek eladó! A telek belterület, újonnan kimért utcában található, közművek az utca elejéig kerültek bekötésre. Az ingatlan 16 méter széles, sík, nincs bekerítve. A telek 30%-a beépíthető, beépítési kötelezettség nem terheli! Az ár alkuképes!', '2015-04-13', 1),
(31, 2, 4, 2, 70000, 0, 600, 600, 3, 6, 0, 'Összközműves építési telkek eladók Fertőszentmiklóson, Soprontól 20, az ausztriai határátkelőtől 15 percre, szép környezetben. 6 db. kerül értékesítésre, víz, villany, csatorna, gáz közművel és aszfaltos úttal rendelkeznek. A telkek 12 méter szélesek és 50 méter hosszúak, területük 600 nm. Az ingatlanokon ikerház építésére van lehetőség, a vásárlót beépítési kötelezettség nem terheli! A 3 db. sárgával jelölt ikertelkek, X-el jelölt oldala már eladásra került. (A. és B.)igény esetén egyben is eladó- így a terület 1200 nm, az ár 7,2 MFt.', '2015-06-20', 2),
(32, 2, 4, 8, 100000, 0, 1435, 1435, 3, 7, 0, 'Mocsán, Komáromtól 11 km-re, a Boldogasszonyi-tó határában a településtől kb. 1 km-re építési telek eladó. A telek bekerített, széles utcafronttal rendelkezik, közművek közvetlenül az ingatlan előtt húzódnak. Beépítési kötelezettség nem terheli, 30%-a beépíthető!', '2015-06-24', 2),
(33, 1, 5, 2, 1200000, 0, 8088, 8088, 5, 7, 0, 'Fertőszentmiklóson, 8088 nm-es erdőterület eladó. A terület 1/3-a akáccal, 2/3-a fenyővel beültetett. A fenyő 30-40 éve telepített. Aranykorona értéke 23,56 Ak. Az erdő összesen 15,6 hektáros területű, ebből 8088 nm terület, ami eladó. Osztatlan közös tulajdon.', '2015-06-30', 2),
(34, 2, 5, 6, 20000, 0, 2766, 2766, 7, 7, 0, 'Szántóföld Fertő tóra néző panorámával eladó! Sopron-Balfon, a Fertő parti út mellett, 2766 nm-es szántó eladó! A terület 1/1-es tulajdoni hányadú, 1,83 Ak, azonnal művelhető. A területet bárki megvásárolhatja!', '2015-09-17', 3),
(35, 2, 5, 7, 30000, 0, 8123, 8123, 7, 7, 0, 'Komáromban, a Monostori erőd mögött, belterület közelében, külterületi szántóföld eladó! A terület 8123 nm, a tulajdonos nem adta ki haszonbérbe, azonnal művelhető!', '2014-05-26', 1),
(36, 1, 5, 11, 1700000, 0, 1732, 1732, 6, 7, 0, 'Putnokon, a település szélén, kavicsos útról megközelíthető, bekerített, parkosított kert eladó. Ténylegesen szántó besorolású, Normann-fenyővel beültetett. Közmű nincs a területen, víz fúrt vagy ásott kúttal megoldható, áram aggregátorral vagy napelemmel lehetséges. Bár külterület, megvásárlása magánszemélyeknek engedélyezett.', '2015-04-07', 1),
(37, 1, 5, 17, 25000000, 0, 25000, 25000, 4, 7, 0, 'Gödöllőn, Budapesttől 30 km-re, a Rákos-patak közelében lévő településen 2,5 hektáros terület Rákos-pataki panorámával eladó! A terület a rendezési terv szerint belterületbe vonható, a település fő utcájának folytatása lehetne. Jelenleg külterület, szőlőként nyilvántartott, mint szőlő is nagyon értékes, éves szinten több milliós hasznot termel. A közművesítés könnyen megoldható! Az ár irányár!', '2015-03-14', 2),
(38, 1, 5, 1, 9600000, 0, 24018, 24018, 7, 7, 0, 'ELCSERÉLHETŐ SOPRONI KERTRE, LAKÁSRA STB...Sopronban, közvetlenül a Magyar-Osztrák határ mellett található ez a 2,4 hektár területű, szántó művelési ágú ingatlan. A terület földútról könnyen megközelíthető, jelenleg is művelés alatt áll, de haszonbérleti szerződés nem terheli. Ára: 400 Ft/nm, 3 külön helyrajziszámból áll a szántó, akár külön-külön is eladó!', '2016-01-05', 3),
(39, 1, 2, 18, 14800000, 2012, 55, 0, 1, 1, 1, 'Fertődön, FÖLDSZINTI téglalakás, egyedi fűtéssel eladó! A lakás Soprontól 25 km-re, a legközelebbi osztrák határátkelőtől 10 percre, óvoda, iskola, élelmiszerüzlet, buszmegálló, orvosi rendelő közelében található. A társasház külső hőszigeteléssel, műanyag nyílászárókkal épült, a lakás alapterülete 55 nm, 1 szoba, galériás nappali, konyha-étkező, fürdőszoba, külön WC, közlekedő helyiségből áll. A lakás benapozott, a rezsi alacsony, a közös költség 5.000 Ft/hó. A fűtés gáz cirkó fűtés. Parkolás a társasház zárt udvarán lehetséges! Költözés gyors határidővel!', '2016-05-07', 1),
(40, 2, 2, 11, 330000, 2007, 70, 0, 1, 1, 2, 'Putnokon, 2 szoba + nappalis lakás, garázzsal eladó! Ózdtól 20 km-re, a szlovákiai határátkelőtől 10 percre, újszerű lakóparkban található a lakás. A 4 lakásos, kétemeletes társasház 2007-ben épült, téglából, műanyag nyílászárókkal, külső hőszigeteléssel, utcáról megközelíthető garázzsal, zárt hátsó udvarral. A lakás 2. emeleti, tetőtéri, bruttó 70 nm, hasznos alapterülete 58 nm. 2 szoba, amerikai konyhás nappali, előtér és fürdőszoba (káddal és zuhanyzóval) helyiségből áll. A fűtés gáz cirkófűtés, víz, villany, gáz külön mérhető. A lakás tartozéka a beépített konyhabútor, elektromos tűzhellyel, gáz főzőlappal. Az ingatlanhoz 29 nm területű garázs tartozik, mosdóval és fűtéssel ellátva. Az ingatlan jó állapotú, a közös költség 5000 ft /hó, költözés megegyezés szerint! ', '2016-05-13', 1),
(41, 2, 4, 19, 72000, 0, 800, 800, 3, 6, 0, 'Miskolcon, bekerített, sportpályaként használt belterületi telek eladó! Villany a telken belül, víz ellátás 42 méter mély fúrt kútból megoldott, de szennyvíz, gáz és vízvezeték is az ingatlan előtt halad el, a csatlakozás megoldható. A telekre lakóház nem építhető, de sokféle hasznosítás lehetséges pl. telephely, üzlet, virágbolt stb...Az ingatlanon lévő faházban mosdó, zuhany és WC is található.', '2016-05-14', 1),
(42, 1, 1, 20, 19900000, 1972, 160, 3230, 1, 1, 4, 'Érden, megosztható telken, 4 szobás családi ház, 80 nm-es melléképülettel eladó! Budapesttől 25 percre, Tárnoktól keletre, Diósdtól nyugatra terül el, 1972-ben épült a családi ház, alapterülete 160 nm, terméskő alappal, tégla falazattal, fafödémmel, cseréptetővel. Az ingatlanban 4 szoba, nappali, 2 konyha, fürdőszoba (igény esetén a kamra felé bővíthető), 2 kamra, kazánház helyiség került kialakításra. A fűtés gáz központi fűtés, hordozható cserépkályhákkal kiegészítve. A családi házhoz kb. 80 nm-es téglaépítésű pajta, tároló tartozik, boltíves tornácokkal. Az udvar 3230 nm nagyságú, bekerített, ásott kúttal. Igény esetén a telekből 2 építési telek kialakítható, többcélú hasznosítás is lehetséges. Az ingatlan azonnal költözhető!', '2016-05-14', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ikomfort`
--

CREATE TABLE IF NOT EXISTS `ikomfort` (
  `komfort_id` tinyint(1) NOT NULL AUTO_INCREMENT,
  `komfort` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`komfort_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=8 ;

--
-- A tábla adatainak kiíratása `ikomfort`
--

INSERT INTO `ikomfort` (`komfort_id`, `komfort`) VALUES
(1, 'összkomfort'),
(2, 'komfortos'),
(3, 'félkomfort'),
(4, 'komfort nélküli'),
(5, 'szükséglakás'),
(6, 'közművesített'),
(7, 'közművek nélküli');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `iszandek`
--

CREATE TABLE IF NOT EXISTS `iszandek` (
  `szandek_id` tinyint(1) NOT NULL AUTO_INCREMENT,
  `szandek` varchar(5) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`szandek_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=3 ;

--
-- A tábla adatainak kiíratása `iszandek`
--

INSERT INTO `iszandek` (`szandek_id`, `szandek`) VALUES
(1, 'eladó'),
(2, 'kiadó');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `itelepules`
--

CREATE TABLE IF NOT EXISTS `itelepules` (
  `telepules_id` tinyint(2) NOT NULL AUTO_INCREMENT,
  `telepules` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `megye` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`telepules_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=21 ;

--
-- A tábla adatainak kiíratása `itelepules`
--

INSERT INTO `itelepules` (`telepules_id`, `telepules`, `megye`) VALUES
(1, 'Sopron', 'Győr-Moson-Sopron'),
(2, 'Fertőszentmiklós', 'Győr-Moson-Sopron'),
(3, 'Petőháza', 'Győr-Moson-Sopron'),
(4, 'Győrújfalu', 'Győr-Moson-Sopron'),
(5, 'Csapod', 'Győr-Moson-Sopron'),
(6, 'Sopron-Balf', 'Győr-Moson-Sopron'),
(7, 'Komárom', 'Komárom-Esztergom'),
(8, 'Mocsa', 'Komárom-Esztergom'),
(9, 'Kazincbarcika', 'Borsod-Abaúj-Zemplén'),
(10, 'Edelény', 'Borsod-Abaúj-Zemplén'),
(11, 'Putnok', 'Borsod-Abaúj-Zemplén'),
(12, 'Bánréve', 'Borsod-Abaúj-Zemplén'),
(13, 'Tiszabecs', 'Szabolcs-Szatmár-Bereg'),
(14, 'Hajdúszoboszló', 'Hajdú-Bihar'),
(15, 'Eger', 'Heves'),
(16, 'Kaposmérő', 'Somogy'),
(17, 'Gödöllő', 'Pest'),
(18, 'Fertőd', 'Győr-Moson-Sopron'),
(19, 'Miskolc', 'Borsod-Abaúj-Zemplén'),
(20, 'Érd', 'Pest');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `itipus`
--

CREATE TABLE IF NOT EXISTS `itipus` (
  `tipus_id` tinyint(1) NOT NULL AUTO_INCREMENT,
  `tipus` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`tipus_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci AUTO_INCREMENT=6 ;

--
-- A tábla adatainak kiíratása `itipus`
--

INSERT INTO `itipus` (`tipus_id`, `tipus`) VALUES
(1, 'ház'),
(2, 'lakás'),
(3, 'üzleti'),
(4, 'telek'),
(5, 'mezőgazdasági');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kiemelt`
--

CREATE TABLE IF NOT EXISTS `kiemelt` (
  `ingatlan_sz_kie` smallint(5) NOT NULL,
  UNIQUE KEY `ingatlan_id` (`ingatlan_sz_kie`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `kiemelt`
--

INSERT INTO `kiemelt` (`ingatlan_sz_kie`) VALUES
(1),
(4),
(8),
(10),
(11),
(20),
(21),
(26),
(28),
(36),
(39),
(40);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
