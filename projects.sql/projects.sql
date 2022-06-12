-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 12 Haz 2022, 13:10:18
-- Sunucu sürümü: 10.4.24-MariaDB
-- PHP Sürümü: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `projects`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `id` tinyint(1) UNSIGNED NOT NULL,
  `kullaniciAdi` varchar(100) NOT NULL,
  `kullaniciSifre` varchar(100) NOT NULL,
  `isimSoyisim` varchar(100) NOT NULL,
  `kullaniciEmail` varchar(100) NOT NULL,
  `kullaniciTelefon` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `kullaniciAdi`, `kullaniciSifre`, `isimSoyisim`, `kullaniciEmail`, `kullaniciTelefon`) VALUES
(0, 'admin', '1234', 'Busenur Adıbelli', 'bsnradblli@gmail.com', '0544 252 37 88');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ciro`
--

CREATE TABLE `ciro` (
  `id` int(11) NOT NULL,
  `kasaToplam` int(11) NOT NULL,
  `satis` int(11) NOT NULL,
  `alis` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `config`
--

CREATE TABLE `config` (
  `id` tinyint(1) NOT NULL,
  `SiteAdi` varchar(50) NOT NULL,
  `SiteTitle` varchar(60) NOT NULL,
  `SiteDescription` text NOT NULL,
  `SiteKeywords` varchar(255) NOT NULL,
  `SiteCopyright` varchar(255) NOT NULL,
  `SiteLogo` varchar(50) NOT NULL,
  `SiteEmail` varchar(50) NOT NULL,
  `SiteEmailSifre` varchar(50) NOT NULL,
  `FacebookLink` varchar(255) NOT NULL,
  `TwitterLink` varchar(255) NOT NULL,
  `InstagramLink` varchar(255) NOT NULL,
  `SabitTelefon` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `config`
--

INSERT INTO `config` (`id`, `SiteAdi`, `SiteTitle`, `SiteDescription`, `SiteKeywords`, `SiteCopyright`, `SiteLogo`, `SiteEmail`, `SiteEmailSifre`, `FacebookLink`, `TwitterLink`, `InstagramLink`, `SabitTelefon`) VALUES
(0, 'Balabanlar Ziraat Mühendisliği', 'Balabanlar Ziraat', 'Tarım, kendi içinde bir çok zorluklarla doludur. Biz, çiftçiler, ziraat mühendisleri, distribütörler, bayiler ve tüm ilgili tarım kuruluşları ile birlikte çalışarak, çiftçilerimizin işlerini kolaylaştırmaya çalışıyoruz.', 'serik, ziraat, zirai, hanife balaban, balabanlar', 'Copyright | 2022 | badblli', '', 'akihiraeth@gmail.com', '38buse07nur', 'https://www.facebook.com/people/Balabanlar-ziraat-m%C3%BChendisli%C4%9Fi/100057218568905/', 'https://twitter.com/hnfblbn', 'https://www.instagram.com/hanifebalaban4/', '+90 242 722 13 27');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `customers`
--

CREATE TABLE `customers` (
  `id` int(11) NOT NULL,
  `musteriAd` varchar(100) NOT NULL,
  `musteriSoyad` varchar(100) NOT NULL,
  `musteriTelefon` varchar(50) NOT NULL,
  `musteriEmail` varchar(100) NOT NULL,
  `musteriAdres` varchar(100) NOT NULL,
  `musteriKayitTarih` date DEFAULT NULL,
  `musteriDurum` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `customers`
--

INSERT INTO `customers` (`id`, `musteriAd`, `musteriSoyad`, `musteriTelefon`, `musteriEmail`, `musteriAdres`, `musteriKayitTarih`, `musteriDurum`) VALUES
(1, 'Busenur', 'Adıbelli', '(544) 252-3788', 'bsnradblli@gmail.com', 'Serik/Antalya', '2022-05-27', 1),
(2, 'Halil', 'Adıbelli', '(505) 039-3788', 'hadibelli@gmail.com', 'Serik/Antalya', '2022-05-27', 1),
(3, 'güncellendi', 's', '(345) 435-3453', 'sfdgf', 'gsg', '2022-05-13', 0),
(4, 'silinecek', 'asfd', '(234) 324-3243', 'sdfsdf', 'dsfsdf', '2022-05-27', 0),
(5, '', '', '(454) 354-3535', '', 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '2022-05-27', 0),
(6, 'agüncel', 'aaa', '(343) 243-2432', 'dfasfs', 'asdf', '2022-05-27', 0),
(7, 'ad', 'a', '(342) 324-3243', 'fvfd', 'fvd', '2022-05-29', 0),
(8, 'a', 'a', '(324) 324-2343', 'dfasdsf', 'sdf', '2022-05-29', 0),
(9, 'güncellendi', 's', '(345) 435-3453', 'sfdgf', 'gsg', '2022-05-13', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `firmabilgileri`
--

CREATE TABLE `firmabilgileri` (
  `SiteUrl` varchar(150) DEFAULT NULL,
  `Title` varchar(200) DEFAULT NULL,
  `Footer` varchar(500) DEFAULT NULL,
  `Footer1` varchar(100) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `Keywords` varchar(250) DEFAULT NULL,
  `Author` varchar(100) DEFAULT NULL,
  `Hakkinda` longtext DEFAULT NULL,
  `Tel` varchar(50) DEFAULT NULL,
  `Mail` varchar(50) DEFAULT NULL,
  `Adres` varchar(500) DEFAULT NULL,
  `Facebook` varchar(50) DEFAULT NULL,
  `Twitter` varchar(50) DEFAULT NULL,
  `Skype` varchar(50) DEFAULT NULL,
  `GPlus` varchar(50) DEFAULT NULL,
  `Instagram` varchar(50) DEFAULT NULL,
  `GoogleAnalytics` varchar(500) DEFAULT NULL,
  `reCAPTCHA` varchar(200) DEFAULT NULL,
  `UstLogo` varchar(150) DEFAULT NULL,
  `AltLogo` varchar(150) DEFAULT NULL,
  `SmtpHost` varchar(100) DEFAULT NULL,
  `SmtpUser` varchar(50) DEFAULT NULL,
  `SmtpPassword` varchar(50) DEFAULT NULL,
  `SmtpPort` varchar(50) DEFAULT NULL,
  `Tema` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `firmabilgileri`
--

INSERT INTO `firmabilgileri` (`SiteUrl`, `Title`, `Footer`, `Footer1`, `Description`, `Keywords`, `Author`, `Hakkinda`, `Tel`, `Mail`, `Adres`, `Facebook`, `Twitter`, `Skype`, `GPlus`, `Instagram`, `GoogleAnalytics`, `reCAPTCHA`, `UstLogo`, `AltLogo`, `SmtpHost`, `SmtpUser`, `SmtpPassword`, `SmtpPort`, `Tema`, `IsActive`) VALUES
('http://badblli.me', 'XtbAdminV2 | Deneme Sayfası', '<p>Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur</p>\r\n', '2022 © Copyright badblli.me Tüm Hakları Saklıdır.', 'PHP Responsive Admin Panel | XtbAdminV2', 'PHP, Responsive, Panel, Admin, Yönetim, XtbAdmin, V2', 'badblli', '<p>Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur</p>\r\n', '+90 544 XXX XX XX', 'info@badbllime', 'Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 'http://facebook.com/mucahid1topal', 'http://twitter.com/illakikonusuruz', 'http://skype.com/badblli', 'https://plus.google.com/u/1/badblli', 'https://instagram.com/badblli?ref=badge', '', '', 'logo.png', 'footer_logo.png', 'mail.badblli.com', 'info@badblli.com', '12345', '587', 1, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `UserID` int(11) NOT NULL,
  `Adi` varchar(50) NOT NULL DEFAULT '0',
  `Soyadi` varchar(50) NOT NULL DEFAULT '0',
  `TelNo` varchar(50) NOT NULL DEFAULT '0',
  `Email` varchar(50) NOT NULL DEFAULT '0',
  `Adres` varchar(100) NOT NULL DEFAULT '0',
  `KullaniciAdi` varchar(50) NOT NULL DEFAULT '0',
  `Sifre` varchar(50) NOT NULL DEFAULT '0',
  `Yetki` varchar(50) NOT NULL DEFAULT 'Personel',
  `IsActive` int(11) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`UserID`, `Adi`, `Soyadi`, `TelNo`, `Email`, `Adres`, `KullaniciAdi`, `Sifre`, `Yetki`, `IsActive`) VALUES
(1, 'Busenur', 'Adıbelli', '0544 252 37 88', 'bsnradblli@gmail.com', 'Antalya', 'admin', '10470c3b4b1fed12c3baac014be15fac67c6e815', 'Admin', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `notes`
--

CREATE TABLE `notes` (
  `id` int(11) NOT NULL,
  `note` varchar(100) NOT NULL,
  `baslik` varchar(100) NOT NULL,
  `tarih` date NOT NULL,
  `durum` int(11) NOT NULL,
  `onem` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `notes`
--

INSERT INTO `notes` (`id`, `note`, `baslik`, `tarih`, `durum`, `onem`) VALUES
(2, 'not 1', 'önemli', '2022-06-12', 0, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `notifications`
--

CREATE TABLE `notifications` (
  `id` int(11) NOT NULL,
  `isimSoyisim` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `mesaj` text NOT NULL,
  `durum` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `notifications`
--

INSERT INTO `notifications` (`id`, `isimSoyisim`, `email`, `mesaj`, `durum`) VALUES
(1, 'Busenur adıbelli', 'bsnradblli@gmail.com', 'bu bir deneme mesajıdır', 1),
(2, 'Joe Doe', 'akihiraeth@gmail.com', 'bu bir deneme mesajıdır.', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oturumtakip`
--

