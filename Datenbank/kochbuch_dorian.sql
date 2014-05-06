-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 06. Mai 2014 um 15:36
-- Server Version: 5.5.27
-- PHP-Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `kochbuch`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `einheit`
--

CREATE TABLE IF NOT EXISTS `einheit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Daten für Tabelle `einheit`
--

INSERT INTO `einheit` (`ID`, `Name`) VALUES
(1, 'kg'),
(2, 'g'),
(3, 'l'),
(4, 'Stk'),
(5, 'tl'),
(6, 'Msp'),
(7, 'ml'),
(8, 'cl');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `rezept`
--

CREATE TABLE IF NOT EXISTS `rezept` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Zubereitung` text,
  `Personen` int(3) DEFAULT NULL,
  `UsrID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `UsrID` (`UsrID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Daten für Tabelle `rezept`
--

INSERT INTO `rezept` (`ID`, `Name`, `Zubereitung`, `Personen`, `UsrID`) VALUES
(1, 'Käsekuchen', 'Knetteig:\r\nKnetteig aus Mehl ( 250 g ), Backpulver ( ½ TL ), Zucker ( 80 g ), 1 Prise Salz, 1 Ei und Butter( 125 g ) kneten/herstellen. Zu einer Kugel kneten/formen, in Klarsichtfolie einwickeln und 20 – 30 Minuten ruhen lassen/kalt stellen.\r\n\r\nAuflage/Fülle:\r\nDie Eier ( 8 Stück ) trennen. Die Sahne ( 330 g ) steif schlagen und die Eigelbe mit Zucker ( 100 g ) schaumig rühren. Die Eiweiße mit einer Prise Salz und dem restlichen Zucker ( 150 g ) sehr steif schlagen. Den Quark ( 1000 g / hier 4 Packungen á 250 g / Die Flüssigkeit aus den Quarkpackungen dazu gut ablaufen/abtropfen lassen ) in die Eigelbcreme geben, gut verrühren, den Eischnee und die Speisestärke vorsichtig mit dem Schneebesen unterheben und zum Schluss die geschlagene Sahne zugeben/unterheben.\r\n\r\nZubereitung:\r\nEine Springform ( 28 cm Durchmesser ) den Boden mit Backpapier auslegen/bespannen und die Seiten mit Margarine einfetten. Knetteig evtl. mit der Kuchenrolle etwas ausrollen und in die Form geben. Dabei am Rand hochziehen ( ca. 5 – 6 cm ). Die Quarkfülle hineingeben, verteilen/glatt streichen und im vorgeheizten Backofen bei 200 °C ca. 20 Minuten backen. Die Temperatur dann auf 140 °C zurückregeln und weitere ca. 40 Minuten backen. Falls erforderlich ( Sichtprobe ! ) den Käsekuchen mit Backpapier abdecken, damit er nicht zu dunkel wird. Herausnehmen, auskühlen lassen, aus der Form nehmen und auf einen Tortenteller legen.', 6, NULL),
(2, 'Karottenkuchen', 'Den Ofen auf 175° C vorheizen. Eine Runde Backform einfetten und mit Semmelbröseln bestreuen. Die Eier trennen. Die Eigelb mit dem Zucker und dem Zitronensaft schaumig rühren.\r\n\r\nMehl, Nüsse, Karotten, Backpulver und Salz vermischen und unter die Eigelbmasse rühren. Die Eiweiß steif schlagen und vorsichtig unter den restlichen Teig heben. Dann die Masse in die Backform füllen und 50-60 min backen.\r\n\r\nAbkühlen lassen und dann mit Puderzucker bestreuen. Zu Ostern kann das ganze mit einem Marzipanmantel und Marzipanmöhrchen versehen werden.', 4, NULL),
(3, 'Nussecken', 'Die Zutaten für den Teig zu einem Mürbeteig verarbeiten. 30 Min. im Kühlschrank ruhen lassen. Auf einem gefetteten Backblech ausrollten.\r\n\r\nAprikosenkonfitüre glatt rühren und gleichmäßig auf den Teig streichen.\r\n\r\nDie Butter in einem Topf zerlassen. Zucker, V.-Zucker und Wasser zugeben und langsam erwärmen. Dann Nüsse und Mandeln unterheben. Belag gleichmäßig auf dem Teig verteilen.\r\n\r\nIm vorgeheizten Backofen bei 175°C (Ober/Unterhitze) ca. 30 Min. backen.\r\n\r\nNach dem Abkühlen in Dreiecke schneiden. Jeweils 2 Ecken in flüssige Kuvertüre tunken und auf Pergamentpapier legen, bis die Schokolade fest geworden ist.', 12, NULL),
(4, 'Schokoladenkuchen', 'Butter schäumig rühren, Eier und Zucker nach und nach unterrühren Schokoblättchen, Mandeln, Mehl zu einer schaumigen masse rühren. Ein Blech einfetten und Teig gleichmässig dadrauf verteilen 180 C ca. 15 - 20 min. backen', 4, NULL),
(5, 'Weintraubenkuchen', 'Eigelb trennen, Eigelb, zucker  Mineralwasser und Vanillezucker schaumig rühren. Eiweiß aufschlagen mit einer Prise salz, mehl und Backpulver zur verrührten masse geben und das Mandelaroma hinzu fügen dann den Eschnee unterheben. Alles in eine gefettete Springform geben und bei mittlerer schiene und 180 grad backen für 25 - 35 Minuten. Gut auskühlen lassen, jetzt das Backfeste Pudding pulver mit Milch anrühren siehe Anleitung auf dem päckchen. Der Pudding sollte nicht zu flüssig sein. Den Pudding auf dem ausgekühlten Kuchenboden glatt streichen. Jetzt die kernlosen Weintrauben halbieren und mit der Schnittfläche nach unten auf den pudding legen. Alles in den Kühlschrank für mindestens 2 stunden. Wer mag kann sich noch einen Tortenguss aus Weintraubensaft und Tortenguss hell anrühren und darüber geben.', 4, NULL),
(6, 'Blaubeer Joghurt Kuchen', 'Butter , zucker und salz verquirlen , danach backpulver , mehl , Aroma , Joghurt und die eier dazu und ebenfalls verquirlen . dann die Blaubeeren vorsichtig mit einem Löffel unterheben . eine gefettete Gugelhupfform vorbereiten und den ofen auf 175 grad vorheitzen . den teig in die form geben und auf mitlere schiene bei ober und unterhitze für 60 minuten backen . nach dem backen mind. 2 stunden auskühlen lassen . wer mag kann noch einen zuckerguß darüber geben . einfach den puderzucker mit blaubeersaft anrühren anstatt mit wasser.', 4, NULL),
(7, 'KitKat-Kuchen', 'Backofen auf 170 Grad vorheizen. Alle Zutaten ( ausser den KitKats ) in eine Rührschüssel geben und mit einem Rührgerät einige Minuten durchkneten bis der Teig geschmeidig geworden ist. Eine Kastenform einfetten und die Hälfte des Teiges hineingeben. Nun kommen die Schokoriegel ins Spiel. Wenn alle 4 Packungen geöffnet sind müssten 16 Stück Kitkat zum Vorschein kommen. Diese nun einzeln, dicht nebeneinander in die Form legen. ( bei mir passen sie wie angegeossen hinein und füllen sie beinahe vollständig aus ). Jetzt den Rest des Teiges hinzugeben. Das Alles ca 50-60 Minuten backen. Zum Schluß müssten die Kitkat im Kucheninneren ihre Konsistenz behalten haben. Dadurch entsteht ein knuspriges "Innenleben".', 8, NULL),
(8, 'Mini Zitronen Blumen Kuchen', 'Butter , Puderzucker und das halbe Päckchen abgeriebene Zitronenschale verrühren . Die Eier hinzugeben und die Masse schaumig schlagen . Nach und nach das Mehl hinzugeben und zu einem geschmeidigen Teig verrühren . In die Silikonform füllen und bei Ober und Unterhitze 25 Minuten bei 170 Grad backen.\r\n\r\nDie Form aus den Ofen nehmen und 10 Minuten abkühlen lassen , Dann die Mini Kuchen aus der Form nehmen und je nach Geschmack mit Puderzucker oder einer Glasur verfeinern . z.B. 2 EL Puderzucker mit etwas Zitronen Saft vermischen und damit die Blumen bestreichen . Sind nicht zum satt essen , ein kleines Schnäckelchen zum Kaffee oder Tee .', 5, NULL),
(9, 'Bunter Limo - Kuchen', 'Eier mit Zucker und Vanillinzucker weißschaumig rühren. Zitronenlimonade und Öl dazugeben. Mehl und Backpulver mischen, darüber sieben und alles zusammen unterrühren. Den Teig vierteln und jeden Teil mit einer anderen Farbe einfärben.\r\n\r\nDen Teig abwechselnd löffelweise in eine gefettete Guglhupfform oder Kranzform füllen und bei 180° C Ober-/Unterhitze oder bei 160° C Umluft im vorgeheizten Backofen 55 Minuten backen. Puderzucker mit Zitronensaft verrühren, den abgekühlten Kuchen damit überziehen und mit bunten Streuseln verzieren.', 14, NULL),
(10, 'M&M-Kuchen', 'Mirabellen entsteinen, halbieren und mit 2 El Zucker mischen. Eine halbe Stunde stehen lassen...\r\n\r\nMargarine, Zucker und Zitroback schaumig schlagen, Eier einzeln unterrühren... Mehl und BP mischen und unterheben.\r\n\r\nüber die Mirabellen 150 ml Wasser gießen und noch einmal umrühren, damit der mit Zucker vermischte Saft rausläuft (hab die Mirabellen in einem Nudelsieb ziehen lassen). Flüssigkeit zum Teig geben und unterrühren!\r\n\r\nTeig auf ein gefettetes und bemehltes Blech (ca. 23x35 cm) streichen und die Mirabellen darauf verteilen.\r\n\r\nAhornsirup erwärmen, Mandelblättchen unterrühren und über den Mirabellen verteilen.\r\n\r\nIm vorgeheizten Backofen bei 175°C ca 45 - 50 Min backen.', 12, NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `rezzut`
--

CREATE TABLE IF NOT EXISTS `rezzut` (
  `RezeptID` int(11) NOT NULL DEFAULT '0',
  `ZutatID` int(11) NOT NULL DEFAULT '0',
  `Menge` float DEFAULT NULL,
  `EinheitID` int(11) DEFAULT NULL,
  PRIMARY KEY (`RezeptID`,`ZutatID`),
  KEY `ZutatID` (`ZutatID`),
  KEY `EinheitID` (`EinheitID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `rezzut`
--

INSERT INTO `rezzut` (`RezeptID`, `ZutatID`, `Menge`, `EinheitID`) VALUES
(1, 1, 250, 2),
(1, 2, 0.5, 5),
(1, 3, 230, 2),
(1, 4, 1, 5),
(1, 5, 125, 2),
(1, 6, 9, 4),
(1, 7, 1, 1),
(1, 8, 330, 2),
(1, 9, 30, 2),
(2, 1, 80, 2),
(2, 2, 3, 5),
(2, 3, 250, 2),
(2, 4, 0.5, 5),
(2, 6, 5, 4),
(2, 10, 10, 7),
(2, 11, 250, 2),
(2, 12, 250, 2),
(3, 1, 300, 2),
(3, 2, 1, 5),
(3, 3, 330, 2),
(3, 5, 330, 2),
(3, 6, 2, 4),
(3, 13, 3, 4),
(3, 14, 150, 2),
(3, 15, 20, 7),
(3, 16, 200, 2),
(3, 17, 200, 2),
(3, 18, 200, 2),
(4, 1, 100, 2),
(4, 3, 250, 2),
(4, 5, 250, 2),
(4, 6, 6, 4),
(4, 19, 300, 2),
(4, 20, 250, 2),
(5, 1, 140, 2),
(5, 2, 1, 4),
(5, 3, 140, 2),
(5, 4, 1, 5),
(5, 6, 3, 4),
(5, 21, 1, 4),
(5, 22, 1, 8),
(5, 23, 20, 7),
(5, 24, 2, 4),
(5, 25, 40, 4),
(6, 1, 550, 2),
(6, 2, 1, 4),
(6, 3, 300, 2),
(6, 4, 1, 5),
(6, 5, 200, 2),
(6, 6, 4, 4),
(6, 22, 50, 7),
(6, 26, 550, 2),
(6, 27, 150, 2),
(7, 1, 200, 2),
(7, 2, 1, 4),
(7, 3, 200, 2),
(7, 5, 200, 2),
(7, 6, 4, 4),
(7, 28, 100, 2),
(7, 29, 20, 4),
(8, 1, 120, 2),
(8, 5, 120, 2),
(8, 6, 2, 4),
(8, 30, 120, 2),
(8, 31, 50, 2),
(9, 1, 450, 2),
(9, 2, 1, 4),
(9, 3, 200, 2),
(9, 6, 6, 4),
(9, 21, 10, 2),
(9, 30, 150, 2),
(9, 32, 150, 7),
(9, 33, 250, 7),
(9, 34, 3, 4),
(9, 35, 2, 4),
(9, 36, 200, 2),
(10, 1, 300, 2),
(10, 2, 1, 4),
(10, 3, 250, 2),
(10, 6, 4, 4),
(10, 37, 1, 1),
(10, 38, 250, 2),
(10, 39, 1, 4),
(10, 40, 200, 2),
(10, 41, 150, 2),
(10, 42, 100, 7);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `passwort` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `zutat`
--

CREATE TABLE IF NOT EXISTS `zutat` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Score` bigint(20) DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=43 ;

--
-- Daten für Tabelle `zutat`
--

INSERT INTO `zutat` (`ID`, `Score`, `Name`) VALUES
(1, 9, 'Mehl'),
(2, 7, 'Backpulver'),
(3, 8, 'Zucker'),
(4, 3, 'Salz'),
(5, 5, 'Butter'),
(6, 9, 'Eier'),
(7, 0, 'Magerquark'),
(8, 0, 'Konditorsahne'),
(9, 0, 'Speisestärke'),
(10, 0, 'Zitronensaft'),
(11, 0, 'gemahlene Nüsse'),
(12, 0, 'geriebene Karotten'),
(13, 0, 'Bourbon-Vanillezucker'),
(14, 0, 'Aprikosen Konfitüre'),
(15, 0, 'Wasser'),
(16, 0, 'Kaselnüsse gemahlen'),
(17, 0, 'Mandeln gehackt'),
(18, 0, 'Kuvertüre dunkel'),
(19, 0, 'Schokoblättchen'),
(20, 0, 'Mandeln gemahlen'),
(21, 1, 'Vanillezucker'),
(22, 1, 'Bittermandel Aroma'),
(23, 0, 'Mineralwasser'),
(24, 0, 'backfester pudding'),
(25, 0, 'Weintrauben (rot, kernlos)'),
(26, 0, 'Joghurt 10% Fett'),
(27, 0, 'Blaubeeren'),
(28, 0, 'Haselnüsse gemahlen'),
(29, 0, 'Kitkat'),
(30, 1, 'Puderzucker'),
(31, 0, 'Zitronenabrieb'),
(32, 0, 'Zitronenlimonade'),
(33, 0, 'Öl'),
(34, 0, 'Speisefarbe'),
(35, 0, 'Zitronen'),
(36, 0, 'Bunte Zuckerstreusel'),
(37, 0, 'Mirabellen frisch'),
(38, 0, 'Magarine'),
(39, 0, 'Zitroback'),
(40, 0, 'Dinkel Mehl'),
(41, 0, 'Mandelblättchen'),
(42, 0, 'Ahornsirup');

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `rezept`
--
ALTER TABLE `rezept`
  ADD CONSTRAINT `rezept_ibfk_1` FOREIGN KEY (`UsrID`) REFERENCES `user` (`ID`);

--
-- Constraints der Tabelle `rezzut`
--
ALTER TABLE `rezzut`
  ADD CONSTRAINT `rezzut_ibfk_1` FOREIGN KEY (`RezeptID`) REFERENCES `rezept` (`ID`),
  ADD CONSTRAINT `rezzut_ibfk_2` FOREIGN KEY (`ZutatID`) REFERENCES `zutat` (`ID`),
  ADD CONSTRAINT `rezzut_ibfk_3` FOREIGN KEY (`EinheitID`) REFERENCES `einheit` (`ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
