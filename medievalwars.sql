-- phpMyAdmin SQL Dump
-- version 2.11.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 08, 2009 at 01:43 PM
-- Server version: 5.0.51
-- PHP Version: 5.2.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Database: `medievalwars`
--

-- --------------------------------------------------------

--
-- Table structure for table `build`
--

CREATE TABLE IF NOT EXISTS `build` (
  `id` int(11) NOT NULL auto_increment,
  `village_id` int(11) NOT NULL,
  `building` int(11) NOT NULL,
  `start_time` datetime NOT NULL,
  `stop_time` datetime default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_build_autoinc` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `build`
--


-- --------------------------------------------------------

--
-- Table structure for table `configuration`
--

CREATE TABLE IF NOT EXISTS `configuration` (
  `id` int(11) NOT NULL auto_increment,
  `index` int(11) default NULL,
  `expand` int(11) default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_configuration_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=2 ;

--
-- Dumping data for table `configuration`
--

INSERT INTO `configuration` (`id`, `index`, `expand`) VALUES
(1, 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `diplomates`
--

CREATE TABLE IF NOT EXISTS `diplomates` (
  `id` int(11) NOT NULL auto_increment,
  `group_1` int(11) NOT NULL,
  `group_2` int(11) NOT NULL,
  `type` int(11) default NULL,
  PRIMARY KEY  (`group_1`,`group_2`),
  KEY `ix_diplomates_autoinc` (`id`),
  KEY `fk_diplomates_groups1` (`group_2`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=30 ;

--
-- Dumping data for table `diplomates`
--

INSERT INTO `diplomates` (`id`, `group_1`, `group_2`, `type`) VALUES
(29, 1, 3, 2);

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE IF NOT EXISTS `groups` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(200) collate utf8_bin default NULL,
  `tag` varchar(500) collate utf8_bin default NULL,
  `description` text collate utf8_bin,
  `introduction` text collate utf8_bin,
  `avatar` bit(1) NOT NULL default '\0',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=5 ;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`id`, `name`, `tag`, `description`, `introduction`, `avatar`) VALUES
(1, 'Pirates Arg Us', 'ARG', 0x42616e67206e676f6e3c6272202f3e, NULL, '\0'),
(3, 'DreamingFighter', 'DREAM', NULL, NULL, '\0'),
(4, 'thangld', 'THANG', NULL, NULL, '\0');

-- --------------------------------------------------------

--
-- Table structure for table `invite`
--

CREATE TABLE IF NOT EXISTS `invite` (
  `id` int(11) NOT NULL auto_increment,
  `user` int(11) default NULL,
  `[group]` int(11) default NULL,
  `time` datetime default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_invite_autoinc` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `invite`
--


-- --------------------------------------------------------

--
-- Table structure for table `invites`
--

CREATE TABLE IF NOT EXISTS `invites` (
  `id` int(11) NOT NULL auto_increment,
  `group_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `invite_time` datetime NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_invites_autoinc` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `invites`
--


-- --------------------------------------------------------

--
-- Table structure for table `movement`
--

CREATE TABLE IF NOT EXISTS `movement` (
  `id` int(11) NOT NULL auto_increment,
  `from` int(11) default NULL,
  `to` int(11) default NULL,
  `type` int(11) default '2',
  `starting_time` datetime default NULL,
  `landing_time` datetime default NULL,
  `building` int(11) default '0',
  `scout` int(11) default '0',
  `bowman` int(11) default '0',
  `spear` int(11) default '0',
  `sword` int(11) default '0',
  `axe` int(11) default '0',
  `mounted` int(11) default '0',
  `light` int(11) default '0',
  `heavy` int(11) default '0',
  `ram` int(11) default '0',
  `catapult` int(11) default '0',
  `noble` int(11) default '0',
  `iron` int(11) default '0',
  `clay` int(11) default '0',
  `wood` int(11) default '0',
  `pending` tinyint(3) unsigned default '1',
  PRIMARY KEY  (`id`),
  KEY `ix_movement_autoinc` (`id`),
  KEY `fk_movement_villages` (`from`),
  KEY `fk_movement_villages1` (`to`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=357 ;

--
-- Dumping data for table `movement`
--

INSERT INTO `movement` (`id`, `from`, `to`, `type`, `starting_time`, `landing_time`, `building`, `scout`, `bowman`, `spear`, `sword`, `axe`, `mounted`, `light`, `heavy`, `ram`, `catapult`, `noble`, `iron`, `clay`, `wood`, `pending`) VALUES
(355, 1, 2, 2, '2009-04-05 09:45:47', '2009-04-05 10:03:47', 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(356, 1, 2, 2, '2009-04-05 09:45:53', '2009-04-05 10:03:53', 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `offers`
--

CREATE TABLE IF NOT EXISTS `offers` (
  `id` int(11) NOT NULL auto_increment,
  `offertype` int(11) NOT NULL,
  `offerquantity` int(11) NOT NULL,
  `fortype` int(11) NOT NULL,
  `forquantity` int(11) NOT NULL,
  `offernumber` int(11) NOT NULL,
  `maxtransporttime` int(11) NOT NULL,
  `village_id` int(11) NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_offers_autoinc` (`id`),
  KEY `fk_offers_villages` (`village_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `offers`
--


-- --------------------------------------------------------

--
-- Table structure for table `recruit`
--

CREATE TABLE IF NOT EXISTS `recruit` (
  `id` int(11) NOT NULL auto_increment,
  `village_id` int(11) NOT NULL,
  `troop` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `start_time` datetime default NULL,
  `end_time` datetime default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_recruit_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=12 ;

--
-- Dumping data for table `recruit`
--

INSERT INTO `recruit` (`id`, `village_id`, `troop`, `quantity`, `start_time`, `end_time`) VALUES
(11, 1, 2, 34, '2009-04-07 17:24:00', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `reports`
--

CREATE TABLE IF NOT EXISTS `reports` (
  `id` int(11) NOT NULL auto_increment,
  `owner` int(11) NOT NULL,
  `type` int(11) NOT NULL default '1',
  `create_time` datetime NOT NULL,
  `village_1` int(11) default NULL,
  `village_2` int(11) default NULL,
  `winningside` tinyint(3) unsigned default NULL,
  `luck` float default '0',
  `morale` float default '0',
  `title` varchar(255) character set utf8 default NULL,
  `aspear` int(11) default '0',
  `asword` int(11) default '0',
  `aaxe` int(11) default '0',
  `ascout` int(11) default '0',
  `alight` int(11) default '0',
  `aheavy` int(11) default '0',
  `amounted` int(11) default '0',
  `abow` int(11) default '0',
  `aram` int(11) default '0',
  `acatapult` int(11) default '0',
  `anoble` int(11) default '0',
  `dspear` int(11) default '0',
  `dsword` int(11) default '0',
  `daxe` int(11) default '0',
  `dscout` int(11) default '0',
  `dlight` int(11) default '0',
  `dheavy` int(11) default '0',
  `dmounted` int(11) default '0',
  `dbowman` int(11) default '0',
  `dram` int(11) default '0',
  `dcatapult` int(11) default '0',
  `dnoble` int(11) default '0',
  `saspear` int(11) default '0',
  `sasword` int(11) default '0',
  `saaxe` int(11) default '0',
  `sascout` int(11) default '0',
  `salight` int(11) default '0',
  `saheavy` int(11) default '0',
  `samounted` int(11) default '0',
  `sabowman` int(11) default '0',
  `saram` int(11) default '0',
  `sacatapult` int(11) default '0',
  `sanoble` int(11) default '0',
  `sdspear` int(11) default '0',
  `sdsword` int(11) default '0',
  `sdaxe` int(11) default '0',
  `sdbowman` int(11) default '0',
  `sdscout` int(11) default '0',
  `sdlight` int(11) default '0',
  `sdheavy` int(11) default '0',
  `sdmounted` int(11) default NULL,
  `sdram` int(11) default '0',
  `sdcatapult` int(11) default '0',
  `sdnoble` int(11) default '0',
  `wallBefore` int(11) default '0',
  `buildingBefore` int(11) default '0',
  `loyalBefore` int(11) default '0',
  `wallAfter` int(11) default '0',
  `buildingAfter` int(11) default '0',
  `loyalAfter` int(11) default '0',
  `iron` int(11) default '0',
  `clay` int(11) default '0',
  `wood` int(11) default '0',
  `unread` tinyint(3) unsigned NOT NULL default '1',
  `description` varchar(255) character set utf8 default NULL,
  `building` int(11) default NULL,
  KEY `ix_reports_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=30 ;

--
-- Dumping data for table `reports`
--

INSERT INTO `reports` (`id`, `owner`, `type`, `create_time`, `village_1`, `village_2`, `winningside`, `luck`, `morale`, `title`, `aspear`, `asword`, `aaxe`, `ascout`, `alight`, `aheavy`, `amounted`, `abow`, `aram`, `acatapult`, `anoble`, `dspear`, `dsword`, `daxe`, `dscout`, `dlight`, `dheavy`, `dmounted`, `dbowman`, `dram`, `dcatapult`, `dnoble`, `saspear`, `sasword`, `saaxe`, `sascout`, `salight`, `saheavy`, `samounted`, `sabowman`, `saram`, `sacatapult`, `sanoble`, `sdspear`, `sdsword`, `sdaxe`, `sdbowman`, `sdscout`, `sdlight`, `sdheavy`, `sdmounted`, `sdram`, `sdcatapult`, `sdnoble`, `wallBefore`, `buildingBefore`, `loyalBefore`, `wallAfter`, `buildingAfter`, `loyalAfter`, `iron`, `clay`, `wood`, `unread`, `description`, `building`) VALUES
(1, 1, 1, '2009-04-02 20:37:25', 1, 2, 0, -0.266194, 0, 'thangld tấn công Thành phố phuc(050|051)', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, NULL, 0),
(2, 2, 1, '2009-04-02 20:37:25', 1, 2, 0, -0.266194, 0, 'thangld tấn công Thành phố phuc(050|051)', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, NULL, 0),
(3, 1, 1, '2009-04-04 00:40:28', 1, 2, 0, -0.0622551, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 17, 0, 0, 0, 0, NULL, 0),
(4, 2, 1, '2009-04-04 00:40:28', 1, 2, 0, -0.0622551, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 17, 0, 0, 0, 0, NULL, 0),
(5, 1, 1, '2009-04-04 00:54:17', 1, 2, 0, -0.104095, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 17, 0, 0, 0, 0, NULL, 0),
(6, 2, 1, '2009-04-04 00:54:17', 1, 2, 0, -0.104095, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 17, 0, 0, 0, 0, NULL, 0),
(7, 1, 1, '2009-04-04 00:55:59', 1, 2, 1, -0.202267, 0, '***TRIAL MODE***', 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 17, 0, 0, 0, 0, NULL, 0),
(8, 2, 1, '2009-04-04 00:55:59', 1, 2, 1, -0.202267, 0, 'thangld tấn công Thành phố phuc(050|051)', 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 17, 0, 0, 0, 0, NULL, 0),
(9, 1, 1, '2009-04-04 10:17:57', 1, 2, 0, 0.130127, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(10, 2, 1, '2009-04-04 10:17:57', 1, 2, 0, 0.130127, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(11, 1, 1, '2009-04-04 10:18:10', 1, 2, 0, -0.25459, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(12, 2, 1, '2009-04-04 10:18:10', 1, 2, 0, -0.25459, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(13, 1, 1, '2009-04-04 10:22:29', 1, 2, 0, 0.0778038, 0, '***TRIAL MODE***', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(14, 2, 1, '2009-04-04 10:22:29', 1, 2, 0, 0.0778038, 0, '***TRIAL MODE***', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(15, 1, 1, '2009-04-04 10:23:28', 1, 2, 0, -0.0203684, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(16, 2, 1, '2009-04-04 10:23:28', 1, 2, 0, -0.0203684, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(17, 1, 1, '2009-04-04 10:24:28', 1, 2, 1, 0.194915, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(18, 2, 1, '2009-04-04 10:24:28', 1, 2, 1, 0.194915, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(19, 1, 1, '2009-04-04 10:25:09', 1, 2, 1, -0.287975, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(20, 2, 1, '2009-04-04 10:25:09', 1, 2, 1, -0.287975, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(21, 1, 1, '2009-04-04 10:25:44', 1, 2, 1, -0.170864, 0, '***TRIAL MODE***', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(22, 2, 1, '2009-04-04 10:25:44', 1, 2, 1, -0.170864, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(23, 1, 1, '2009-04-04 10:26:59', 1, 2, 1, 0.259702, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(24, 2, 1, '2009-04-04 10:26:59', 1, 2, 1, 0.259702, 0, 'thangld tấn công Thành phố phuc(050|051)', 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(25, 1, 1, '2009-04-04 10:29:43', 1, 2, 0, 0.109207, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(26, 2, 1, '2009-04-04 10:29:43', 1, 2, 0, 0.109207, 0, '***TRIAL MODE***', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(27, 1, 1, '2009-04-04 10:30:56', 1, 2, 0, 0.0110349, 0, 'thangld tấn công Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(28, 2, 1, '2009-04-04 10:30:56', 1, 2, 0, 0.0110349, 0, '***TRIAL MODE***', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, -1, 26, 0, 0, 0, 0, NULL, 0),
(29, 1, 6, '2009-04-04 23:54:24', 1, 2, NULL, 0, 0, 'thangld gửi quân hỗ trợ Thành phố phuc(050|051)', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `shoutbox`
--

CREATE TABLE IF NOT EXISTS `shoutbox` (
  `id` int(11) NOT NULL auto_increment,
  `userid` int(11) NOT NULL,
  `text` varchar(255) character set utf8 NOT NULL,
  `time` datetime NOT NULL,
  `[group]` int(11) default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_shoutbox_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=129 ;

--
-- Dumping data for table `shoutbox`
--


-- --------------------------------------------------------

--
-- Table structure for table `station`
--

CREATE TABLE IF NOT EXISTS `station` (
  `id` int(11) NOT NULL auto_increment,
  `from_village` int(11) NOT NULL,
  `at_village` int(11) NOT NULL,
  `spear` int(11) NOT NULL default '0',
  `sword` int(11) NOT NULL default '0',
  `axe` int(11) NOT NULL default '0',
  `bowman` int(11) NOT NULL default '0',
  `scout` int(11) NOT NULL default '0',
  `light` int(11) NOT NULL default '0',
  `heavy` int(11) NOT NULL default '0',
  `mounted` int(11) NOT NULL default '0',
  `ram` int(11) NOT NULL default '0',
  `catapult` int(11) NOT NULL default '0',
  `noble` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `ix_station_autoinc` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `station`
--


-- --------------------------------------------------------

--
-- Table structure for table `stationed`
--

CREATE TABLE IF NOT EXISTS `stationed` (
  `id` int(11) NOT NULL auto_increment,
  `from_village` int(11) default NULL,
  `at_village` int(11) default NULL,
  `spear` int(11) default NULL,
  `sword` int(11) default NULL,
  `axe` int(11) default NULL,
  `scout` int(11) default NULL,
  `light` int(11) default NULL,
  `heavy` int(11) default NULL,
  `ram` int(11) default NULL,
  `catapult` int(11) default NULL,
  `noble` int(11) default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_stationed_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=2 ;

--
-- Dumping data for table `stationed`
--

INSERT INTO `stationed` (`id`, `from_village`, `at_village`, `spear`, `sword`, `axe`, `scout`, `light`, `heavy`, `ram`, `catapult`, `noble`) VALUES
(1, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL auto_increment,
  `username` varchar(200) character set utf8 NOT NULL,
  `password` varchar(200) character set utf8 default NULL,
  `[group]` int(11) default NULL,
  `sex` tinyint(3) unsigned default '1',
  `birthdate` datetime default NULL,
  `last_update` datetime default NULL,
  `email` char(50) character set utf8 default NULL,
  `address` varchar(255) character set utf8 default NULL,
  `yahoo` varchar(50) collate utf8_bin default NULL,
  `msn` varchar(50) collate utf8_bin default NULL,
  `skype` varchar(50) collate utf8_bin default NULL,
  `description` mediumtext collate utf8_bin,
  `graphics_village` tinyint(3) unsigned default '1',
  `building_level` tinyint(3) unsigned default '1',
  `tribe_permission` int(11) default '0',
  `avatar` bit(1) NOT NULL default '\0',
  PRIMARY KEY  (`id`),
  KEY `ix_users_autoinc` (`id`),
  KEY `fk_users_groups` (`[group]`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `[group]`, `sex`, `birthdate`, `last_update`, `email`, `address`, `yahoo`, `msn`, `skype`, `description`, `graphics_village`, `building_level`, `tribe_permission`, `avatar`) VALUES
(1, 'thangld', '123', 1, 1, NULL, NULL, 'thangld@fpt.net', 'Hà Nội', 'Dreaming.Fighter', '', 'DF.thangld', 0x447265616d696e6746696768746572206cc3a02074610d0a, 0, 1, 246, '\0'),
(2, 'phuc', '123', NULL, 0, '1986-12-22 00:00:00', NULL, 'phuc@gmail.com', NULL, '', '', '', '', 0, 0, 0, '\0');

-- --------------------------------------------------------

--
-- Table structure for table `villages`
--

CREATE TABLE IF NOT EXISTS `villages` (
  `id` int(11) NOT NULL auto_increment,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  `name` varchar(100) character set utf8 default NULL,
  `userid` int(11) default NULL,
  `wood` int(11) default '500',
  `clay` int(11) default '500',
  `iron` int(11) default '500',
  `headquarter` int(11) default '1',
  `barracks` int(11) default '0',
  `stable` int(11) default '0',
  `workshop` int(11) default '0',
  `academy` int(11) default '0',
  `smithy` int(11) default '0',
  `rally` int(11) default '1',
  `market` int(11) default '0',
  `timbercamp` int(11) default '20',
  `claypit` int(11) default '30',
  `ironmine` int(11) default '20',
  `storage` int(11) default '1',
  `farm` int(11) default '1',
  `hide` int(11) default '1',
  `wall` int(11) default '0',
  `points` int(11) NOT NULL default '0',
  `unit_spear_tec_level` int(11) default '1',
  `unit_sword_tec_level` int(11) default '0',
  `unit_axe_tec_level` int(11) default '0',
  `unit_spy_tec_level` int(11) default '1',
  `unit_light_tec_level` int(11) default '0',
  `unit_heavy_tec_level` int(11) default '0',
  `unit_ram_tec_level` int(11) default '0',
  `unit_catapult_tec_level` int(11) default '0',
  `unit_snob_tec_level` int(11) default '1',
  `spear` int(11) NOT NULL default '0',
  `sword` int(11) NOT NULL default '0',
  `axe` int(11) NOT NULL default '0',
  `bowman` int(11) NOT NULL default '0',
  `scout` int(11) NOT NULL default '0',
  `light` int(11) NOT NULL default '0',
  `heavy` int(11) NOT NULL default '0',
  `mounted` int(11) NOT NULL default '0',
  `ram` int(11) NOT NULL default '0',
  `catapult` int(11) NOT NULL default '0',
  `noble` int(11) NOT NULL default '0',
  `last_update` datetime default NULL,
  `loyal` int(11) default '100',
  `in_spear` int(11) default '0',
  `in_sword` int(11) default '0',
  `in_axe` int(11) default NULL,
  `in_scout` int(11) default '0',
  `in_light` int(11) default '0',
  `in_heavy` int(11) default '0',
  `in_ram` int(11) default '0',
  `in_catapult` int(11) default '0',
  `in_noble` int(11) default '0',
  PRIMARY KEY  (`id`),
  KEY `ix_villages_autoinc` (`id`),
  KEY `fk_villages_users` (`userid`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=4 ;

--
-- Dumping data for table `villages`
--

INSERT INTO `villages` (`id`, `x`, `y`, `name`, `userid`, `wood`, `clay`, `iron`, `headquarter`, `barracks`, `stable`, `workshop`, `academy`, `smithy`, `rally`, `market`, `timbercamp`, `claypit`, `ironmine`, `storage`, `farm`, `hide`, `wall`, `points`, `unit_spear_tec_level`, `unit_sword_tec_level`, `unit_axe_tec_level`, `unit_spy_tec_level`, `unit_light_tec_level`, `unit_heavy_tec_level`, `unit_ram_tec_level`, `unit_catapult_tec_level`, `unit_snob_tec_level`, `spear`, `sword`, `axe`, `bowman`, `scout`, `light`, `heavy`, `mounted`, `ram`, `catapult`, `noble`, `last_update`, `loyal`, `in_spear`, `in_sword`, `in_axe`, `in_scout`, `in_light`, `in_heavy`, `in_ram`, `in_catapult`, `in_noble`) VALUES
(1, 50, 50, 'DreamingFighter1', NULL, 2404, 4864, 2184, 3, 1, 0, 0, 0, 0, 1, 0, 5, 5, 5, 5, 5, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 292, 94, 188, 0, 0, 0, 0, 0, 0, 0, 0, '2009-04-07 17:35:56', 100, 292, 94, 188, 0, 0, 0, 0, 0, 0),
(2, 50, 51, 'Thành phố phuc', 2, 110, 110, 110, 1, 0, 0, 0, 0, 0, 1, 0, 5, 5, 5, 5, 5, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '2009-04-04 10:30:56', 26, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 49, 50, 'Thành phố thangld', 1, 2042, 2042, 2042, 1, 0, 0, 0, 0, 0, 1, 0, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '2009-04-08 09:37:25', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