CREATE TABLE `oturumtakip` (
  `ID` int(11) NOT NULL,
  `ip` varchar(50) NOT NULL DEFAULT '0',
  `basarili` varchar(50) NOT NULL DEFAULT '0',
  `proxy` varchar(50) NOT NULL DEFAULT '0',
  `hostadi` varchar(50) NOT NULL DEFAULT '0',
  `username` varchar(50) NOT NULL DEFAULT '0',
  `password` varchar(50) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `oturumtakip`
--

INSERT INTO `oturumtakip` (`ID`, `ip`, `basarili`, `proxy`, `hostadi`, `username`, `password`) VALUES
(44, '::1', '1', '', 'root-mtlive', '0', '0'),
(43, '::1', '1', '', 'root-mtlive', '0', '0'),
(42, '::1', '0', '', 'root-mtlive', 'admin', '12541254'),
(41, '::1', '1', '', 'root-mtlive', '0', '0'),
(45, '::1', '1', '', 'badblli', '0', '0'),
(46, '::1', '0', '', 'badblli', 'admin', '1234'),
(47, '::1', '0', '', 'badblli', 'admin', '123456'),
(48, '::1', '0', '', 'badblli', 'admin', '63982e54a7aeb0d89910475ba6dbd3ca6dd4e5a1'),
(49, '::1', '1', '', 'badblli', '0', '0'),
(50, '::1', '1', '', 'badblli', '0', '0'),
(51, '::1', '1', '', 'badblli', '0', '0');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `products`
--

CREATE TABLE `products` (
  `id` int(10) UNSIGNED NOT NULL,
  `urunAdi` varchar(100) NOT NULL,
  `ureticiFirma` varchar(100) NOT NULL,
  `urunTuru` varchar(50) NOT NULL,
  `urunAlisFiyat` int(100) NOT NULL,
  `urunSatisFiyat` int(100) NOT NULL,
  `urunAdet` int(100) NOT NULL,
  `urunAlimTarih` date NOT NULL,
  `urunResim` text NOT NULL,
  `urunDurum` int(11) NOT NULL,
  `urunAciklama` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `products`
--

INSERT INTO `products` (`id`, `urunAdi`, `ureticiFirma`, `urunTuru`, `urunAlisFiyat`, `urunSatisFiyat`, `urunAdet`, `urunAlimTarih`, `urunResim`, `urunDurum`, `urunAciklama`) VALUES
(2, 'Dexfol Rojo', 'Tim Plant Care Tarım San. ve Tic. Ltd. Şti', 'İlaç', 450, 800, 100, '2022-03-09', 'https://www.timplantcare.com.tr/upload/products/dexfol_rojo.png', 1, 'Bitkide kuru madde sağlar. Metabolizmaya hızlı katılır. Birçok karışımda kullanılabilir. Hızlı olgunlaştırma sağlar.'),
(3, 'Pulse', 'Ekosan Tarım ltd.şti.', 'Gübre', 850, 1200, 97, '2022-03-10', 'http://www.ekosantarim.com.tr/uploads/image/urunler/pulse16-8-24kutu.png', 1, ' Ürünün sahip olduğu düşük EC seviyesi yüksek beslenme imkânı sağlar, verimliliği arttırır. %100 büyüme gücü veren en kaliteli damlama sulama gübresidir.'),
(4, 'İKİSIR', 'Ekosan Tarım ltd.şti.', 'İlaç', 200, 450, 0, '2022-04-05', 'https://scontent.fist3-1.fna.fbcdn.net/v/t1.6435-9/80547163_2656277964466454_2772589934337327104_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=5qhXZkO0jbAAX9bawkM&_nc_ht=scontent.fist3-1.fna&oh=00_AT8Bxe_JNpkC9leA7FIbiPYlkiD_f4DfhcLhYAQ83dCikA&oe=62C89C2C', 1, 'Daha hızlı ve daha sağlıklı mahsuller için Zira Ixir. Çinko (Zn) : %5  Yoğunluk :1,1'),
(5, 'SUPERNAT 93', 'CİFAGRO TARIM LTD.ŞTİ.', 'Gübre', 500, 850, 100, '2022-02-18', 'https://www.cifagro.com.tr/upload/2016/05/supernat-toplu-medium.jpg', 1, 'Organik kökenli suda çözülebilen sıvı bir gübredir. Her türlü bahçe, çiçekçilik ve meyve bitkileri için üretilmiş, doğrudan toprak veya damlama sulama ile kullanıma uygundur.'),
(6, 'CIFALGA GROW', 'CİFAGRO TARIM LTD.ŞTİ.', 'Gübre', 500, 850, 0, '2022-05-18', 'https://www.cifagro.com.tr/upload/2016/12/cifalga-grow_1.jpg', 1, 'Verimi artırmak ve nihai ürünün kalitesel özelliklerini artırmak için özel olarak geliştirilmiş olan besinsel bir bioaktivatördür.'),
(7, 'POTAMAX', 'Odak Tarım Ltd. Şti.', 'Gübre', 300, 500, 100, '2022-04-14', 'http://www.odaktarim.com/assets/images/products/IMG_4639.png', 1, 'Bitkide meyveyi büyütür, verimi arttırır ve vejetatif gelişimi teşvik eder.Toprakta bitki büyümesi gerekli olan elementlerin alımını kolaylaştırır ve meyveye uzun raf ömrü sağlar.    '),
(8, 'NovaMass', 'BioNova', 'Gübre', 580, 610, 100, '2022-04-22', 'https://bionovanutrients.com/media/51/4f/21/1598380976/Vitasol-Set-5L-1L-250ml-Bionova-stimulator.jpg', 1, 'Meyve tatlandırıcı doğal şekerler içerir. Kalsiyum, Magnezyum, Bakır, Kireç, Potasyum, vitaminler ve çok sayıda elementi barındırır.'),
(9, 'METEOR', 'Odak Tarım Ltd. Şti.', 'Gübre', 630, 780, 150, '2022-05-01', 'http://www.odaktarim.com/assets/images/products/IMG_4885.png', 1, 'NPK formulasyonlarını tüm bitkilerin farklı gelişim dönemlerinde kullanıma uygundur. Kolaylıkla suda tamamen çözünür. Bitki tarafından hızlı alınabilen mikro elementler içerir. Damlama sulama sistemlerini temiz tutar, tüplerde tıkanmaya neden olmaz.'),
(10, 'LION', 'Odak Tarım Ltd. Ştiç.', 'Gübre', 750, 810, 100, '2022-05-01', 'http://www.odaktarim.com/assets/images/products/lion-npk.png', 1, 'Gübrelerinin tüm formülasyonları alınabilirliği yüksek kaliteli ham maddelerden yapılmıştır. Tüm formülasyonlar asidik karakterlidir. İçerisindeki izelementler edta ile şelatlanmıştır. Yapraktan ve topraktan rahatlıkla kullanılabilir.'),
(11, 'Calpo-Dex', 'Tim Plant Care Tarım San. ve Tic. Ltd. Şti', 'İlaç', 580, 650, 20, '2022-05-01', 'https://www.timplantcare.com.tr/upload/products/calpodex.png', 1, 'Kalsiyum, Azot ve Potasyum içerikli çok amaçlı bir üründür. Bitkilerin son dönemde ihtiyaç duyduğu kuru madde üretiminde aktif görev yapan elementleri içerir. Hücre büyümesinde görev yapar. Bitki dayanıklılığını artırır. Raf ömrünü artırır.'),
(12, 'Milagro NUTRIGOLD', 'TEKTAR TEKNİK TARIM A.Ş.', 'Gübre', 390, 690, 50, '2022-04-21', 'https://www.tektar.com.tr/wp-content/uploads/2020/08/TK_NUTRIGOLD_20-20-20_-10-25kg-AW-scaled.jpg', 1, ' Her türlü kirleticiden, ağır metalden ari olup yüksek safiyet ve kaliteye sahiptir. Mükemmelen çözünür, düşük tuzlulukla yüksek etkinlik gösterir ve asit karakterlidir. Tüm formülasyonlarının iz element içeriği eşit olup yüksek orandadır. Bitki besleme performansıyla kaliteli gübre segmentinin öncüsüdür.'),
(13, 'AGROFOL N300', 'TEKTAR TEKNİK TARIM A.Ş.', 'İlaç', 320, 420, 50, '2022-04-21', 'https://www.tektar.com.tr/wp-content/uploads/2020/08/AGROFOL-N300-L1.jpg', 1, 'yüksek oranda azot ihtiva etmekte olup, bitkilerde yeşil aksamın gelişme devresinin başından hasada kadar güvenle kullanılır.'),
(14, 'K-Energy', 'Asos Tarım Tohum Ltd. Şti.', 'İlaç', 320, 450, 100, '2022-04-21', 'http://www.asostarim.com/img_site/gubre-tr/032_k_energy.jpg', 1, ''),
(15, 'First SULP', 'Etüt Tarım Ltd. Şti.', 'İlaç', 280, 380, 100, '2022-03-11', 'https://scontent.fist3-1.fna.fbcdn.net/v/t39.30808-6/285744129_10160214293672417_2750726502746098744_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=xE_jG2QVafYAX8NMhDt&_nc_ht=scontent.fist3-1.fna&oh=00_AT-RiI4JwVkG77mMsXwsWpCMDWykbHTbaoAJzecBBcOtUA&oe=62A97605', 1, ''),
(16, 'First Cal', 'Etüt Tarım Ltd. Şti.', 'İlaç', 390, 680, 100, '2022-04-14', 'https://scontent.fist3-1.fna.fbcdn.net/v/t39.30808-6/285744129_10160214293672417_2750726502746098744_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=xE_jG2QVafYAX8NMhDt&_nc_ht=scontent.fist3-1.fna&oh=00_AT-RiI4JwVkG77mMsXwsWpCMDWykbHTbaoAJzecBBcOtUA&oe=62A97605', 1, ''),
(17, 'First POTAS', 'Etüt Tarım Ltd. Şti.', 'İlaç', 280, 320, 10, '2022-04-14', 'https://scontent.fist3-1.fna.fbcdn.net/v/t39.30808-6/285744129_10160214293672417_2750726502746098744_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=xE_jG2QVafYAX8NMhDt&_nc_ht=scontent.fist3-1.fna&oh=00_AT-RiI4JwVkG77mMsXwsWpCMDWykbHTbaoAJzecBBcOtUA&oe=62A97605', 1, ''),
(18, 'First ZnP-B', 'Etüt Tarım Ltd. Şti.', 'İlaç', 380, 650, 100, '2022-04-21', 'https://scontent.fist3-1.fna.fbcdn.net/v/t39.30808-6/285744129_10160214293672417_2750726502746098744_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=xE_jG2QVafYAX8NMhDt&_nc_ht=scontent.fist3-1.fna&oh=00_AT-RiI4JwVkG77mMsXwsWpCMDWykbHTbaoAJzecBBcOtUA&oe=62A97605', 1, ''),
(19, 'First N', 'Etüt Tarım Ltd. Şti.', 'İlaç', 320, 630, 100, '2022-04-21', 'https://scontent.fist3-1.fna.fbcdn.net/v/t39.30808-6/285744129_10160214293672417_2750726502746098744_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=xE_jG2QVafYAX8NMhDt&_nc_ht=scontent.fist3-1.fna&oh=00_AT-RiI4JwVkG77mMsXwsWpCMDWykbHTbaoAJzecBBcOtUA&oe=62A97605', 1, ''),
(21, 'deneme12', 'deneme12', 'Gübre', 454, 775, 10, '2022-05-28', 'C:\\Users\\bsnra\\OneDrive\\Masaüstü\\SATProje\\SATProje\\Resources\\73145417_2556916371069281_2041834693833261056_n.jpg', 0, 'güncellendi'),
(22, 'deneme123', 'deneme123', 'Gübre', 454, 775, 10, '2022-05-28', 'C:\\Users\\bsnra\\OneDrive\\Masaüstü\\SATProje\\SATProje\\Resources\\73145417_2556916371069281_2041834693833261056_n.jpg', 0, 'güncellendi'),
(23, 'silinecek', 'a', 'İlaç', 4, 5, 2, '2022-05-29', 'C:\\Users\\bsnra\\OneDrive\\Masaüstü\\SATProje\\SATProje\\Resources\\r1oaqci.jpg', 0, '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `resimler`
--

CREATE TABLE `resimler` (
  `ID` int(11) NOT NULL,
  `KatID` int(11) DEFAULT NULL,
  `Resim` text DEFAULT NULL,
  `ResimAdi` varchar(50) DEFAULT NULL,
  `ResimAciklamasi` longtext DEFAULT NULL,
  `IsActive` int(11) DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `resimler`
--

INSERT INTO `resimler` (`ID`, `KatID`, `Resim`, `ResimAdi`, `ResimAciklamasi`, `IsActive`) VALUES
(6, 6, 'aeee.jpg', 'Garaj', ' Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 1),
(7, 6, 'BlobServer.png', ' Blob', ' Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 1),
(8, 6, 'elektrikli-araclar-batarya-sistemi.jpg', ' Elektrikli', ' Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 1),
(9, 4, 'tersev.jpg', ' Ters Ev', ' Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 1),
(10, 4, 'yuksekev.jpg', ' Yüksek Ev', ' Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 1),
(11, 3, 'foto1.jpg', ' Bilgisyarlar', 'Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur Lorem ipsum dolor sit amet consectetur adipiscing elit. Phasellus id lectus quis dui euismod con placerat massa nec elit egestas efficitur', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sales`
--

CREATE TABLE `sales` (
  `id` int(11) NOT NULL,
  `urunAdi` varchar(100) NOT NULL,
  `satilanUrunAdet` int(11) NOT NULL,
  `urunTuru` varchar(100) NOT NULL,
  `musteriAdSoyad` varchar(100) NOT NULL,
  `satisTarihi` date NOT NULL,
  `toplamUcret` int(11) NOT NULL,
  `urunSatisFiyat` int(100) NOT NULL,
  `satisDurum` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `sales`
--

INSERT INTO `sales` (`id`, `urunAdi`, `satilanUrunAdet`, `urunTuru`, `musteriAdSoyad`, `satisTarihi`, `toplamUcret`, `urunSatisFiyat`, `satisDurum`) VALUES
(1, 'CIFALGA GROW', 50, 'Gübre', 'Busenur Adıbelli', '2022-06-10', 42500, 850, 1),
(2, 'First POTAS', 40, 'İlaç', 'Halil Adıbelli', '2022-06-10', 12800, 320, 1),
(3, 'Pulse', 3, 'Gübre', 'Halil Adıbelli', '2022-06-11', 3600, 1200, 1),
(4, 'İKİSIR', 100, 'İlaç', 'Busenur Adıbelli', '2022-06-11', 45000, 450, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yorumlar`
--

CREATE TABLE `yorumlar` (
  `ID` int(11) NOT NULL,
  `AdSoyad` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Yorum` longtext DEFAULT NULL,
  `Onaylandi` int(11) DEFAULT NULL,
  `Tarih` timestamp NOT NULL DEFAULT current_timestamp(),
  `IsActive` int(11) DEFAULT NULL,
  `IP` varchar(50) DEFAULT NULL,
  `Tarayici` varchar(100) DEFAULT NULL,
  `IsletimSistemi` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `yorumlar`
--

INSERT INTO `yorumlar` (`ID`, `AdSoyad`, `Email`, `Yorum`, `Onaylandi`, `Tarih`, `IsActive`, `IP`, `Tarayici`, `IsletimSistemi`) VALUES
(1, 'Ziyaretçi Adı', 'mail@gmail.com', 'Sizde Öneri Ve Görüşünüzü Bizimle Paylaşın , Birlikte Büyüyelim...', 1, '2017-09-12 21:43:26', 1, NULL, NULL, NULL);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `ciro`
--
ALTER TABLE `ciro`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `config`
--
ALTER TABLE `config`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`UserID`);

--
-- Tablo için indeksler `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `notifications`
--
ALTER TABLE `notifications`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `oturumtakip`
--
ALTER TABLE `oturumtakip`
  ADD PRIMARY KEY (`ID`);

--
-- Tablo için indeksler `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `resimler`
--
ALTER TABLE `resimler`
  ADD PRIMARY KEY (`ID`);

--
-- Tablo için indeksler `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `yorumlar`
--
ALTER TABLE `yorumlar`
  ADD PRIMARY KEY (`ID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `config`
--
ALTER TABLE `config`
  MODIFY `id` tinyint(1) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `notes`
--
ALTER TABLE `notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `notifications`
--
ALTER TABLE `notifications`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `oturumtakip`
--
ALTER TABLE `oturumtakip`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- Tablo için AUTO_INCREMENT değeri `products`
--
ALTER TABLE `products`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- Tablo için AUTO_INCREMENT değeri `resimler`
--
ALTER TABLE `resimler`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `sales`
--
ALTER TABLE `sales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `yorumlar`
--
ALTER TABLE `yorumlar`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
