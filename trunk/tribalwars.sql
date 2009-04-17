-- phpMyAdmin SQL Dump
-- version 2.11.9.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 17, 2009 at 04:08 PM
-- Server version: 5.0.67
-- PHP Version: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `tribalwars`
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
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=230 ;

--
-- Dumping data for table `build`
--

INSERT INTO `build` (`id`, `village_id`, `building`, `start_time`, `stop_time`) VALUES
(179, 23, 1, '2009-04-15 16:18:32', '2009-04-15 16:34:20');

-- --------------------------------------------------------

--
-- Table structure for table `configuration`
--

CREATE TABLE IF NOT EXISTS `configuration` (
  `id` int(11) NOT NULL auto_increment,
  `expand_count` int(11) default NULL,
  `expand` int(11) default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_configuration_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=2 ;

--
-- Dumping data for table `configuration`
--

INSERT INTO `configuration` (`id`, `expand_count`, `expand`) VALUES
(1, 4, 2);

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
  `from_village` int(11) default NULL,
  `to_village` int(11) default NULL,
  `type` int(11) default '2',
  `starting_time` bigint(20) unsigned default NULL,
  `landing_time` bigint(20) unsigned default NULL,
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
  KEY `fk_movement_villages` (`from_village`),
  KEY `fk_movement_villages1` (`to_village`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=411 ;

--
-- Dumping data for table `movement`
--

INSERT INTO `movement` (`id`, `from_village`, `to_village`, `type`, `starting_time`, `landing_time`, `building`, `scout`, `bowman`, `spear`, `sword`, `axe`, `mounted`, `light`, `heavy`, `ram`, `catapult`, `noble`, `iron`, `clay`, `wood`, `pending`) VALUES
(410, 24, 23, 2, 63375478689421, 63375483009421, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

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
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=17 ;

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
  `unread` tinyint(3) unsigned NOT NULL default '1',
  `text_id` int(20) NOT NULL,
  `title` varchar(250) collate utf8_bin NOT NULL,
  KEY `ix_reports_autoinc` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `reports`
--


-- --------------------------------------------------------

--
-- Table structure for table `shoutbox`
--

CREATE TABLE IF NOT EXISTS `shoutbox` (
  `id` int(11) NOT NULL auto_increment,
  `userid` int(11) NOT NULL,
  `text` varchar(255) character set utf8 collate utf8_unicode_ci NOT NULL,
  `time` datetime NOT NULL,
  `group_id` int(11) default NULL,
  PRIMARY KEY  (`id`),
  KEY `ix_shoutbox_autoinc` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=139 ;

--
-- Dumping data for table `shoutbox`
--

INSERT INTO `shoutbox` (`id`, `userid`, `text`, `time`, `group_id`) VALUES
(129, 1, 'Th?ng Vi?t kia a gít chú', '2009-04-08 16:01:27', NULL),
(130, 1, 'Th?ng Vi?t kia', '2009-04-08 16:03:05', NULL),
(131, 1, 'Th?ng kia', '2009-04-08 16:03:47', NULL),
(132, 1, 'th?ng', '2009-04-08 16:04:36', NULL),
(133, 1, 'th?ng', '2009-04-08 16:04:42', NULL),
(134, 1, 'th?ng', '2009-04-08 16:04:45', NULL),
(135, 1, 'thằng kia', '2009-04-08 16:12:23', NULL),
(136, 1, 't45trghgfd', '2009-04-08 17:06:53', NULL),
(137, 1, 'Bang này đẹp thế mà chưa ai vào', '2009-04-17 11:13:40', 1),
(138, 1, 'gghhgg', '2009-04-17 14:01:24', 1);

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


-- --------------------------------------------------------

--
-- Table structure for table `text`
--

CREATE TABLE IF NOT EXISTS `text` (
  `id` int(20) NOT NULL auto_increment,
  `text` text collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

--
-- Dumping data for table `text`
--


-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL auto_increment,
  `username` varchar(200) character set utf8 NOT NULL,
  `password` varchar(200) character set utf8 default NULL,
  `group_id` int(11) default NULL,
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
  `tribe_title` varchar(100) collate utf8_bin default NULL,
  `avatar` bit(1) NOT NULL default '\0',
  `point` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `ix_users_autoinc` (`id`),
  KEY `fk_users_groups` (`group_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=4 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `group_id`, `sex`, `birthdate`, `last_update`, `email`, `address`, `yahoo`, `msn`, `skype`, `description`, `graphics_village`, `building_level`, `tribe_permission`, `tribe_title`, `avatar`, `point`) VALUES
(1, 'thangld', '123', 1, 1, NULL, NULL, 'thangld@fpt.net', 'Hà Nội', 'Dreaming.Fighter', '', 'DF.thangld', 0x447265616d696e6746696768746572206cc3a02074610d0a, 0, 1, 246, NULL, '\0', 0),
(2, 'phuc', '123', NULL, 0, '1986-12-22 00:00:00', NULL, 'phuc@gmail.com', NULL, '', '', '', '', 0, 0, 0, NULL, '\0', 0),
(3, 'lastdra', '123', NULL, 0, '1986-05-23 00:00:00', NULL, 'lastdra@gmail.com', NULL, '', '', '', '', 0, 0, 0, NULL, '\0', 0);

-- --------------------------------------------------------

--
-- Table structure for table `villages_building`
--

CREATE TABLE IF NOT EXISTS `villages_building` (
  `id` int(11) NOT NULL,
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
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `villages_building`
--

INSERT INTO `villages_building` (`id`, `headquarter`, `barracks`, `stable`, `workshop`, `academy`, `smithy`, `rally`, `market`, `timbercamp`, `claypit`, `ironmine`, `storage`, `farm`, `hide`, `wall`) VALUES
(23, 1, 0, 0, 0, 0, 0, 1, 0, 5, 5, 5, 5, 5, 0, 0),
(24, 13, 9, 1, 0, 0, 0, 1, 0, 20, 20, 20, 11, 11, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `villages_common`
--

CREATE TABLE IF NOT EXISTS `villages_common` (
  `id` int(11) NOT NULL auto_increment,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  `name` varchar(100) collate utf8_bin default NULL,
  `userid` int(11) default NULL,
  `points` int(11) NOT NULL default '0',
  `last_update` bigint(20) unsigned default NULL,
  `loyal` int(11) default '100',
  PRIMARY KEY  (`id`),
  KEY `ix_villages_autoinc` (`id`),
  KEY `fk_villages_users` (`userid`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=25 ;

--
-- Dumping data for table `villages_common`
--

INSERT INTO `villages_common` (`id`, `x`, `y`, `name`, `userid`, `points`, `last_update`, `loyal`) VALUES
(23, 48, 48, 'Thành phố phuc', 2, 0, 63375409763906, 100),
(24, 48, 52, 'Lưu Đức Thắng', 1, 0, 63375577623984, 100);

-- --------------------------------------------------------

--
-- Table structure for table `villages_research`
--

CREATE TABLE IF NOT EXISTS `villages_research` (
  `id` int(11) NOT NULL,
  `unit_spear_tec_level` int(11) default '1',
  `unit_sword_tec_level` int(11) default '0',
  `unit_axe_tec_level` int(11) default '0',
  `unit_spy_tec_level` int(11) default '1',
  `unit_light_tec_level` int(11) default '0',
  `unit_heavy_tec_level` int(11) default '0',
  `unit_ram_tec_level` int(11) default '0',
  `unit_catapult_tec_level` int(11) default '0',
  `unit_snob_tec_level` int(11) default '1',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `villages_research`
--

INSERT INTO `villages_research` (`id`, `unit_spear_tec_level`, `unit_sword_tec_level`, `unit_axe_tec_level`, `unit_spy_tec_level`, `unit_light_tec_level`, `unit_heavy_tec_level`, `unit_ram_tec_level`, `unit_catapult_tec_level`, `unit_snob_tec_level`) VALUES
(23, 0, 0, 0, 0, 0, 0, 0, 0, 1),
(24, 0, 0, 0, 0, 0, 0, 0, 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `villages_resources`
--

CREATE TABLE IF NOT EXISTS `villages_resources` (
  `id` int(11) NOT NULL,
  `wood` int(11) default '500',
  `clay` int(11) default '500',
  `iron` int(11) default '500',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `villages_resources`
--

INSERT INTO `villages_resources` (`id`, `wood`, `clay`, `iron`) VALUES
(23, 2153, 2123, 2193),
(24, 12363, 12181, 13777);

-- --------------------------------------------------------

--
-- Table structure for table `villages_troop`
--

CREATE TABLE IF NOT EXISTS `villages_troop` (
  `id` int(11) NOT NULL,
  `spear` int(11) NOT NULL default '0',
  `sword` int(11) NOT NULL default '0',
  `axe` int(11) NOT NULL default '0',
  `scout` int(11) NOT NULL default '0',
  `light` int(11) NOT NULL default '0',
  `heavy` int(11) NOT NULL default '0',
  `ram` int(11) NOT NULL default '0',
  `catapult` int(11) NOT NULL default '0',
  `noble` int(11) NOT NULL default '0',
  `in_spear` int(11) default '0',
  `in_sword` int(11) default '0',
  `in_axe` int(11) default NULL,
  `in_scout` int(11) default '0',
  `in_light` int(11) default '0',
  `in_heavy` int(11) default '0',
  `in_ram` int(11) default '0',
  `in_catapult` int(11) default '0',
  `in_noble` int(11) default '0',
  `total_spear` int(11) default '0',
  `total_sword` int(11) default '0',
  `total_axe` int(11) default NULL,
  `total_scout` int(11) default '0',
  `total_light` int(11) default '0',
  `total_heavy` int(11) default '0',
  `total_ram` int(11) default '0',
  `total_catapult` int(11) default '0',
  `total_noble` int(11) default '0',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `villages_troop`
--

INSERT INTO `villages_troop` (`id`, `spear`, `sword`, `axe`, `scout`, `light`, `heavy`, `ram`, `catapult`, `noble`, `in_spear`, `in_sword`, `in_axe`, `in_scout`, `in_light`, `in_heavy`, `in_ram`, `in_catapult`, `in_noble`, `total_spear`, `total_sword`, `total_axe`, `total_scout`, `total_light`, `total_heavy`, `total_ram`, `total_catapult`, `total_noble`) VALUES
(23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(24, 0, 11, 25, 0, 0, 0, 0, 0, 0, 0, 11, 26, 0, 0, 0, 0, 0, 0, 0, 11, 26, 0, 0, 0, 0, 0, 0);
