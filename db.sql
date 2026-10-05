/*
 Navicat Premium Data Transfer

 Source Server         : LOCALHOST
 Source Server Type    : PostgreSQL
 Source Server Version : 170004 (170004)
 Source Host           : localhost:5432
 Source Catalog        : postgres
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 170004 (170004)
 File Encoding         : 65001

 Date: 28/04/2025 15:31:31
*/


-- ----------------------------
-- Sequence structure for account_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."account_id_seq";
CREATE SEQUENCE "public"."account_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for accounts_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."accounts_id_seq";
CREATE SEQUENCE "public"."accounts_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for auto_ban_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."auto_ban_seq";
CREATE SEQUENCE "public"."auto_ban_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ban_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ban_seq";
CREATE SEQUENCE "public"."ban_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for channels_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."channels_id_seq";
CREATE SEQUENCE "public"."channels_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for check_event_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."check_event_seq";
CREATE SEQUENCE "public"."check_event_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for clan_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."clan_seq";
CREATE SEQUENCE "public"."clan_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for clans_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."clans_id_seq";
CREATE SEQUENCE "public"."clans_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for contas_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."contas_seq";
CREATE SEQUENCE "public"."contas_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for gameservers_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."gameservers_id_seq";
CREATE SEQUENCE "public"."gameservers_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for gift_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."gift_id_seq";
CREATE SEQUENCE "public"."gift_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ipsystem_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ipsystem_id_seq";
CREATE SEQUENCE "public"."ipsystem_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for items_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."items_id_seq";
CREATE SEQUENCE "public"."items_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for jogador_amigo_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."jogador_amigo_seq";
CREATE SEQUENCE "public"."jogador_amigo_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for jogador_inventario_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."jogador_inventario_seq";
CREATE SEQUENCE "public"."jogador_inventario_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for jogador_mensagem_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."jogador_mensagem_seq";
CREATE SEQUENCE "public"."jogador_mensagem_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for loja_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."loja_seq";
CREATE SEQUENCE "public"."loja_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for message_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."message_id_seq";
CREATE SEQUENCE "public"."message_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for player_characters_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."player_characters_id_seq";
CREATE SEQUENCE "public"."player_characters_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for player_eqipment_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."player_eqipment_id_seq";
CREATE SEQUENCE "public"."player_eqipment_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for player_friends_player_account_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."player_friends_player_account_id_seq";
CREATE SEQUENCE "public"."player_friends_player_account_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for player_topups_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."player_topups_seq";
CREATE SEQUENCE "public"."player_topups_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for players_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."players_id_seq";
CREATE SEQUENCE "public"."players_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for storage_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."storage_seq";
CREATE SEQUENCE "public"."storage_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for templates_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."templates_id_seq";
CREATE SEQUENCE "public"."templates_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Table structure for ban_history
-- ----------------------------
DROP TABLE IF EXISTS "public"."ban_history";
CREATE TABLE "public"."ban_history" (
  "object_id" int8 NOT NULL DEFAULT nextval('ban_seq'::regclass),
  "provider_id" int8 NOT NULL DEFAULT 0,
  "type" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "value" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "reason" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "start_date" timestamp(6) NOT NULL DEFAULT '2000-01-01 00:00:00'::timestamp without time zone,
  "end_date" timestamp(6) NOT NULL DEFAULT '2000-01-01 00:00:00'::timestamp without time zone
)
;

-- ----------------------------
-- Records of ban_history
-- ----------------------------

-- ----------------------------
-- Table structure for ban_hwid
-- ----------------------------
DROP TABLE IF EXISTS "public"."ban_hwid";
CREATE TABLE "public"."ban_hwid" (
  "hwid" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of ban_hwid
-- ----------------------------

-- ----------------------------
-- Table structure for channels
-- ----------------------------
DROP TABLE IF EXISTS "public"."channels";
CREATE TABLE "public"."channels" (
  "server_id" int4 NOT NULL DEFAULT 0,
  "channel_id" int4 NOT NULL DEFAULT 0,
  "type" int4 NOT NULL DEFAULT 0,
  "announce" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "online" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of channels
-- ----------------------------
INSERT INTO "public"."channels" VALUES (1, 0, 3, 'Novice', 0);
INSERT INTO "public"."channels" VALUES (1, 1, 1, 'General', 0);
INSERT INTO "public"."channels" VALUES (1, 2, 1, 'General', 0);
INSERT INTO "public"."channels" VALUES (1, 3, 1, 'General', 0);
INSERT INTO "public"."channels" VALUES (1, 4, 1, 'General', 0);
INSERT INTO "public"."channels" VALUES (1, 5, 1, 'General', 0);
INSERT INTO "public"."channels" VALUES (1, 6, 1, 'General', 1);
INSERT INTO "public"."channels" VALUES (1, 7, 4, 'Clan', 0);
INSERT INTO "public"."channels" VALUES (1, 8, 4, 'Clan', 0);
INSERT INTO "public"."channels" VALUES (1, 9, 4, 'Clan', 0);
INSERT INTO "public"."channels" VALUES (1, 10, 4, 'clan', 0);

-- ----------------------------
-- Table structure for clan_invites
-- ----------------------------
DROP TABLE IF EXISTS "public"."clan_invites";
CREATE TABLE "public"."clan_invites" (
  "clan_id" int4 NOT NULL DEFAULT 0,
  "player_id" int8 NOT NULL DEFAULT 0,
  "dateinvite" int4 NOT NULL DEFAULT 0,
  "text" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying
)
;

-- ----------------------------
-- Records of clan_invites
-- ----------------------------
INSERT INTO "public"."clan_invites" VALUES (24, 7, 20140727, 'Hi');

-- ----------------------------
-- Table structure for clans
-- ----------------------------
DROP TABLE IF EXISTS "public"."clans";
CREATE TABLE "public"."clans" (
  "clan_id" int4 NOT NULL DEFAULT nextval('clan_seq'::regclass),
  "clan_rank" int4 NOT NULL DEFAULT 0,
  "clan_name" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "owner_id" int8 NOT NULL DEFAULT 0,
  "logo" int8 NOT NULL DEFAULT 0,
  "color" int4 NOT NULL DEFAULT 0,
  "clan_info" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "clan_news" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "create_date" int4 NOT NULL DEFAULT 0,
  "autoridade" int4 NOT NULL DEFAULT 0,
  "limite_rank" int4 NOT NULL DEFAULT 0,
  "limite_idade" int4 NOT NULL DEFAULT 0,
  "limite_idade2" int4 NOT NULL DEFAULT 0,
  "partidas" int4 NOT NULL DEFAULT 0,
  "vitorias" int4 NOT NULL DEFAULT 0,
  "derrotas" int4 NOT NULL DEFAULT 0,
  "pontos" float4 NOT NULL DEFAULT 1000,
  "max_players" int4 NOT NULL DEFAULT 50,
  "clan_exp" int4 NOT NULL DEFAULT 0,
  "best_exp" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "best_participation" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "best_wins" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "best_kills" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "best_headshot" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "effect" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of clans
-- ----------------------------
INSERT INTO "public"."clans" VALUES (24, 0, 'E*N*I*G*M*A', 6, 0, 0, '', '', 20140429, 0, 0, 0, 0, 0, 0, 0, 1000, 50, 0, '0-0', '0-0', '0-0', '0-0', '0-0', 0);
INSERT INTO "public"."clans" VALUES (232, 0, 'Nova', 7, 441123594, 0, '', '', 20240605, 0, 0, 0, 0, 0, 0, 0, 1000, 50, 0, '0-0', '0-0', '0-0', '0-0', '0-0', 0);
INSERT INTO "public"."clans" VALUES (231, 0, 'Limb', 8, 0, 0, '', '', 20240414, 0, 0, 0, 0, 0, 0, 0, 1000, 50, 0, '0-0', '0-0', '0-0', '0-0', '0-0', 0);
INSERT INTO "public"."clans" VALUES (230, 0, 'dasdsadsa', 9, 0, 0, '', '', 20240216, 0, 0, 0, 0, 0, 0, 0, 1000, 50, 0, '0-0', '0-0', '0-0', '0-0', '0-0', 0);

-- ----------------------------
-- Table structure for gameservers
-- ----------------------------
DROP TABLE IF EXISTS "public"."gameservers";
CREATE TABLE "public"."gameservers" (
  "id" int4 NOT NULL,
  "state" int4 NOT NULL,
  "type" int4 NOT NULL,
  "ip" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "port" int4 NOT NULL,
  "sync_port" int4 NOT NULL,
  "max_players" int4 NOT NULL
)
;

-- ----------------------------
-- Records of gameservers
-- ----------------------------
INSERT INTO "public"."gameservers" VALUES (0, 1, 1, '127.0.0.1', 39190, 1908, 700);
INSERT INTO "public"."gameservers" VALUES (1, 1, 1, '127.0.0.1', 39191, 1909, 700);

-- ----------------------------
-- Table structure for item_goods
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_goods";
CREATE TABLE "public"."item_goods" (
  "item_id" int4 NOT NULL,
  "item_name" varchar(255) COLLATE "pg_catalog"."default",
  "item_consume" int4,
  "counts" varchar(255) COLLATE "pg_catalog"."default",
  "moneys" varchar(255) COLLATE "pg_catalog"."default",
  "points" varchar(255) COLLATE "pg_catalog"."default",
  "item_title" int4 DEFAULT 0,
  "item_icon" int4 DEFAULT 0,
  "item_visible" bool DEFAULT true,
  "price_discount" int4 DEFAULT 0
)
;

-- ----------------------------
-- Records of item_goods
-- ----------------------------
INSERT INTO "public"."item_goods" VALUES (103451, 'AUG A3 M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103355, 'AUG-A3 Lebaran2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103354, 'AUG-A3 Mech ID', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103435, 'G11 Acrylic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103444, 'AUG A3 LatinChampionship', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103537, 'AUG A3 Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103565, 'AUG A3 PostApocalypse Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103427, 'AUG A3 Puppy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103566, 'AUG A3 Ramadan19-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103560, 'AUG A3 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103507, 'AUG A3 Splash', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103508, 'MSBS Splash', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103352, 'AUG A3 CNPB-T5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103512, 'AUG A3 BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103513, 'AUG-HBAR BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103516, 'STG44 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103519, 'FAMAS G2 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103521, 'SC 2010 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103522, 'MSBS Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103523, 'Pindad SS2 V5 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103524, 'AUG A3 Xmas2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103525, 'Pindad SS2 V5 Xmas2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103527, 'AUG A3 GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103529, 'SC 2010 BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103531, 'AUG-HBAR BOG-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103532, 'AUG A3 NewYear2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103534, 'AUG A3 Vaquinha', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103535, 'FAMAS G2 Commando Vaquinha', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103536, 'SC 2010 Vaquinha', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103538, 'SC 2010 Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103539, 'AUG-A3 Snack', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103543, 'AUG A3 EvosGalaxy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103544, 'SC 2010 EvosGalaxy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103546, 'AUG A3 Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103547, 'AUG A3 Lycan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103548, 'AUG A3 PBLC19', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103553, 'AUG A3 PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103554, 'AUG-HBAR PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103556, 'AUG A3 PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103557, 'AUG-HBAR PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103558, 'SC 2010 PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103562, 'SC 2010 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103563, 'STG44 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103564, 'AUG A3 PostApocalypse Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103570, 'AUG-HBAR Ramadan19-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103571, 'AUG A3 GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103572, 'SC 2010 GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103573, 'AUG A3 Summer2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103577, 'AUG A3 Independence817', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103578, 'SC 2010 Independence817', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103579, 'AUG A3 Spider', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103419, 'SC 2010 Red', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103356, 'SC 2010 Lebaran2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103368, 'AUG A3 Phantom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103405, 'AUG A3 Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103438, 'SC 2010 GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103448, 'SC 2010 Holi', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103450, 'AK-47 Digital', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103437, 'AUG-A3 GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103436, 'AUG A3 Acrylic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103540, 'SC 2010 Snack', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103346, 'AK-47 Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103025, 'AK-47 Point15', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103246, 'AK 12', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103476, 'AUG A3 Football Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103360, 'Pindad SS2 V5 ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103304, 'Pindad SS2 V5 Mystic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103261, 'AUG-A3 Midnight2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103344, 'AUG-A3 Naga', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103470, 'AUG A3 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103359, 'AUG A3 ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103478, 'AUG A3 LatinChampionship2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103278, 'AUG A3 Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103267, 'AUG A3 Mummy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103357, 'AUG A3 Nagi-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104352, 'MX4', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103511, 'AUG A3 DemonHunter', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103541, 'AUG-A3 SignaturePB', 2, '86400,259200', '1000,2500', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103576, 'AUG A3 Crimson', 2, '259200', '2700', '2700', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103358, 'AUG A3 Nagi-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103487, 'AUG A3 Oni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103374, 'AUG A3 Ottoman', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103463, 'AUG A3 Paladin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103462, 'AUG A3 Ramazan2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103505, 'AUG A3 RustIron', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103452, 'SC 2010 M1LGR4U', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103453, 'AUG A3 Maze', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103501, 'M4A1 Freedom RB', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103454, 'AUG A3 PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103456, 'AUG A3 Vittoria', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103457, 'AUG A3 GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103458, 'AUG A3 MNB4', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103459, 'AUG A3 WhiteRabbit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103460, 'SC 2010 WhiteRabbit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103464, 'SC 2010 Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103469, 'SC 2010 3rdAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103472, 'SC 2010 Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103473, 'MSBS Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103475, 'SC 2010 Brazuca3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103477, 'AUG A3 Football Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103481, 'AUG A3 GhostHouse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103482, 'SC 2010 Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103484, 'AUG A3 PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103488, 'SC 2010 Oni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103489, 'AUG A3 Viper', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103490, 'SC 2010 Viper', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103491, 'AUG-A3 Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103492, 'MSBS Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103502, 'AUG A3 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103503, 'AUG-HBAR PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103504, 'SC 2010 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103342, 'AK-47 Chicano', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103495, 'MSBS PBST2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103260, 'AUG A3 Tiger-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103262, 'AUG A3 Skeleton', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103263, 'AUG A3 E-Sports2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103264, 'FAMAS G2 M203 E-Sports2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103265, 'AUG A3 Dragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103277, 'AUG A3 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103353, 'SC 2010 CNPB-T5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103361, 'AUG A3 Graffiti', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103364, 'AUG A3 Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103369, 'AUG A3 PBTC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103370, 'AUG A3 PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103372, 'SC 2010 PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103373, 'TAR-21 Newborn2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103362, 'AUG A3 Brazuca2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103474, 'AUG A3 Brazuca3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103465, 'MSBS Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103173, 'AUG A3 Cangaceiro', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103317, 'AUG A3 Chicken', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103327, 'AUG A3 Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103379, 'AUG A3 Darkness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103403, 'M4A1 Freedom', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103269, 'Pindad SS2 V5 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103184, 'AUG-A3 NEWBORN 2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103188, 'AUG-A3 Ongame', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103279, 'AUG A3 Alien', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103315, 'AUG A3 Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103271, 'AUG A3 ID 1stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103290, 'AUG A3 Liberty', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103311, 'AUG A3 Pahlawan', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103283, 'AUG A3 Puzzle', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103392, 'AUG A3 Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103397, 'AUG A3 Shatter UM', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103396, 'AUG A3 Shatter Z1', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103377, 'SC 2010 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103381, 'SC 2010 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103383, 'SC 2010 Aguila', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103378, 'AUG A3 Brightness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103384, 'AUG A3 PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103385, 'SC 2010 PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103387, 'AUG A3 PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103388, 'Pindad SS2 V5 PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103348, 'SC 2010 Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (103366, 'SC 2010 Bolt', 2, '86400,259200', '1000,2700', '0,0', 0, 5, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103302, 'AUG A3 Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103337, 'AUG A3 Renegade', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103479, 'AUG A3 Renegade2', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103389, 'K2C PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103391, 'Famas G2 Commando TSE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103393, 'SC 2010 Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103394, 'AUG A3 Halloween2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103395, 'SC 2010 Halloween2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103398, 'AUG A3 PBIWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103401, 'AUG A3 DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103258, 'AUG A3 GSL2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103257, 'AUG-A3 PBGC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103390, 'AUG A3 TSE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103399, 'AUG A3 FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103165, 'AUG A3 Toy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103167, 'AN-94 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103168, 'HK417 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103177, 'XM8 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103181, 'AUG-A3 Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103182, 'TAR-21 Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103186, 'AUG A3 GSL2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103189, 'AUG-A3 Redemption', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103190, 'AUG-A3 Summer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103191, 'SC 2010 Rose', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103255, 'AUG A3 GRS3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103266, 'AUG A3 PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103274, 'AUG A3 Demonic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103280, 'AUG A3 Woody', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103281, 'XM8 Woody', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103285, 'Groza Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103287, 'SC 2010 Dracula', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103291, 'AUG A3 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103292, 'SC 2010 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103293, 'K2C PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103294, 'AUG-A3 PBTC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103309, 'SIG-Sauer MCX Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103312, 'AUG A3 Latin6', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103313, 'Christmas2016 CaneGun', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103323, 'AUG-A3 Pirates', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103325, 'AUG A3 MechHero', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103326, 'FAMAS G2 Commando Fire', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103318, 'AUG-A3 Hybridman', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103380, 'AUG A3 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103382, 'AUG A3 Aguila', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104815, 'OA93 PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103335, 'AUG-A3 GSL2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103197, 'AUG A3 4Game', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103160, 'AUG A3 BR 4th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103250, 'AUG A3 Cupid', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103114, 'M4A1 Elite', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103333, 'M4A1 FC Talos', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103127, 'M4A1 SE P', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103316, 'Pindad SS2 V5 Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103207, 'AUG-A3 Lebaran2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103245, 'AUG A3 Arena-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103194, 'AUG A3 Independence', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103193, 'AUG A3 LionFlame', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103144, 'AUG A3 R', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103192, 'AUG A3 Rose', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103334, 'AUG A3 Salvation', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103253, 'AUG A3 Serpent', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103328, 'AUG A3 PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103330, 'Pindad SS2 V5 PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103157, 'AUG-A3 Champion', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103331, 'AUG A3 NevO', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103163, 'AUG-A3 PC Cafe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103164, 'AUG A3 G ESports', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103329, 'AUG A3 PBGC2017 Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103097, 'AUG A3 GRS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103101, 'AK-SOPMOD PBNC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103104, 'AUG A3 GSL', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103108, 'AUG A3 GRS EV', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103109, 'AUG A3 TW1st', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103110, 'AUG A3 TW1st P', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103120, 'AUG-A3 PBIC2013', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103129, 'AUG-A3 BLOODY', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103130, 'AUG-A3 Gold BLOODY', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103131, 'AUG-A3 LATIN3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103142, 'AUG A3 TH 1YEAR', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103145, 'FG42 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103150, 'TAR-21 Midnight', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103152, 'AK-SOPMOD BR Camo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103187, 'AUG-A3 PBNC6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103172, 'Snow-ball Blaster', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103200, 'AUG A3 Emblem-Bolivia', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103201, 'AUG A3 Emblem-Ecuador', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103203, 'AUG A3 Emblem-Venezuela', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103204, 'AUG A3 Emblem-Argentian', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103205, 'AUG A3 Emblem-Chile', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103206, 'AUG A3 Emblem-Peru', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103214, 'AUG-A3 PBNC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103215, 'AUG-A3 PBTC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103217, 'AUG-A3 DarkDays', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103218, 'SCAR-L FC PBNC2015 US', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103219, 'AUG-A3 PBIC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103221, 'AK-47 SOPMOD Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103222, 'AUG-A3 VeraCruz', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103224, 'AUG-A3 Basketball', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103226, 'SC 2010 Medical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103232, 'AUG A3 Halloween', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103235, 'AUG A3 Obsidian', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103242, 'SC 2010 Xmas2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103243, 'AUG A3 Monkey', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103247, 'AK 12 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103092, 'AK-SOPMOD R', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103093, 'AUG-A3 Blaze', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103240, 'AUG A3 DFN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103159, 'AUG A3 PBIC2014', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104821, 'KrissSuperV Independence817', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104634, 'APC9 Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103195, 'AUG-A3 Brazil', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103155, 'AUG-A3 Brazuca', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103209, 'Vz52 Black Pearl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103428, 'AUG A3 Nevasca', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103559, 'AUG A3 Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104670, 'P90 Ext Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104500, 'P90 Ext Halloween2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104823, 'P90 Ext Independence817', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104485, 'P90 Ext Military', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104488, 'P90 Ext PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104675, 'P90 Ext PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104701, 'P90 Ext RustIron', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104522, 'OA93 FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104664, 'OA93 GhostHouse', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104802, 'OA93 GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104762, 'OA93 Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104524, 'OA93 Latin7', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104766, 'OA93 Lycan', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104493, 'OA93 Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104772, 'OA93 Shark', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104507, 'OA93 Shatter UM', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104645, 'OA93 Surfing', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104686, 'OA93 Viper', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104635, 'KrissSuperV 3rdAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104637, 'OA93 3rdAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104789, 'P90 Ext 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104641, 'OA93 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104643, 'KrissSuperV Surfing', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104651, 'APC9 Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104662, 'KrissSuperV GhostHouse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104666, 'KrissSuperV Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104668, 'OA93 Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104671, 'KrissSuperV PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104673, 'OA93 PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104680, 'KrissSuperV Oni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104682, 'OA93 Oni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104689, 'KrissSuperV Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104690, 'APC9 Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104691, 'MX4 Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104760, 'KrissSuperV Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104764, 'KrissSuperV Lycan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104768, 'OA93 PBLC19', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104774, 'KrissSuperV PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104776, 'OA93 PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104778, 'KrissSuperV PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104780, 'OA93 PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104787, 'OA93 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104800, 'KrissSuperV GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104804, 'P90 Ext GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104799, 'APC9 Ramadan19-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103252, 'AK-SOPMOD Sakura', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104661, 'P90 Ext Renegade2', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104790, 'Thompson 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104657, 'OA93 Renegade2', 2, '259200,2592000', '3000,8000', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (116003, 'RPG', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104807, 'OA93 Summer2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104817, 'KrissSuperV Crimson', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104819, 'OA93 Crimson', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104824, 'KrissSuperV Spider', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104826, 'OA93 Spider', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103158, 'AUG A3 WOE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104805, 'KrissSuperV Summer2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104498, 'OA93 Halloween2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104501, 'KrissSuperV Silence Shatter Z1', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104511, 'OA93 PBIWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104515, 'T77 Silver', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104521, 'P90 Ext FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104527, 'KrissSuperV DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104532, 'KrissSuperV Freedom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104491, 'KrissSuperV TSE', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104517, 'T77 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104495, 'KrissSuperV Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104770, 'KrissSuperV Shark', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103574, 'AUG A3 9th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104418, 'P90 Ext Lebaran2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104407, 'P90 Ext MNB3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104395, 'P90 Ext Naga', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104375, 'P90 Ext PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104482, 'P90 Ext PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104445, 'P90 Ext Phantom', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104559, 'KrissSuperV RRQ', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104755, 'OA93 EvosGalaxy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104428, 'OA93 Graffiti', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104383, 'OA93 GSL2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104431, 'OA93 Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104566, 'OA93 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104379, 'OA93 Salvation', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104747, 'OA93 Snack', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104443, 'OA93 Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104534, 'OA93 Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104726, 'OA93 Xmas2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104561, 'P90 Ext RRQ', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104562, 'OA93 RRQ', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104568, 'KrissSuperV HeartValentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104545, 'MP9 Ext Red', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104556, 'OA93 Puppy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104370, 'P90 Ext Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104558, 'P90 Ext Nevasca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104630, 'KrissSuperV Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104695, 'KrissSuperV PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104697, 'OA93 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104702, 'APC9 Splash', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104715, 'OA93 BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104721, 'P90 Ext Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104722, 'P90 Ext Zepetto Silence', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104728, 'KrissSuperV GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104730, 'OA93 GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104733, 'MX4 BOG-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104734, 'OA93 NewYear2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104736, 'KrissSuperV NewYear2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104741, 'P90 Ext Vaquinha', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104745, 'KrissSuperV Snack', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104753, 'KrissSuperV EvosGalaxy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104483, 'KrissSuperV Military', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104732, 'MX4 BOG-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104371, 'KrissSuperV PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104373, 'OA93 PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104376, 'P90 MC Talos', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104381, 'KrissSuperV GSL2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104389, 'KrissSuperV Chicano', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104391, 'KrissSuperV Beach', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104396, 'KrissSuperV Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104408, 'KrissSuperV PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104410, 'OA93 PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104421, 'OA93 ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104423, 'KrissSuperV ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104425, 'P90 Ext Silence ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104426, 'KrissSuperV Graffiti', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104435, 'APC9 Silver', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104436, 'APC9 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104402, 'P90 Ext Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (104751, 'KrissSuperV SignaturePB', 2, '86400,259200', '1000,2500', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104707, 'OA93 Halloween2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104749, 'OA93 SignaturePB Silence', 2, '86400,259200', '1000,2500', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104711, 'OA93 DemonHunter', 3, '100', '25000', '25000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104529, 'OA93 DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104724, 'KrissSuperV Xmas2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104441, 'KrissSuperV Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104703, 'OA93 Splash', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104478, 'MX4 PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104327, 'P90 Ext Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104288, 'P90 Ext Demonic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104531, 'P90 Ext DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104294, 'P90 Ext Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104460, 'P90 Ext Ottoman', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104262, 'P90 Ext PBGC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104454, 'P90 Ext PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104306, 'P90 Ext Puzzle', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104364, 'OA93 Fire', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104332, 'OA93 Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104461, 'OA93 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104588, 'OA93 LatinChampionship', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104309, 'OA93 Liberty', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104605, 'OA93 Maze', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104300, 'OA93 Woody', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104458, 'KrissSuperV Ottoman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104552, 'KrissSuperV Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104554, 'OA93 Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104412, 'P90 Ext CNPB-T5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104576, 'KrissSuperV Red', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104578, 'KrissSuperV Nusantara', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104580, 'OA93 Nusantara', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104583, 'KrissSuperV Graduation', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104596, 'OA93 Holi', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104598, 'KrissSuperV Digital', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104607, 'OA93 PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104615, 'KrissSuperV GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104617, 'OA93 GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104619, 'KrissSuperV MNB4', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104621, 'OA93 MNB4', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104623, 'P90 Ext WhiteRabbit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104626, 'KrissSuperV Paladin', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104603, 'KrissSuperV Maze', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104624, 'KrissSuperV Ramazan2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104245, 'KrissSuperV DFN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104239, 'P90 Ext Halloween', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104247, 'OA93 DFN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104253, 'KrissSuperV Monkey', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104256, 'KrissSuperV GRS3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104258, 'KrissSuperV Beast', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104260, 'KrissSuperV PBGC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104263, 'KrissSuperV GSL2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104265, 'KrissSuperV Midnight2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104269, 'P90 Ext Skeleton', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104270, 'KrissSuperV E-Sports2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104272, 'P90 Ext Dragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104273, 'OA93 PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104275, 'KrissSuperV PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104277, 'P90 MC PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104280, 'KrissSuperV ID 1stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104285, 'P90 Ext Silence Strike', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104286, 'KrissSuperV Demonic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104298, 'KrissSuperV Alien', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104304, 'KrissSuperV Puzzle', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104318, 'KrissSuperV DarkSteel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104328, 'OA93 Halloween2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104336, 'OA93 Pahlawan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104405, 'OA93 MNB3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104448, 'OA93 Phantom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104455, 'OA93 PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104457, 'P90 Ext Silence Newborn2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104297, 'P90 Ext Alien', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104361, 'P90 Ext Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104368, 'OA93 Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104295, 'KrissSuperV Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104467, 'P90 Ext Brightness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104470, 'P90 Ext Darkness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104128, 'P90 Ext Inferno', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104463, 'P90 Ext Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104341, 'P90 Ext Latin6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104351, 'P90 Ext Lightning', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104338, 'P90 Ext Pahlawan', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104146, 'P90 Ext PBIC2014', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104289, 'KrissSuperV Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104291, 'P90 Ext Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104218, 'P90 Ext PBIC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104129, 'P90 Ext PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104118, 'P90 Ext Serpent', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104180, 'OA93 GSL2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104165, 'OA93 Xmas', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104194, 'EVO3 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104465, 'KrissSuperV Brightness', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104468, 'KrissSuperV Darkness', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104138, 'P90 Ext Brazuca', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104471, 'KrissSuperV 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104474, 'OA93 Aguila', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104242, 'KrissSuperV Obsidian', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104464, 'MX4 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104108, 'KrissSuperV SILENCE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104116, 'KrissSuperV Serpent', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104123, 'KrissSuperV R', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104132, 'KrissSuperV Midnight', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104139, 'KrissSuperV Brazuca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104142, 'KrissSuperV Champion', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104151, 'KrissSuperV PC Cafe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104161, 'MP9 Ext Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104164, 'MP9 Ext Xmas', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104167, 'PP19 Xmas', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104170, 'KrissSuperV CoupleBreaker', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104172, 'KrissSuperV CNY-2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104175, 'KrissSuperV GRS2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104177, 'P90 NEWBORN 2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104178, 'KrissSuperV NEWBORN 2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104182, 'P90 Ext Silence GSL2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104185, 'KrissSuperV Ongame', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104187, 'P90 Ext Ongame', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104191, 'KrissSuperV Summer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104195, 'P90 MC Rose', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104198, 'OA93 Independence', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104200, 'P90 MC Brazil', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104209, 'KrissSuperV Mech', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104212, 'KrissSuperV DarkDays', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104221, 'KrissSuperV Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104237, 'KrissSuperV Halloween', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104314, 'OA93 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104316, 'KrissSuperV PBTC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104321, 'KrissSuperV PBNC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104334, 'KrissSuperV Mystic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104342, 'KrissSuperV Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104345, 'KrissSuperV Chicken', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104349, 'OA93 Hybridman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104355, 'KrissSuperV Pirates', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104357, 'KrissSuperV Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104089, 'P90 GSL', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104103, 'KrissSuperV PBIC2013', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104339, 'KrissSuperV Latin6', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104359, 'OA93 Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104214, 'OA93 PBNC2015 US', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104216, 'KrissSuperV PBIC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104223, 'KrissSuperV Basketball', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104225, 'OA93 Basketball', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104228, 'OA93 Medical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104227, 'P90 BasketBall', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104114, 'P90 BR CAMO', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104188, 'KrissSuperV Redemption', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105353, 'Cheytac M200 BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105326, 'Cheytac M200 Brazuca3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105243, 'Cheytac M200 Brightness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105398, 'Cheytac M200 Crimson', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105244, 'Cheytac M200 Darkness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105387, 'Tactilite T2 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105321, 'Tactilite T2 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105333, 'Tactilite T2 Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105363, 'Tactilite T2 BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105263, 'Tactilite T2 DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105373, 'Tactilite T2 EvosGalaxy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105332, 'Tactilite T2 GhostHouse', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105393, 'Tactilite T2 GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105241, 'Tactilite T2 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105378, 'Tactilite T2 Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2800001, 'Dragon battleBox', 1, '1', '50000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000009, ' Dummy Modeling', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000010, ' Motorcycle Handle', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000011, ' Motorcycle Exhaust', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000012, ' Motorcycle Model', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000013, ' Ninja Dart', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000014, ' Ninja SD badge', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000015, ' Ninja SD Character', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000016, ' Forge Keychain', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000017, ' Ghost Doll', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000018, ' Sports car model', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000019, ' Sports car tire', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000020, ' Sports car emblem', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000021, ' Royal Key Chain', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000022, ' Rusty AI Robot', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000023, ' Welding Robot', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000024, ' 3D Hologram', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000039, ' Signature.PB Logo', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000077, ' Tiger Fang Key Chain', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000085, ' Berserker Yellow Shield', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000091, ' Pink Whale Keychain ', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000108, ' OP3K Keychain', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (3000112, ' Katana Akai Keychain', 1, '50,100', '0,0', '40000,79900', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105330, 'Tactilite T2 LatinChampionship2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105343, 'AS 50 Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105354, 'AS 50 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104232, 'OA93 Cobra', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105323, 'Cheytac M200 Surfing', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105324, 'Tactilite T2 Surfing', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105248, 'Cheytac M200 Aguila', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105334, 'Cheytac M200 PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105335, 'Tactilite T2 PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105340, 'Tactilite T2 Oni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105341, 'Tactilite T2 Viper', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105344, 'Tactilite T2 PBST2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105350, 'Tactilite T2 Splash', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105356, 'Cheytac M200 Zepetto Silence', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105358, 'PGM-Hecate2 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105359, 'Cheytac M200 Xmas2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105361, 'Cheytac M200 GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105366, 'Cheytac M200 NewYear2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105367, 'L115A1 Vaquinha', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105368, 'Cheytac M200 Vaquinha', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105370, 'Cheytac M200 Snack', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105379, 'Cheytac M200 Lycan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105381, 'Tactilite T2 Shark', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105391, 'Tactilite T2 Ramadan19-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105395, 'Tactilite T2 Summer2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104081, 'MP7 GRS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104183, 'KrissSuperV PBNC6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105392, 'Cheytac M200 GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105235, 'AS 50 Phantom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105236, 'AS 50 PBTC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105239, 'Cheytac M200 Newborn2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105242, 'AS 50 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105247, 'PGM Hecate2 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105249, 'Tactilite T2 PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105250, 'Tactilite T2 Military', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105251, 'Cheytac M200 PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105252, 'AS 50 PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105254, 'SSG69 TSE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105255, 'L115A1 Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105258, 'Cheytac M200 Shatter UM', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105259, 'Cheytac M200 PBIWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105260, 'Tactilite T2 PBIWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104230, 'P90 Ext Medical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105338, 'Kar98k Gold', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105246, 'Cheytac M200 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105399, 'Tactilite T2 Independence817', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105371, 'Tactilite T2 Snack', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105170, 'Cheytac M200 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105195, 'Cheytac M200 Chicken', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105203, 'Cheytac M200 Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105185, 'Cheytac M200 DarkSteel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105318, 'Tactilite T2 3rdAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105287, 'Tactilite T2 HeartValentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105171, 'Tactilite T2 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105162, 'Tactilite T2 Dragon', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105202, 'Tactilite T2 Fire', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105264, 'Tactilite T2 Freedom', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105289, 'Tactilite T2 GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105307, 'Tactilite T2 GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105286, 'Tactilite T2 RRQ', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105298, 'Tactilite T2 Holi', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105288, 'Tactilite T2 Acrylic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105265, 'Cheytac M200 Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105266, 'Tactilite T2 Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105199, 'Cheytac M200 Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105282, 'Cheytac M200 Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105283, 'Tactilite T2 Puppy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105294, 'Cheytac M200 LatinChampionship', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105297, 'L115A1 Rebel PC', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105299, 'Cheytac M200 Holi', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105300, 'Cheytac M200 Digital', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105306, 'Tactilite T2 Vittoria', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105308, 'Cheytac M200 GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105309, 'Cheytac M200 MNB4', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105311, 'L115A1 WhiteRabbit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105313, 'Cheytac M200 Ramazan2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105314, 'Tactilite T2 Ramazan2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105380, 'Cheytac M200 PBLC19', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105382, 'Cheytac M200 PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105383, 'Tactilite T2 PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105385, 'Tactilite T2 PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105400, 'Tactilite T2 Spider', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105233, 'Cheytac M200 Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105158, 'Cheytac M200 Midnight2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105160, 'Cheytac M200 Skeleton', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105163, 'Cheytac M200 PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105165, 'Cheytac M200 ID 1stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105174, 'L115A1 Alien', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105175, 'Cheytac M200 Woody', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105177, 'Tactilite T2 Puzzle', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105178, 'SVD-Dragunov Russian Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105180, 'Tactilite T2 Liberty', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105181, 'Cheytac M200 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105182, 'Tactilite T2 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105183, 'Cheytac M200 PBTC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105184, 'AS 50 PBTC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105191, 'Cheytac M200 Mystic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105193, 'Cheytac M200 Latin6', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105194, 'Cheytac M200 Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105197, 'L115A1 Lightning', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105198, 'Cheytac M200 Pirates', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105200, 'AS 50 Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105201, 'Tactilite T2 MechHero', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105205, 'Cheytac M200 PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105206, 'Tactilite T2 PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105173, 'Cheytac M200 Alien', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105320, 'Cheytac M200 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105293, 'Cheytac M200 Graduation', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105192, 'Tactilite T2 Pahlawan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106187, 'M1887 PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105292, 'Barrett Nusantara', 2, '86400,259200', '5000,15000', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105110, 'Cheytac M200 Brazil', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105097, 'Cheytac M200 Cangaceiro', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105084, 'Cheytac M200 Champion', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105212, 'Cheytac M200 Chicano', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105220, 'Cheytac M200 CNPB-T5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105215, 'Cheytac M200 Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105147, 'Cheytac M200 Cupid', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105118, 'CheyTac M200 DarkDays', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105226, 'Tactilite T2 ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105222, 'Tactilite T2 Lebaran2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105207, 'L115A1 Talos', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105208, 'Tactilite T2 Salvation', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105151, 'Cheytac M200 Beast', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105209, 'AS 50 GSL2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105214, 'Cheytac M200 Naga', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105225, 'AS 50 ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105227, 'Tactilite T2 Graffiti', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105230, 'Cheytac M200 Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105296, 'Cheytac M200 Space-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105305, 'Tactilite T2 PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105064, 'L115A1 LATIN3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105075, 'HK-PSG1 Elite', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105213, 'PGM-Hecate2 Beach', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105078, 'VSK94 Elite', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105080, 'Cheytac M200 PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105089, 'L115A1 Black PC Cafe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105090, 'Cheytac M200 Merdeka', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105092, 'L115A1 Toy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105093, 'VSK94 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105096, 'Cheytac M200 LATIN4', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105100, 'Cheytac M200 GRS2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105101, 'L115A1 NEWBORN 2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105102, 'Cheytac M200 GSL2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105103, 'Cheytac M200 PBNC6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105104, 'Cheytac M200 Ongame', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105106, 'L115A1 Summer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105107, 'SVD-Dragunov Rose', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105108, 'Cheytac M200 LionFlame', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105109, 'L115A1 Harimau', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105117, 'L115A1 Mech', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105124, 'Cheytac M200 Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105125, 'L115A1 Basketball', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105168, 'Cheytac M200 Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105169, 'L115A1 Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105232, 'Barrett Premium', 2, '86400,259200', '5000,15000', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105211, 'AS 50 Renegade', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105126, 'Cheytac M200 Medical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105127, 'L115A1 Cobra', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105137, 'Cheytac M200 DFN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105139, 'Tactilite T2 Xmas2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105140, 'Cheytac M200 Monkey', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105149, 'Cheytac M200 Serpent', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105150, 'Tactilite T2 GRS3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105155, 'Cheytac M200 Tiger-Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105218, 'Cheytac M200 PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106073, 'SPAS15 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106076, 'M1887 Newborn2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106080, 'M1887 DarkSteel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106087, 'Christmas2016 CaneShotgun', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106175, 'M1887 Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106176, 'M1887 Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106186, 'M1887 Summer2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105142, 'Cheytac M200 Arena-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106184, 'Zombie Slayer PostApocalypse Deluxe', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105131, 'Cheytac M200 Halloween', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103233, 'AUG A3 SPY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106169, 'Zombie Slayer Zepetto', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106108, 'Zombie Slayer ID 2stAnni', 2, '86400,259200', '2000,4000', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105053, 'L115A1 PBNC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106121, 'Zombie Slayer Latin7', 2, '86400,259200', '2000,4000', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105031, 'Winchester M70', 2, '86400,259200', '2000,4000', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106142, 'Zombie Slayer Graduation', 2, '86400,259200', '2000,4000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106157, 'Zombie Slayer GhostHouse', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106189, 'M1887 Spider', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106074, 'M1887 Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106185, 'M1887 GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106036, 'Kel Tec KSG 15 GSL2014', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106037, 'M1887 Brazuca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106041, 'M1887 LionHeart', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106047, 'Cerberus', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106049, 'M1887 GSL2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106056, 'M1887 Mech', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106064, 'M1887 Arena-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106065, 'M1887 Cupid', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106079, 'M1887 PBTC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106081, 'M1887 PBNC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106089, 'M1887 Lightning', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106090, 'M1887 Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106091, 'Remington ETA MechHero', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106093, 'M1887 Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106096, 'M1887 GSL2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106099, 'M1887 Beach', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106101, 'M1887 Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106103, 'M1887 PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106105, 'M1887 Lebaran2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106110, 'M1887 Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106112, 'M1887 PBTC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106114, 'UTS-15 Newborn2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106117, 'M1887 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106118, 'Cerberus Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106119, 'M1887 PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106120, 'Cerberus FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106123, 'Cerberus Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106124, 'M1887 Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106143, 'M1887 LatinChampionship', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106144, 'M1887 Digital', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106147, 'M1887 GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106149, 'Cerberus Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106151, 'M1887 3rdAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106152, 'M1887 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106153, 'M1887 Surfing', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106158, 'SPAS15 Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106168, 'UTS-15 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106171, 'M1887 GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106174, 'M1887 BOG-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106178, 'M1887 PBLC19', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106034, 'M1887-W R', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106032, 'SPAS15 Elite', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106051, 'WaterGun', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106054, 'SPAS15 PBNC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106102, 'M1887 Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (106072, 'M1887 Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106084, 'Cerberus Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106164, 'Zombie Slayer Halloween2018', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106165, 'M1887 DemonHunter', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106057, 'SPAS15 MSC PBNC2015 US', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106058, 'M1887 PBIC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106066, 'M1887 GRS3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106068, 'M1887 PBGC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106069, 'M1887 Skeleton', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106070, 'M1887 Dragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106145, 'Zombie Slayer Maze', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106188, 'M1887 Crimson', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106067, 'M1887 Beast', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301297, 'GH5007 PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202184, 'Taurus 454SS Scope GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202129, 'Taurus 454SS Scope Darkness', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202124, 'Taurus 454SS Scope PBTC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202073, 'Tarus 454SS Scope Cobra', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202132, 'ColtPython PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202114, 'TEC-9 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202177, 'ColtPython PBIWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202176, 'ColtPython PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202180, 'ColtPython PostApocalypse Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202181, 'ColtPython PostApocalypse Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202058, 'ColtPython Summer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (234009, 'Compound Bow Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (234007, 'Compound Bow Graduation', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202179, 'Taurus 454SS Scope 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202113, 'TEC-9 Silver', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (234002, 'Compound Bow Silver', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (234003, 'Compound Bow Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (234004, 'Compound Bow Blue', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106159, 'M1887 PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202115, 'Glock18 Samurai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202110, 'Kriss Vector SDP MechHero', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202117, 'DesertEagle Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202119, 'ColtPython Nagi-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202120, 'ColtPython Nagi-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202121, 'Luger P08 Brazuca2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202122, 'ColtPython Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202123, 'ColtPython Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202127, 'ColtPython Ottoman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202133, 'ColtPython Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202134, 'ColtPython FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202182, 'MK23 Ramadan19-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202185, 'ColtPython Summer2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214031, 'Scorpion Vz61 Ramadan19-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213008, 'ColtPython Cutlass', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214002, 'DesertEagle Dual', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214004, 'DesertEagle DualGold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214012, 'Hk45 Halloween Dual', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214015, 'DesertEagle Dual BR Camo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214016, 'DesertEagle Dual G ESports', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214023, 'Scorpion Vz61 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214024, 'Scorpion Vz61 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214025, 'Scorpion Vz61 Latin7', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214027, 'DesertEagle Dual Nevasca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214028, 'Scorpion Vz61 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106038, 'M1887 PBIC2014', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106050, 'SPAS15 PBNC6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202186, 'ColtPython Independence817', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202047, 'Glock18 BR Camo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202049, 'ColtPython Brazuca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202052, 'ColtPython Toy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202059, 'ColtPython Rose', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202062, 'Glock18 4Game', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202063, 'Glock18 4Game-SE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202071, 'Glock18 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202072, 'ColtPython VeraCruz', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202084, 'ColtPython GSL2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202118, 'ColtPython PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202125, 'ColtPython PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202131, 'ColtPython PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202137, 'ColtPython Freedom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202138, 'ColtPython Puppy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202069, 'Kriss Vector SDP DarkDays', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202111, 'Kriss Vector SDP Fire', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214020, 'Scorpion Vz61 Woody', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214029, 'DesertEagle Dual Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202174, 'Taurus 454SS Scope Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202152, 'Taurus 454SS Scope Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301166, 'GH5007 Latin6', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202164, 'ColtPython BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202162, 'ColtPython PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202148, 'ColtPython PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (234008, 'Compound Bow PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202161, 'Glock18 PBST2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202168, 'ColtPython BOG-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202155, 'ColtPython Football Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202154, 'ColtPython Football Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202147, 'ColtPython Holi', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202156, 'ColtPython LatinChampionship2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202151, 'ColtPython Ramazan2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202170, 'ColtPython NewYear2019', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202159, 'ColtPython Oni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202150, 'ColtPython WhiteRabbit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202140, 'ColtPython Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202157, 'Taurus 454SS Scope Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202153, 'Taurus 454SS Scope Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202144, 'Taurus 454SS Scope Nusantara', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202166, 'Taurus 454SS Scope Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202149, 'TEC-9 GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301185, 'GH5007 Lebin2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (234006, 'Compound Bow PBIWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202023, 'IMI Uzi9', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202056, 'ColtPython PBNC6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202061, 'Glock18 PBST2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202067, 'ColtPython PBNC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202077, 'MK23 Spy-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202079, 'ColtPython Arena-Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202080, 'ColtPython Arena-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202083, 'ColtPython Beast', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202085, 'DesertEagle Tiger-Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202086, 'DesertEagle Tiger-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202087, 'ColtPython PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202088, 'Glock18 Mummy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202089, 'MK23 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202091, 'MK23 Alien', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202092, 'ColtPython Newborn2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202097, 'ColtPython PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202098, 'ColtPython DarkSteel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202101, 'ColtPython Mystic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202103, 'Luger P08 Silver', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202104, 'Luger P08 Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202105, 'ColtPython Latin6', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202106, 'ColtPython Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202107, 'ColtPython Chicken', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301148, 'Ladle Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301159, 'FangBlade DarkSteel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301162, 'Halloween Hammer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301167, 'FangBlade Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301168, 'Chicken Hammer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301181, 'Kukrii Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301186, 'GH5007 Nagi-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301188, 'Karambit ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202167, 'Taurus 454SS Scope GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202142, 'U22-Neos Acrylic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202143, 'Taurus 454SS Scope GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202175, 'Glock18 Shark', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202160, 'Taurus 454SS Scope Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202075, 'MK23 SPY', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202108, 'ColtPython Hybridman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103231, 'AUG A3 Steam', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103238, 'AUG A3 Spy-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301243, 'GH5007 Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301248, 'Karambit Football Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301261, 'FangBlade Splash', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301267, 'Karambit Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301256, 'Karambit Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301255, 'Karambit Viper', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301295, 'Karambit GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301284, 'Arabian Sword Lycan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301264, 'Arabian Sword Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301250, 'ButterflyKnife GhostHouse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407086, 'Heart Bomb', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407080, 'BundleM24', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301298, 'GH5007 Crimson', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301239, 'GH5007 Ramazan2018', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202082, 'ColtPython Sakura', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202039, 'Glock18 Azerbaijan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301246, 'Karambit Brazuca3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301193, 'Karambit Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301194, 'FangBlade Kareem', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301196, 'Arabian Sword Phantom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301223, 'Karambit GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301200, 'Kukrii Newborn2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301205, 'GH5007 Aguila', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301209, 'GH5007 Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301212, 'FangBlade FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301216, 'Rudolph Hammer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (323006, 'SpikedKnuckle', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (323009, 'GarenaKnuckle', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (323010, 'ZombieToothKnuckle', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202033, 'Glock18 PBNC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202040, 'ColtPython PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315014, 'Dual BoneKnife E-Sports2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301066, 'Death-Scythe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301071, 'Goat Hammer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301080, 'Field Shovel Royal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301082, 'Arabian Sword Midnight', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301084, 'GH5007 Rose', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301096, 'GH5007 4Game-SE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301098, 'HairDryer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301103, 'Bamboo-Runcing', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301108, 'FangBlade Cobra', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301119, 'GH5007 DFN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301136, 'FangBlade Dragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301139, 'Kukrii Mummy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301143, 'Kukrii Poison', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301145, 'GH5007 Strike', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301146, 'Death Scythe Demonic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301155, 'GH5007 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301183, 'ButterflyKnife PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301184, 'Karambit CNPB-T5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301197, 'Arabian Sword PBTC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301208, 'Kukrii PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301218, 'Puppy Hammer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301220, 'Karambit Nevasca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301259, 'Kukrii PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301273, 'GH5007 BOG-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315012, 'Dual Kunai Serpent', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407064, 'C5 Lightning', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407067, 'Beer Glass', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315015, 'Dual Sword TH', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407060, 'Football Bomb2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 4);
INSERT INTO "public"."item_goods" VALUES (301225, 'Diploma', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301283, 'GH5007 Komodo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301097, 'HairDryer Indonesia', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301161, 'FangBlade Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202100, 'ColtPython Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103575, 'AUG A3 PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602226, 'AcidPol BasketBall', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602002, 'AcidPol', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103295, 'AUG A3 DarkSteel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602209, 'Chou FireFight', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103336, 'AUG A3 Samurai', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407050, 'WaterBomb', 2, '86400,259200', '15000,20000', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601007, 'D-Fox', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601144, 'D-Fox Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601147, 'D-Fox Indian', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601148, 'D-Fox Pirate', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601149, 'D-Fox Hitman', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601151, 'D-Fox BasketBall', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601069, 'Caimangrey', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (527002, 'WP SmokeGrenade D', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (527004, 'WP SmokeGrenade EV', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (527005, 'WP SmokeGrenadePlus P', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528001, 'Medical Kit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508004, 'FlashBangPlus', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103198, 'AUG A3 4Game-SE', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602334, 'AcidPol Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602215, 'Chou BunnyGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301182, 'FangBlade Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (104437, 'KrissSuperV Bolt', 2, '86400,259200', '1000,2700', '0,0', 0, 5, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105231, 'Tactilite T2 Bolt', 2, '86400,259200', '1000,2700', '0,0', 0, 5, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315035, 'Dual BoneKnife GLS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301280, 'GH5007 SignaturePB', 2, '86400,259200', '1000,2500', '0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601152, 'D-Fox Ninja', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407010, 'Fanoos Grenade', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407005, 'ChocolateGrenade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407074, 'IceCreamGrenade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601143, 'D-Fox Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301057, 'FangBlade Inferno', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103057, 'Vz52', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103248, 'AUG A3 VeraCruz2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301024, 'CandyCane', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301137, 'Kukrii PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407009, 'CANDYGRENADE', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407018, 'M14 Mine D', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407055, 'K-413 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407061, 'C5 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407066, 'Beer Barrel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407069, 'C5 PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407078, 'C5 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508002, 'FlashBang', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508006, 'SmokeGrenade Blue', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508007, 'SmokeGrenade Yellow', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508008, 'CS Gas', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (527001, 'WP SmokeGrenade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528002, 'Halloween Medical Kit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528003, 'Chocolate Kit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528004, 'Medical Kit Lotus', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528005, 'Medical Kit Opor Ayam', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528008, 'Medical Kit Lotus2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528009, 'Medical Kit Kurma', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528010, 'Medical Kit PBNC6', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528012, 'Medical Kit PBNC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602011, 'Chou', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602218, 'AcidPol Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301064, 'BadmintonRacket', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601153, 'D-Fox Chemical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301138, 'GH5007 PBWC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528014, 'Medical Kit Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602467, 'AcidPol Indiana', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602198, 'Chou Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602200, 'Chou Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602201, 'Chou Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602202, 'Chou Valentine16', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602205, 'Chou Navy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602208, 'Chou NBGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602207, 'Chou Killbill', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602217, 'Chou Police Squad', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602227, 'AcidPol Ninja', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602228, 'AcidPol Chemical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602229, 'AcidPol Boarder', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602235, 'AcidPol Cavaliers', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602236, 'AcidPol Navy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602273, 'AcidPol Pilot', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602275, 'Chou SantaGuard', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602289, 'Chou UKSAS', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602295, 'Chou Pilot', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602296, 'AcidPol Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602307, 'Chou Libra', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602310, 'Chou Valentine Witch', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602355, 'Chou Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602321, 'Chou P1000', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602325, 'Chou Invasion', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602328, 'Chou Highschool', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602402, 'Chou Halloween Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602427, 'Chou EOD', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103254, 'WaterGun2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103371, 'Pindad SS2 V5 PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601333, 'D-Fox Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602389, 'AcidPol Paramedic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602184, 'Hide Navy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602061, 'Leopard Madness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602156, 'KeenEyes Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602067, 'Hide Black', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602159, 'KeenEyes Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602162, 'KeenEyes Cavaliers', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602163, 'KeenEyes Navy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602164, 'KeenEyes Swimsuit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602385, 'AcidPol Disco', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602166, 'KeenEyes NBGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105148, 'Cheytac M200 Sakura', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103301, 'AK 12 Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106083, 'M1887 Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602210, 'Chou Ninja', 3, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602220, 'AcidPol Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601154, 'D-Fox Boarder', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602179, 'Hide Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (528013, 'IceCream Kit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602170, 'KeenEyes Zombie', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602171, 'KeenEyes Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602172, 'KeenEyes Chipao', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602173, 'KeenEyes BunnyGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602174, 'KeenEyes JumpSuit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602180, 'Hide Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602183, 'Hide Cavaliers', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602009, 'Hide', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602185, 'Hide Swimsuit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602187, 'Hide NBGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602188, 'Hide FireFight', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602191, 'Hide Zombie', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602192, 'Hide Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602039, 'Hide Recon', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601470, 'D-Fox Indiana', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601382, 'D-Fox Army-Afghan', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601388, 'D-Fox Paramedic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602036, 'Hide Soccer', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601384, 'D-Fox Disco', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602216, 'Chou JumpSuit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602060, 'Hide Madness', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601376, 'D-Fox HawaianGang', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601068, 'REBEL Viper Kopassus', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601016, 'Reinforced REBEL Male', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601128, 'Rica Demolition', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601130, 'RedBulls Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601131, 'RedBulls Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602014, 'Normal Hide', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601132, 'RedBulls Valentine16', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601134, 'RedBulls Indian', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601135, 'RedBulls Pirate', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601138, 'RedBulls BasketBall', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601139, 'RedBulls Ninja', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601026, 'Reinforced Combo D-Fox', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601263, 'RedBulls Pilot', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601331, 'D-Fox SteamPunk', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602372, 'KeenEyes Camocoat', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601381, 'RedBulls Army-Afghan', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601387, 'RedBulls Paramedic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601430, 'Rica EOD', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602023, 'Reinforced Hide', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602231, 'Leopard Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602027, 'Reinforced Combo Leopard', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602193, 'Hide Chipao', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602029, 'Reinforced Combo Hide', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601020, 'Reinforced D-Fox', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602239, 'Leopard BasketBall', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602240, 'Leopard Ninja', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602241, 'Leopard Chemical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601469, 'RedBulls Indiana', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602013, 'Normal Leopard', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602195, 'Hide JumpSuit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602199, 'Chou Halloween', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602272, 'Chou Space', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601298, 'RedBulls Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602326, 'Hide Invasion', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602251, 'Hide General', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602308, 'Hide GIGN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602306, 'Hide Libra', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602346, 'Chou Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601126, 'Rica Chipao', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602373, 'Hide Camocoat', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602222, 'Leopard Cavaliers', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602403, 'Chou Pocong', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602436, 'Hide Wardog', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602424, 'Hide Rudolph', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602438, 'Chou Wardog', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602455, 'Chou Shopholic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601334, 'RedBulls Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601038, 'REBEL ViperShadow', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602035, 'Leopard Bope', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602008, 'Leopard', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601022, 'Reinforced ViperRed', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601383, 'RedBulls Disco', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601028, 'Reinforced Combo ViperRed', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601037, 'REBEL Soccer', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602021, 'Reinforced Leopard', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602345, 'Hide Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601136, 'RedBulls Hitman', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602448, 'Hide MintChoco', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602452, 'Chou MintChoco', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601121, 'Rica FireFight', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602025, 'Reinforced Chou', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602409, 'Chou Racer', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601127, 'Rica BunnyGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602196, 'Hide Police Squad', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601375, 'RedBulls HawaianGang', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601123, 'Rica Somalian', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602437, 'KeenEyes Wardog', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602305, 'KeenEyes Libra', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601078, 'Tarantula NBGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601079, 'Tarantula FireFight', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601081, 'Tarantula Somalian', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601082, 'Tarantula Zombie', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601083, 'Tarantula Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601084, 'Tarantula Chipao', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601087, 'Tarantula Bouncer', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601095, 'ViperRed Indian', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601099, 'ViperRed NBGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601110, 'Rica Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601111, 'Rica Halloween', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601074, 'Tarantula Indian', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601112, 'Rica Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601024, 'Reinforced Bella', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601116, 'Rica Indian', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601117, 'Rica Pirate', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601118, 'Rica Swimsuit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601119, 'Rica Killbill', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601247, 'Tarantula General', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601325, 'Rica Invasion', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601071, 'Tarantula Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601458, 'Rica Shopholic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601406, 'Rica Rangda', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601286, 'Rica UKSAS', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601292, 'Rica Pilot', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601300, 'Rica Spy', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601303, 'Rica Virgo', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601313, 'Rica Valentine Witch', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601125, 'Rica Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601412, 'Rica Racer', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601340, 'Rica Priest', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601358, 'Rica Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601366, 'Rica Matilda', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601122, 'Rica Ninja', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601280, 'Rica Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601100, 'ViperRed FireFight', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602232, 'Leopard Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602233, 'Leopard Valentine16', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602297, 'Leopard Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602333, 'Leopard Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601462, 'Rica SecretAgent', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602390, 'Leopard Paramedic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601076, 'Tarantula Swimsuit', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601005, 'ViperRed', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601449, 'Rica PinkChoco', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601113, 'Rica Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601322, 'Rica Rugby', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601328, 'Rica Highschool', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601435, 'Rica Wardog', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103506, 'SC 2010 RustIron', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602331, 'Leopard SteamPunk', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601318, 'Rica P1000', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602250, 'KeenEyes General', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601343, 'Rica Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602367, 'KeenEyes GIGN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601120, 'Rica NBGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602274, 'Leopard Pilot', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105261, 'Tactilite T2 FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104785, 'KrissSuperV 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105156, 'Cheytac M200 Tiger-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105189, 'Cheytac M200 Halloween2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1800047, 'Change Nickname', 1, '1', '50000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1800051, 'Change Clan Name', 1, '1', '50000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1800052, 'Change Clan Mark', 1, '1', '5000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105316, 'Tactilite T2 Lebaran2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601463, 'Tarantula SecretAgent', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104705, 'KrissSuperV Halloween2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602425, 'KeenEyes Rudolph', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601085, 'Tarantula BunnyGvasirl', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602344, 'KeenEyes Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602378, 'Leopard FBI-MA', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602447, 'KeenEyes MintChoco', 2, '50', '25000', '25000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103447, 'AUG A3 Holi', 3, '100', '10000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105390, 'Cheytac M200 PostApocalypse Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106100, 'M1887 Naga', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601092, 'ViperRed Sheep', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601103, 'ViperRed Zombie', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601104, 'ViperRed Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601106, 'ViperRed BunnyGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601107, 'ViperRed Demolition', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601108, 'ViperRed Bouncer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601393, 'Rica PBRanger', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601248, 'ViperRed General', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601089, 'ViperRed Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601279, 'Tarantula Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601302, 'Tarantula Virgo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601304, 'ViperRed Virgo', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601326, 'ViperRed Invasion', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601341, 'Tarantula Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601244, 'Tarantula Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601342, 'ViperRed Muaythai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601464, 'ViperRed SecretAgent', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601450, 'Tarantula PinkChoco', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601269, 'Rica Space', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601421, 'ViperRed Rudolph', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601433, 'ViperRed Wardog', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601434, 'Tarantula Wardog', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601451, 'ViperRed PinkChoco', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601091, 'ViperRed Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601102, 'ViperRed Somalian', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104249, 'KrissSuperV Xmas2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602070, 'Wolf', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103296, 'AUG A3 PBNC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103431, 'AUG-HBAR Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103349, 'AUG A3 MNB3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103351, 'FAMAS G2 Commando PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103485, 'AUG-HBAR PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103555, 'SC 2010 PBWC2019', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104153, 'KrissSuperV PBSC2014', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104203, 'OA93 PBST2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104312, 'KrissSuperV PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104403, 'KrissSuperV MNB3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104452, 'KrissSuperV PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103426, 'AUG A3 Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104005, 'KrissSuperV Cupid', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104130, 'KrissSuperV GSL2014', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104196, 'KrissSuperV Harimau', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104628, 'OA93 Paladin', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103404, 'SCAR-L FC Freedom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104639, 'KrissSuperV Arcade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601309, 'ViperRed Matilda', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103429, 'SC 2010 Nevasca', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106082, 'M1887 Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105312, 'BattleBox DragonSniper', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103400, 'AUG A3 Latin7', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103039, 'AK-SOPMOD D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103041, 'AK-SOPMOD KingCobra', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103054, 'AK-47 Gold D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103058, 'AK FC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103059, 'AK-47 Non Ext', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103068, 'AK FC Flame', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103072, 'AK-47 OLD SPEC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103074, 'AK-SOPMOD EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103076, 'AK-47 Point15 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103078, 'AK-47 Ext EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103099, 'AK-SOPMOD GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103115, 'AN-94', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103002, 'AK-47 DualMag', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103009, 'AK-47 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103015, 'AK-SOPMOD', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103017, 'AK-47 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104325, 'KrissSuperV Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103124, 'AK-47 Gold P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103125, 'AK FC P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103126, 'AK-SOPMOD KingCobra P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103128, 'AUG A3 Azerbaijan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103171, 'AUG A3 LATIN4', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103199, 'AUG A3 Emblem-Mexico', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103234, 'AUG A3 LATIN5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103244, 'AUG A3 Arena-Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103449, 'AUG A3 Digital', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301229, 'GH5007 Holi', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202146, 'DesertEagle Space-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601246, 'Tarantula Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (1701006, 'Pewarna Nickname', 2, '2592000', '15000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601327, 'Tarantula Invasion', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104398, 'BattleBox Dragon', 3, '100', '25000', '25000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202130, 'TEC-9 PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202126, 'Taurus 454SS Scope PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (1730080, '%100 canlanma', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730011, 'Fee Move, Free Pass', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730014, 'Color Change Crosshair', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730017, 'Get Dropped Weapon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730028, 'HP Up 10%', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730029, 'Invincible +1 Sec', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730032, 'Hollow Point', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730036, 'Jack Hollow Point', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730044, '10% Defense Up', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730064, 'Quick Respawn 50%', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730078, 'Hollow Point Plus', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730079, '20% Defense Up', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730187, 'Muzzle Color', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601332, 'RedBulls SteamPunk', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602332, 'AcidPol SteamPunk', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601349, 'Rica SteamPunk', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104476, 'OA93 PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104509, 'KrissSuperV PBIWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730031, 'Full Metal Jack', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104609, 'KrissSuperV PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105217, 'AS 50 MNB3', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105348, 'Tactilite T2 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106027, 'M1887 PBNC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103196, 'AUG A3 PBST2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106055, 'M1887 PBTC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106138, 'M1887 Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106154, 'Cerberus Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202057, 'DesertEagle Ongame', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202116, 'ColtPython Naga', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301070, 'GH5007 Cangaceiro', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301150, 'GH5007 Newborn2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301214, 'Karambit DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407023, 'M18A1 Claymore', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508005, 'SmokeGrenade Pink', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528006, 'Medical Kit PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528007, 'Medical Kit Easter', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103225, 'AK-47 SOPMOD Medical', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602396, 'Chou PBRanger', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202109, 'Taurus 454SS Scope Lightning', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106183, 'Zombie Slayer PostApocalypse Basic', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104813, 'KrissSuperV PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105397, 'Cheytac M200 PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103005, 'F2000', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103011, 'K201', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103013, 'G36C', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103027, 'G36C Event', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103028, 'AUG-A3 Event', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103029, 'G36C Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103031, 'G36C Silver Special Exp Pt 20', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103032, 'F2000 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103034, 'G36C Silver Exp Pt 20', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103036, 'AUG-A3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103037, 'AUG-A3 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103038, 'G36C D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103040, 'AUG-A3 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103046, 'F2000 Silver P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103048, 'AUG-A3 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103049, 'FAMAS G2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103050, 'FAMAS G2 Commando', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103051, 'FAMAS G2 Scope', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103052, 'FAMAS G2 M203', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103060, 'M4 Non Ext', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103063, 'AUG-A3 ESports', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103064, 'FAMAS G2 Commando Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103065, 'AUG-A3 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103067, 'G36C NON EXT', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103075, 'AUG-A3 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103077, 'F2000 Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103087, 'FAMAS G2 Sl', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103089, 'AUG-A3 Gold Non', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103090, 'FAMAS G2M', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103091, 'FAMAS G2 Commando PBTN', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103100, 'FAMAS G2 GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103102, 'HK417', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103106, 'AUG-A3 ITALIA', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103107, 'AUG-A3 Black P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103112, 'AUG-A3 Turkey', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103113, 'FAMAS G2 GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103116, 'F2000 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103143, 'FG42', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103146, 'G36C Elite', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103210, 'AUG-A3 Egypt', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103212, 'AUG-A3 Saudi', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103213, 'AUG-A3 UAE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103223, 'M14-EBR', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103229, 'G36C Camo-Soldier', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103236, 'K2C', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103237, 'K2C Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103239, 'M14-EBR Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103284, 'Groza', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103286, 'Groza Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103288, 'Groza Russian Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103289, 'Groza Russian Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103305, 'G11', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103307, 'G11 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103308, 'G11 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103332, 'FAMAS G2 Commando Talos', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103407, 'AUG-HBAR SL', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103408, 'AUG-HBAR Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103411, 'Groza Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103415, 'AUG-A3 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103417, 'Groza Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103421, 'Famas G2 Commando Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103422, 'Groza Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103442, 'Groza Graduation', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103443, 'BattleBox Lion', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103496, 'FAMAS G2 Commando RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103497, 'FAMAS G2 Commando Gold RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103498, 'Famas G2 Commando Red RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103517, 'AUG A3 Zepetto Silence', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103530, 'AUG-HBAR BOG-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103014, 'SG550 Camo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103018, 'SG550 MB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103019, 'SG550 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103020, 'SG550 White', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103026, 'SG550 Point10', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103030, 'SG550 MB Exp Pt 20', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103042, 'M4-SR16-LV1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103043, 'M4-SR16-LV2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103044, 'M4-SR16-LV3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103079, 'M4A1 Ext EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103103, 'M4A1 FC D-Hunter', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103023, 'M4A1 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103500, 'M4A1 Gold RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103098, 'M4A1 GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103208, 'M4A1 GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103533, 'M4A1 NewYear2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103121, 'M4A1 PBIC2013', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103080, 'M4A1 S EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103003, 'M4A1 Scope2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103010, 'M4A1 SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103021, 'M4A1 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103055, 'M4A1 White D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103499, 'M4A1 White RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103216, 'AUG-A3 Mech', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103439, 'AUG-A3 Nusantara', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103432, 'AUG-A3 Blue TH', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103053, 'Pindad SS2 V4', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103056, 'SG550 Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103061, 'Pindad SS2 V4 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103066, 'SG550 NON EXT', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103069, 'SCAR-H CQC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103070, 'SCAR STD SILENCER', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103073, 'SG550 S EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103083, 'M4-SR16-LV2 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103084, 'M4-SR16-LV3 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103088, 'SCAR LB SNIPER', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103094, 'SCAR-L Carbine', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103095, 'SCAR-L Recon', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103096, 'SCAR-L FC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103117, 'SG550 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103118, 'Pindad SS2 V4 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103123, 'TAR-21', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103151, 'TAR-21 BR Camo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103153, 'SC 2010', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103156, 'Pindad SS2 V4 Gold GW', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103162, 'TAR-21 Midnight NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103166, 'SC 2010 Q', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103169, 'TAR-21 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103170, 'SCAR-L Carbine Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103174, 'XM8', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103175, 'SCAR-L Carbine D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103268, 'Pindad SS2 V5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103270, 'Pindad SS2 V5 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103273, 'SC 2010 Strike', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103306, 'SIG-Sauer MCX', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103338, 'MSBS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103339, 'MSBS Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103340, 'MSBS Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103413, 'SC 2010 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103414, 'TAR-21 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103418, 'Pindad SS2 V5 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103420, 'TAR-21 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103424, 'SC 2010 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103425, 'TAR-21 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103468, 'MSBS 3rdAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103514, 'STG44', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103515, 'STG44 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103549, 'MPT 76', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103550, 'MPT 76 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103551, 'MPT 76 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118004, 'Dual Uzi', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135001, 'Cerberus Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135002, 'Cerberus Dual Gorgeous', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135003, 'Cerberus Dual Kemerde', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135004, 'Cerberus Dual FireDragon', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135005, 'Cerberus Dual Xmas2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135006, 'Cerberus Dual Lebaran2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (135007, 'Cerberus Dual Milkyway', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214006, 'DesertEagle Dual D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214009, 'DesertEagle Dual EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214030, 'DesertEagle Dual Ramadan19-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (234001, 'Compound Bow', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (234005, 'Compound Bow Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315003, 'Dual BoneKnife', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315005, 'Dual BoneKnife GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315008, 'Dual Kunai', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315010, 'Dual BoneKnife Camo-Soldier', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315016, 'Dual BoneKnife Beyond', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315017, 'Dual BoneKnife PBGC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315019, 'Dual BoneKnife PBNC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315020, 'Dual BoneKnife PBST-ES', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315021, 'Dual BoneKnife Military', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315023, 'Dual BoneKnife Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315026, 'Dual BoneKnife M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315028, 'Dual BoneKnife Lebaran2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315030, 'Dual BoneKnife Milkyway', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315031, 'Dual BoneKnife Bhinneka', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315032, 'Dual BoneKnife PBTC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118007, 'Dual Uzi Silencer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118011, 'Dual Uzi Micro Silencer Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118013, 'Dual Uzi Mini Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118033, 'OA93 Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118034, 'OA93 Dual Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118050, 'OA93 Dual GSL2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118056, 'OA93 Dual Independence', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118057, 'OA93 Dual PBST2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118063, 'OA93 Dual PBNC2015 US', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118065, 'OA93 Dual Cobra', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118066, 'OA93 Dual Medical', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118069, 'OA93 Dual Basketball', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118074, 'OA93 Dual DFN', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118095, 'OA93 Dual BlueDiamond', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118099, 'OA93 Dual Newborn2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118101, 'OA93 Dual Liberty', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118103, 'OA93 Dual PBIC2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118109, 'OA93 Dual Halloween2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118111, 'OA93 Dual Gorgeous', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118113, 'OA93 Dual Pahlawan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118118, 'OA93 Dual Hybridman', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118121, 'OA93 Dual Beyond', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118122, 'OA93 Dual MechHero', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118123, 'OA93 Dual Fire', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118128, 'Dual Uzi Mini Talos', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118132, 'OA93 Dual GSL2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118142, 'OA93 Dual MNB3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118145, 'OA93 Dual MechHero ID', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118147, 'OA93 Dual ID 2stAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118150, 'OA93 Dual Graffiti', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118151, 'OA93 Dual Kareem', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118160, 'OA93 Dual PBNC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118162, 'OA93 Dual Kemerde', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118166, 'OA93 Dual Aguila', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118167, 'OA93 Dual PBST-ES', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118170, 'OA93 Dual Military', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118175, 'OA93 Dual Halloween2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118181, 'OA93 Dual PBIWC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118188, 'OA93 Dual FireDragon', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118189, 'OA93 Dual Latin7', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118195, 'OA93 Dual Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118198, 'OA93 Dual Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118200, 'OA93 Dual Pandora', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118207, 'OA93 Dual GRSV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118211, 'OA93 Dual Nusantara', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118214, 'OA93 Dual LatinChampionship', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118218, 'OA93 Dual Holi', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118222, 'OA93 Dual Maze', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118228, 'OA93 Dual GSL2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118230, 'OA93 Dual MNB4', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118233, 'OA93 Dual Paladin', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118235, 'OA93 Dual Lebaran2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118237, 'OA93 Dual 3rdAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118239, 'OA93 Dual Arcade', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118243, 'OA93 Dual Milkyway', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118249, 'OA93 Dual GhostHouse', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118251, 'OA93 Dual Bhinneka', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118257, 'OA93 Dual Oni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118261, 'OA93 Dual PBST2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118263, 'OA93 Dual PBIC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118271, 'OA93 Dual BlackCat', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118277, 'OA93 Dual GunZeeD', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118267, 'OA93 Dual Halloween2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315007, 'Dual BoneKnife GRS2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315024, 'Dual BoneKnife Nusantara', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315027, 'Dual BoneKnife GSL2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (118278, 'OA93 Dual NewYear2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118286, 'OA93 Dual EvosGalaxy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118289, 'OA93 Dual Komodo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118291, 'OA93 Dual Lycan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118292, 'OA93 Dual PBLC19', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118299, 'OA93 Dual Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118301, 'OA93 Dual 10Anniv', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118306, 'OA93 Dual GLS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118310, 'OA93 Dual 9th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118314, 'OA93 Dual Crimson', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214005, 'MK23-K5 Dual D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214007, 'Hk45 Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214008, 'MK23-K5 Dual EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315001, 'M-9 Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315002, 'M-9 Dual D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315004, 'M-9 Dual EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315006, 'M-9 Dual PBNC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315025, 'M-9 Dual Digital', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315029, 'M-9 Dual 3rdAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118044, 'OA93 Dual Xmas', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118076, 'OA93 Dual Xmas2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118089, 'OA93 Dual PBWC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118098, 'OA93 Dual Woody', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118130, 'OA93 Dual Salvation', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118144, 'OA93 Dual PBWC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118155, 'OA93 Dual Vacance17', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118157, 'OA93 Dual Phantom', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118173, 'OA93 Dual Rebel', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118178, 'OA93 Dual Shatter Z1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118179, 'OA93 Dual Shatter UM', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118182, 'T77 Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118183, 'T77 Dual Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118184, 'T77 Dual Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118196, 'OA93 Dual Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118201, 'OA93 Dual Puppy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118203, 'OA93 Dual RRQ', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118205, 'OA93 Dual Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118216, 'OA93 Dual Space-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118223, 'OA93 Dual PBWC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118226, 'OA93 Dual Vittoria', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118241, 'OA93 Dual Surfing', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118253, 'OA93 Dual PBTC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118259, 'OA93 Dual Viper', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118264, 'OA93 Dual RustIron', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118265, 'OA93 Dual Splash', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118273, 'OA93 Dual Zepetto Silence', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118275, 'OA93 Dual Xmas2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118282, 'OA93 Dual Snack', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118294, 'OA93 Dual Shark', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118296, 'OA93 Dual PBWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118308, 'OA93 Dual Summer2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118317, 'OA93 Dual Spider', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213001, 'P99-Hak CIC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213002, 'P99-Hak CIC Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213003, 'P99-Hak CIC D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213005, 'P99-Hak CIC EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213006, 'P99-Hak CIC D GW', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213007, 'P99-Hak CIC Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214017, 'Scorpion Vz61', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214018, 'Scorpion Vz61 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301016, 'BoneKnife', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301018, 'BallisticKnife', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301020, 'BallisticKnife I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301037, 'BallisticKnife GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301039, 'BallisticKnife GRS I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301040, 'BoneKnife GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301041, 'Arabian Sword', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301075, 'BoneKnife GRS2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301110, 'BallisticKnife SPY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301112, 'BallisticKnife SPY I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301114, 'BallisticKnife SPY-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301116, 'BallisticKnife SPY-Deluxe I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301135, 'BoneKnife E-Sports2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301152, 'BallisticKnife Ru Normal I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301153, 'BallisticKnife Russian Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301154, 'BallisticKnife Ru Deluxe I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301172, 'BoneKnife Beyond', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301175, 'BoneKnife PBGC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301190, 'BallisticKnife Brazuca2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301191, 'BallisticKnife Brazuca2 I3S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301207, 'BoneKnife Military', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301211, 'AITOROSONEGRO', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301215, 'BoneKnife DesertHound', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301224, 'BoneKnife Nusantara', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301231, 'BoneKnife M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301236, 'BoneKnife GSL2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301241, 'BoneKnife Lebaran2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301245, 'BoneKnife Milkyway', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301251, 'BoneKnife Bhinneka', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118244, 'Thompson Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118254, 'Thompson Dual Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118255, 'Thompson Dual Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118302, 'Thompson Dual 10Anniv', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323001, 'BareFist', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323002, 'BlackKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323003, 'BrassKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323004, 'SilverKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323007, 'BallockKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323011, 'KarambitKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323012, 'ZepettoKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118312, 'OA93 Dual PinkyPig', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301010, 'Hak Silver Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301014, 'GH5007', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301017, 'FangBlade', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301025, 'Field Shovel', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301029, 'Hak EV Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301030, 'Hak GW Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301031, 'Hak D Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301043, 'GH5007 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301044, 'GH5007 PBSC2013', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301045, 'Hak Reload Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301051, 'FangBlade GSL2014', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301052, 'FangBlade Brazuca', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301054, 'FryingPan DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301058, 'ChineseCleaver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301059, 'GH5007 PBSC2013 NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301060, 'ChineseCleaver DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301061, 'ChineseCleaver Seized', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301062, 'ChineseCleaver Seized DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301063, 'Field Shovel Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301067, 'FangBlade LATIN4', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301068, 'Icicle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301069, 'Ice Fork', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301072, 'Goat Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301074, 'ChineseCleaver CNY-2015 DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301077, 'FangBlade NEWBORN 2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301078, 'FangBlade PBNC6', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301079, 'FangBlade Ongame', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301094, 'FangBlade PBST2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301099, 'HairDryer DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301100, 'HairDryer Indonesia Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301101, 'Fangblade PBNC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301102, 'BoneKnife PBNC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301105, 'Cutlass Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301106, 'GH5007 VeraCruz', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301113, 'FangBlade LATIN5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301122, 'ButterflyKnife', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301123, 'FangBlade Arena-Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301124, 'FangBlade Arena-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301130, 'FangBlade PBGC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301132, 'FangBlade Tiger-Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301133, 'FangBlade Tiger-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301134, 'BoneKnife Skeleton', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301147, 'Karambit', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301163, 'Halloween Hammer DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301164, 'FangBlade Mystic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301169, 'Chicken Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301171, 'FangBlade Pirates', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301199, 'BoneKnife PBNC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301201, 'FangBlade Ottoman', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301204, 'ButterflyKnife 7th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301206, 'BoneKnife PBST-ES', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301213, 'FangBlade Latin7', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301221, 'BoneKnife Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301222, 'ChocoStick', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301226, 'FangBlade LatinChampionship', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301227, 'ButterflyKnife Space-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301232, 'Karambit M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301233, 'FangBlade Maze', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301235, 'ButterflyKnife Vittoria', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301237, 'ButterflyKnife WhiteRabbit', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301238, 'FangBlade Ramazan2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301240, 'FangBlade Paladin', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301244, 'FangBlade Surfing', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301252, 'BoneKnife PBTC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301258, 'FangBlade PBST2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301260, 'FangBlade RustIron', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301265, 'FangBlade Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301266, 'Fangblade Zepetto Speed', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301270, 'GH5007 GunZeeD', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301272, 'GH5007 BOG-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301285, 'FangBlade PBLC19', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301289, 'GH5007 Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301290, 'FangBlade 10Anniv', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301291, 'GH5007 PostApocalypse Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301131, 'Keris GSL2016', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301065, 'Keris G ESports', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301202, 'Keris Kemerde', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301129, 'Keris Beast', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202001, 'DesertEagle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202005, 'DesertEagle REF', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202007, 'ColtPython', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301282, 'FangBlade Technicolor', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301249, 'Karambit Renegade2', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301262, 'GH5007 Halloween2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301178, 'FangBlade Renegade', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202010, 'ColtPython Gold Exp Pt 10', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202011, 'Glock18', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202012, 'ColtPython D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202018, 'ColtPython Gold D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202019, 'MK23 Silencer D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202020, 'ColtPython P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202021, 'Glock18 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202022, 'Colt45', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202024, 'Kriss Vector SDP', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202025, 'Hk45', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202030, 'DesertEagle EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202031, 'Colt45 100M', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202032, 'DesertEagle GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202035, 'MK23 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202036, 'DesertEagle Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202037, 'Glock18 Turkey', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202038, 'Hk45 Halloween', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202048, 'DesertEagle BR Camo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202051, 'DesertEagle G ESports', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202076, 'ColtPython LATIN5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202090, 'DesertEagle Lebaran2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202102, 'Luger P08', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202139, 'DesertEagle Nevasca', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202145, 'DesertEagle Space-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202163, 'Glock18 Splash', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202165, 'DesertEagle Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202183, 'DesertEagle Ramadan19-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301002, 'M-9', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301004, 'Kukrii', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301006, 'MiniAxe Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301007, 'MiniAxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301008, 'MiniAxe E', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301009, 'M-7 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301011, 'Kukrii D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301012, 'MiniAxe D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301013, 'MiniAxe Dummy D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301026, 'Kukrii EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301027, 'MiniAxe EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301028, 'MiniAxe Dummy EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301033, 'M-7 MiniAxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301034, 'M-7 MiniAxe D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301035, 'M-7 MiniAxe EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301036, 'M-7 BallisticKnife', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301042, 'M-9 PBNC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301085, 'Madness M-7', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301086, 'Madness Kukrii', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301090, 'Madness Arabian Sword', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301091, 'Madness Death Scythe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301092, 'Madness GH5007', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301107, 'Kunai', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301117, 'M-7 BallisticKnife DELUXE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301118, 'M-7 BallisticKnife SPY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301120, 'Monkey Hammer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301121, 'Monkey Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301125, 'M-9 VeraCruz2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301128, 'Kunai Serpent', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301140, 'MiniAxe Poison', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301141, 'MiniAxe Dummy Poison', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301142, 'M-7 MiniAxe Poison', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301158, 'Sword TH', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301177, 'Sword Samurai', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301217, 'Rudolph Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301219, 'Puppy Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301230, 'M-9 Digital', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301234, 'Kukrii PBWC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301242, 'M-9 3rdAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301269, 'M-9 Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301271, 'Kukrii BlackCat', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301274, 'Pig Hammer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301275, 'Pig Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301276, 'TrenchKnife', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301277, 'Vaquinha Hammer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301279, 'Vaquinha Hammer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301286, 'Kukrii Shark', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301287, 'Kukrii PBWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301288, 'Kukrii PBIWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104033, 'AKS74U Zoom', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104096, 'AKS74U Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106001, '870MCS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106002, '870MCS E', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106003, 'SPAS15', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106004, '870MCS W', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106005, 'M1887', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106008, '870MCS Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106009, 'SPAS15 Silver ExpPt 20', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106010, 'M1887 W', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106011, '870MCS W D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106012, 'SPAS15 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301174, 'Keris PBGC2017', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301253, 'Keris PBTC2018', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301268, 'Keris Zepetto', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301198, 'Keris PBNC2017', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106013, 'M26 LSS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106014, '870MCS Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106015, '870MCS D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106016, 'SPAS15 Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106017, 'M1887 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106018, 'SPAS15 MSC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106020, 'Kel Tec KSG 15', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106021, 'M1887 SL', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106022, 'SPAS15 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106023, '870MCS W EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106025, 'M26 LSS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106028, 'M1887-W GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106029, 'SPAS15 PBSC2013', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106033, 'M1887-W TH 1YEAR', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106039, 'UTS-15', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106040, 'SPAS15 PBSC2013 NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106043, 'Remington ETA', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106044, 'Remington ETA Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106046, 'UTS-15 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106048, 'UTS-15 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106053, 'M1887 PBNC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106059, 'M1887 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106060, 'M1887 Medical', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106061, 'M1887 Steam', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106062, 'M1887 Obsidian', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106063, 'M1887 Arena-Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106071, 'M1887 ID 1stAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106075, 'M1887 Woody', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106077, 'M1887 Liberty', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106086, 'M1887 Pahlawan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106092, 'SPAS15 Fire', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106094, 'M1887 PBGC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106104, 'M1887 Mech ID', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106106, 'M1887 Nagi-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106107, 'M1887 Nagi-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106109, 'M1887 ID 2stAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106111, 'M1887 Vacance17', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106116, 'M1887 Ottoman', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106125, 'M1887 Chicano Durability', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106127, 'M1887 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106128, 'SPAS15 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106129, 'Remington ETA Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106130, 'Jackhammer Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106131, 'M1887 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106132, 'SPAS15 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106133, 'Remington ETA Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106135, 'M1887 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106136, 'SPAS15 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106141, 'M1887 Nusantara', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106146, 'M1887 PBWC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106148, 'M1887 Ramazan2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106150, 'UTS-15 3rdAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106160, 'M1887 Oni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106161, 'M1887 Viper', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106162, 'M1887 Sacrifice', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106167, 'SPAS15 Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106170, 'M1887 Xmas2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106173, 'M1887 BOG-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106177, 'M1887 Lycan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106179, 'SPAS15 Shark', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106180, 'M1887 PBWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106181, 'M1887 PBIWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106182, 'M1887 10Anniv', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202006, 'P99', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202027, 'MK23 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202094, 'U22-Neos', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202095, 'U22-Neos Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202096, 'U22-Neos Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202112, 'TEC-9', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (230001, 'SuperShorty870', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104401, 'KrissSuperV Green Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104012, 'KrissSuperV Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104013, 'KrissSuperV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104018, 'KrissSuperV Cupid Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104019, 'KrissSuperV Event', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104026, 'KrissSuperV Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104028, 'KrissSuperV Gold Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104030, 'KrissSuperV Dummy D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104031, 'KrissSuperV D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104039, 'KrissSuperV Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104040, 'KrissSuperV Black Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104047, 'KrissSuperV Batik D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104050, 'KrissSuperV ESports', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104051, 'KrissSuperV ESports Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104052, 'KrissSuperV Batik', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104053, 'KrissSuperV Batik Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104065, 'KrissSuperV EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104073, 'KrissSuperV EV Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104076, 'AKS74U Zoom 100M', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104083, 'KrissSuperV GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104084, 'KrissSuperV GRS Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104088, 'KrissSuperV GSL Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104090, 'KrissSuperV Black P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104091, 'KrissSuperV Black P Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104093, 'KrissSuperV GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104094, 'KrissSuperV GRS EV Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104102, 'KrissSuperV 4th Anniversary Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104131, 'KrissSuperV GSL2014 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106156, 'M1887 Renegade2', 3, '100', '100', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106126, 'JackHammer Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106134, 'JackHammer Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106019, 'JackHammer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104140, 'KrissSuperV Brazuca Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104143, 'KrissSuperV Champion Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104156, 'KrissSuperV G ESports Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104173, 'KrissSuperV CNY-2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104176, 'KrissSuperV GRS2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104193, 'EVO3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104213, 'KrissSuperV DarkDays Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104224, 'KrissSuperV Basketball Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104238, 'KrissSuperV Halloween Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104246, 'KrissSuperV DFN Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104257, 'KrissSuperV GRS3 DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104259, 'KrissSuperV Beast Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104264, 'KrissSuperV GSL2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104271, 'KrissSuperV E-Sports2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104287, 'KrissSuperV Demonic Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104299, 'KrissSuperV Alien Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104319, 'KrissSuperV DarkSteel Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104331, 'KrissSuperV Gorgeous Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104346, 'KrissSuperV Chicken Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104358, 'KrissSuperV Beyond Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104367, 'KrissSuperV Cursed Valentine Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104382, 'KrissSuperV GSL2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104390, 'KrissSuperV Chicano Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104392, 'KrissSuperV Beach Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104397, 'KrissSuperV Comic Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104399, 'BattleBox Dragon Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104427, 'KrissSuperV Graffiti Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104434, 'APC9', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104469, 'KrissSuperV Darkness Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104472, 'KrissSuperV 7th Anniversary Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104520, 'KrissSuperV FireDragon Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104528, 'KrissSuperV DesertHound Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104533, 'KrissSuperV Freedom Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104546, 'KrissSuperV Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104547, 'KrissSuperV Blue Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104574, 'KrissSuperV GRSV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104575, 'KrissSuperV GRSV Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104584, 'KrissSuperV Graduation Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104599, 'KrissSuperV Digital Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202016, 'Taurus 454SS Scope', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104616, 'KrissSuperV GSL2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104636, 'KrissSuperV 3rdAnni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104640, 'KrissSuperV Arcade Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104663, 'KrissSuperV GhostHouse Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104667, 'KrissSuperV Bhinneka Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104714, 'KrissSuperV BlackCat Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104729, 'KrissSuperV GunZeeD Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104786, 'KrissSuperV 10Anniv Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104801, 'KrissSuperV GLS Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104809, 'KrissSuperV 9th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104818, 'KrissSuperV Crimson Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104079, 'KrissSuperV PBTN', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104080, 'KrissSuperV PBTN Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104104, 'KrissSuperV PBIC2013 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104124, 'KrissSuperV R Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104126, 'KrissSuperV Inferno', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104127, 'KrissSuperV Inferno DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104133, 'KrissSuperV Midnight Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104149, 'KrissSuperV Midnight NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104150, 'KrissSuperV Midnight NonLogo Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104152, 'KrissSuperV PC Cafe Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104154, 'KrissSuperV PBSC2014 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104184, 'KrissSuperV PBNC6 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104186, 'KrissSuperV Ongame Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104189, 'KrissSuperV Redemption DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104197, 'KrissSuperV Harimau Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104206, 'KrissSuperV PBNC2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104208, 'KrissSuperV PBTC2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104211, 'KrissSuperV Mech Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104217, 'KrissSuperV PBIC2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104243, 'KrissSuperV Obsidian Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104254, 'KrissSuperV Monkey Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104261, 'KrissSuperV PBGC Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104266, 'KrissSuperV Midnight2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104276, 'KrissSuperV PBWC Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104279, 'KrissSuperV Mummy Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104281, 'KrissSuperV ID 1stAnni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104296, 'KrissSuperV Lebaran2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104305, 'KrissSuperV Puzzle Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104313, 'KrissSuperV PBIC2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104317, 'KrissSuperV PBTC2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104322, 'KrissSuperV PBNC2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104323, 'KrissSuperV PBST2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104324, 'KrissSuperV PBST2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104335, 'KrissSuperV Mystic Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104343, 'KrissSuperV Ice Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104710, 'KrissSuperV DemonHunter Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104356, 'KrissSuperV Pirates Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104372, 'KrissSuperV PBGC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104388, 'KrissSuperV Renegade Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104394, 'KrissSuperV Naga Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104404, 'KrissSuperV MNB3 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104409, 'KrissSuperV PBWC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104417, 'KrissSuperV Lebaran2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104424, 'KrissSuperV ID 2stAnni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104447, 'KrissSuperV Phantom Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104451, 'KrissSuperV PBTC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104453, 'KrissSuperV PBNC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104459, 'KrissSuperV Ottoman Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104480, 'KrissSuperV PBST-ES Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104484, 'KrissSuperV Military Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104490, 'KrissSuperV PBIC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104510, 'KrissSuperV PBIWC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104553, 'KrissSuperV Pandora Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104560, 'KrissSuperV RRQ Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104577, 'KrissSuperV Red Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104579, 'KrissSuperV Nusantara Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104600, 'KrissSuperV M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104601, 'KrissSuperV M1LGR4U Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104604, 'KrissSuperV Maze Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104610, 'KrissSuperV PBWC2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104620, 'KrissSuperV MNB4 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104625, 'KrissSuperV Ramazan2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104627, 'KrissSuperV Paladin Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104631, 'KrissSuperV Lebaran2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104648, 'KrissSuperV Milkyway Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104656, 'KrissSuperV LatinChampionship2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104672, 'KrissSuperV PBTC2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104681, 'KrissSuperV Oni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104688, 'KrissSuperV Sacrifice Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104696, 'KrissSuperV PBIC2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104737, 'KrissSuperV NewYear2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104743, 'KrissSuperV Lovely Valentine Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104761, 'KrissSuperV Komodo Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104765, 'KrissSuperV Lycan Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104775, 'KrissSuperV PBWC2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104779, 'KrissSuperV PBIWC2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104822, 'KrissSuperV Independence817 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104814, 'KrissSuperV PinkyPig Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104004, 'MP7 DotSight', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104007, 'MP5K SERIF', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104014, 'MP5K Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104015, 'MP5K White', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104022, 'MP7 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104034, 'M4-CQBR-LV1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104035, 'M4-CQBR-LV2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104036, 'M4-CQBR-LV3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104037, 'MP7 Silver P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104038, 'MP7 Camo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104041, 'MP5K Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104045, 'MP7 DotSight D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104054, 'KrissSuperV Vector', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104055, 'KrissSuperV Vector Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104056, 'MP7 NON EXT', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104059, 'MP7 SE2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104063, 'MP5K G EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104066, 'MP7 Ext EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104070, 'M4-CQBR-LV1 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104071, 'M4-CQBR-LV2 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104072, 'M4-CQBR-LV3 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104100, 'MP5K Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104105, 'MP7 GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104107, 'MP9 Ext', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104109, 'KrissSuperV SILENCE Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104110, 'KrissSuperV Turkey', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104111, 'KrissSuperV Turkey Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104117, 'KrissSuperV Serpent Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104122, 'KrissSuperV TH 1YEAR DUMMY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104134, 'OA93', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104144, 'KrissSuperV WOE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104145, 'KrissSuperV WOE Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104157, 'KrissSuperV Toy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104158, 'KrissSuperV Toy Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104192, 'KrissSuperV Summer Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104222, 'KrissSuperV Sheep Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104226, 'OA93 Basketball Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104231, 'MP9 Ext D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104235, 'KrissSuperV Steam', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104250, 'KrissSuperV Xmas2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104268, 'KrissSuperV Skeleton Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104283, 'KrissSuperV Strike', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104284, 'KrissSuperV Strike Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104353, 'MX4 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104354, 'MX4 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104360, 'OA93 Beyond Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104378, 'KrissSuperV Salvation Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104386, 'KrissSuperV Samurai Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104706, 'KrissSuperV Halloween2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104442, 'KrissSuperV Vacance17 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104475, 'OA93 Aguila Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104492, 'KrissSuperV TSE Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104503, 'KrissSuperV Silence Shatter UM', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104504, 'KrissSuperV Silence Shatter UM Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104538, 'OA93 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104539, 'OA93 Black Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104541, 'MP9 Ext Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104549, 'OA93 Blue Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104551, 'MP9 Ext Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104564, 'KrissSuperV Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104612, 'KrissSuperV Vittoria Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104638, 'OA93 3rdAnni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104642, 'OA93 Arcade Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104644, 'KrissSuperV Surfing Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104660, 'KrissSuperV Silence Renegade2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104669, 'OA93 Bhinneka Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104685, 'KrissSuperV Viper Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104716, 'OA93 BlackCat Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104718, 'KrissSuperV Zepetto Silence Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104725, 'KrissSuperV Xmas2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104738, 'MP40', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104739, 'MP40 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104740, 'MP40 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104746, 'KrissSuperV Snack Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104771, 'KrissSuperV Shark Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104788, 'OA93 10Anniv Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104793, 'KrissSuperV Silence Gold Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104806, 'KrissSuperV Summer2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104811, 'OA93 9th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104812, 'OA93 9th Anniversary Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104159, 'OA93 Q', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104160, 'OA93 Q Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104199, 'OA93 Independence Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104204, 'OA93 PBST2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104136, 'OA93 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104137, 'OA93 Gold Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104181, 'OA93 GSL2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104215, 'OA93 PBNC2015 US Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104229, 'OA93 Medical Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104233, 'OA93 Cobra Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104248, 'OA93 DFN Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104274, 'OA93 PBWC Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104303, 'OA93 Newborn2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104315, 'OA93 PBIC2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104329, 'OA93 Halloween2016 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104337, 'OA93 Pahlawan Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104350, 'OA93 Hybridman Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104363, 'OA93 MechHero Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104369, 'OA93 Cursed Valentine Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104374, 'OA93 PBGC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104384, 'OA93 GSL2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104406, 'OA93 MNB3 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104411, 'OA93 PBWC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104413, 'OA93 MechHero ID', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104422, 'OA93 ID 2stAnni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104440, 'OA93 Bolt Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104449, 'OA93 Phantom Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104477, 'OA93 PBST-ES Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104487, 'OA93 Military Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104499, 'OA93 Halloween2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104512, 'OA93 PBIWC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104530, 'OA93 DesertHound Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104555, 'OA93 Pandora Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104557, 'OA93 Puppy Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104597, 'OA93 Holi Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104608, 'OA93 PBWC2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104618, 'OA93 GSL2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104622, 'OA93 MNB4 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104629, 'OA93 Paladin Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104649, 'OA93 Milkyway', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104650, 'OA93 Milkyway Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104674, 'OA93 PBTC2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104683, 'OA93 Oni Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104693, 'OA93 PBST2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104694, 'OA93 PBST2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104698, 'OA93 PBIC2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104731, 'OA93 GunZeeD Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104735, 'OA93 NewYear2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104769, 'OA93 PBLC19 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104777, 'OA93 PBWC2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104781, 'OA93 PBIWC2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104782, 'OA93 Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104783, 'OA93 Independence2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104820, 'OA93 Crimson Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104816, 'OA93 PinkyPig Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104009, 'Spectre SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104010, 'P90MC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104016, 'Spectre White', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104027, 'P90MC Camo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104032, 'P90MC D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104708, 'OA93 Halloween2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104548, 'T77 Cendrawasih', 3, '100', '99999', '99999', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104042, 'Spectre Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104043, 'Pindad SS1 R5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104049, 'Pindad SS1 R5 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104057, 'Spectre NON EXT', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104062, 'Spectre W EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104064, 'P90MC S EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104069, 'P90 Ext EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104074, 'Spectre Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104075, 'P90 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104077, 'P90 W PBSC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104078, 'P90 PBTN', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104756, 'OA93 EvosGalaxy Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104365, 'OA93 Fire Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104523, 'OA93 FireDragon Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104665, 'OA93 GhostHouse Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104803, 'OA93 GLS Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104333, 'OA93 Gorgeous Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104586, 'OA93 Graduation', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104587, 'OA93 Graduation Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104429, 'OA93 Graffiti Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104432, 'OA93 Kareem Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104462, 'OA93 Kemerde Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104763, 'OA93 Komodo Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104525, 'OA93 Latin7 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104632, 'OA93 Lebaran2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104633, 'OA93 Lebaran2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104310, 'OA93 Liberty Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104767, 'OA93 Lycan Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104606, 'OA93 Maze Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104494, 'OA93 Rebel Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104542, 'OA93 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104543, 'OA93 Red Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104658, 'OA93 Renegade2 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104563, 'OA93 RRQ Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104773, 'OA93 Shark Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104508, 'OA93 Shatter UM Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104505, 'OA93 Shatter Z1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104506, 'OA93 Shatter Z1 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104082, 'P90 MC GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104085, 'P90 NEWBORN', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104086, 'P90MC PBNC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104095, 'P90 MC GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104098, 'Spectre Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104106, 'PP19', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104113, 'P90MC LATIN3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104125, 'P90 NEWBORN 2014', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104147, 'P90 W PBSC NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104148, 'P90MC LATIN3 NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104162, 'PP19 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104174, 'P90MC Sheep', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104219, 'P90 MC Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104234, 'P90MC Camo-Soldier', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104240, 'P90MC SPY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104241, 'P90 MC LATIN5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104244, 'P90 MC Spy-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104307, 'PP19 Russian Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104308, 'PP19 Russian Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104419, 'P90 MC Nagi-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104420, 'P90 MC Nagi-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104433, 'P90 MC Kareem', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104481, 'P90 MC PBST-ES', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104513, 'T77', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104514, 'T77 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104516, 'T77 Silver Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104518, 'T77 Gold Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104526, 'P90 MC Latin7', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104567, 'OA93 Zepetto Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104571, 'P90 Ext GRSV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104585, 'P90 Ext Graduation', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104590, 'OA93 Space-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104591, 'OA93 Space-Basic Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104592, 'OA93 Space-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104593, 'OA93 Space-Deluxe Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104704, 'OA93 Splash Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104720, 'OA93 Zepetto Silence Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104723, 'P90 MC Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104748, 'OA93 Snack Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104794, 'P90 Ext Silence Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104798, 'P90 MC Ramadan19-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104808, 'OA93 Summer2019 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104827, 'OA93 Spider Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104023, 'UMP45 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104046, 'UMP45 DualMag D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104058, 'UMP45 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104068, 'UMP45 Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104092, 'UMP45 Black P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104097, 'UMP45 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105002, 'HK-PSG1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105005, 'L115A1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104652, 'Thompson', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104653, 'Thompson Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104678, 'Thompson Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104679, 'Thompson Gold Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104791, 'Thompson 10Anniv Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104676, 'Thompson Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104677, 'Thompson Silver Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105007, 'HK-PSG1 S', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105009, 'HK-PSG1 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105016, 'HK-PSG1 S D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105017, 'L115A1 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105026, 'L115A1 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105030, 'Cheytac M200', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105032, 'Barrett', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105034, 'DSR-1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105042, 'HK-PSG1 Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105052, 'Cheytac M200 GRS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105055, 'Cheytac M200 GSL', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105056, 'L115A1 Black P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105058, 'Cheytac M200 GRS EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105059, 'HK-PSG1 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105063, 'Cheytac M200 Turkey', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105073, 'Cheytac M200 R', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105079, 'Cheytac M200 Inferno', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105082, 'Barrett P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105086, 'Cheytac M200 WOE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105091, 'Cheytac M200 G ESports', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104570, 'P90 Ext Acrylic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104540, 'P90 Ext Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104654, 'P90 Ext Brazuca3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104282, 'P90 Ext ID 1stAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104784, 'P90 Ext Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104602, 'P90 Ext M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104210, 'P90 Ext Mech', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104415, 'P90 Ext Mech ID', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104544, 'P90 Ext Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104646, 'OA93 Surfing Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104444, 'OA93 Vacance17 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104687, 'OA93 Viper Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104614, 'OA93 Vittoria Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104301, 'OA93 Woody Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104252, 'OA93 Xmas2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104535, 'OA93 Xmas2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104727, 'OA93 Xmas2018 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104166, 'OA93 Xmax Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105095, 'DSR-1 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105098, 'DSR-1 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105120, 'Cheytac M200 PBIC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105121, 'Cheytac M200 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105122, 'Cheytac M200 VeraCruz', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105130, 'Cheytac M200 Steam', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105133, 'DSR 1 SPY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105135, 'Cheytac M200 Obsidian', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105136, 'DSR 1 Spy-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105138, 'Cheytac M200 Xmas2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105143, 'Cheytac M200 VeraCruz2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105144, 'Cheytac M200 Silence', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105157, 'AS 50', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105159, 'AS 50 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105164, 'AS 50 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105166, 'Cheytac M200 Strike', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105186, 'Cheytac M200 PBNC2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105187, 'Cheytac M200 PBST2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105223, 'Cheytac M200 Nagi-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105224, 'Cheytac M200 Nagi-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105228, 'L115A1 Brazuca2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105237, 'Cheytac M200 PBNC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105240, 'Cheytac M200 Ottoman', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105245, 'L115A1 7th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105253, 'Cheytac M200 TSE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105257, 'Cheytac M200 Shatter Z1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105262, 'Cheytac M200 Latin7', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105267, 'AS 50 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105271, 'AS 50 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105273, 'Cheytac M200 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105276, 'AS 50 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105277, 'Barrett Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105279, 'L115A1 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105295, 'Cheytac M200 Space-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105302, 'Cheytac M200 M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105303, 'Cheytac M200 Maze', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105304, 'Cheytac M200 PBWC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105310, 'Cheytac M200 WhiteRabbit', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105339, 'Kar98k Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105349, 'Cheytac M200 RustIron', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105355, 'Cheytac M200 Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105364, 'AS 50 BOG-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105365, 'AS 50 BOG-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105375, 'BORA12', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105376, 'BORA12 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105377, 'BORA12 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105384, 'Cheytac M200 PBIWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105389, 'Cheytac M200 PostApocalypse Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105394, 'Cheytac M200 Summer2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105001, 'SVD-Dragunov', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105004, 'SSG69 Camo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105006, 'SVD-Dragunov SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105008, 'SSG69 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105010, 'SVD-Dragunov Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105012, 'SVD-Dragunov KingCobra Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105014, 'SVD-Dragunov G D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105015, 'L115A1 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105018, 'M4-SPR-LV1', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105019, 'M4-SPR-LV2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105020, 'M4-SPR-LV3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105021, 'RangeMaster338', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105022, 'RangeMaster762', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105023, 'RangeMaster762Stby', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105025, 'SSG69 IN MODE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105027, 'SSG69 Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105028, 'SVD-Dragunov D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105029, 'VSK94', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105033, 'L115A1 ESports', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105035, 'SVU', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105036, 'L115A1 SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105039, 'SVD-Dragunov G EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105040, 'SVD-Dragunov Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105041, 'L115A1 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105043, 'SSG69 Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105044, 'M4-SPR-LV1 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105045, 'M4-SPR-LV2 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105046, 'M4-SPR-LV3 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105047, 'SVD-Dragunov Flame', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105048, 'VSK94 100M', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105050, 'L115A1 PBTN', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105054, 'SVU SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105061, 'RangeMaster762 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105062, 'RangeMaster762Stby Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105068, 'XM2010', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105072, 'Walther wa2000', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105074, 'Walther wa2000 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105076, 'SVD-Dragunov Elite', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105077, 'SVU Elite', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105081, 'L115A1 GSL2014', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105085, 'SVD-Dragunov WOE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105141, 'Cheytac M200 Arena-Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105272, 'Barrett Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105190, 'Cheytac M200 Azerbaijan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105269, 'Cheytac M200 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105278, 'Cheytac M200 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105088, 'L115A1 LATIN3 NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105094, 'SVU Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105116, 'SVU PBTC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105123, 'Tactilite T2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105128, 'RangeMaster338 Camo-Soldier', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105132, 'Tactilite T2 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105145, 'PGM-Hecate2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105146, 'PGM-Hecate2 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105179, 'SVD-Dragunov Russian Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105221, 'Tactilite T2 MechHero ID', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105274, 'L115A1 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105284, 'L115A1 Nevasca', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105317, 'SKS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105319, 'PGM-Hecate2 3rdAnni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105331, 'Tactilite T2 Renegade2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105336, 'SKS Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105337, 'SKS Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105345, 'Tactilite T2 RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105346, 'Tactilite T2 Gold RB', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105357, 'Tactilite T2 Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105360, 'Tactilite T2 Xmas2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407002, 'C5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407003, 'C5 D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407006, 'C5 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407012, 'Decoy bomb', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407015, 'K-400 Easter', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407025, 'K-400 Goat', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407044, 'C5 CNY-2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407053, 'C5 PBWC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407054, 'K-400 Mummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407056, 'K-400 Alien', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407062, 'C5 PBNC2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407065, 'K-400 Fire', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407072, 'C5 PBWC2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407077, 'C5 Sacrifice', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407081, 'C5 Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407082, 'K-400 Xmas2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407083, 'K-400 BOG-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407084, 'K-400 BOG-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407087, 'C5 PBWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407088, 'C5 PBIWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407089, 'K-400 Ramadan19-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407004, 'K-413', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407007, 'K-413 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407008, 'Ketupat Grenade', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104017, 'P90 Ext Cupid', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104344, 'P90 Ext Ice', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104190, 'P90 Ext Redemption', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103552, 'AUG A3 Shark', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103148, 'AUG-A3 PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103149, 'AUG A3 GSL2014', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105396, 'Tactilite T2 9th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105270, 'Tactilite T2 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105280, 'Tactilite T2 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105327, 'Tactilite T2 Brazuca3', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105386, 'Tactilite T2 Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104267, 'KrissSuperV Skeleton', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103202, 'AUG A3 Emblem-Columbia', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103256, 'AUG A3 Beast', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103259, 'AUG A3 Tiger-Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103297, 'Pindad SS2 V5 PBNC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103324, 'AUG A3 Beyond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103343, 'AUG A3 Beach', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103350, 'AUG A3 PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103386, 'AUG A3 Military', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103402, 'SC 2010 DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103440, 'SC 2010 Nusantara', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103466, 'SC 2010 Silence', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103486, 'Pindad SS2 V5 PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103494, 'AUG A3 PBST2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103528, 'SC 2010 GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103298, 'AUG A3 PBST2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103567, 'SC 2010 Ramadan19-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104060, 'KrissSuperV IC', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104087, 'KrissSuperV GSL', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104101, 'KrissSuperV 4th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104155, 'KrissSuperV G ESports', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104205, 'KrissSuperV PBNC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104302, 'OA93 Newborn2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103178, 'AUG-A3 CoupleBreaker', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103341, 'AUG A3 Chicano', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407013, 'M14 Mine', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407014, 'K-479', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407019, 'K-413 Traditional', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407020, 'K-413 PC Cafe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407021, 'ShuttleCock Grenade', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407022, 'Sepaktakraw Grenade', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407024, 'K-413 GW', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407045, 'K-413 Chocolate', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407046, 'K-413 Redemption', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407047, 'K-413 4Game', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407048, 'K-413 4Game-SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407051, 'K-413 Tiger-Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407052, 'K-413 Tiger-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407057, 'K-413 Puzzle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407059, 'K-413 Russian Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407063, 'K-413 Ice', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407071, 'K-413 Maze', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407075, 'K-413 Football Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407076, 'K-413 Football Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407079, 'Pumpkin Bomb', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118191, 'OA93 Dual DesertHound', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104171, 'KrissSuperV CoupleBreaker Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106139, 'M1887 Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103001, 'SG550 DotSight', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103045, 'M4-SR16-FC', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103082, 'M4-SR16-LV1 EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103176, 'SCAR-L Recon D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103211, 'AUG-A3 Jordan', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104613, 'OA93 Vittoria', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105057, 'Cheytac M200 BLOODY', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105154, 'Tactilite T2 GSL2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202128, 'Taurus 454SS Scope Brightness', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103081, 'M4A1 Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301049, 'Arabian Sword2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202135, 'Taurus 454SS Scope DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202158, 'Taurus 454SS Scope PBTC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105210, 'Tactilite T2 Samurai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104366, 'KrissSuperV Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104377, 'KrissSuperV Salvation', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104699, 'OA93 RustIron', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104416, 'KrissSuperV Lebaran2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103105, 'FAMAS G2 Commando GSL', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104713, 'KrissSuperV BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104742, 'KrissSuperV Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105065, 'L115A1 BR CAMO', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105087, 'Cheytac M200 PBIC2014', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105114, 'Cheytac M200 PBNC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105152, 'Cheytac M200 PBGC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105172, 'Cheytac M200 Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105196, 'Cheytac M200 Hybridman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105238, 'Tactilite T2 PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105256, 'Cheytac M200 Halloween2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105281, 'Tactilite T2 Pandora', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105290, 'Cheytac M200 GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105315, 'Cheytac M200 Paladin', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105325, 'Tactilite T2 Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105347, 'Cheytac M200 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103365, 'AUG A3 Bolt', 2, '86400,259200', '1000,2700', '0,0', 0, 5, 't', 0);
INSERT INTO "public"."item_goods" VALUES (528015, 'Medical Kit SignaturePB', 3, '100', '100', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103275, 'AUG A3 Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103509, 'AUG A3 Halloween2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104659, 'KrissSuperV Silence Renegade2', 2, '259200,2592000', '3000,8000', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105369, 'Cheytac M200 Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106026, 'M1887-W GRS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106035, 'M1887 PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106052, 'M1887 Summer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106098, 'M1887 Chicano', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106155, 'M1887 LatinChampionship2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106163, 'M1887 PBIC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202008, 'DesertEagle Gold', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202060, 'ColtPython Brazil', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214019, 'DesertEagle Dual Lebaran2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214022, 'Scorpion Vz61 Newborn2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301093, 'GH5007 Brazil', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104795, 'P90 Ext Ramadan19-Basic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202081, 'Taurus 454SS Scope VeraCruz2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104572, 'OA93 GRSV', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103410, 'Famas G2 Commando Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104001, 'MP5K Silencer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104002, 'Spectre SteadyAim', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104008, 'UMP45 DualMag', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104020, 'Spectre Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104061, 'KrissSuperV IC Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104067, 'MP5K Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104099, 'Pindad SS1 R5 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104135, 'OA93 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104169, 'KrissSuperV Xmas Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104179, 'KrissSuperV NEWBORN 2015 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104293, 'OA93 BlueDiamond Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104348, 'KrissSuperV Hybridman Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104438, 'KrissSuperV Bolt Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104456, 'OA93 PBNC2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104581, 'OA93 Nusantara Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104582, 'P90 Ext Nusantara', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104595, 'KrissSuperV Rebel PC Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104754, 'KrissSuperV EvosGalaxy Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104792, 'KrissSuperV Silence Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104797, 'KrissSuperV Ramadan19-Deluxe Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105038, 'HK-PSG1 S EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105049, 'SVD-Dragunov KingCobra Gold P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105115, 'Cheytac M200 PBTC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105275, 'Tactilite T2 Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105328, 'Cheytac M200 Football Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106007, '870MCS IN MODE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106030, 'M1887 BLOODY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106095, '870MCS Talos', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106115, 'BattleBox SF Shotgun', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118005, 'Dual Uzi Mini', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118006, 'Dual Uzi Micro', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118008, 'Dual Uzi Mini Silencer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118043, 'OA93 Dual Q', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118125, 'OA93 Dual PBGC2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (1800049, 'Reset Win/Lose', 1, '1', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1800048, 'Reset Win/Lose', 1, '1', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (118193, 'OA93 Dual Xmas2017', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202178, 'ColtPython Independence2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301003, 'Hak Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301032, 'Hak Silver D Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301073, 'ChineseCleaver CNY-2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301088, 'Madness FangBlade', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301109, 'BoneKnife Camo-Soldier', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301149, 'FangBlade Alien', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301210, 'Syringe Halloween', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301228, 'ButterflyKnife Space-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104320, 'P90 Ext DarkSteel', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105229, 'Cheytac M200 Brazuca2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202050, 'Taurus 454SS Scope PBSC2013 NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601262, 'D-Fox Pilot', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601105, 'ViperRed Chipao', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601129, 'Rica Bouncer', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602368, 'Chou GIGN', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601370, 'Rica Camocoat', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301165, 'Kukrii Pahlawan', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301203, 'Karambit 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301160, 'Arabian Sword PBNC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104479, 'KrissSuperV PBST-ES', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601399, 'Rica Halloween Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602167, 'KeenEyes FireFight', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602204, 'Chou Cavaliers', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602175, 'KeenEyes Police Squad', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103086, 'AK-47 Taiwan1', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (118283, 'OA93 Dual SignaturePB Silence', 3, '100', '100', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602212, 'Chou Zombie', 3, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601249, 'Rica General', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602237, 'Leopard Hitman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104712, 'OA93 DemonHunter Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118269, 'OA93 Dual DemonHunter', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103185, 'SC 2010 NEWBORN 2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103282, 'FAMAS G2 Commando Newborn2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103434, 'AUG A3 HeartValentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104450, 'KrissSuperV PBTC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104647, 'KrissSuperV Milkyway', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601015, 'REBEL ViperRed', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407068, 'VallyBall Bomb', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601010, 'Rica', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301293, 'FangBlade Ramadan19-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315009, 'Dual BoneKnife PBNC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315034, 'M-9 Dual Zepetto', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407016, 'Football bomb', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407058, 'K-413 Russian Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103299, 'AUG-A3 Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103033, 'AK-SOPMOD Exp Pt 20', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103249, 'AUG A3 Silence', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103445, 'AUG A3 Space-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103446, 'AUG A3 Space-Deluxe', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103272, 'AUG A3 Strike', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103119, 'AK-47 Elite', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103409, 'AK-47 Chicano Durability', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103062, 'FAMAS G2 Commando ESports', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103161, 'AUG-A3 LATIN3 NonLogo', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103406, 'AUG-HBAR', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103416, 'Famas G2 Commando Red', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103035, 'SG550 Camo D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103154, 'SC 2010 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214010, 'DesertEagle DualGold P', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315013, 'Dual BoneKnife Skeleton', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118009, 'Dual Uzi Micro Silencer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118127, 'OA93 Dual Cursed Valentine', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118213, 'OA93 Dual Graduation', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104163, 'P90 Ext LATIN4', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105083, 'Cheytac M200 Brazuca', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700038, 'A E Beret Brazuca3', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700004, 'A E Beret Bope', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103024, 'M4A1 G Exp Pt 30', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103423, 'Pindad SS2 V5 Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700035, 'A E Beret M1LGR4U', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700034, 'A E Beret RRQ', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700010, 'A E Beret Turkey', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601145, 'D-Fox Valentine16', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106122, 'M1887 Freedom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202064, 'DesertEagle Lebaran2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602194, 'Hide BunnyGirl', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601003, 'Tarantula', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602034, 'Hide Kopassus', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700002, 'A E Beret Brazil', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700003, 'A E Beret BlackPB', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700006, 'A E Beret Kopassus', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700005, 'A E Beret CrossSword', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700025, 'A E Beret Fire', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700007, 'A E Beret Star-Red', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700012, 'A E Beret PBNC5', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700008, 'A E Beret S-General', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700022, 'A E Beret Russian Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700019, 'A E Beret VeraCruz2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700011, 'A E Beret Star-Yellow', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700021, 'A E Beret Strike', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700009, 'A E Beret Super', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700023, 'A E Beret Russian Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700027, 'A E Beret Green', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700031, 'A E Beret Military', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700026, 'A E Beret PBGC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700028, 'A E Beret PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700029, 'A E Beret Blangkon Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700030, 'A E Beret 7th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700024, 'A E Beret PBNC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700032, 'A E Beret FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700033, 'A E Beret DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700001, 'A E Beret Black', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (528011, 'Medical Kit Pigeon', 2, '86400,259200', '1000,2700', '0,0', 0, 3, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315022, 'Dual BoneKnife DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (2700020, 'A E Beret ID 1stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118298, 'OA93 Dual PBIWC2019', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214001, 'MK23-K5 Dual', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (701104, 'A H Headgear Target', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (701106, 'A H Headgear Super', 2, '2592000', '55000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (701209, 'A H Headgear Reinforce Count', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (701105, 'A H Headgear Strengthen Plus', 2, '2592000', '27500', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301263, 'BoneKnife DemonHunter', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315011, 'M-9 Dual VeraCruz2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118215, 'OA93 Dual Space-Basic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (213004, 'P99-Hak CIC Silver D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301151, 'BallisticKnife Russian Normal', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (323005, 'PumpkinKnuckle', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301081, 'Field Shovel Royal Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301173, 'Ice Fork Fire', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301254, 'FangBlade Oni', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202002, 'MK23 Silencer', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202017, 'ColtPython Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202136, 'DesertEagle DesertHound', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301046, 'Kukrii Turkey', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301176, 'Kukrii Talos', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301296, 'Kukrii 9th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106006, 'SPAS15 Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106024, 'SPAS15 Silver EV', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106085, 'M1887 Mystic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106137, 'Remington ETA Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104048, 'KrissSuperV Batik Dummy D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104202, 'KrissSuperV Flame Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104466, 'KrissSuperV Brightness Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104810, 'KrissSuperV 9th Anniversary Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104207, 'KrissSuperV PBTC2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104340, 'KrissSuperV Latin6 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104569, 'KrissSuperV HeartValentine Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104024, 'MP5K SERIF D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104236, 'KrissSuperV Steam Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104565, 'KrissSuperV Zepetto Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104825, 'KrissSuperV Spider Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104414, 'OA93 MechHero ID Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104025, 'Spectre White D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104112, 'P90 MC BLOODY', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104220, 'P90 M.C VeraCruz', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104255, 'P90 MC VeraCruz2016', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104719, 'OA93 Zepetto Silence', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105024, 'HK-PSG1 Gold', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105111, 'Cheytac M200 PBST2015', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105134, 'Cheytac M200 LATIN5', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105167, 'Cheytac M200 Demonic', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105285, 'Cheytac M200 Nevasca', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105011, 'SVD-Dragunov KingCobra Silver', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105060, 'RangeMaster338 Reload', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105119, 'XM2010 PBNC2015 US', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105301, 'Tactilite T2 M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407070, 'K-400 M1LGR4U', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407017, 'K-413 T', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407073, 'K-413 Ramazan2018', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104502, 'KrissSuperV Silence Shatter Z1 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105188, 'Cheytac M200 Supreme', 3, '100', '100', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104326, 'KrissSuperV Supreme Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103376, 'Pindad SS2 V5 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103319, 'Pindad SS2 V5 Lightning', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103568, 'AUG A3 Ramadan19-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104550, 'P90 Ext Blue', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104573, 'OA93 GRSV Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104700, 'OA93 RustIron Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104380, 'OA93 Salvation Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103441, 'AUG-A3 Graduation', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103433, 'AUG A3 Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103455, 'SC 2010 PBWC2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202015, 'Taurus 454SS 8M', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103493, 'Pindad SS2 V5 Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103180, 'AUG A3 CNY-2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103363, 'SC 2010 Brazuca2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103367, 'AUG A3 Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103300, 'AUG A3 Halloween2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103310, 'SIG-Sauer MCX Silver', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103241, 'AUG A3 Xmas2015', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104655, 'KrissSuperV LatinChampionship2', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104796, 'KrissSuperV Ramadan19-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104486, 'OA93 Military', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104385, 'KrissSuperV Samurai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103430, 'SC 2010 RRQ', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103147, 'AUG-A3 Inferno', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104141, 'P90 Ext 5th Anniversary', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104311, 'P90 Ext Liberty', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700037, 'A E Beret Garena', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800001, 'Boeing Sunglasses', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104362, 'OA93 MechHero', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105099, 'Cheytac M200 CoupleBreaker', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105161, 'Tactilite T2 E-Sports2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105388, 'Kar98k 10Anniv', 2, '86400,259200', '2000,4000', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1800085, 'PB Inspector', 1, '50', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602439, 'Chou VampireHunter', 3, '100', '250000', '250000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104709, 'KrissSuperV DemonHunter', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602468, 'Leopard Indiana', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202099, 'Taurus 454SS Scope PBST2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202141, 'ColtPython HeartValentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202171, 'ColtPython Lovely Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202013, 'Taurus 454SS 2M', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202070, 'Taurus 454SS Scope PBIC2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602459, 'Chou FrenchLegion', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800002, 'Mask Gas', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601114, 'Rica Valentine16', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601086, 'Tarantula Demolition', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104393, 'KrissSuperV Naga', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602374, 'Chou Camocoat', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602352, 'Chou SteamPunk', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104278, 'KrissSuperV Mummy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104292, 'OA93 BlueDiamond', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (508003, 'SmokeGrenadePlus', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104121, 'KrissSuperV TH 1YEAR', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104201, 'KrissSuperV Flame', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104347, 'KrissSuperV Hybridman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105342, 'PGM-Hecate2 Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105234, 'Tactilite T2 Vacance17', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105291, 'Tactilite T2 Nusantara', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105176, 'Tactilite T2 Newborn2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105219, 'Tactilite T2 PBWC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105105, 'Cheytac M200 Redemption', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105153, 'Cheytac M200 GSL2016', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106078, 'M1887 PBIC2016', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106113, 'M1887 PBNC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106172, 'M1887 BlackCat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214011, 'DesertEagle Dual GRS', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (214026, 'DesertEagle Dual DesertHound', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301187, 'GH5007 Nagi-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301083, 'Nunchaku', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602206, 'Chou Swimsuit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602213, 'Chou Nurse', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602177, 'Hide Vacance', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601423, 'Rica Rudolph', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104446, 'KrissSuperV Phantom', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601422, 'Tarantula Rudolph', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104692, 'APC9 PBST2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103122, 'AK-47 PBIC2013', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103375, 'AUG A3 Kemerde', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104489, 'KrissSuperV PBIC2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105071, 'Cheytac M200 TH 1YEAR', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105329, 'Cheytac M200 Football Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301257, 'FangBlade Sacrifice', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800005, 'Mask M15 Gas', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800006, 'Sport Sun Glasses', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104594, 'KrissSuperV Rebel PC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (1730008, 'Extended Magazine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301095, 'GH5007 4Game', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103518, 'AK-SOPMOD Zepetto', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602214, 'Chou Chipao', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301180, 'Arabian Sword Beach', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (800009, 'Wiley P Sun Glasses', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800012, 'Standard Face Gurad', 2, '86400,259200', '5000,25000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106042, 'Zombie Slayer', 2, '86400,259200', '2000,4000', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (800013, 'Mask G PB V2 Steel', 2, '86400,259200', '5000,25000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104496, 'KrissSuperV Rebel Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104011, 'P90 Ext', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104473, 'P90 Ext 7th Anniversary', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104430, 'P90 Ext Brazuca2', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800025, 'Mask Yellow Desert', 2, '86400,259200', '5000,25000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800033, 'Mask Red Cross', 2, '86400,259200', '5000,25000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800007, 'Mask Skull Warmer', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601264, 'Rica SantaGuard', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (106088, 'Zombie Slayer Ice', 2, '86400,259200', '2000,4000', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301127, 'FangBlade Sakura', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (407011, 'Maamoul Grenade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602386, 'Leopard Disco', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601140, 'RedBulls Chemical', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602224, 'AcidPol Hitman', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800018, 'Mask Face Magic', 3, '100', '0', '50000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800010, 'Mask PB6200', 3, '100', '0', '50000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800035, 'Mask Gold', 3, '100', '0', '200000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800022, 'Mask Black', 3, '100', '0', '10000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800023, 'Mask Blue Tiger', 3, '100', '0', '50000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (800014, 'Mask Joker', 3, '100', '0', '50000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800019, 'Mask Death', 3, '100', '200000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601369, 'Tarantula Camocoat', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104537, 'KrissSuperV Xmas2017 Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104029, 'P90 Ext D', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104589, 'OA93 LatinChampionship Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103461, 'M4A1 Elite MX', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103022, 'M4A1 White', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103412, 'Pindad SS2 V5 Black', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105113, 'Cheytac M200 4Game-SE', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105322, 'Kar98k', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601018, 'Reinforced REBEL Female', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602242, 'Leopard Boarder', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104519, 'KrissSuperV FireDragon', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601141, 'RedBulls Boarder', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (527003, 'WP SmokeGrenadePlus', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602252, 'Chou General', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (800011, 'Mask Skull Face Guard', 2, '86400,259200', '5000,25000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602158, 'KeenEyes Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103111, 'AUG-A3 BR-Camo', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103228, 'AUG-A3 Camo-Soldier', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103227, 'AUG-A3 Cobra', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103345, 'AUG-A3 Comic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103183, 'AUG-A3 GRS2', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103071, 'AUG-A3 IC', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103467, 'AUG A3 3rdAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202074, 'Kriss Vector SDP Camo-Soldier', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (202093, 'Kriss Vector SDP Puzzle', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104717, 'KrissSuperV Zepetto Silence', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104168, 'KrissSuperV Xmas', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104536, 'KrissSuperV Xmas2017', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104684, 'KrissSuperV Viper', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104611, 'KrissSuperV Vittoria', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104497, 'P90 Ext Rebel', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104251, 'OA93 Xmas2015', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103561, 'Pindad SS2 V5 10Anniv', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103483, 'Pindad SS2 V5 Bhinneka', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105112, 'Cheytac M200 4Game', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105204, 'Tactilite T2 Cursed Valentine', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602322, 'Chou Rugby', 2, '86400,259200', '1000,2700', '0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105268, 'Barrett Black', 2, '86400,259200', '5000,15000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (601299, 'D-Fox Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (800008, 'Mask G PB V2', 2, '86400,259200', '5000,25000', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800024, 'Mask Green Jungle', 2, '86400,259200', '5000,25000', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301294, 'BoneKnife GLS', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202014, 'Taurus 454SS 5M', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301189, 'FangBlade ID 2stAnni', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105362, 'Tactilite T2 GunZeeD', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103303, 'AUG A3 Mystic', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (315018, 'Dual Sword Samurai', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301247, 'Karambit Football Normal', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301292, 'GH5007 PostApocalypse Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202169, 'ColtPython BOG-Deluxe', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202068, 'Taurus 454SS Scope Mech', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202034, 'Taurus 454SS Scope PBSC2013', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106140, 'M1887 HeartValentine', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103471, 'AUG A3 Surfing', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602301, 'Chou FBI', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602337, 'Chou Priest', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602223, 'Leopard Navy', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601278, 'ViperRed Redeye', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601365, 'Tarantula Matilda', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601371, 'ViperRed Camocoat', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601124, 'Rica Zombie', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601097, 'ViperRed Swimsuit', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601012, 'Normal D-Fox', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602377, 'AcidPol FBI-MA', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301144, 'Keris ID 1stAnni', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301023, 'Keris SE', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301047, 'Keris SE XMAS', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301021, 'Keris', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301104, 'Keris PBIC2015', 2, '86400,259200', '2000,4500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301050, 'FangBlade PBNC5', 2, '86400,259200', '1500,3500', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301170, 'Keris Lightning', 3, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301089, 'Madness Keris', 3, '86400,259200', '2000,4500', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104759, 'P90 Ext Technicolor', 3, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104757, 'OA93 Technicolor', 3, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602219, 'AcidPol Santa', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (701103, 'A H Headgear Reinforce', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104387, 'KrissSuperV Renegade', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800021, 'Mask Frail Skull Gold', 3, '100', '200000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (2700013, 'Beret PBTN', 2, '86400,259200', '7000,20000', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103545, 'AUG A3 Technicolor', 3, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105374, 'Tactilite T2 Technicolor', 3, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202173, 'ColtPython Technicolor', 3, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (301281, 'GH5007 Technicolor', 3, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118287, 'OA93 Dual Technicolor', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104758, 'OA93 Technicolor Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103510, 'SC 2010 Halloween2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105351, 'Cheytac M200 Halloween2018', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602327, 'KeenEyes Invasion', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (407049, 'Snowman Grenade', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103347, 'AUG A3 Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (105216, 'Tactilite T2 Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (104400, 'KrissSuperV Green', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 25);
INSERT INTO "public"."item_goods" VALUES (104439, 'OA93 Bolt', 2, '86400,259200', '1000,2700', '0,0', 0, 5, 't', 0);
INSERT INTO "public"."item_goods" VALUES (301195, 'GH5007 Bolt', 2, '86400,259200', '1000,2700', '0,0', 0, 5, 't', 0);
INSERT INTO "public"."item_goods" VALUES (118153, 'OA93 Dual Bolt', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202172, 'Taurus 454SS Scope SignaturePB', 2, '86400,259200', '1000,2700', '0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104752, 'KrissSuperV SignaturePB Dummy', 3, '100', '100', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104750, 'OA93 SignaturePB Silence Dummy', 3, '100', '100', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103542, 'SC 2010 SignaturePB', 2, '86400,259200', '1000,2700', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (105372, 'Tactilite T2 SignaturePB', 2, '86400,259200', '1000,2500', '0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103251, 'AUG-A3 Sakura', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104115, 'KrissSuperV Sakura', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104044, 'KrissSuperV Sakura Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103276, 'SC 2010 Dolphin', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104290, 'KrissSuperV Dolphin Dummy', 3, '100', '100', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (214021, 'Scorpion Vz61 Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (104330, 'KrissSuperV Gorgeous', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (103480, 'AUG-HBAR Renegade2', 3, '100', '100', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106097, 'M1887 Renegade', 3, '100', '100', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (1800055, 'Clan Member +50', 1, '1', '10000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601261, 'Wolf Rein', 3, '86400,259200', '1000,2700', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602260, 'Caiman Rein', 3, '86400,259200', '1000,2700', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103643, 'M4_AzureDragon', 3, '100', '25000', '25000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103700, 'HK-417 RECAMO', 3, '100', '25000', '25000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (118246, 'OA93 Dual Renegade2', 2, '2592000', '15000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (105352, 'Tactilite T2 DemonHunter', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (602526, 'Chou_Wraith ', 3, '100', '250000', '250000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (106166, 'Zombie Slayer DemonHunter', 2, '86400,259200', '2000,4000', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601528, 'Rica_Wraith ', 3, '100', '250000', '250000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (315033, 'Dual BoneKnife DemonHunter', 2, '86400,259200', '1000,2700', '0,0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (601442, 'Rica VampireHunter', 3, '100', '250000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (116005, 'RPG Space', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (116002, 'RPG', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104897, 'Kriss S.V CRB', 3, '100', '250000', '250000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (602426, 'Chou Rudolph', 2, '86400,259200', '1000,2700', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (104969, 'KrissSuperV_CRB_Crow', 3, '100', '250000', '250000', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (800169, 'PBTN Memorial Mask', 3, '100', '350000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods" VALUES (116006, 'RPG', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (116001, 'RPG', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202029, 'GL06', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202054, 'GL06', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202026, 'HK69', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (202028, 'ML79', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (116007, 'MGL_32_MX', 3, '100', '10000000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (1800183, 'Megafone', 1, '1', '50000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods" VALUES (103520, 'M4A1 Zepetto', 2, '0', '0', '0', 0, 4, 't', 0);

-- ----------------------------
-- Table structure for item_goods_effects
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_goods_effects";
CREATE TABLE "public"."item_goods_effects" (
  "effect_id" int4 NOT NULL,
  "effect_name" varchar(255) COLLATE "pg_catalog"."default",
  "count_days" varchar(255) COLLATE "pg_catalog"."default",
  "price_moneys" varchar(255) COLLATE "pg_catalog"."default",
  "price_points" varchar(255) COLLATE "pg_catalog"."default",
  "icon" int4 DEFAULT 0,
  "effect_visible" bool DEFAULT true,
  "price_discount" int4 DEFAULT 0
)
;

-- ----------------------------
-- Records of item_goods_effects
-- ----------------------------
INSERT INTO "public"."item_goods_effects" VALUES (1700002, 'Exp 130%', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700026, 'Quick Change Weapon', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700003, 'Exp 150%', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700004, 'Point 130%', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700119, 'Point 150%', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700191, '+1 Smoke', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700040, '+5% HP', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700030, '+5% Defense', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700034, 'C4 Speed Up', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700035, '+1 Grenade', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);
INSERT INTO "public"."item_goods_effects" VALUES (1700027, 'Quick Reload', '1,7,30', '100,500,1500', '0,0,0', 0, 't', 0);

-- ----------------------------
-- Table structure for item_goods_sets
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_goods_sets";
CREATE TABLE "public"."item_goods_sets" (
  "set_id" int4 NOT NULL,
  "set_name" varchar(255) COLLATE "pg_catalog"."default",
  "visible" bool DEFAULT true
)
;

-- ----------------------------
-- Records of item_goods_sets
-- ----------------------------

-- ----------------------------
-- Table structure for item_goods_sets_items
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_goods_sets_items";
CREATE TABLE "public"."item_goods_sets_items" (
  "set_id" int4 NOT NULL,
  "item_id" int4 NOT NULL,
  "item_name" varchar(255) COLLATE "pg_catalog"."default",
  "item_consume" int4,
  "item_count" int4,
  "price_money" int4,
  "price_points" int4
)
;

-- ----------------------------
-- Records of item_goods_sets_items
-- ----------------------------

-- ----------------------------
-- Table structure for item_goods_test
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_goods_test";
CREATE TABLE "public"."item_goods_test" (
  "item_id" int4 NOT NULL,
  "item_name" varchar(255) COLLATE "pg_catalog"."default",
  "item_consume" int4,
  "counts" varchar(255) COLLATE "pg_catalog"."default",
  "moneys" varchar(255) COLLATE "pg_catalog"."default",
  "points" varchar(255) COLLATE "pg_catalog"."default",
  "item_title" int4 DEFAULT 0,
  "item_icon" int4 DEFAULT 0,
  "item_visible" bool DEFAULT true,
  "price_discount" int4 DEFAULT 0
)
;

-- ----------------------------
-- Records of item_goods_test
-- ----------------------------
INSERT INTO "public"."item_goods_test" VALUES (700142, 'Fes Hat', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800049, 'Reset Kill/Death', 1, '1', '5000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (700032, 'Marine Cap', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800022, 'Mask Black', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800023, 'Mask Blue Tiger', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800019, 'Mask Death', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800008, 'Mask G PB V2', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800002, 'Mask Gas', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800005, 'Mask M15 Gas', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301021, 'Keris', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301018, 'BallisticKnife', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106047, 'Cerberus', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103051, 'Famas G2 Sniper', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104033, 'AKS74U Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104611, 'KRISS S.V VITTORIA', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (700036, 'Chinese Marines Headgear', 2, '86400,604800,2592000', '180,768,1000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800055, 'Clan Member +50', 1, '1', '10000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800052, 'Change Clan Mark', 1, '1', '7000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800051, 'Change Clan Name', 1, '1', '3000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202021, 'Glock 18 D', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103005, 'F2000 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103015, 'AK SOPMOD', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103041, 'AK SOPMOD CG', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103232, 'AUG A3 HALLOWEEN', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103102, 'HK-417', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103284, 'Groza', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202012, 'C.Python D', 2, '86400,604800,2592000', '0,0,0', '120,720,1200', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104013, 'Kriss S.V', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104193, 'EVO 3', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104096, 'AKS74U Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105006, 'Dragunov G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105030, 'Cheytac M200', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (110004, 'L86 LSW', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105005, 'L115A1', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (214004, 'Dual D-Eagle G', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202022, 'Colt 45', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202036, 'Desert Eagle Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (214002, 'Dual D-Eagle', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (214005, 'Dual Handgun D', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (214006, 'Dual D-Eagle D', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301014, 'GH5007', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (323009, 'Bare Fist', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301017, 'Fang Blade', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301041, 'Arabian Sword', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301024, 'Candy Cane', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301058, 'Chinese Kitchen Knife', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301066, 'Death Scythe', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301122, 'Butterfly', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301147, 'Karambit', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (315001, 'Dual Knife', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (315003, 'BoneKnife', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (315008, 'Dual Kunai', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700150, 'Chinese Hat', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407002, 'C-5', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (407007, 'K-413 G', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (407012, 'Decoy Bomb', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800010, 'Mask PB6200', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800033, 'Mask Red Cross', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800007, 'Mask Skull Warmer', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (701105, 'Helmet +3 PLUS', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (701104, 'Helmet C5', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (701103, 'Helmet ++', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103305, 'G11', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1701031, 'Full Metal Jack', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1707036, 'Jack Hollow Point', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1730011, 'Fee Move, Free Pass', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1730017, 'Get Dropped Weapon', 2, '86400,604800,2592000', '1,2,3', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1730029, 'Invincible +1 Sec.', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800047, 'Change Nickname', 1, '1', '5000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700156, 'SASR Cap', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700030, 'UDT Boonie Hat', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601010, 'Rica', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800006, 'Sport Sun Glasses', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800009, 'Wiley P Sun Glasses', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (701106, 'Helmet PLUS ++++', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105029, 'VSK94', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104134, 'OA-93', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301007, 'Mini Axe', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700033, 'Pentagram Army Cap', 2, '86400,604800,2592000', '180,768,1000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105007, 'PSG1 S.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104014, 'MP5K SL.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103001, 'SG 550 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103002, 'AK-47 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103003, 'M4A1 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103009, 'AK-47 G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103014, 'SG 550 S.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103053, 'SS2-V4 Para Sniper', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103095, 'SCAR-L Recon', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103118, 'SS2-V Para Sniper Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103123, 'TAR-21', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103153, 'SC-2010', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104174, 'P90MC_Sheep', 2, '604800', '1690', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103246, 'AK-12', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104002, 'Spectre Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104004, 'MP7 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104043, 'SS1-R5 Carbine', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104098, 'Spectre Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104099, 'SS1-R5 Carbine Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104100, 'MP5K Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104106, 'PP-19 Bizon', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104107, 'MP9 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105035, 'SVU', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105031, 'Winchester M70', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104001, 'MP5K Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (323010, 'Zombie Tooth', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105068, 'XM-2010', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105072, 'Walther WA2000', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105123, 'Tactilite-T2', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106003, 'SPAS-15', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106012, 'SPAS-15 D', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106018, 'SPAS-15 MSC', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106043, 'Remington ETA', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (110011, 'Ultimax 100', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202094, 'U22 Neos', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (213001, 'P99&Hak', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (213007, 'P99&Hak Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (323005, 'Pumpkin Knukle', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (508003, 'Smoke Plus', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (508007, 'Yellow Smoke Grenade', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (527001, 'WP Smoke', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800024, 'Mask Green Jungle', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105008, 'SSG-69 SL.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800018, 'Mask Face Magic', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800012, 'Standard Face Gurad', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601127, 'BunnyGirlRica', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602004, 'Keyn eys', 1, '100', '0', '350000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601016, 'Г В№в‚¬Г ВёВЈГ ВёвЂќ Г ВёЕЎГ ВёВ№Г ВёВҐГ ВёВЄГ В№Е’', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602178, 'Sketion Blue', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602210, 'Ninja Chou', 2, '86400,604800,2592000', '500,2405,5000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1730187, 'Muzzle Color', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800013, 'Mask G PB V2 Steel', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103174, 'XM8', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700004, 'Beret Skull', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1701014, 'Color Change Crosshair', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800025, 'Mask Yellow Desert', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103040, 'Aug A3 D.', 2, '86400,604800,2592000', '300,1685,3000', '0,0,0', 0, 0, 't', 50);
INSERT INTO "public"."item_goods_test" VALUES (2700025, 'Beret Fire', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700026, 'Beret PBGC2017', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700027, 'Beret Green', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700029, 'Beret Ottoman', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700020, 'Р‘РµСЂРµС‚ Xmas2016', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103010, 'M4A1 S.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103013, 'G36C Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103181, 'AUG-A3_Sheep', 2, '604800', '2700', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103057, 'Vz. 52', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103116, 'F2000 Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103117, 'SG 550 Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103223, 'M14 EBR', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105098, 'DSR-1 D', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104097, 'UMP45 Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105059, 'PSG1 Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105004, 'SS-69 S.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105012, 'Dragunov CG.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104011, 'P90 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105002, 'PSG1', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106046, 'UTS-15 D', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106005, 'M1887', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106020, 'Kel-Tec KSG-15', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (110003, 'RPD', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202001, 'Desert Eagle', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202002, 'MK.23 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202007, 'C.Python', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202024, 'Kriss Vector SDP', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407004, 'Г ВёВЈГ ВёВ°Г В№в‚¬Г ВёЕЎГ ВёВґГ ВёвЂќГ ВёвЂћГ ВёВ№Г В№Л† K-413', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202035, 'MK.23 Reload', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202102, 'Luger P08', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (214001, 'Dual Handgun', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (214007, 'HK45 Dual', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (323004, 'Silver Knukle', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (508002, 'FlashBang', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (508005, 'Pink Smoke Grenade', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700024, 'Beret PBNC2016', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800053, 'Clan Reset Win/Lose', 1, '1', '5000', '0', 0, 4, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103236, 'K2C', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103017, 'AK-47 SL.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (214017, 'Scorpion Vz.61', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104008, 'UMP46 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104016, 'Spectre Wh.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (202017, 'C.Python G', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601003, 'Tarantula', 1, '100', '0', '10000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104338, 'P90 Red Wound', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 5, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601244, 'Vacance 2017 Tarantula', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601341, 'MuayThai Tarantula', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601090, 'Sketion Red', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800198, 'Mask IC''12', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800368, 'Mask Midnight Blue III', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800048, 'Win Lose', 1, '1', '6500', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1701193, 'Change Effect Clan', 2, '86400,604800,2592000', '3000,5000,10000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602389, 'Paramedic Acid Pol', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103574, 'AUG A3 9thAnniversary', 2, '86400', '1000', '0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301210, 'HalloweenSrynge', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234007, 'Compound Bow Graduation', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105210, 'Tactilite-T2 Samurai', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105322, 'KAR98K ZF39', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407089, 'Ramadan19 BasicGrenade', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601388, 'Paramedic D-Fox', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103050, 'Famas G2 Comando', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (323003, 'Г ВёВЄГ Вёв„ўГ ВёВ±Г ВёЕЎГ ВёВЎГ ВёВ·Г ВёВ­Г ВёвЂ”Г ВёВ­Г ВёвЂЎГ В№в‚¬Г ВёВ«Г ВёВҐГ ВёВ·Г ВёВ­Г ВёвЂЎ', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601069, 'Г В№вЂћГ ВёвЂћГ ВёВЎГ ВёВІГ Вёв„ўГ В№в‚¬Г ВёВЃГ ВёВЈГ ВёВўГ В№Е’', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602021, 'Г ВёВҐГ ВёВµГ В№вЂљГ ВёВ­Г ВёЕѕГ ВёВІГ ВёВЈГ В№Е’Г ВёвЂќГ В№в‚¬Г ВёВЄГ ВёВЈГ ВёВґГ ВёВЎГ В№ВЃГ ВёВЃГ ВёВЈГ В№Л†Г ВёвЂЎ', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (700137, 'Santa Hat', 2, '86400,604800,2592000', '90,320,900', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103439, 'AUG-A3_Nusantara', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602275, 'RobotSantaChou', 2, '84600', '99999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103144, 'AUG_A3_R', 2, '86400', '9999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234004, 'Compound Bow Blue', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301276, 'M1918 TrenchKnife', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700007, 'Demonic Box', 2, '86400', '3', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301297, 'C.MachetePinkyPig', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234002, 'Compound Bow Silver', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234001, 'Compound Bow', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301232, 'Karambit_M1LGR4U', 2, '86400,2592000', '130,1300', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407074, 'Ice Cream Grenade', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103433, 'AUG A3 Zepetto', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700021, 'Boina Strick', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800056, 'Reset Clan Point', 1, '1', '20000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103444, 'AUG A3 Latin Championship', 2, '1209600', '8888888', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (528003, 'Chocolate Kit', 2, '86400,2592000', '210,2100', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800085, 'PB Inspector', 1, '100', '0', '50000', 0, 5, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105315, 'aug a3 hallow', 2, '86400', '39880', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234005, 'Compound Bow Black', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700023, '3', 2, '86400', '5', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700030, 'Beret Brazill', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301225, 'Diploma', 2, '259200', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407079, 'PumpkinBomb', 2, '86400', '1000', '0', 0, 5, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103579, 'AUG A3 Spider', 2, '86400', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700013, 'Р‘РµСЂРµС‚ GM', 2, '86400', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105232, 'Barrett M82A1 PREMIUM', 2, '259200', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104600, 'KrissSuperV_M1LGR4U', 2, '86400,604800,2592000', '280,1540,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103406, 'AUG-HBAR', 2, '86400', '9999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301222, 'ChocoStick', 2, '259200', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103575, 'AUG A3 PinkyPig', 2, '86400', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602308, 'HideGIGN', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602214, 'ChineseDressChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601248, 'General Viper Red', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602034, 'HideKopassus', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602036, 'HideCup', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602062, 'InfectedAcidPol', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602063, 'InfectedKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602064, 'InfectedHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602065, 'InfectedLeopard', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602165, 'KungFuKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602166, 'NBGirlKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602168, 'NinjaKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602173, 'BunnyGirlKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602174, 'ArmyAgentKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602179, 'Ms.SantaHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602186, 'KungFuHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602187, 'NBGirlHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602192, 'NurseHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602194, 'BunnyGirlHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602195, 'ArmyAgentHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602207, 'KungFuChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602208, 'NBGirlChou', 2, '259200', '99999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602227, 'NinjaAcidPol', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602250, 'GeneralKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602252, 'GeneralChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602257, 'PBQuinnKeenEyes', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602258, 'PBQuinnHide', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602259, 'PBQuinnChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602325, 'InvasionChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602326, 'InvasionHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602329, 'HighschoolHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602330, 'HighschoolKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602390, 'Paramedic Leopard', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700168, 'Mask TigerFang', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700211, 'Mask Chicken', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602039, 'HideRecon', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (234009, 'Compound Bow Lovely', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234003, 'Compound Bow Gold', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (234006, 'Compound Bow PBWC2017', 2, '259200', '9999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103451, 'AUG_A3_M1LGR4U', 2, '86400,604800,2592000', '400,2365,4000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103486, 'Pindad_SS2_V5_PBTC2018', 2, '86400,604800,2592000', '400,2365,4000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103484, 'AUG_A3_PBTC2018', 2, '86400,604800,2592000', '400,2365,4000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104673, 'OA93_PBTC2018', 2, '86400,604800,2592000', '280,1540,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301253, 'Keris_PBTC2018', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800050, 'Reset Desertion', 1, '1', '10000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407086, 'HeartBomb', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103452, 'SC_2010_M1LGR4U', 2, '86400,604800,2592000', '400,2365,4000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104602, 'P90_Ext_M1LGR4U', 2, '86400,604800,2592000', '280,1540,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105032, 'Barrett M82A1', 2, '86400', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601074, 'IndianTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601077, 'KungFuTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602218, 'SwimsuitAcidPol', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602219, 'Mr.SantaAcidPol', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103268, 'Pindad SS2 V5', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202158, 'Taurus_454SS_Scope_PBTC2018', 2, '86400,2592000', '230,2300', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104671, 'KrissSuperV_PBTC2018', 2, '86400,604800,2592000', '280,1540,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301274, 'PIG Hammer', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602158, 'Ms.SantaKeenEyes', 2, '86400,604800,2592000', '510,2698,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601084, 'ChineseDressTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601085, 'BunnyGirlTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601086, 'ArmyChicTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601095, 'IndianViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601098, 'KungFuViperRed', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601105, 'ChineseDressViperRed', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601106, 'BunnyGirlViperRed', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601107, 'ArmyChicViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601111, 'GrimReaperRica', 2, '86400,604800,2592000', '510,3586,5210', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601116, 'IndianRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601119, 'KungFuRica', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601126, 'ChineseDressRica', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601134, 'IndianRedBulls', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601147, 'IndianD-Fox', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601247, 'GeneralTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601249, 'GeneralRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602271, 'AstrogirlHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602272, 'AstrogirlChou', 2, '84600', '99999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601325, 'InvasionRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601326, 'InvasionViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601327, 'InvasionTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601329, 'HighschoolViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601330, 'HighschoolTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602025, 'ReinforcedChou(CT-FORCE)', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602157, 'GrimReaperKeenEyes', 2, '86400,604800,2592000', '510,3586,5210', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602162, 'WesternKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602163, 'SeaAdventurerKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602171, 'NurseKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602172, 'ChineseDressKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602175, 'RiderKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602183, 'WesternHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602189, 'NinjaHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602196, 'RiderHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602198, 'SwimsuitChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602204, 'WesternChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602213, 'NurseChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602215, 'BunnyGirlChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602216, 'ArmyAgentChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602217, 'RiderChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602222, 'WesternLeopard', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602223, 'SeaAdventurerLeopard', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602231, 'SwimsuitLeopard', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602235, 'WesternAcidPol', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602295, 'PilotChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602310, 'ValentineWitchChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602311, 'ValentineWitchHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602312, 'ValentineWitchKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602319, 'AndroidKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602353, 'Swimsuit2017KeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602354, 'Swimsuit2017Hide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602355, 'Swimsuit2017Chou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602367, 'RiderKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602368, 'RiderChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602380, 'PSTrainerLeopard', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602394, 'PBRangerKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602395, 'PBRangerHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602396, 'PBRangerChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602401, 'PsychoNurseHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602402, 'PsychoNurseChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602403, 'PocongChou', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602425, 'RudolphKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602426, 'RudolphChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602436, 'PuppyHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602437, 'PuppyKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602438, 'PuppyChou', 2, '259200', '9999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104020, 'Spectre SL.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105301, 'Tactilite_T2_M1LGR4U', 2, '86400,604800,2592000', '500,2687,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105124, 'Cheytac_M200_Sheep', 2, '86400,2592000', '350,3500', '0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104703, 'OA-93 Splash', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202163, 'Glock 18 Splash', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 1, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301047, 'Keris Xmas', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104003, 'K-1 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (106010, 'M1887 W.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301218, 'PuppyHammer', 2, '259200', '999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601317, 'AndroidViperRed', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601265, 'RobotSantaViperRed', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601091, 'Ms.SantaViperRed', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601131, 'Mr.SantaRedBulls', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601264, 'RobotSantaRica', 2, '86400', '99999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601266, 'RobotSantaTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602276, 'RobotSantaHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602277, 'RobotSantaKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106042, 'Zombie_Slayer', 2, '86400', '999999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601037, 'WorldTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (116002, 'RPG7', 2, '86400', '9999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602011, 'Chou', 2, '86400,604800,2592000', '500,2405,5000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103206, 'AUG A3 Peru', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (528002, 'Halloween Medical Kit', 2, '86400', '1000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601068, 'ViperKopassus', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601075, 'SeaAdventurerTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601080, 'NinjaTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601081, 'PirateTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601083, 'NurseTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601087, 'RiderTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601099, 'NBGirlViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601101, 'NinjaViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601104, 'NurseViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601108, 'RiderViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601110, 'SwimsuitRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601117, 'SeaAdventurerRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601120, 'NBGirlRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601125, 'NurseRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601128, 'ArmyChicRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601129, 'RiderRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601130, 'SwimsuitRedbulls', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601269, 'AstrogirlRica', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601135, 'SeaAdventurerRedBulls', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601139, 'NinjaRedBulls', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601143, 'SwimsuitD-fox', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601148, 'SeaAdventurerD-Fox', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601246, 'Ms.SanataTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601255, 'PBQuinnViperRed', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601256, 'PBQuinnRica', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601284, 'UKRebelViperRed', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601286, 'UKRebelRica', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601292, 'PilotRica', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601298, 'WWIIRedBulls', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601300, 'RebelRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601309, 'RevolutionistViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601314, 'ValentineWitchTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601315, 'ValentineWitchViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601332, 'teamPunkRedBulls', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601356, 'Swimsuit2017Tarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601358, 'Swimsuit2017Rica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601366, 'RevolutionistRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601391, 'PBRangerTarantula', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601392, 'PBRangerViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601393, 'PBRangerRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601399, 'PsychoNurseRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601406, 'RangdaRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601423, 'RudolphRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601433, 'PuppyViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601434, 'PuppyTarantula', 2, '259200', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601435, 'PuppyRica', 2, '259200', '9999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602184, 'SeaAdventurerHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602236, 'SeaAdventurerAcidPol', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105335, 'Tactilite_T2_PBTC2018', 2, '86400,604800,2592000', '510,2698,5100', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (315032, 'Dual_BoneKnife_PBTC2018', 2, '86400,604800,2592000', '120,600,1200', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105334, 'Cheytac_M200_PBTC2018', 2, '86400,259200,2592000', '610,3478,6145', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106159, 'M1887_PBTC2018', 2, '86400,604800,2592000', '400,2365,4000', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103485, 'AUG-HBAR_PBTC2018', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104675, 'P90_Ext_PBTC2018', 2, '86400,2592000', '250,2500', '0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105388, 'Kar98k_10Anniv', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202179, 'Taurus_454SS_Scope_10Anniv', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104790, 'Thompson_Dual_10Anniv', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (118095, 'OA DIAMAN BUG', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104221, 'KrissSuperV_Sheep', 1, '100,500', '0,0', '60000,250000', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301290, 'FangBlade_10Anniv', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104517, 'T77_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105377, 'BORA12_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301177, 'Sword_Samurai', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602320, 'AndroidHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602321, 'AndroidChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103542, 'SC-2010 Signature', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601089, 'SwimsuitViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301280, 'GH5007_SignaturePB', 2, '86400,604800,2592000', '210,720,2100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601096, 'SeaAdventurerViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601285, 'UKRebelTarantula', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601313, 'ValentineWitchRica', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601398, 'PsychoNurseViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602199, 'GrimReaperChou', 2, '86400,604800,2592000', '510,3586,5210', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800269, 'Mask Kid', 2, '86400,2592000', '500,1700', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800014, 'Mask Joker', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104075, 'P90_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104794, 'P90_Ext_Silence_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103483, 'Pindad_SS2_V5_Bhinneka', 2, '604800', '99999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105093, 'VSK94_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105015, 'L115A1_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106059, 'M1887_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104162, 'PP-19 Bizon G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105024, 'HK-PSG1_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104136, 'OA93_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105272, 'Barrett_Red', 2, '86400', '9999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104228, 'OA93_Medical', 2, '86400,604800,2592000', '410,2400,4100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700008, 'Beret General', 2, '86400', '999999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601005, 'Г В№вЂћГ ВёВ§Г В№в‚¬Г ВёвЂєГ ВёВ­Г ВёВЈГ В№Е’Г В№в‚¬Г ВёВЈГ ВёвЂќ', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105146, 'PGM-Hecate2_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301009, 'M-7_Gold', 2, '86400,604800,2592000', '200,550,2000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105121, 'Cheytac_M200_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601338, 'PriestTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601340, 'PriestRica', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105132, 'Tactilite_T2_Gold', 3, '100', '0', '10000000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105095, 'DSR-1_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105159, 'AS-50 G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103225, 'AK-47_SOPMOD_Medical', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106048, 'UTS-15_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (116004, 'MGL_32', 2, '86400', '9999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103541, 'AUG A3 Signature', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800708, 'РљРѕСЂРѕР±РєР° PBIC2015', 1, '1', '500', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601078, 'NBGirlTarantula', 2, '259200', '9999999', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601245, 'GrimReaperTarantula', 2, '86400,604800,2592000', '510,3586,5210', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601357, 'Swimsuit2017ViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601421, 'RudolphViperRed', 2, '86400', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602067, 'HideElite', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602327, 'InvasionKeenEyes', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602344, 'MuayThai KeenEyes', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602424, 'RudolphHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301167, 'FangBlade_Ice', 2, '86400,604800,2592000', '210,720,2100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104678, 'Thompson_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104230, 'P90_Ext_Medical', 2, '86400,604800,2592000', '280,1450,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301069, 'Ice_Fork', 2, '86400,604800,2592000', '230,790,2300', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106060, 'M1887_Medical', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103553, 'AUG_A3_PBWC2019', 2, '86400,604800,2592000', '400,2000,4000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103315, 'AUG_A3_Ice', 2, '86400,604800,2592000', '400,2000,4000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106088, 'Zombie_Slayer_Ice', 2, '86400,604800,2592000', '720,4500,7200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202106, 'ColtPython_Ice', 2, '86400,604800,2592000', '180,680,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (528013, 'IceCream_Kit', 2, '86400,604800,2592000', '120,500,1200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104342, 'KrissSuperV_Ice', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104344, 'P90_Ext_Ice', 2, '86400,604800,2592000', '280,1450,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105194, 'Cheytac_M200_Ice', 2, '86400,604800,2592000', '500,3200,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407063, 'K-413_Ice', 2, '86400,604800,2592000', '120,500,1200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407077, 'C5_Sacrifice', 2, '86400,604800,2592000', '120,500,1200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104219, 'P90_MC_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103269, 'Pindad_SS2_V5_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104049, 'Pindad_SS1_R5_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601144, 'Mr.SantaD-Fox', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602232, 'Mr.SantaLeopard', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601018, 'Г ВёвЂ”Г ВёВІГ ВёВЈГ ВёВ±Г Вёв„ўГ ВёвЂ”Г ВёВ№Г ВёВҐГ ВёВІ', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601022, 'Г В№вЂћГ ВёВ§Г В№в‚¬Г ВёвЂєГ ВёВ­Г ВёВЈГ В№Е’Г В№в‚¬Г ВёВЈГ ВёвЂќГ В№в‚¬Г ВёВЄГ ВёВЈГ ВёВґГ ВёВЎГ В№ВЃГ ВёВЃГ ВёВЈГ В№Л†Г ВёвЂЎ', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104751, 'KrissSuperV_SignaturePB', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202172, 'Taurus_454SS_Scope_SignaturePB', 2, '86400,604800,2592000', '210,720,2100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104749, 'OA93_SignaturePB_Silence', 2, '86400,604800,2592000', '410,2400,4100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105277, 'Barrett_Blue', 2, '604800', '50000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103316, 'Pindad_SS2_V5_Ice', 2, '86400,604800,2592000', '380,2100,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106115, 'Shotgun SSF', 1, '86400', '50000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105348, 'Tactilite_T2_PBIC2018', 2, '86400,604800,2592000', '510,3300,5100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (340098, 'NameCardMouse', 2, '86400', '50000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301287, 'Kukrii_PBWC2019', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202176, 'ColtPython_PBWC2019', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104776, 'OA93_PBWC2019', 2, '86400,604800,2592000', '410,2400,4100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106180, 'M1887_PBWC2019', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105382, 'Cheytac_M200_PBWC2019', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105383, 'Tactilite_T2_PBWC2019', 2, '86400,604800,2592000', '510,3300,5100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407087, 'C5_PBWC2019', 2, '86400,604800,2592000', '180,500,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103503, 'AUG-HBAR_PBIC2018', 2, '86400,604800,2592000', '500,3100,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103502, 'AUG_A3_PBIC2018', 2, '86400,604800,2592000', '400,2000,4000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103504, 'SC_2010_PBIC2018', 2, '86400,604800,2592000', '380,2100,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301259, 'Kukrii_PBIC2018', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202162, 'ColtPython_PBIC2018', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104695, 'KrissSuperV_PBIC2018', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104697, 'OA93_PBIC2018', 2, '86400,604800,2592000', '410,2400,4100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106163, 'M1887_PBIC2018', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103443, 'Lion', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103479, 'AUG_A3_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2800001, 'Dragon battleBox', 1, '1', '50000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106099, 'M1887_Beach', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (110015, 'L86LSW_Beach', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103121, 'M4A1_PBIC2013', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103301, 'AK_12_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103114, 'M4A1_Elite', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301178, 'FangBlade_Renegade', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301249, 'Karambit_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103534, 'AUG A3 Vaquinha', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105372, 'Tactilite_T2_SignaturePB', 2, '86400,604800,2592000', '510,3300,5100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103555, 'SC_2010_PBWC2019', 2, '86400,604800,2592000', '380,2100,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104774, 'KrissSuperV_PBWC2019', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106051, 'WaterGun', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407050, 'WaterBomb', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103254, 'WaterGun2016', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103302, 'AUG_A3_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104387, 'KrissSuperV_Renegade', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104659, 'KrissSuperV_Silence_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103119, 'AK-47_Elite', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105347, 'Cheytac_M200_PBIC2018', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104718, 'OA-93 Zepetto Silence', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104657, 'OA93_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104661, 'P90_Ext_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106097, 'M1887_Renegade', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106156, 'M1887_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105211, 'AS_50_Renegade', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (118111, 'OA93_Dual_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103480, 'AUG-HBAR_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104330, 'KrissSuperV_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104332, 'OA93_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106083, 'M1887_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104391, 'KrissSuperV_Beach', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105213, 'PGM-Hecate2_Beach', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103343, 'AUG_A3_Beach', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104398, 'BattleBox_Dragon_Dual', 2, '86400,604800,2592000', '650,4350,6500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103122, 'AK-47_PBIC2013', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407078, 'C5_PBIC2018', 2, '86400,604800,2592000', '180,500,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104103, 'KrissSuperV_PBIC2013', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103554, 'AUG-HBAR_PBWC2019', 2, '86400,604800,2592000', '500,3100,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202150, 'ColtPython_WhiteRabbit', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103120, 'AUG-A3_PBIC2013', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105331, 'Tactilite_T2_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103475, 'SC_2010_Brazuca3', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301246, 'Karambit_Brazuca3', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104654, 'P90_Ext_Brazuca3', 2, '86400,604800,2592000', '280,1450,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202170, 'ColtPython_NewYear2019', 2, '86400,604800,2592000', '180,680,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103227, 'AUG-A3_Cobra', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105097, 'Cheytac_M200_Cangaceiro', 2, '86400,604800,2592000', '400,1500,4000', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103532, 'AUG_A3_NewYear2019', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800421, 'Mascara_Brazuca3', 2, '86400,604800,2592000', '210,1350,2100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104623, 'P90_Ext_WhiteRabbit', 2, '86400,604800,2592000', '280,900,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301070, 'GH5007_Cangaceiro', 2, '86400,604800,2592000', '50,350,500', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104200, 'P90_MC_Brazil', 2, '86400,604800,2592000', '280,1450,2800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105310, 'Cheytac_M200_WhiteRabbit', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800302, 'Mascara Cobra', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301237, 'ButterflyKnife_WhiteRabbit', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103460, 'SC_2010_WhiteRabbit', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301108, 'FangBlade_Cobra', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104232, 'OA93_Cobra', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105311, 'L115A1_WhiteRabbit', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105366, 'Cheytac_M200_NewYear2019', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (214021, 'Scorpion_Vz61_Gorgeous', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105127, 'L115A1_Cobra', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104377, 'KrissSuperV_Salvation', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103459, 'AUG_A3_WhiteRabbit', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700038, 'Boina_Brazuca3', 2, '86400,604800,2592000', '210,1350,2100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103173, 'AUG_A3_Cangaceiro', 2, '86400,604800,2592000', '280,900,2800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202073, 'Tarus_454SS_Scope_Cobra', 2, '86400,604800,2592000', '210,850,2100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700002, 'Boina Brasil', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104379, 'OA93_Salvation', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103334, 'AUG_A3_Salvation', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105208, 'Tactilite_T2_Salvation', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104734, 'OA93_NewYear2019', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103533, 'M4A1_NewYear2019', 2, '86400,604800,2592000', '280,1356,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105367, 'L115A1_Vaquinha', 2, '86400,604800,2592000', '450,2365,4500', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103474, 'AUG_A3_Brazuca3', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103535, 'Famas Vaquinha', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202060, 'ColtPython_Brazil', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104736, 'KrissSuperV_NewYear2019', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105110, 'Cheytac_M200_Brazil', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103457, 'AUG_A3_GSL2018', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202149, 'TEC-9_GSL2018', 2, '86400,604800,2592000', '180,680,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104615, 'KrissSuperV_GSL2018', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104617, 'OA93_GSL2018', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106147, 'M1887_GSL2018', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105308, 'Cheytac_M200_GSL2018', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105307, 'Tactilite_T2_GSL2018', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103545, 'AUG_A3_Technicolor', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202173, 'ColtPython_Technicolor', 2, '86400,604800,2592000', '180,680,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301282, 'FangBlade_Technicolor', 2, '86400,604800,2592000', '180,680,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104721, 'P90 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301281, 'GH5007_Technicolor', 2, '86400,604800,2592000', '180,680,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104757, 'OA93_Technicolor', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104759, 'P90_Ext_Technicolor', 2, '86400,604800,2592000', '280,1450,2800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105374, 'Tactilite_T2_Technicolor', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103540, 'SC_2010_Snack', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104745, 'KrissSuperV_Snack', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104747, 'OA93_Snack', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105370, 'Cheytac_M200_Snack', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105371, 'Tactilite_T2_Snack', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103539, 'AUG-A3_Snack', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (700161, 'Chapeu Cangaceiro', 2, '86400,604800,2592000', '210,1350,2100', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301277, 'Vaquinha_Hammer', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104741, 'P90_Ext_Vaquinha', 2, '86400,604800,2592000', '280,1450,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (315027, 'Dual_BoneKnife_GSL2018', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301162, 'HALLOWEEN_HAMMER', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301168, 'ChickenHammer', 2, '86400', '1000', '0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602288, 'UKSASHide', 2, '86400,604800,2592000', '1250,2500,5000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103195, 'AUG-A3_Brazil', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601316, 'AndroidTarantula', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105291, 'Tactilite_T2_Nusantara', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601112, 'Ms.SantaRica', 2, '86400,604800,2592000', '510,2698,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602200, 'Ms.SantaChou', 2, '86400,604800,2592000', '510,2698,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103214, 'AUG-A3_PBNC2015', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602287, 'UKSASKeenEyes', 2, '86400,604800,2592000', '1250,2500,5000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (407066, 'Beer Barrel Grenade', 2, '86400,259200', '210,2100', '0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301193, 'Karambit_Kareem', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202122, 'ColtPython_Kareem', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104534, 'OA93_Xmas2017', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104433, 'P90_MC_Kareem', 2, '86400,604800,2592000', '280,900,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106110, 'M1887_Kareem', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105230, 'Cheytac_M200_Kareem', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800400, 'Mascara_Nusantara', 2, '86400,604800,2592000', '210,1350,2100', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103405, 'AUG_A3_Xmas2017', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202067, 'ColtPython_PBNC2015', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104431, 'OA93_Kareem', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106053, 'M1887_PBNC2015', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106054, 'SPAS15_PBNC2015', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104580, 'OA93_Nusantara', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105114, 'Cheytac_M200_PBNC2015', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105321, 'Tactilite_T2_Arcade', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800420, 'Mascara_Arcade', 2, '86400,604800,2592000', '210,1350,2100', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (315024, 'BoneKnife_PBNC2015', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (315009, 'Fangblade_PBNC2015', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103470, 'AUG_A3_Arcade', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (214028, 'Scorpion_Vz61_Arcade', 2, '86400,604800,2592000', '280,900,2800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301243, 'GH5007_Arcade', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104582, 'P90_Ext_Nusantara', 2, '86400,604800,2592000', '280,900,2800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104726, 'OA93_Xmas2018', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104641, 'OA93_Arcade', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106152, 'M1887_Arcade', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105320, 'Cheytac_M200_Arcade', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103335, 'AUG-A3_GSL2017', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104381, 'KrissSuperV_GSL2017', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104383, 'OA93_GSL2017', 2, '86400,604800,2592000', '380,2300,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106141, 'M1887_Nusantara', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105292, 'Barrett_Nusantara', 2, '86400,604800,2592000', '3100,9520,31000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106123, 'Cerberus_Xmas2017', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105209, 'AS_50_GSL2017', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800361, 'Mascara_GSL2017', 2, '86400,604800,2592000', '210,1350,2100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103364, 'AUG_A3_Kareem', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301194, 'FangBlade_Kareem', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103525, 'Pindad_SS2_V5_Xmas2018', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104205, 'KrissSuperV_PBNC2015', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103526, 'M4A1_Xmas2018', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105266, 'Tactilite_T2_Xmas2017', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104724, 'KrissSuperV_Xmas2018', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407005, 'NA TEST 407005', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105360, 'Tactilite_T2_Xmas2018', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106096, 'M1887_GSL2017', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (528012, 'Medical_Kit_PBNC2015', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103524, 'AUG_A3_Xmas2018', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104578, 'KrissSuperV_Nusantara', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104536, 'KrissSuperV_Xmas2017', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106124, 'M1887_Xmas2017', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106170, 'M1887_Xmas2018', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105312, 'L11 DRAGON NAO TENTAR', 2, '86400,604800,2592000', '1021,6100,12100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105359, 'Cheytac_M200_Xmas2018', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (407082, 'K-400_Xmas2018', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601387, 'Paramedic Red Bulls', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103036, 'AUG A3', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601318, 'AndroidRica', 2, '86400', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103440, 'SC_2010_Nusantara', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202144, 'Taurus_454SS_Scope_Nusantara', 2, '86400,604800,2592000', '235,1150,2350', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (800001, 'Boeing Sunglasses', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105104, 'Cheytac M200 Ongame', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (508006, 'Blue Smoke Grenade', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (110001, 'MK.46 Ext.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (800011, 'Mask Skull Face Guard', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103508, 'MSBS Splash', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 1, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (301004, 'Amok Kukri', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (315026, 'Dual_BoneKnife_M1LGR4U', 2, '86400,604800,2592000', '200,1650,2000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602193, 'ChineseDressHide', 2, '84600', '1000', '0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (700195, 'Mask Monkey', 2, '86400,604800,2592000', '180,980,1800', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105302, 'Cheytac_M200_M1LGR4U', 2, '86400,604800,2592000', '310,2400,3100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103507, 'AUG A3 Splash', 3, '100,200,500', '0,0,0', '100000,150000,360000', 0, 1, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601254, 'PBQuinnTarantula', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602205, 'SeaAdventurerChou', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601007, 'Г ВёвЂќГ ВёВµГ ВёЕёГ ВёВ­Г ВёВЃГ ВёвЂ№Г В№Е’', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104613, 'OA-93 VITTORIA', 2, '86400,604800,2592000', '280,1540,2800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105337, 'SKS_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105126, 'Cheytac_M200_Medical', 2, '86400,604800,2592000', '500,3200,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602289, 'UKSASChou', 2, '86400,604800,2592000', '1250,2500,5000', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103226, 'SC_2010_Medical', 2, '86400,604800,2592000', '380,2100,3800', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (528015, 'Medical_Kit_SignaturePB', 2, '86400,604800,2592000', '250,1400,2500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (301093, 'GH5007_Brazil', 2, '86400,604800,2592000', '180,750,1800', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105326, 'Cheytac_M200_Brazuca3', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105327, 'Tactilite_T2_Brazuca3', 2, '86400,604800,2592000', '510,3100,5100', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105368, 'Cheytac_M200_Vaquinha', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104639, 'KrissSuperV_Arcade', 2, '86400,604800,2592000', '320,1800,3200', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106044, 'Remington_ETA_Gold', 2, '86400,604800,2592000', '400,1800,3500', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104161, 'MP9 Ext. G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103544, 'SC-2010 EvosGalaxy', 2, '86400,604800,2592000', '400,2000,4000', '0,0,0', 0, 4, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (101079, 'Fang Blade Ongame', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103238, 'AUG A3 Spy Deluxe', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103209, 'Vz52 BlackPearl', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103568, 'AUG A3 Ramadan19 Deluxe', 1, '100', '0', '1000000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103570, 'AUG HBAR Ramadan19 Deluxe', 1, '100', '0', '1000000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104795, 'P90 Ramadan19 Basic', 1, '100', '0', '1000000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104796, 'Kriss SV Ramadan19 Deluxe', 1, '100', '0', '1000000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104798, 'P90 M.C. Ramadan19 Deluxe', 1, '100', '0', '1000000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104799, 'APC9 Ramadan19 Deluxe', 1, '100', '0', '1000000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103536, 'SC-2010 Vaquinha', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103309, 'SIG-Sauer MCX Gold', 1, '100', '0', '40000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (102057, 'Dual-Eagle Ongame', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103167, 'AN-94 G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103168, 'HK-417 G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103169, 'TAR-21 G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103170, 'SCAR-L Carbine G.', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601267, 'AstrogirlTarantula', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602270, 'AstrogirlKeenEyes', 2, '86400,2592000', '650,6500', '0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (103172, 'Snow-ball Blaster', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103188, 'AUG A3 Ongame', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103231, 'AUG A3 Steam', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103233, 'AUG A3 Spy', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103293, 'K2C PBIC 2016', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103313, 'Cane Gun', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103478, 'AUG_A3_LatinChampionship2', 2, '1209600', '999999999', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104185, 'Kriss Ongame', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104187, 'P90 Ongame', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105001, 'Dragunov', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (105265, 'Cheytac_M200_Xmas2017', 2, '86400,604800,2592000', '500,3000,5000', '0,0,0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700031, 'Beret Military', 2, '86400,604800,2592000', '398,980,1800', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104702, 'APC9 Splash', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 1, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800908, 'Medical Kit Box', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104722, 'P90 Zepetto Silence', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104723, 'P90 M.C. Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106167, 'SPAS-15 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106168, 'UTS-15 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (204564, 'Kriss SV Zepetto Deluxe', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (204565, 'Kriss SV Zepetto Basic', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (204566, 'OA-93 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103517, 'AUG A3 Zepetto Silence', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103518, 'AK SOPMOD Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103519, 'Famas Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103520, 'M4A1 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103521, 'SC2010 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103522, 'MSBS Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103523, 'SS2 V5 Zepetto', 1, '1', '5000', '0', 0, 1, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106169, 'Zombie Slayer Zepetto', 2, '86400,604800,2592000', '480,2700,4800', '0,0,0', 0, 1, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104632, 'OA-93 Laberan2018', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104634, 'APC9 Laberan2018', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104630, 'Kriss SV Laberan2018 Deluxe', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (104631, 'Kriss SV Laberan2018 Basic', 1, '100,200,500', '0,0,0', '100000,150000,360000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (118246, 'OA93_Dual_Renegade2', 2, '86400,604800,2592000', '380,1700,3800', '0,0,0', 0, 2, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (601339, 'PriestViperRed', 1, '100', '0', '40000', 0, 1, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (602336, 'PriestHide', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602335, 'PriestKeenEyes', 2, '84600', '1000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (602337, 'PriestChou', 1, '100', '0', '40000', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (601268, 'AstrogirlViperRed', 2, '86400,604800,2592000', '398,980,3500', '0,0,0', 0, 0, 't', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800832, 'AUG 7 Box', 1, '1', '5000', '0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (1800914, 'Demonic Box', 1, '3,6,10', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (2700009, 'Beret Negra', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104647, ' Kriss S. V Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103473, ' MSBS Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (104649, ' OA-93 Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (103472, ' SC-2010 Млечный Путь ', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (105325, ' Tactilite T2 Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (106154, ' Цербер Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (202153, ' R.B 454 SS8M+S Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);
INSERT INTO "public"."item_goods_test" VALUES (315030, ' Костяные ножи Млечный Путь', 2, '86400,604800,2592000', '2100,4000,6500', '0,0,0', 0, 0, 'f', 0);

-- ----------------------------
-- Table structure for item_repair
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_repair";
CREATE TABLE "public"."item_repair" (
  "item_id" int8 NOT NULL DEFAULT 0,
  "point" int8 NOT NULL DEFAULT 0,
  "cash" int8 NOT NULL DEFAULT 0,
  "quautity" int8 NOT NULL DEFAULT 100,
  "enable" bool NOT NULL DEFAULT false
)
;

-- ----------------------------
-- Records of item_repair
-- ----------------------------
INSERT INTO "public"."item_repair" VALUES (103003, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103005, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103041, 0, 15, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103053, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103057, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103058, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103069, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103116, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103117, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103118, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103153, 63, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103174, 130, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103223, 70, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103268, 85, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103284, 90, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103305, 100, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103306, 81, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103338, 105, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103406, 100, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104001, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104002, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104003, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104004, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104007, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104008, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104009, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104011, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104013, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104027, 0, 15, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104033, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104038, 0, 6, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104043, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104059, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104096, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104098, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104099, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104100, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (104134, 84, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105001, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105002, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105004, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105005, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105006, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105007, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105011, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105012, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105024, 0, 6, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105029, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105030, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105031, 90, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105032, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105034, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105035, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (105068, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106001, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106003, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106004, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106009, 0, 15, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106010, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106018, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106019, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106020, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106021, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (106043, 140, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (110001, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (110003, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (110004, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (110011, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202001, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202002, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202005, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202007, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202010, 0, 9, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202011, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202021, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202022, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202023, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202026, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202036, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202094, 32, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202102, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (202112, 55, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (213001, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (214001, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (214002, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (214004, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (214007, 29, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103001, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103002, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103013, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103014, 59, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103015, 89, 0, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103024, 0, 20, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103025, 0, 15, 100, 't');
INSERT INTO "public"."item_repair" VALUES (103036, 89, 0, 100, 't');

-- ----------------------------
-- Table structure for item_stats
-- ----------------------------
DROP TABLE IF EXISTS "public"."item_stats";
CREATE TABLE "public"."item_stats" (
  "id" int4 NOT NULL,
  "name" varchar(255) COLLATE "pg_catalog"."default",
  "loaded_bullet" int4,
  "total_bullet" int4,
  "damage" int4,
  "fire_delay" numeric(255,2),
  "helmet_penetrate" int4,
  "range" numeric(255,2)
)
;

-- ----------------------------
-- Records of item_stats
-- ----------------------------
INSERT INTO "public"."item_stats" VALUES (103002, 'AK-47 DualMag', 30, 240, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103119, 'AK-47 Elite', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103078, 'AK-47 DualMag', 30, 240, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103009, 'AK-47 Gold', 45, 360, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103054, 'AK-47 Gold', 45, 360, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103124, 'AK-47 Gold', 45, 360, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103059, 'AK-47 Non Ext', 30, 90, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103072, 'AK-47 Silver', 40, 320, 31, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103122, 'AK-47 PBIC2013', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103025, 'AK-47 Silver', 40, 320, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103076, 'AK-47 Silver', 40, 320, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103221, 'AK-47 SOPMOD Gold', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103225, 'AK-47 SOPMOD Medical', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103017, 'AK-47 Silver', 40, 320, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103086, 'AK-47 Taiwan1', 45, 360, 33, 0.10, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103015, 'AK-47 SOPMOD', 30, 150, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103152, 'AK-47 SOPMOD BR Camo', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103039, 'AK-47 SOPMOD', 40, 200, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103074, 'AK-47 SOPMOD', 30, 150, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103033, 'AK-47 SOPMOD', 30, 150, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103099, 'AK-47 SOPMOD GRS', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103041, 'AK-47 SOPMOD KingCobra', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103126, 'AK-47 SOPMOD KingCobra', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103101, 'AK-47 SOPMOD PBNC', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103092, 'AK-47 SOPMOD R', 30, 150, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103252, 'AK-47 SOPMOD Sakura', 45, 225, 33, 0.09, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103058, 'GrenadeLauncher AK47', 45, 225, 33, 0.10, 95, 140.00);
INSERT INTO "public"."item_stats" VALUES (103125, 'GrenadeLauncher AK47', 45, 225, 33, 0.10, 95, 140.00);
INSERT INTO "public"."item_stats" VALUES (103068, 'GrenadeLauncher AK47 RED', 45, 235, 35, 0.10, 95, 140.00);
INSERT INTO "public"."item_stats" VALUES (103115, 'AN-94', 30, 150, 31, 0.08, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103167, 'AN94 Gold', 45, 225, 31, 0.08, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103036, 'AUG-A3', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103129, 'AUG-A3 BLOODY', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103111, 'AUG A3 BR-Camo', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103224, 'AUG A3 Basketball', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103048, 'AUG-A3 Black', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103107, 'AUG-A3 Black', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103093, 'AUG A3 Blaze', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103065, 'AUG A3 Blue', 40, 160, 29, 0.07, 75, 100.00);
INSERT INTO "public"."item_stats" VALUES (103195, 'AUG A3 Brazil', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103155, 'AUG A3 Brazuca', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103228, 'AUG A3 Camo-Soldier', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103227, 'AUG A3 Cobra', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103178, 'AUG A3 EvilCupid', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103217, 'AUG A3 Dark-Days', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103063, 'AUG A3 ESports', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103075, 'AUG-A3', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103210, 'AUG A3 Egypt', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103028, 'AUG-A3', 30, 150, 26, 0.07, 85, 120.00);
INSERT INTO "public"."item_stats" VALUES (103183, 'AUG A3 GRS2', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103037, 'AUG-A3 Gold', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103130, 'AUG-A3 Gold BLOODY', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103089, 'AUG-A3 Gold', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103071, 'AUG-A3 IC', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103106, 'AUG-A3 ITALIA', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103147, 'AUG A3 Inferno', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103211, 'AUG A3 Jordan', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103131, 'AUG-A3 Latin3', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103161, 'AUG A3 Latin3 Non-Logo', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103207, 'AUG A3 Lebaran2015', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103216, 'AUG A3 Mech', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103184, 'AUG A3 NEWBORN 2015', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103188, 'AUG A3 Ongame', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103120, 'AUG-A3 PBIC2013', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103219, 'AUG A3 PBIC2015', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103214, 'AUG A3 PBNC2015', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103148, 'AUG A3 PBNC5', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103187, 'AUG A3 PBNC6', 45, 255, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103215, 'AUG A3 PBTC2015', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103163, 'AUG A3 PC Cafe', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103189, 'AUG A3 Redemption', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103251, 'AUG A3 Sakura', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103212, 'AUG A3 Saudi', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103181, 'Aug A3 sheep', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103190, 'AUG A3 Summer', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103112, 'AUG A3 Turkey', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103213, 'AUG A3 UAE', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103222, 'AUG A3 VeraCruz', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103197, 'AUG A3 4Game', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103198, 'AUG A3 4Game-SE', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103245, 'AUG A3 Arena-Deluxe', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103244, 'AUG A3 Arena-Normal', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103128, 'AUG A3 Azerbaijan', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103160, 'AUG A3 BR 4th Anniversary', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103180, 'AUG A3 CNY-2015', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103173, 'AUG A3 Cangaceiro', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103250, 'AUG A3 Cupid', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103240, 'AUG A3 DFN', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103204, 'AUG A3 Emblem-Argentian', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103200, 'AUG A3 Emblem-Bolivia', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103205, 'AUG A3 Emblem-Chile', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103202, 'AUG A3 Emblem-Columbia', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103201, 'AUG A3 Emblem-Ecuador', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103199, 'AUG A3 Emblem-Mexico', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103206, 'AUG A3 Emblem-Peru', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103203, 'AUG A3 Emblem-Venezuela', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103097, 'AUG-A3 GRS', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103108, 'AUG-A3 GRS EV', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103104, 'AUG-A3 GSL', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103149, 'AUG A3 GSL 2014', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103186, 'AUG A3 GSL2015', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103164, 'AUG A3 G E-Sports', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103232, 'AUG A3 Halloween', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103194, 'AUG A3 Independence', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103171, 'AUG A3 Latin4', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103234, 'AUG A3 Latin5', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103193, 'AUG A3 LionFlame', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103243, 'AUG A3 Monkey', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103235, 'AUG A3 Obsidian', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103159, 'AUG A3 PBIC2014', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103196, 'AUG A3 PBST2015', 45, 225, 28, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103144, 'AUG A3 Russia', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103192, 'AUG A3 Rose', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103233, 'AUG A3 Spy-Normal', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103249, 'AUG A3 Silence', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103238, 'AUG A3 Spy-Deluxe', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103231, 'AUG A3 Steam', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103142, 'AUG A3 1st-Garena', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103109, 'AUG A3 TW1st', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103110, 'AUG A3 TW1st', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103165, 'AUG A3 Toy', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103248, 'AUG A3 VeraCruz2016', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103158, 'AUG A3 WOE', 45, 225, 30, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103241, 'AUG A3 Xmas2015', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103005, 'F2000', 30, 150, 26, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (103116, 'F2000 Reload', 30, 150, 26, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (103032, 'F2000 SL', 40, 200, 26, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (103077, 'F2000 SL', 40, 200, 26, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (103046, 'F2000 SL', 40, 200, 27, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (103049, 'FAMAS G2', 25, 150, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103090, 'FAMAS G2M', 25, 150, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103050, 'FAMAS G2 Commando', 25, 150, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103062, 'FAMAS G2 Commando ESports', 25, 150, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103105, 'FAMAS G2 Commando GSL', 40, 240, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103064, 'FAMAS G2 Commando Gold', 40, 240, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103091, 'famas G2 Commando PBTN', 25, 150, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103100, 'FAMAS G2 GRS', 40, 240, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103113, 'FAMAS G2 GRS EV', 40, 240, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103052, 'FAMAS G2 M203', 25, 150, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103051, 'FAMAS G2 Scope', 25, 150, 24, 0.06, 87, 100.00);
INSERT INTO "public"."item_stats" VALUES (103087, 'FAMAS G2 Silver', 30, 195, 24, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103143, 'FG42', 20, 100, 45, 0.11, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103145, 'FG42 Gold', 30, 150, 45, 0.11, 85, 140.00);
INSERT INTO "public"."item_stats" VALUES (103013, 'G36C', 30, 150, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103038, 'G36C', 40, 200, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103229, 'G36C Camo-Soldier', 40, 200, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103146, 'G36C Elite', 45, 225, 29, 0.07, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103027, 'G36C', 30, 150, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103067, 'G36C NON EX', 30, 90, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103029, 'G36C Silver', 40, 200, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103034, 'G36C Silver', 30, 150, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103031, 'G36C Silver', 30, 150, 25, 0.08, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103102, 'HK417 12', 30, 150, 33, 0.08, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103168, 'HK417 12 Gold', 45, 225, 33, 0.08, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (103004, 'K-2', 30, 90, 27, 0.08, 55, 140.00);
INSERT INTO "public"."item_stats" VALUES (103047, 'K-2', 30, 90, 27, 0.08, 79, 140.00);
INSERT INTO "public"."item_stats" VALUES (103011, 'K201', 30, 90, 27, 0.08, 79, 140.00);
INSERT INTO "public"."item_stats" VALUES (103236, 'K2C', 30, 150, 28, 0.07, 80, 140.00);
INSERT INTO "public"."item_stats" VALUES (103237, 'K2C Gold', 45, 225, 28, 0.07, 80, 140.00);
INSERT INTO "public"."item_stats" VALUES (103223, 'M14-EBR', 20, 100, 42, 0.13, 95, 140.00);
INSERT INTO "public"."item_stats" VALUES (103239, 'M14-EBR Gold', 30, 150, 42, 0.13, 95, 140.00);
INSERT INTO "public"."item_stats" VALUES (103045, 'M4-SR16-FC', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103042, 'M4-SR16-LV1', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103082, 'M4-SR16-LV1', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103043, 'M4-SR16-LV2', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103083, 'M4-SR16-LV2', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103044, 'M4-SR16-LV3', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103084, 'M4-SR16-LV3', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103114, 'M4A1 Elite', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103079, 'M4A1 Scope2', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103103, 'M4-SR16-FC', 50, 250, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103098, 'M4A1 GRS', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103208, 'M4A1 GRS EV', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103024, 'M4A1 Gold', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103023, 'M4A1 Gold', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103121, 'M4A1 PBIC2013', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103010, 'M4A1 SE', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103127, 'M4A1 SE', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103080, 'M4A1 SE', 45, 225, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103003, 'M4A1 Scope2', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103021, 'M4A1 Silver', 40, 200, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103081, 'M4A1 Silver', 40, 200, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103022, 'M4A1 White', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103055, 'M4A1 White', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103060, 'M4 NON EXT', 30, 90, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103053, 'Pindad SS2 V4', 30, 120, 27, 0.07, 82, 75.00);
INSERT INTO "public"."item_stats" VALUES (103061, 'Pindad SS SS2-V4 ParaSniper Gold', 45, 180, 27, 0.07, 82, 75.00);
INSERT INTO "public"."item_stats" VALUES (103156, 'Pindad SS2 V4 Gold', 45, 180, 27, 0.07, 82, 75.00);
INSERT INTO "public"."item_stats" VALUES (103118, 'Pindad SS2 V4 Reload', 30, 150, 26, 0.07, 82, 100.00);
INSERT INTO "public"."item_stats" VALUES (103226, 'SC-2010 Medical', 45, 225, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103191, 'SC-2010 Rose', 45, 225, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103242, 'SC-2010 Xmas2015', 45, 225, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103069, 'SCAR-H CQC', 20, 100, 29, 0.10, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (103094, 'SCAR-L Cabine', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103175, 'SCAR-L Cabine', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103170, 'SCAR-L Cabine Gold', 45, 225, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103096, 'SCAR-L FC', 30, 150, 26, 0.07, 95, 100.00);
INSERT INTO "public"."item_stats" VALUES (103218, 'SCAR-L FC PBNC2015 US', 45, 225, 26, 0.07, 95, 100.00);
INSERT INTO "public"."item_stats" VALUES (103095, 'SCAR-L Recon', 30, 150, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103176, 'SCAR-L Recon', 40, 200, 26, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103088, 'SCAR-H LB sniper', 30, 150, 26, 0.07, 100, 100.00);
INSERT INTO "public"."item_stats" VALUES (103070, 'SCAR-H Std Sil', 30, 150, 26, 0.07, 76, 100.00);
INSERT INTO "public"."item_stats" VALUES (103153, 'SC-2010', 30, 150, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103154, 'SC-2010 Gold', 45, 225, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103185, 'SC-2010 NEWBORN 2015', 45, 225, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103166, 'SC-2010', 40, 200, 30, 0.08, 85, 105.00);
INSERT INTO "public"."item_stats" VALUES (103014, 'SG550 SE', 45, 225, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103035, 'SG550 SE', 40, 200, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103001, 'SG550 DotSight', 30, 150, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103018, 'SG550 MB', 30, 150, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103030, 'SG550 MB', 30, 150, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103066, 'SG550 NON EX', 30, 90, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103026, 'SG550 MB', 30, 150, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103117, 'SG550 Reload', 30, 150, 33, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103073, 'SG550 SE', 45, 225, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103019, 'SG550 Silver', 40, 200, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103056, 'SG550 Silver', 40, 200, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103020, 'SG550 White', 30, 150, 30, 0.09, 82, 160.00);
INSERT INTO "public"."item_stats" VALUES (103172, 'Snow-ball Blaster', 30, 150, 1, 0.07, 40, 45.00);
INSERT INTO "public"."item_stats" VALUES (103123, 'TAR-21', 30, 180, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103151, 'TAR-21 BR Camo', 45, 225, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103169, 'TAR-21 Gold', 45, 225, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103150, 'TAR-21 Midnight', 40, 225, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103162, 'Tar-21 Midnight Non-Logo', 40, 225, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103182, 'TAR-21 Sheep', 45, 225, 25, 0.06, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (103057, 'vz52', 15, 75, 56, 0.16, 73, 160.00);
INSERT INTO "public"."item_stats" VALUES (103209, 'Vz52 Black-Pearl', 23, 115, 56, 0.16, 73, 160.00);
INSERT INTO "public"."item_stats" VALUES (103174, 'XM8', 30, 150, 25, 0.07, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (103177, 'XM8 Gold', 45, 225, 25, 0.07, 73, 100.00);
INSERT INTO "public"."item_stats" VALUES (5009001, 'C4', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009002, 'C4', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009016, 'CrownWatermelon', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009004, 'DummyLV1', 1, 1, 90, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009005, 'DummyLV2', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009006, 'DummyLV3', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009007, 'DummyLV4', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009003, 'DummyLV1', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009009, 'SentryGunLV1', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009010, 'SentryGunLV2', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009011, 'SentryGunLV3', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009012, 'SentryGunLV4', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009008, 'SentryGunLV1', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009015, 'SkillShop', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009013, 'SupplyAmmo', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (5009014, 'SupplyHP', 1, 1, 100, 5.00, 100, 35.00);
INSERT INTO "public"."item_stats" VALUES (301022, 'Compound Bow Blue Arrow', 3, 3, 47, 1.00, 75, 120.00);
INSERT INTO "public"."item_stats" VALUES (411023, 'Compound Bow Blue GrenadeArrow', 3, 3, 0, 0.50, 100, 20.00);
INSERT INTO "public"."item_stats" VALUES (411022, 'Compound Bow Blue GrenadeArrow', 1, 1, 80, 0.50, 95, 20.00);
INSERT INTO "public"."item_stats" VALUES (411020, 'Compound Bow Blue GrenadeArrow', 1, 1, 0, 0.50, 94, 20.00);
INSERT INTO "public"."item_stats" VALUES (411021, 'Compound Bow Blue GrenadeArrow', 1, 1, 1, 0.50, 94, 20.00);
INSERT INTO "public"."item_stats" VALUES (234001, 'Compound Bow', 10, 10, 47, 1.00, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (234005, 'Compound Bow Bl', 10, 10, 48, 1.00, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (234004, 'Compound Bow Blue', 15, 15, 48, 0.09, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (234003, 'Compound Bow Gold', 15, 15, 47, 0.09, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (234002, 'Compound Bow Sl', 13, 13, 47, 0.09, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (119010, 'M-7', 0, 0, 40, 0.40, 43, 2.00);
INSERT INTO "public"."item_stats" VALUES (119011, 'M-7', 0, 0, 40, 0.80, 43, 8.00);
INSERT INTO "public"."item_stats" VALUES (119021, 'M-7', 0, 0, 85, 0.40, 43, 2.00);
INSERT INTO "public"."item_stats" VALUES (119022, 'M-7', 0, 0, 120, 0.80, 43, 9.50);
INSERT INTO "public"."item_stats" VALUES (119015, 'M-7', 0, 0, 70, 0.40, 43, 2.00);
INSERT INTO "public"."item_stats" VALUES (119016, 'M-7', 0, 0, 120, 0.80, 43, 8.00);
INSERT INTO "public"."item_stats" VALUES (119017, 'M-7', 0, 0, 0, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119018, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119019, 'M-7', 0, 0, 55, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119020, 'M-7', 0, 0, 40, 0.40, 43, 100.00);
INSERT INTO "public"."item_stats" VALUES (119013, 'M-7', 0, 0, 30, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119012, 'M-7', 0, 0, 70, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119001, 'M-7', 0, 0, 70, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119023, 'M-7', 0, 0, 0, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119024, 'M-7', 0, 0, 70, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119002, 'M-7', 0, 0, 30, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119014, 'M-7', 0, 0, 55, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119007, 'M-7', 0, 0, 25, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119025, 'M-7', 0, 0, 90, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119026, 'M-7', 0, 0, 60, 0.40, 43, 100.00);
INSERT INTO "public"."item_stats" VALUES (119006, 'M-7', 0, 0, 10, 0.40, 43, 100.00);
INSERT INTO "public"."item_stats" VALUES (119003, 'M-7', 0, 0, 100, 0.40, 43, 3.50);
INSERT INTO "public"."item_stats" VALUES (119005, 'M-7', 0, 0, 200, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (119004, 'M-7', 0, 0, 20, 0.40, 43, 30.00);
INSERT INTO "public"."item_stats" VALUES (119008, 'M-7', 0, 0, 25, 0.80, 43, 6.00);
INSERT INTO "public"."item_stats" VALUES (119009, 'M-7', 0, 0, 10, 0.00, 43, 1.70);
INSERT INTO "public"."item_stats" VALUES (119027, 'M-7', 0, 0, 55, 0.00, 43, 1.70);
INSERT INTO "public"."item_stats" VALUES (135001, 'Cerberus Shotgun', 36, 36, 44, 1.50, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (213008, 'ColtPython Black-Pearl', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (214002, 'DesertEagle Gold', 14, 42, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214006, 'DesertEagle Gold', 18, 54, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214004, 'DesertEagle Gold', 21, 63, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214010, 'DesertEagle Gold', 21, 63, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214015, 'DesertEagle BR Camo', 21, 63, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214009, 'DesertEagle Gold', 14, 42, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214011, 'DesertEagle GRS', 21, 63, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (214016, 'DesertEagle G E-Sports', 21, 63, 28, 0.35, 58, 45.00);
INSERT INTO "public"."item_stats" VALUES (315003, 'BoneKnife', 0, 0, 49, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315010, 'BoneKnife Camo-Soldier', 0, 0, 49, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315005, 'BoneKnife GRS', 0, 0, 49, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315007, 'BoneKnife GRS2', 0, 0, 49, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315009, 'BoneKnife PBNC2015', 0, 0, 49, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315008, 'Kunai Dual', 10, 10, 65, 0.05, 60, 1.70);
INSERT INTO "public"."item_stats" VALUES (118004, 'Uzi', 60, 300, 19, 0.08, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118006, 'Uzi Micro', 60, 300, 15, 0.07, 80, 56.00);
INSERT INTO "public"."item_stats" VALUES (118009, 'Uzi Micro', 60, 300, 14, 0.07, 80, 55.00);
INSERT INTO "public"."item_stats" VALUES (118011, 'Uzi Micro SL', 78, 390, 14, 0.07, 80, 55.00);
INSERT INTO "public"."item_stats" VALUES (118005, 'Uzi Mini', 60, 300, 17, 0.07, 80, 58.00);
INSERT INTO "public"."item_stats" VALUES (118013, 'Uzi Mini Gold', 80, 400, 17, 0.07, 80, 58.00);
INSERT INTO "public"."item_stats" VALUES (118008, 'Uzi Mini', 60, 300, 16, 0.07, 80, 57.00);
INSERT INTO "public"."item_stats" VALUES (118007, 'Uzi', 60, 300, 18, 0.08, 80, 59.00);
INSERT INTO "public"."item_stats" VALUES (214007, 'HK45 Dual', 20, 60, 21, 0.32, 58, 42.00);
INSERT INTO "public"."item_stats" VALUES (214012, 'HK45 Dual Halloween', 30, 90, 21, 0.32, 58, 42.00);
INSERT INTO "public"."item_stats" VALUES (118001, 'KrissSuperV', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118024, 'KrissSuperV 4th Anniversary', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118068, 'KrissSuperV Basketball', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118012, 'KrissSuperV Batik', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118015, 'KrissSuperV Batik', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118010, 'KrissSuperV Black', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118022, 'KrissSuperV Black', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118035, 'KrissSuperV Brazuca', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118047, 'KrissSuperV CNY-2015', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118036, 'KrissSuperV Champion', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118046, 'KrissSuperV EvilCupid', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118078, 'KrissSuperV Cupid', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118003, 'KrissSuperV', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118073, 'KrissSuperV DFN', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118062, 'KrissSuperV Dark-Days', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118018, 'KrissSuperV', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118014, 'KrissSuperV ESports', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118020, 'KrissSuperV GRS', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118048, 'KrissSuperV GRS2', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118023, 'KrissSuperV GRS EV', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118021, 'KrissSuperV GSL', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118031, 'KrissSuperV GSL 2014', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118041, 'KrissSuperV G E-Sports', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118002, 'KrissSuperV G', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118071, 'KrissSuperV Halloween', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118055, 'KrissSuperV Harimau', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118017, 'KrissSuperV IC', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118030, 'KrissSuperV Inferno', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118061, 'KrissSuperV Mech', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118032, 'KrissSuperV Midnight', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118038, 'KrissSuperV Midnight Non-Logo', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118077, 'KrissSuperV Monkey', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118049, 'KrissSuperV NEWBORN 2015', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118072, 'KrissSuperV Obsidian', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118052, 'Kriss S V Ongame', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118025, 'KrissSuperV PBIC2013', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118064, 'KrissSuperV PBIC2015', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118059, 'KrissSuperV PBNC2015', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118051, 'KrissSuperV Silence PBNC6', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118040, 'KrissSuperV PBSC2014', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118060, 'KrissSuperV PBTC2015', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118019, 'Kriss S V PBTN', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118039, 'KrissSuperV PC-Cafe', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118029, 'KrissSuperV Russia', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118058, 'KrissSuperV Red', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118053, 'KrissSuperV Redemption', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118026, 'KrissSuperV Silence', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118079, 'KrissSuperV Sakura', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118067, 'KrissSuperV Sheep', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118070, 'Kriss S V Steam', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118054, 'KrissSuperV Summer', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118028, 'KrissSuperV 1st-Garena', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118042, 'KrissSuperV Toy', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118027, 'KrissSuperV Turkey', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118016, 'Kriss Vector SV', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118037, 'KrissSuperV WOE', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118045, 'KrissSuperV Xmas', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118075, 'KrissSuperV Xmas2015', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (315001, 'M-9', 0, 0, 45, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315002, 'M-9', 0, 0, 45, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315004, 'M-9', 0, 0, 45, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315006, 'M-9 PBNC', 0, 0, 45, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (315011, 'M-9 VeraCruz2016', 0, 0, 45, 1.20, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (214001, 'MK23', 24, 72, 19, 0.30, 58, 40.00);
INSERT INTO "public"."item_stats" VALUES (214005, 'MK23', 32, 98, 19, 0.30, 58, 40.00);
INSERT INTO "public"."item_stats" VALUES (214008, 'MK23', 24, 72, 19, 0.30, 58, 40.00);
INSERT INTO "public"."item_stats" VALUES (118065, 'OA-93 Cobra', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118066, 'OA-93 Medical', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118076, 'OA-93 Xmas2015', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118033, 'OA-93', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118069, 'OA-93 Basketball', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118074, 'OA-93 DFN', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118050, 'OA-93 GSL2015', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118034, 'OA-93 Gold', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118056, 'OA-93 Independence', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118063, 'OA-93 PBNC2015 US', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118057, 'OA-93 PBST2015', 60, 60, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118044, 'OA-93 Xmas', 60, 60, 23, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (118043, 'OA-93', 60, 60, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (213001, 'P99', 12, 48, 20, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (213003, 'P99', 16, 64, 20, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (213006, 'P99', 16, 64, 20, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (213005, 'P99', 12, 48, 20, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (213007, 'P99 Reload', 12, 48, 23, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (213002, 'P99 Silver', 16, 64, 20, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (213004, 'P99 Silver', 16, 64, 20, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (214017, 'Scorpion Vz61', 40, 160, 16, 0.08, 75, 50.00);
INSERT INTO "public"."item_stats" VALUES (214018, 'Scorpion Vz61 Gold', 60, 240, 16, 0.08, 75, 50.00);
INSERT INTO "public"."item_stats" VALUES (411001, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411008, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411019, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411013, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411002, 'GrenadeShell', 1, 2, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411026, 'GrenadeShell', 1, 0, 0, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411027, 'GrenadeShell', 1, 0, 0, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411007, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411014, 'GrenadeShell', 1, 0, 50, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411025, 'GrenadeShell', 1, 0, 50, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411011, 'GrenadeShell', 1, 0, 42, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411015, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411006, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411005, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411012, 'GrenadeShell', 1, 0, 25, 0.60, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411024, 'GrenadeShell', 1, 0, 50, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411009, 'PoisonGrenade', 1, 0, 20, 0.50, 95, 20.00);
INSERT INTO "public"."item_stats" VALUES (411017, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411028, 'GrenadeShell', 1, 0, 65, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411004, 'RPG7Shell', 1, 0, 2100, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411003, 'RPG7Shell', 1, 0, 1500, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (411016, 'RPG7Shell', 1, 0, 2100, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (323007, 'BallockKnuckle', 0, 0, 35, 0.10, 50, 1.65);
INSERT INTO "public"."item_stats" VALUES (323001, 'BarefistKnuckle', 0, 0, 32, 0.10, 50, 1.40);
INSERT INTO "public"."item_stats" VALUES (323002, 'BlackKnuckle', 0, 0, 35, 0.10, 50, 1.50);
INSERT INTO "public"."item_stats" VALUES (323003, 'BrassKnuckle', 0, 0, 35, 0.10, 50, 1.50);
INSERT INTO "public"."item_stats" VALUES (323009, 'Garenaknuckle', 0, 0, 35, 0.10, 50, 1.50);
INSERT INTO "public"."item_stats" VALUES (323005, 'PumpkinKnuckle', 0, 0, 35, 0.10, 50, 1.50);
INSERT INTO "public"."item_stats" VALUES (323004, 'SilverKnuckle', 0, 0, 37, 0.10, 50, 1.50);
INSERT INTO "public"."item_stats" VALUES (323006, 'SpikedKnuckle', 0, 0, 35, 0.10, 60, 1.50);
INSERT INTO "public"."item_stats" VALUES (323010, 'Knuckle Holloween', 0, 0, 35, 0.10, 50, 1.50);
INSERT INTO "public"."item_stats" VALUES (110004, 'L86 LSW', 75, 300, 26, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (110010, 'L86 LSW XMAS', 113, 450, 26, 0.07, 76, 120.00);
INSERT INTO "public"."item_stats" VALUES (110005, 'MK46 SteadyAim', 150, 300, 25, 0.08, 79, 120.00);
INSERT INTO "public"."item_stats" VALUES (110009, 'MK46 SteadyAim', 150, 200, 25, 0.08, 79, 120.00);
INSERT INTO "public"."item_stats" VALUES (110002, 'MK46 Silver', 195, 390, 25, 0.08, 79, 120.00);
INSERT INTO "public"."item_stats" VALUES (110001, 'MK46 SteadyAim', 150, 300, 25, 0.08, 79, 120.00);
INSERT INTO "public"."item_stats" VALUES (110003, 'RPD', 100, 300, 33, 0.10, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (110006, 'RPD', 100, 300, 33, 0.10, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (110008, 'RPD', 100, 300, 33, 0.10, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (110007, 'RPD Silver', 130, 390, 33, 0.10, 85, 160.00);
INSERT INTO "public"."item_stats" VALUES (110011, 'Ultimax-100', 100, 200, 28, 0.08, 85, 120.00);
INSERT INTO "public"."item_stats" VALUES (110012, 'Ultimax-100 Gold', 150, 300, 28, 0.08, 85, 120.00);
INSERT INTO "public"."item_stats" VALUES (110013, 'Ultimax-100 Madness', 150, 300, 28, 0.08, 85, 120.00);
INSERT INTO "public"."item_stats" VALUES (301041, 'Arabian sword', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301049, 'Arabian sword2', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301082, 'Arabian Sword Midnight', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301064, 'BadmintonRacket', 0, 0, 88, 0.55, 56, 2.00);
INSERT INTO "public"."item_stats" VALUES (301018, 'BallisticKnife', 5, 5, 60, 0.80, 60, 1.50);
INSERT INTO "public"."item_stats" VALUES (301037, 'BallisticKnife GRS', 5, 5, 60, 0.80, 60, 1.50);
INSERT INTO "public"."item_stats" VALUES (301039, 'Ballistic', 5, 1, 60, 0.80, 60, 70.00);
INSERT INTO "public"."item_stats" VALUES (301020, 'Ballistic', 5, 1, 60, 0.80, 60, 70.00);
INSERT INTO "public"."item_stats" VALUES (301110, 'BallisticKnife Spy-Normal', 5, 5, 60, 0.80, 60, 1.50);
INSERT INTO "public"."item_stats" VALUES (301114, 'BallisticKnife Spy-Deluxe', 5, 5, 60, 0.80, 60, 1.50);
INSERT INTO "public"."item_stats" VALUES (301116, 'Ballistic Spy-Deluxe', 5, 1, 60, 0.80, 60, 70.00);
INSERT INTO "public"."item_stats" VALUES (301112, 'Ballistic Spy-Normal', 5, 1, 60, 0.80, 60, 70.00);
INSERT INTO "public"."item_stats" VALUES (301103, 'Bamboo-Runcing', 0, 0, 85, 0.60, 70, 3.00);
INSERT INTO "public"."item_stats" VALUES (301016, 'BoneKnife', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301109, 'BoneKnife Camo-Soldier', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301040, 'BoneKnife GRS', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301075, 'BoneKnife GRS2', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301102, 'BoneKnife PBNC2015', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301122, 'Butterfly Knife', 0, 0, 86, 0.50, 56, 1.50);
INSERT INTO "public"."item_stats" VALUES (301024, 'CandyCane', 0, 0, 40, 0.20, 56, 2.00);
INSERT INTO "public"."item_stats" VALUES (301058, 'ChineseCleaver', 3, 3, 86, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301073, 'ChineseCleaver CNY-2015', 5, 5, 86, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301074, 'ChineseCleaver CNY-2015', 5, 5, 86, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301060, 'ChineseCleaver', 3, 3, 86, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301061, 'ChineseCleaver', 30, 30, 86, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301062, 'ChineseCleaver', 30, 30, 86, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301105, 'Cutlass Black-Pearl', 0, 0, 84, 1.60, 47, 2.00);
INSERT INTO "public"."item_stats" VALUES (301066, 'Death-Scythe', 0, 0, 92, 1.00, 65, 2.85);
INSERT INTO "public"."item_stats" VALUES (301017, 'FangBlade', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301124, 'FangBlade Arena-Deluxe', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301123, 'FangBlade Arena-Normal', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301052, 'FangBlade Brazuca', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301108, 'Fangblade Cobra', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301051, 'Fang Blade GSL 2014', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301057, 'FangBlade Inferno', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301067, 'FangBlade Latin4', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301113, 'FangBlade Latin5', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301077, 'FangBlade NEWBORN 2015', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301079, 'FangBlade Ongame', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301050, 'FangBlade PBNC5', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301078, 'FangBlade PBNC6', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301094, 'FangBlade PBST2015', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301127, 'FangBlade Sakura', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301101, 'Fangblade PBNC2015', 0, 0, 88, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301025, 'Spetnatz Field Shovel', 2, 2, 108, 0.60, 46, 1.95);
INSERT INTO "public"."item_stats" VALUES (301063, 'Spetnatz Field Shovel', 2, 2, 108, 0.60, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301080, 'Spetnatz Field Shovel Royal', 6, 6, 108, 0.60, 46, 1.95);
INSERT INTO "public"."item_stats" VALUES (301081, 'Spetnatz Field Shovel Royal', 6, 6, 108, 0.60, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301053, 'FryingPan', 99, 99, 30, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301054, 'FryingPan', 99, 99, 30, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301014, 'GH5007', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301095, 'GH5007 4Game', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301096, 'GH5007 4Game-SE', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301093, 'GH5007 Brazil', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301070, 'GH5007 Cangaceiro', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301119, 'GH5007 DFN', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301043, 'GH5007 Gold', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301044, 'GH5007 PBSC2013', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301059, 'GH5007 PBSC2013 Non-Logo', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301084, 'GH5007 Rose', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301106, 'GH5007 VeraCruz', 0, 0, 72, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301071, 'Stick Goat', 4, 4, 108, 0.60, 46, 1.95);
INSERT INTO "public"."item_stats" VALUES (301072, 'Stick Goat', 3, 3, 108, 0.60, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301098, 'HairDryer', 99, 99, 30, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301099, 'HairDryer', 1, 1, 30, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301031, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301003, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301029, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301030, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301045, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301032, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301010, 'Hak', 0, 0, 75, 0.90, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301069, 'Ice Fork', 0, 0, 86, 0.50, 47, 2.20);
INSERT INTO "public"."item_stats" VALUES (301068, 'Icicles', 0, 0, 75, 0.25, 65, 2.20);
INSERT INTO "public"."item_stats" VALUES (301021, 'Keris', 0, 0, 86, 0.83, 65, 1.70);
INSERT INTO "public"."item_stats" VALUES (301065, 'Keris G E-Sports', 0, 0, 86, 0.83, 65, 1.70);
INSERT INTO "public"."item_stats" VALUES (301104, 'Keris PBIC2015', 0, 0, 88, 0.83, 65, 1.70);
INSERT INTO "public"."item_stats" VALUES (301023, 'Keris SE', 0, 0, 88, 0.83, 65, 1.70);
INSERT INTO "public"."item_stats" VALUES (301047, 'Keris XMAS', 0, 0, 88, 0.83, 65, 1.70);
INSERT INTO "public"."item_stats" VALUES (301004, 'Kukrii', 0, 0, 84, 0.60, 47, 2.00);
INSERT INTO "public"."item_stats" VALUES (301011, 'Kukrii', 0, 0, 84, 0.60, 47, 2.00);
INSERT INTO "public"."item_stats" VALUES (301026, 'Kukrii', 0, 0, 84, 0.60, 47, 2.00);
INSERT INTO "public"."item_stats" VALUES (301046, 'Kukri Turkey', 0, 0, 84, 0.60, 47, 2.00);
INSERT INTO "public"."item_stats" VALUES (301107, 'Kunai Dual', 0, 0, 65, 0.05, 43, 70.00);
INSERT INTO "public"."item_stats" VALUES (301001, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301036, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301117, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301118, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301009, 'M-7 Gold', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301033, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301034, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301035, 'M-7', 0, 0, 60, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301002, 'M-9', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301042, 'M-9 PBNC', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301125, 'M-9 VeraCruz2016', 0, 0, 64, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301090, 'Arabian sword', 0, 0, 35, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301091, 'Death-Scythe', 0, 0, 70, 1.00, 65, 2.85);
INSERT INTO "public"."item_stats" VALUES (301088, 'FangBlade', 0, 0, 40, 0.55, 56, 2.20);
INSERT INTO "public"."item_stats" VALUES (301092, 'GH5007', 0, 0, 40, 0.50, 47, 1.90);
INSERT INTO "public"."item_stats" VALUES (301089, 'Keris', 0, 0, 35, 0.83, 65, 1.70);
INSERT INTO "public"."item_stats" VALUES (301086, 'Kukrii', 0, 0, 35, 0.60, 47, 2.00);
INSERT INTO "public"."item_stats" VALUES (301085, 'M-7', 0, 0, 30, 0.40, 43, 1.50);
INSERT INTO "public"."item_stats" VALUES (301007, 'MiniAxe', 2, 2, 60, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301012, 'MiniAxe', 2, 2, 60, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301006, 'MiniAxe', 1, 1, 60, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301013, 'MiniAxe', 1, 1, 60, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301028, 'MiniAxe', 1, 1, 60, 1.00, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (301008, 'MiniAxe', 2, 2, 60, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301027, 'MiniAxe', 2, 2, 60, 1.00, 46, 1.70);
INSERT INTO "public"."item_stats" VALUES (301120, 'Stick Monkey', 4, 4, 108, 0.60, 46, 1.95);
INSERT INTO "public"."item_stats" VALUES (301121, 'Stick Monkey', 3, 3, 108, 0.60, 46, 70.00);
INSERT INTO "public"."item_stats" VALUES (117001, 'M197', 300000, 900000, 30, 0.07, 79, 7000.00);
INSERT INTO "public"."item_stats" VALUES (202022, 'Colt45', 7, 28, 25, 0.20, 83, 55.00);
INSERT INTO "public"."item_stats" VALUES (202031, 'Colt45', 7, 28, 25, 0.20, 83, 55.00);
INSERT INTO "public"."item_stats" VALUES (202007, 'ColtPython', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202080, 'ColtPython Arena-Deluxe', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202079, 'ColtPython Arena-Normal', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202060, 'ColtPython Brazil', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202049, 'ColtPython Brazuca', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202012, 'ColtPython', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202017, 'ColtPython Gold', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202018, 'ColtPython Gold', 14, 53, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202010, 'ColtPython Gold', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202076, 'ColtPython Latin5', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202020, 'ColtPython', 7, 28, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202067, 'ColtPython PBNC2015', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202040, 'ColtPython PBNC5', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202056, 'ColtPython PBNC6', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202059, 'ColtPython Rose', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202082, 'ColtPython Sakura', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202058, 'ColtPython Summer', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202052, 'ColtPython Toy', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202072, 'ColtPython VeraCruz', 11, 44, 47, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202001, 'DesertEagle', 7, 28, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202048, 'DesertEagle BR Camo', 11, 44, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202030, 'DesertEagle', 7, 28, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202032, 'DesertEagle GRS', 11, 44, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202051, 'DesertEagle G E-Sports', 11, 44, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202008, 'DesertEagle Gold', 11, 44, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202064, 'DesertEagle Lebaran2015', 7, 35, 33, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202057, 'DesertEagle Ongame', 9, 36, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202005, 'DesertEagle REF', 11, 44, 28, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202036, 'DesertEagle Reload', 7, 35, 33, 0.29, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202011, 'Glock18', 17, 68, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202021, 'Glock18', 20, 80, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202062, 'Glock18 4Game', 17, 68, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202063, 'Glock18 4Game-SE', 25, 100, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202039, 'Glock18 Azerbaijan', 20, 80, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202047, 'Glock18 EX BR Camo', 25, 100, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202071, 'Glock18 Gold', 25, 100, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202033, 'Glock18 PBNC', 25, 100, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202061, 'Glock18 PBST2015', 20, 80, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202037, 'Glock18 Ex Turkey', 20, 80, 17, 0.09, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202025, 'HK45 Dual', 10, 30, 22, 0.40, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202038, 'HK45 Dual Halloween', 10, 30, 22, 0.40, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202023, 'IMI Uzi 9mm', 20, 80, 16, 0.08, 50, 60.00);
INSERT INTO "public"."item_stats" VALUES (202003, 'K5', 12, 48, 17, 0.22, 38, 45.00);
INSERT INTO "public"."item_stats" VALUES (202009, 'K5', 12, 48, 17, 0.22, 55, 45.00);
INSERT INTO "public"."item_stats" VALUES (202024, 'Kriss Vector SDP', 13, 39, 17, 0.07, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (202074, 'Kriss Vector SDP Camo-Soldier', 17, 51, 17, 0.07, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (202069, 'Kriss Vector SDP Dark-Days', 20, 60, 17, 0.07, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (202035, 'MK23 Reload', 12, 48, 23, 0.16, 64, 45.00);
INSERT INTO "public"."item_stats" VALUES (202075, 'MK23 Spy-Normal', 12, 48, 20, 0.16, 64, 45.00);
INSERT INTO "public"."item_stats" VALUES (202002, 'MK23', 12, 48, 20, 0.16, 64, 45.00);
INSERT INTO "public"."item_stats" VALUES (202019, 'MK23', 16, 64, 20, 0.16, 64, 45.00);
INSERT INTO "public"."item_stats" VALUES (202027, 'MK23 SILVER', 16, 64, 20, 0.16, 64, 45.00);
INSERT INTO "public"."item_stats" VALUES (202077, 'MK23 Spy-Deluxe', 16, 64, 20, 0.16, 64, 45.00);
INSERT INTO "public"."item_stats" VALUES (202006, 'P99', 12, 48, 17, 0.16, 55, 40.00);
INSERT INTO "public"."item_stats" VALUES (202073, 'Taurus 454SS Scope Cobra', 8, 40, 75, 0.10, 79, 55.00);
INSERT INTO "public"."item_stats" VALUES (202013, 'Taurus 454SS 2M', 5, 25, 64, 0.10, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202014, 'Taurus 454SS 5M', 5, 25, 71, 0.10, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202015, 'Taurus 454SS 8M', 5, 25, 75, 0.10, 79, 45.00);
INSERT INTO "public"."item_stats" VALUES (202016, 'Taurus 454SS Scope', 5, 25, 75, 0.10, 79, 50.00);
INSERT INTO "public"."item_stats" VALUES (202068, 'Taurus 454SS Scope Mech', 8, 40, 75, 0.10, 79, 50.00);
INSERT INTO "public"."item_stats" VALUES (202070, 'Taurus 454SS Scope PBIC2015', 8, 40, 75, 0.10, 79, 55.00);
INSERT INTO "public"."item_stats" VALUES (202034, 'Tarus 454SS Scope PBSC2013', 8, 40, 75, 0.10, 79, 55.00);
INSERT INTO "public"."item_stats" VALUES (202050, 'Tarus 454SS Scope PBSC2013 Non-Logo', 8, 40, 75, 0.10, 79, 55.00);
INSERT INTO "public"."item_stats" VALUES (202081, 'Taurus 454SS Scope VeraCruz2016', 8, 40, 75, 0.10, 79, 50.00);
INSERT INTO "public"."item_stats" VALUES (202029, 'GL 06', 1, 3, 50, 0.50, 95, 40.00);
INSERT INTO "public"."item_stats" VALUES (202054, 'GL 06 CNY-2015', 1, 5, 50, 0.50, 95, 40.00);
INSERT INTO "public"."item_stats" VALUES (202026, 'HK69', 1, 3, 42, 0.50, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (202028, 'M79', 1, 3, 25, 0.60, 95, 45.00);
INSERT INTO "public"."item_stats" VALUES (202053, 'MGL-Snow', 6, 24, 120, 3.00, 90, 70.00);
INSERT INTO "public"."item_stats" VALUES (116002, 'RPG7', 1, 3, 2100, 0.30, 100, 70.00);
INSERT INTO "public"."item_stats" VALUES (116003, 'RPG7', 1, 1, 1000, 0.30, 100, 70.00);
INSERT INTO "public"."item_stats" VALUES (116001, 'RPG7', 1, 1, 2100, 0.30, 100, 70.00);
INSERT INTO "public"."item_stats" VALUES (104096, 'AKS74U Reload', 30, 210, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104033, 'AKS74U', 30, 210, 26, 0.09, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (104076, 'AKS74U', 30, 210, 26, 0.09, 85, 60.00);
INSERT INTO "public"."item_stats" VALUES (104193, 'GrenadeLauncher EVO-3', 30, 210, 23, 0.05, 57, 100.00);
INSERT INTO "public"."item_stats" VALUES (104194, 'GrenadeLauncher EVO-3 Gold', 45, 225, 23, 0.05, 57, 100.00);
INSERT INTO "public"."item_stats" VALUES (104006, 'K-1', 30, 120, 23, 0.08, 51, 70.00);
INSERT INTO "public"."item_stats" VALUES (104021, 'K-1 SE', 40, 280, 23, 0.08, 73, 70.00);
INSERT INTO "public"."item_stats" VALUES (104003, 'K-1', 30, 210, 23, 0.08, 73, 70.00);
INSERT INTO "public"."item_stats" VALUES (104013, 'KrissSuperV', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104101, 'KrissSuperV 4th Anniversary', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104102, 'KrissSuperV 4th Anniversary', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104223, 'KrissSuperV Basketball', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104224, 'KrissSuperV Basketball', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104052, 'KrissSuperV Batik', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104047, 'KrissSuperV Batik', 40, 280, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104053, 'KrissSuperV Batik', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104048, 'KrissSuperV Batik', 40, 280, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104039, 'KrissSuperV Black', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104040, 'KrissSuperV Black', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104090, 'KrissSuperV Black', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104091, 'KrissSuperV Black', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104139, 'KrissSuperV Brazuca', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104140, 'KrissSuperV Brazuca', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104172, 'KrissSuperV CNY-2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104173, 'KrissSuperV CNY-2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104142, 'KrissSuperV Champion', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104143, 'KrissSuperV Champion', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104170, 'KrissSuperV EvilCupid', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104171, 'KrissSuperV EvilCupid', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104005, 'KrissSuperV Cupid', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104018, 'KrissSuperV Cupid', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104031, 'KrissSuperV', 40, 280, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104245, 'KrissSuperV DFN', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104246, 'KrissSuperV DFN', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104212, 'KrissSuperV Dark-Days', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104213, 'KrissSuperV Dark-Days', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104012, 'KrissSuperV', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104030, 'KrissSuperV', 40, 280, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104050, 'KrissSuperV ESports', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104051, 'KrissSuperV ESports', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104065, 'KrissSuperV', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104073, 'KrissSuperV', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104019, 'KrissSuperV', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104083, 'KrissSuperV GRS', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104175, 'KrissSuperV GRS2', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104176, 'KrissSuperV GRS2', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104084, 'KrissSuperV GRS', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104093, 'KrissSuperV GRS EV', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104094, 'KrissSuperV GRS EV', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104087, 'KrissSuperV GSL', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104130, 'KrissSuperV GSL 2014', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104131, 'KrissSuperV GSL 2014', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104088, 'KrissSuperV GSL', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104155, 'KrissSuperV G E-Sports', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104156, 'KrissSuperV G E-Sports', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104026, 'KrissSuperV G', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104028, 'KrissSuperV G', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104237, 'KrissSuperV Halloween', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104238, 'KrissSuperV Halloween', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104196, 'KrissSuperV Harimau', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104197, 'KrissSuperV Harimau', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104060, 'KrissSuperV IC', 40, 280, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104061, 'KrissSuperV IC', 40, 280, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104126, 'KrissSuperV Inferno', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104127, 'KrissSuperV Inferno', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104209, 'KrissSuperV Mech', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104211, 'KrissSuperV Mech', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104132, 'KrissSuperV Midnight', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104133, 'KrissSuperV Midnight', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104149, 'KrissSuperV Midnight Non-Logo', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104150, 'KrissSuperV Midnight Non-Logo', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104253, 'KrissSuperV Monkey', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104254, 'KrissSuperV Monkey', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104178, 'KrissSuperV NEWBORN 2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104179, 'KrissSuperV NEWBORN 2015', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104242, 'KrissSuperV Obsidian', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104243, 'KrissSuperV Obsidian', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104185, 'Kriss S V Ongame', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104186, 'Kriss S V Ongame', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104103, 'KrissSuperV PBIC2013', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104104, 'KrissSuperV PBIC2013', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104216, 'KrissSuperV PBIC2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104217, 'KrissSuperV PBIC2015', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104205, 'KrissSuperV PBNC2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104206, 'KrissSuperV PBNC2015', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104183, 'KrissSuperV Silence PBNC6', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104184, 'KrissSuperV Silence PBNC6', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104153, 'KrissSuperV PBSC2014', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104154, 'KrissSuperV PBSC2014', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104207, 'KrissSuperV PBTC2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104208, 'KrissSuperV PBTC2015', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104079, 'Kriss S V PBTN', 30, 210, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104080, 'Kriss S V PBTN', 40, 280, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104151, 'KrissSuperV PC-Cafe', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104152, 'KrissSuperV PC-Cafe', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104123, 'KrissSuperV Russia', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104124, 'KrissSuperV Russia', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104201, 'KrissSuperV Red', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104202, 'KrissSuperV Red', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104188, 'KrissSuperV Redemption', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104189, 'KrissSuperV Redemption', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104108, 'KrissSuperV Silence', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104109, 'KrissSuperV Silence', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104115, 'KrissSuperV Sakura', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104044, 'KrissSuperV Sakura', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104221, 'KrissSuperV Sheep', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104222, 'KrissSuperV Sheep', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104235, 'Kriss S V Steam', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104236, 'Kriss S V Steam', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104191, 'KrissSuperV Summer', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104192, 'KrissSuperV Summer', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104121, 'KrissSuperV 1st-Garena', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104122, 'KrissSuperV 1st-Garena', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104157, 'KrissSuperV Toy', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104158, 'KrissSuperV Toy', 35, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104110, 'KrissSuperV Turkey', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104111, 'KrissSuperV Turkey', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104054, 'Kriss Vector SV', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104055, 'Kriss Vector SV', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104144, 'KrissSuperV WOE', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104145, 'KrissSuperV WOE', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104168, 'KrissSuperV Xmas', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104249, 'KrissSuperV Xmas2015', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104250, 'KrissSuperV Xmas2015', 30, 210, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104169, 'KrissSuperV Xmas', 45, 315, 21, 0.07, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104034, 'M4-CQBR-LV1', 30, 210, 23, 0.07, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (104070, 'M4-CQBR-LV1', 30, 210, 23, 0.07, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (104035, 'M4-CQBR-LV2', 30, 210, 23, 0.07, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (104071, 'M4-CQBR-LV2', 30, 210, 23, 0.07, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (104036, 'M4-CQBR-LV3', 30, 210, 23, 0.07, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (104072, 'M4-CQBR-LV3', 30, 210, 23, 0.07, 76, 80.00);
INSERT INTO "public"."item_stats" VALUES (104063, 'MP5K SERIF', 45, 320, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104100, 'MP5K Reload', 30, 210, 21, 0.06, 70, 60.00);
INSERT INTO "public"."item_stats" VALUES (104007, 'MP5K SERIF', 45, 320, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104024, 'MP5K SERIF', 45, 320, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104001, 'MP5K', 30, 210, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104014, 'MP5K Silver', 40, 280, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104041, 'MP5K Silver', 40, 280, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104067, 'MP5K Silver', 40, 280, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104015, 'MP5K White', 30, 210, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104038, 'MP7 Camo', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104004, 'MP7 DotSight', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104045, 'MP7 DotSight', 40, 280, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104066, 'MP7 DotSight', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104081, 'MP7 GRS', 30, 210, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104105, 'MP7 GRS EV', 45, 315, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104056, 'MP7 NON EX', 30, 120, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104059, 'MP7 SE2', 35, 210, 22, 0.06, 80, 70.00);
INSERT INTO "public"."item_stats" VALUES (104022, 'MP7 SL', 40, 280, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104037, 'MP7 SL', 40, 280, 21, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104107, 'MP9 Ext', 30, 210, 20, 0.06, 55, 60.00);
INSERT INTO "public"."item_stats" VALUES (104161, 'MP9 Ext Gold', 45, 315, 20, 0.06, 55, 60.00);
INSERT INTO "public"."item_stats" VALUES (104164, 'MP9 Ext Xmas', 45, 315, 21, 0.06, 55, 60.00);
INSERT INTO "public"."item_stats" VALUES (104232, 'OA-93 Cobra', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104233, 'OA-93 Cobra', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104228, 'OA-93 Medical', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104229, 'OA-93 Medical', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104251, 'OA-93 Xmas2015', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104252, 'OA-93 Xmas2015', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104134, 'OA-93', 30, 210, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104225, 'OA-93 Basketball', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104226, 'OA-93 Basketball', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104247, 'OA-93 DFN', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104248, 'OA-93 DFN', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104135, 'OA-93', 30, 210, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104180, 'OA-93 GSL2015', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104181, 'OA-93 GSL2015', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104136, 'OA-93 Gold', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104137, 'OA-93 Gold', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104198, 'OA-93 Independence', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104199, 'OA-93 Independence', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104214, 'OA-93 PBNC2015 US', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104215, 'OA-93 PBNC2015 US', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104203, 'OA-93 PBST2015', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104204, 'OA-93 PBST2015', 45, 315, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104159, 'OA-93', 40, 280, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104160, 'OA-93', 40, 280, 22, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104165, 'OA-93 Xmas', 45, 315, 23, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104166, 'OA-93 Xmas', 45, 315, 23, 0.06, 80, 60.00);
INSERT INTO "public"."item_stats" VALUES (104010, 'P90MC', 30, 150, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104027, 'P90MC Camo', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104234, 'P90 MC Camo-Soldier', 40, 200, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104032, 'P90MC', 40, 200, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104113, 'P90MC Latin3', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104148, 'P90 MC Latin3 Non-Logo', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104086, 'P90MC PBNC', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104240, 'P90 MC Spy-Normal', 30, 150, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104064, 'P90MC Camo', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104174, 'P90 MC Sheep', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104114, 'P90 BR-Camo', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104227, 'P90 Ext Basketball', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104011, 'P90 Ext', 50, 200, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104029, 'P90 Ext', 65, 260, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104141, 'P90 Ext 5th Anniversary', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104138, 'P90 EXT Brazuca', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104017, 'P90 EXT Cupid', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104069, 'P90 Ext', 50, 200, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104239, 'P90 Ext Halloween', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104128, 'P90 Ext Inferno', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104163, 'P90 Ext Latin4', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104210, 'P90 Ext Mech', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104230, 'P90 Ext Medical', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104187, 'P90 Ext Ongame', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104146, 'P90 Ext PBIC2014', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104218, 'P90 Ext PBIC2015', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104129, 'P90 Ext PBNC5', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104190, 'P90 Ext Redemption', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104182, 'P90 Ext Silence GSL2015', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104089, 'P90 GSL', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104075, 'P90 Gold', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104220, 'P90 MC VeraCruz', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104112, 'P90MC BLOODY', 50, 200, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104200, 'P90 MC Brazil', 40, 200, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104082, 'P90MC GRS', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104095, 'P90MC GRS EV', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104219, 'P90 MC Gold', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104241, 'P90 MC Latin5', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104195, 'P90 MC Rose', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104244, 'P90 MC Spy-Deluxe', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104255, 'P90 MC VeraCruz2016', 45, 225, 22, 0.07, 85, 100.00);
INSERT INTO "public"."item_stats" VALUES (104085, 'P90 NEWBORN', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104125, 'P90 NEWBORN 2014', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104177, 'P90 NEWBORN 2015', 75, 300, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104078, 'P90 PBTN', 50, 200, 22, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104077, 'P90 Wh PBSC', 50, 250, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104147, 'P90 Wh PBSC Non-Logo', 50, 250, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104106, 'PP19-BIZON', 53, 212, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104162, 'PP19-BIZON Gold', 80, 320, 24, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104167, 'PP19-BIZON Xmas', 80, 320, 25, 0.07, 85, 65.00);
INSERT INTO "public"."item_stats" VALUES (104043, 'Pindad SS1-R5 Carbine', 30, 120, 25, 0.08, 73, 70.00);
INSERT INTO "public"."item_stats" VALUES (104049, 'Pindad SS SS1-R5 Carbine Gold', 45, 180, 25, 0.08, 73, 70.00);
INSERT INTO "public"."item_stats" VALUES (104099, 'Pindad SS SS1-R5 Carbine Reload', 30, 150, 25, 0.07, 73, 70.00);
INSERT INTO "public"."item_stats" VALUES (104057, 'Spectre NON EX', 50, 120, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104098, 'Spectre Reload', 50, 300, 22, 0.07, 70, 65.00);
INSERT INTO "public"."item_stats" VALUES (104009, 'Spectre SE', 50, 300, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104020, 'Spectre Silver', 65, 390, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104042, 'Spectre Silver', 65, 390, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104074, 'Spectre Silver', 65, 390, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104002, 'Spectre', 50, 300, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104062, 'Spectre SE', 50, 300, 23, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104016, 'Spectre White', 50, 300, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104025, 'Spectre SE', 65, 390, 22, 0.07, 70, 45.00);
INSERT INTO "public"."item_stats" VALUES (104058, 'UMP45 Black', 25, 200, 25, 0.09, 70, 50.00);
INSERT INTO "public"."item_stats" VALUES (104092, 'UMP45 Black', 25, 200, 25, 0.09, 70, 50.00);
INSERT INTO "public"."item_stats" VALUES (104008, 'UMP45', 25, 200, 25, 0.09, 70, 50.00);
INSERT INTO "public"."item_stats" VALUES (104046, 'UMP45', 33, 260, 25, 0.09, 70, 50.00);
INSERT INTO "public"."item_stats" VALUES (104097, 'UMP45 Reload', 25, 200, 25, 0.07, 70, 65.00);
INSERT INTO "public"."item_stats" VALUES (104023, 'UMP45 SL', 33, 264, 25, 0.09, 70, 50.00);
INSERT INTO "public"."item_stats" VALUES (104068, 'UMP45 SL', 33, 264, 25, 0.09, 70, 50.00);
INSERT INTO "public"."item_stats" VALUES (106001, '870MCS', 8, 32, 23, 1.00, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106015, '870MCS', 8, 32, 23, 1.00, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106002, '870MCS E', 8, 32, 23, 1.00, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106007, '870MCS', 8, 32, 22, 1.00, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106008, '870MCS SL', 10, 40, 23, 1.00, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106014, '870MCS SL', 11, 44, 23, 1.00, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106004, '870MCS W', 8, 32, 23, 1.00, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106011, '870MCS W', 10, 40, 23, 1.00, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106023, '870MCS W', 8, 32, 23, 1.00, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106047, 'Cerberus Shotgun', 15, 45, 50, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106019, 'JackHammer', 8, 32, 19, 0.20, 25, 20.00);
INSERT INTO "public"."item_stats" VALUES (106020, 'Kel Tec KSG 15', 14, 32, 21, 1.00, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106036, 'Kel Tec KSG 15 GSL 2014', 14, 32, 21, 1.00, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106005, 'M1887', 8, 32, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106010, 'M1887 SE', 8, 24, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106026, 'M1887 GRS', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106028, 'M1887 GRS EV', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106034, 'M1887 GRS', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106033, 'M1887 1st-Garena', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106064, 'M1887 Arena-Deluxe', 8, 32, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106063, 'M1887 Arena-Normal', 8, 32, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106030, 'M1887 BLOODY', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106037, 'M1887 Brazuca', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106065, 'M1887 Cupid', 12, 48, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106017, 'M1887', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106049, 'M1887 GSL2015', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106059, 'M1887 Gold', 12, 48, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106041, 'M1887 Lion-Heart', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106056, 'M1887 Mech', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106060, 'M1887 Medical', 12, 48, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106062, 'M1887 Obsidian', 12, 48, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106038, 'M1887 PBIC2014', 10, 42, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106058, 'M1887 PBIC2015', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106027, 'M1887 PBNC', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106053, 'M1887 PBNC2015', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106035, 'M1887 PBNC5', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106055, 'M1887 PBTC2015', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106021, 'M1887 SL', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106061, 'M1887 Steam', 12, 48, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106052, 'M1887 Summer', 10, 40, 23, 1.10, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (106043, 'Remington ETA', 8, 32, 15, 0.72, 3, 65.00);
INSERT INTO "public"."item_stats" VALUES (106044, 'Remington ETA Gold', 12, 48, 15, 0.72, 3, 65.00);
INSERT INTO "public"."item_stats" VALUES (106003, 'SPAS15', 6, 30, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106012, 'SPAS15', 8, 40, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106022, 'SPAS15', 6, 30, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106032, 'SPAS15 Elite', 9, 45, 50, 0.71, 50, 100.00);
INSERT INTO "public"."item_stats" VALUES (106018, 'SPAS15 MSC', 10, 40, 19, 0.70, 30, 90.00);
INSERT INTO "public"."item_stats" VALUES (106057, 'SPAS15 MSC PBNC2015 US', 15, 80, 19, 0.70, 30, 90.00);
INSERT INTO "public"."item_stats" VALUES (106054, 'SPAS15 PBNC2015', 10, 50, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106050, 'SPAS15 PBNC6', 10, 50, 50, 0.71, 50, 100.00);
INSERT INTO "public"."item_stats" VALUES (106029, 'SPAS 15 PBSC2013', 10, 50, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106040, 'SPAS15 PBSC2013 Non-Logo', 10, 50, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106006, 'SPAS15 Silver', 8, 40, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106016, 'SPAS15 Silver', 8, 40, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106024, 'SPAS15 Silver', 8, 40, 25, 0.75, 50, 65.00);
INSERT INTO "public"."item_stats" VALUES (106009, 'SPAS15 Silver', 6, 30, 25, 0.75, 30, 65.00);
INSERT INTO "public"."item_stats" VALUES (230001, 'SuperShorty870', 6, 24, 10, 0.95, 0, 30.00);
INSERT INTO "public"."item_stats" VALUES (106039, 'UTS-15', 14, 56, 19, 0.70, 10, 60.00);
INSERT INTO "public"."item_stats" VALUES (106046, 'UTS-15', 18, 72, 19, 0.70, 10, 60.00);
INSERT INTO "public"."item_stats" VALUES (106048, 'UTS-15 Gold', 21, 84, 19, 0.70, 10, 60.00);
INSERT INTO "public"."item_stats" VALUES (106051, 'WaterGun', 6, 20000, 14, 0.35, 25, 65.00);
INSERT INTO "public"."item_stats" VALUES (106042, 'Zombie Slayer', 12, 48, 22, 0.88, 10, 70.00);
INSERT INTO "public"."item_stats" VALUES (105032, 'Barrett M82A1', 10, 30, 200, 0.66, 150, 200.00);
INSERT INTO "public"."item_stats" VALUES (105118, 'Cheytac M200 Dark-Days', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105030, 'Cheytac', 5, 30, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105112, 'Cheytac M200 4Game', 5, 30, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105113, 'Cheytac M200 4Game-SE', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105142, 'Cheytac M200 Arena-Deluxe', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105141, 'Cheytac M200 Arena-Normal', 5, 30, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105057, 'Cheytac M200 BLOODY', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105110, 'Cheytac M200 Brazil', 6, 36, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105083, 'Cheytac M200 Brazuca', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105097, 'Cheytac M200 Cangaceiro', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105084, 'Cheytac M200 Champion', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105099, 'Cheytac M200 EvilCupid', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105147, 'Cheytac M200 Cupid', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105137, 'Cheytac M200 DFN', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105052, 'Cheytac GRS', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105100, 'Cheytac M200 GRS2', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105058, 'Cheytac GRS EV', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105055, 'Cheytac GSL', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105102, 'Cheytac M200 GSL2015', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105091, 'Cheytac M200 G E-Sports', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105121, 'Cheytac M200 Gold', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105131, 'Cheytac M200 Halloween', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105079, 'Cheytac M200 Inferno', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105096, 'Cheytac M200 Latin4', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105134, 'Cheytac M200 Latin5', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105108, 'Cheytac M200 LionFlame', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105126, 'Cheytac M200 Medical', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105090, 'Cheytac M200 Merdeka', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105140, 'Cheytac M200 Monkey', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105135, 'Cheytac M200 Obsidian', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105104, 'Cheytac M200 Ongame', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105087, 'Cheytac M200 PBIC2014', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105120, 'Cheytac M200 PBIC2015', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105114, 'Cheytac M200 PBNC2015', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105080, 'Cheytac M200 PBNC5', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105103, 'Cheytac M200 PBNC6', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105111, 'Cheytac M200 PBST2015', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105115, 'Cheytac M200 PBTC2015', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105073, 'Cheytac M200 Russia', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105105, 'Cheytac M200 Redemption', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105148, 'Cheytac M200 Sakura', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105124, 'Cheytac M200 Sheep', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105144, 'Cheytac M200 Silence', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105130, 'Cheytac M200 Steam', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105071, 'Cheytac M200 1st-Garena', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105063, 'Cheytac M200 Turkey', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105122, 'Cheytac M200 VeraCruz', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105143, 'Cheytac M200 VeraCruz2016', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105086, 'Cheytac M200 WOE', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105138, 'Cheytac M200 Xmas2015', 7, 42, 95, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105034, 'Dsr 1', 5, 30, 84, 0.35, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105098, 'Dsr 1', 7, 42, 84, 0.35, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105095, 'Dsr 1 Gold', 8, 48, 84, 0.35, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105133, 'DSR 1 Spy-Normal', 5, 30, 84, 0.35, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105136, 'DSR 1 Spy-Deluxe', 8, 48, 84, 0.35, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105002, 'HK-PSG1', 5, 40, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105024, 'HK-PSG1 Gold', 8, 64, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105059, 'HK-PSG1 Reload', 5, 40, 84, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105007, 'HK-PSG1 S', 8, 64, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105016, 'HK-PSG1 S', 7, 56, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105038, 'HK-PSG1 S', 8, 64, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105009, 'HK-PSG1 Silver', 7, 56, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105042, 'HK-PSG1 Silver', 7, 56, 81, 0.60, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105005, 'L115A1', 5, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105017, 'L115A1', 7, 42, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105065, 'L115A1 BR-Camo', 8, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105125, 'L115A1 Basketball', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105026, 'L115A1 Black', 5, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105056, 'L115A1 Black', 5, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105089, 'L115A1 PC-Cafe', 5, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105127, 'L115A1 Cobra', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105033, 'L115A1 ESports', 5, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105041, 'L115A1', 5, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105081, 'L115A1 GSL 2014', 10, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105015, 'L115A1 G', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105109, 'L115A1 Harimau', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105064, 'L115A1 Latin3', 10, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105088, 'L115A1 Latin3 Non-Logo', 10, 30, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105117, 'L115A1 Mech', 8, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105101, 'L115A1 NEWBORN 2015', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105053, 'L115A1 PBNC', 8, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105050, 'L115A1 PBTN', 10, 30, 86, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105036, 'L115A1 SE', 8, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105106, 'L115A1 Summer', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105092, 'L115A1 Toy', 10, 48, 85, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105018, 'M4-SPR-LV1', 20, 60, 36, 0.20, 76, 160.00);
INSERT INTO "public"."item_stats" VALUES (105044, 'M4-SPR-LV1', 20, 60, 36, 0.20, 76, 160.00);
INSERT INTO "public"."item_stats" VALUES (105019, 'M4-SPR-LV2', 20, 60, 36, 0.20, 76, 160.00);
INSERT INTO "public"."item_stats" VALUES (105045, 'M4-SPR-LV2', 20, 60, 36, 0.20, 76, 160.00);
INSERT INTO "public"."item_stats" VALUES (105020, 'M4-SPR-LV3', 20, 60, 36, 0.20, 76, 160.00);
INSERT INTO "public"."item_stats" VALUES (105046, 'M4-SPR-LV3', 20, 60, 36, 0.20, 76, 160.00);
INSERT INTO "public"."item_stats" VALUES (105145, 'PGM-Hecate2', 7, 42, 97, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105146, 'PGM-Hecate2 Gold', 10, 60, 97, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105021, 'RangeMaster338', 5, 30, 86, 0.34, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105128, 'RngMaster 338 Camo-Soldier', 7, 42, 86, 0.34, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105060, 'RangeMaster338', 5, 30, 86, 0.34, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105022, 'RangeMaster762', 10, 30, 80, 0.32, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105023, 'RangeMaster762Stby', 10, 30, 77, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105062, 'RngMaster 762 Stby Reload', 10, 30, 80, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105061, 'RngMaster 762 Reload', 10, 30, 82, 0.32, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105003, 'SSG69', 5, 30, 76, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105004, 'SSG69 Camo', 8, 48, 76, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105025, 'SSG69', 5, 30, 76, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105008, 'SSG69 Silver', 7, 42, 76, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105027, 'SSG69 Silver', 7, 42, 76, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105043, 'SSG69 Silver', 7, 42, 76, 0.30, 100, 180.00);
INSERT INTO "public"."item_stats" VALUES (105001, 'SVD-Dragunov', 10, 30, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105028, 'SVD-Dragunov', 10, 30, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105076, 'SVD-Dragunov Elite', 15, 45, 85, 0.50, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105014, 'SVD-Dragunov SE', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105039, 'SVD-Dragunov SE', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105012, 'SVD-Dragunov KingCobra Gold', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105049, 'SVD-Dragunov KingCobra Gold', 20, 60, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105011, 'SVD-Dragunov KingCobra Silver', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105047, 'SVD-Dragunov Red', 13, 36, 80, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105107, 'SVD-Dragunov Rose', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105006, 'SVD-Dragunov SE', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105010, 'SVD-Dragunov Silver', 13, 39, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105040, 'SVD-Dragunov Silver', 13, 39, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105085, 'SVD-Dragunov WOE', 15, 45, 78, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105035, 'SVU', 10, 40, 76, 0.47, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105077, 'SVU Elite', 15, 60, 81, 0.47, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105094, 'SVU Gold', 15, 60, 76, 0.47, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105116, 'SVU PBTC2015', 15, 60, 76, 0.47, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105054, 'SVU SE', 15, 60, 76, 0.47, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105123, 'Tactilite T2', 5, 30, 97, 0.33, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105132, 'Taclite-T2 Gold', 7, 42, 97, 0.33, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105139, 'Taclite-T2 Xmas2015', 7, 42, 97, 0.33, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105029, 'VSK94', 10, 40, 45, 0.30, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105048, 'VSK94', 10, 40, 45, 0.30, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105078, 'VSK94 Elite', 15, 60, 50, 0.29, 100, 130.00);
INSERT INTO "public"."item_stats" VALUES (105093, 'VSK94 Gold', 15, 60, 45, 0.30, 100, 120.00);
INSERT INTO "public"."item_stats" VALUES (105072, 'Walther wa2000', 10, 30, 80, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105074, 'Walther wa2000 Gold', 15, 45, 80, 0.60, 100, 160.00);
INSERT INTO "public"."item_stats" VALUES (105031, 'M70', 7, 35, 83, 0.30, 100, 210.00);
INSERT INTO "public"."item_stats" VALUES (105068, 'XM2010', 5, 30, 82, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (105119, 'XM2010 PBNC2015 US', 7, 42, 82, 0.35, 100, 200.00);
INSERT INTO "public"."item_stats" VALUES (407002, 'C5', 1, 1, 60, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407044, 'C5 CNY-2015', 1, 1, 60, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407003, 'C5', 1, 1, 60, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407006, 'C5', 1, 1, 60, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407009, 'CANDYGRENADE', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407005, 'ChocolateGrenade', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407012, 'Decoy Bomb', 1, 1, 25, 1.00, 100, 30.00);
INSERT INTO "public"."item_stats" VALUES (407010, 'Fanoos Grenade', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407016, 'Football Bomb', 1, 1, 25, 1.00, 100, 30.00);
INSERT INTO "public"."item_stats" VALUES (407001, 'K-400', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407015, 'K-400 Easter', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407025, 'K-400 Goat', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407004, 'K-413', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407047, 'K-413 4Game', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407048, 'K-413 4Game-SE', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407045, 'K-413 Chocolate', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407024, 'K-413', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407007, 'K-413 Gold', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407020, 'K-413 PC Cafe', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407046, 'K-413 Redemption', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407017, 'K-413', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407019, 'K-413', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407014, 'K-479', 1, 1, 35, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407008, 'Ketupat Grenade', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407013, 'M14 Mine', 1, 1, 35, 1.00, 0, 30.00);
INSERT INTO "public"."item_stats" VALUES (407018, 'M14 Mine', 1, 1, 35, 1.00, 0, 30.00);
INSERT INTO "public"."item_stats" VALUES (407023, 'M18 A1 Claymore', 1, 1, 65, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407011, 'Maamoul Grenade', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407026, 'Meat-Bomb', 1, 1, 500, 1.00, 94, 20.00);
INSERT INTO "public"."item_stats" VALUES (407022, 'Bomb SepaktakrawBall', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407021, 'bomb Shuttlecock', 2, 2, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (407049, 'Snowman Grenade', 1, 1, 90, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528003, 'Chocolate Kit', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (508002, 'FlashBang', 1, 1, 0, 1.00, 100, 30.00);
INSERT INTO "public"."item_stats" VALUES (508004, 'FlashBang Plus', 1, 1, 0, 1.00, 100, 30.00);
INSERT INTO "public"."item_stats" VALUES (528002, 'Halloween Medical Kit', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528001, 'Medical Kit', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528007, 'Medical Kit Easter', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528009, 'Medical Kit Kurma', 1, 1, 50, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528004, 'Medical Kit Lotus', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528008, 'Medical Kit Lotus2', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528005, 'Medical Kit Opor-Ayam', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528012, 'Medical Kit PBNC2015', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528006, 'MedicalKit PBNC5', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528010, 'MedicalKit PBNC6', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (528011, 'Medical Kit Pigeon', 1, 1, 40, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (508001, 'SmokeGrenade', 1, 1, 0, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (508003, 'Smoke Plus', 1, 1, 0, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (527001, 'SmokeGrenade WP', 1, 1, 1, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (527003, 'WP Smoke Plus', 1, 1, 2, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (527005, 'WP Smoke Plus', 1, 1, 2, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (527002, 'SmokeGrenade WP', 1, 1, 1, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (527004, 'SmokeGrenade WP', 1, 1, 1, 1.00, 94, 30.00);
INSERT INTO "public"."item_stats" VALUES (412003, 'BombTrigger', 1, 1, 90, 1.00, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (412002, 'BombTrigger', 1, 1, 90, 1.00, 95, 30.00);
INSERT INTO "public"."item_stats" VALUES (103040, 'AUG-A3 D.', 40, 200, 26, 0.07, 85, 100.00);

-- ----------------------------
-- Table structure for logs_auto_ban
-- ----------------------------
DROP TABLE IF EXISTS "public"."logs_auto_ban";
CREATE TABLE "public"."logs_auto_ban" (
  "object_id" int8 NOT NULL DEFAULT nextval('auto_ban_seq'::regclass),
  "player_id" int8 NOT NULL DEFAULT 0,
  "login" varchar(255) COLLATE "pg_catalog"."default",
  "player_name" varchar(255) COLLATE "pg_catalog"."default",
  "type" varchar(255) COLLATE "pg_catalog"."default",
  "time" varchar(255) COLLATE "pg_catalog"."default",
  "ip" varchar(255) COLLATE "pg_catalog"."default",
  "hack_type" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of logs_auto_ban
-- ----------------------------

-- ----------------------------
-- Table structure for logs_nick_history
-- ----------------------------
DROP TABLE IF EXISTS "public"."logs_nick_history";
CREATE TABLE "public"."logs_nick_history" (
  "player_id" int8 NOT NULL DEFAULT 0,
  "from_nick" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "to_nick" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "change_date" int8 NOT NULL DEFAULT 0,
  "motive" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying
)
;

-- ----------------------------
-- Records of logs_nick_history
-- ----------------------------
INSERT INTO "public"."logs_nick_history" VALUES (5, '', 'EmpireB', 1404181059, 'First nick choosed');
INSERT INTO "public"."logs_nick_history" VALUES (6, '', 'EmpireB', 2404181319, 'First nick choosed');
INSERT INTO "public"."logs_nick_history" VALUES (7, '', 'hELLO', 2404231556, 'First nick choosed');
INSERT INTO "public"."logs_nick_history" VALUES (8, '', '11111', 2404231615, 'First nick choosed');
INSERT INTO "public"."logs_nick_history" VALUES (9, '', 'Ambasador', 2407270250, 'First nick choosed');

-- ----------------------------
-- Table structure for permissions
-- ----------------------------
DROP TABLE IF EXISTS "public"."permissions";
CREATE TABLE "public"."permissions" (
  "id" int4 NOT NULL,
  "permission" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of permissions
-- ----------------------------
INSERT INTO "public"."permissions" VALUES (1, 'observer_enabled', 'Enable observer check box in rooms');
INSERT INTO "public"."permissions" VALUES (2, 'commandscommand', 'Allow to use :commands %page% command');
INSERT INTO "public"."permissions" VALUES (3, 'giftcommand', 'Allow to use :gift %userId% %type% %value% command');
INSERT INTO "public"."permissions" VALUES (4, 'updatecommand', 'Allow to use :update %what% command');
INSERT INTO "public"."permissions" VALUES (5, 'testcommand', 'Just for speed-up dev phase');

-- ----------------------------
-- Table structure for permissions_levels
-- ----------------------------
DROP TABLE IF EXISTS "public"."permissions_levels";
CREATE TABLE "public"."permissions_levels" (
  "id" int4 NOT NULL,
  "name" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "fake_rank" int4
)
;

-- ----------------------------
-- Records of permissions_levels
-- ----------------------------
INSERT INTO "public"."permissions_levels" VALUES (6, 'GameMaster', 'Access level for gamemaster', 53);
INSERT INTO "public"."permissions_levels" VALUES (5, 'Moderator', 'Access level for moderator', 54);
INSERT INTO "public"."permissions_levels" VALUES (4, 'Trial Moderator', 'Access level for trial moderator', 54);
INSERT INTO "public"."permissions_levels" VALUES (3, 'Streamer', 'Access level for youtube / twitch streamer', -1);
INSERT INTO "public"."permissions_levels" VALUES (2, 'Vip Gold', 'Access level for advanced vip', -1);
INSERT INTO "public"."permissions_levels" VALUES (1, 'Vip Silver', 'Access level for basic vip', -1);
INSERT INTO "public"."permissions_levels" VALUES (0, 'User', 'Access level for normal users', -1);

-- ----------------------------
-- Table structure for permissions_rights
-- ----------------------------
DROP TABLE IF EXISTS "public"."permissions_rights";
CREATE TABLE "public"."permissions_rights" (
  "level_id" int4 NOT NULL,
  "permission_id" int4
)
;

-- ----------------------------
-- Records of permissions_rights
-- ----------------------------
INSERT INTO "public"."permissions_rights" VALUES (3, 1);
INSERT INTO "public"."permissions_rights" VALUES (5, 1);
INSERT INTO "public"."permissions_rights" VALUES (4, 2);
INSERT INTO "public"."permissions_rights" VALUES (5, 2);
INSERT INTO "public"."permissions_rights" VALUES (6, 2);
INSERT INTO "public"."permissions_rights" VALUES (4, 3);
INSERT INTO "public"."permissions_rights" VALUES (5, 3);
INSERT INTO "public"."permissions_rights" VALUES (6, 4);
INSERT INTO "public"."permissions_rights" VALUES (6, 1);
INSERT INTO "public"."permissions_rights" VALUES (6, 3);
INSERT INTO "public"."permissions_rights" VALUES (6, 5);

-- ----------------------------
-- Table structure for player_bonus
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_bonus";
CREATE TABLE "public"."player_bonus" (
  "player_id" int8 NOT NULL DEFAULT 0,
  "bonuses" int4 NOT NULL DEFAULT 0,
  "sightcolor" int4 NOT NULL DEFAULT 4,
  "freepass" int4 NOT NULL DEFAULT 0,
  "fakerank" int4 NOT NULL DEFAULT 55,
  "fakenick" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "muzzle" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of player_bonus
-- ----------------------------
INSERT INTO "public"."player_bonus" VALUES (5, 0, 4, 0, 55, '', 0);
INSERT INTO "public"."player_bonus" VALUES (6, 0, 4, 0, 55, '', 0);
INSERT INTO "public"."player_bonus" VALUES (7, 0, 4, 0, 55, '', 0);
INSERT INTO "public"."player_bonus" VALUES (8, 0, 4, 0, 55, '', 0);
INSERT INTO "public"."player_bonus" VALUES (9, 0, 4, 0, 55, '', 0);

-- ----------------------------
-- Table structure for player_characters
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_characters";
CREATE TABLE "public"."player_characters" (
  "object_id" int8 NOT NULL DEFAULT nextval('player_characters_id_seq'::regclass),
  "player_id" int8 NOT NULL DEFAULT 0,
  "id" int4 NOT NULL DEFAULT 0,
  "slot" int4 NOT NULL DEFAULT 0,
  "name" varchar(33) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "createdate" int8 NOT NULL DEFAULT 1010000,
  "playtime" int8 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of player_characters
-- ----------------------------
INSERT INTO "public"."player_characters" VALUES (315, 5, 601001, 0, 'Red Bulls', 1404181059, 0);
INSERT INTO "public"."player_characters" VALUES (316, 5, 602002, 1, 'Acid Pol', 1404181059, 0);
INSERT INTO "public"."player_characters" VALUES (329, 6, 601001, 0, 'Red Bulls', 1404181319, 0);
INSERT INTO "public"."player_characters" VALUES (330, 6, 602002, 1, 'Acid Pol', 1404181319, 0);
INSERT INTO "public"."player_characters" VALUES (333, 8, 601001, 0, 'Red Bulls', 1404231615, 0);
INSERT INTO "public"."player_characters" VALUES (334, 8, 602002, 1, 'Acid Pol', 1404231615, 0);
INSERT INTO "public"."player_characters" VALUES (350, 9, 601001, 0, 'Red Bulls', 1407270250, 0);
INSERT INTO "public"."player_characters" VALUES (351, 9, 602002, 1, 'Acid Pol', 1407270250, 0);
INSERT INTO "public"."player_characters" VALUES (331, 7, 601001, 0, 'Red Bulls', 1404231556, 0);
INSERT INTO "public"."player_characters" VALUES (332, 7, 602002, 1, 'Acid Pol', 1404231556, 0);
INSERT INTO "public"."player_characters" VALUES (337, 7, 601391, 2, 'PB Ranger Tarantula', 1407262051, 0);
INSERT INTO "public"."player_characters" VALUES (338, 7, 602011, 3, 'Chou(CT-FORCE)', 1407262052, 0);
INSERT INTO "public"."player_characters" VALUES (341, 7, 601398, 4, 'Psycho Nurse Viper Red', 1407262101, 0);
INSERT INTO "public"."player_characters" VALUES (344, 7, 601124, 5, 'Non String', 1407270118, 0);
INSERT INTO "public"."player_characters" VALUES (346, 7, 602035, 6, 'Leopard Bope', 1407270126, 0);
INSERT INTO "public"."player_characters" VALUES (347, 7, 602195, 7, 'Army Agent Hide', 1407270126, 0);
INSERT INTO "public"."player_characters" VALUES (349, 7, 602070, 8, 'Wolf', 1407270128, 0);
INSERT INTO "public"."player_characters" VALUES (352, 7, 601111, 9, 'Grim Reaper Rica', 1407270426, 0);

-- ----------------------------
-- Table structure for player_configs
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_configs";
CREATE TABLE "public"."player_configs" (
  "owner_id" int8 NOT NULL DEFAULT 0,
  "config" int4 NOT NULL DEFAULT 55,
  "sangue" int4 NOT NULL DEFAULT 1,
  "mira" int4 NOT NULL DEFAULT 0,
  "mao" int4 NOT NULL DEFAULT 0,
  "audio1" int4 NOT NULL DEFAULT 100,
  "audio2" int4 NOT NULL DEFAULT 60,
  "audio_enable" int4 NOT NULL DEFAULT 6,
  "sensibilidade" int4 NOT NULL DEFAULT 50,
  "visao" int4 NOT NULL DEFAULT 70,
  "mouse_invertido" int4 NOT NULL DEFAULT 0,
  "msgconvite" int4 NOT NULL DEFAULT 0,
  "chatsussurro" int4 NOT NULL DEFAULT 0,
  "macro" int4 NOT NULL DEFAULT 31,
  "macro_1" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "macro_2" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "macro_3" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "macro_4" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "macro_5" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "keys" bytea NOT NULL DEFAULT '\x'::bytea
)
;

-- ----------------------------
-- Records of player_configs
-- ----------------------------
INSERT INTO "public"."player_configs" VALUES (6, 32, 0, 1, 0, 0, 0, 0, 55, 70, 0, 0, 6, 0, '', '', '', '', '', E'\\000\\012\\000\\000\\000\\000\\015\\000\\000\\000\\000 \\000\\000\\000\\000\\034\\000\\000\\000\\000,\\000\\000\\000\\000(\\000\\000\\000\\000&\\000\\000\\000\\000\\017\\000\\000\\000\\001\\001\\000\\000\\000\\001\\002\\000\\000\\000\\000\\033\\000\\000\\000\\000\\035\\000\\000\\000\\000\\001\\000\\000\\000\\000\\002\\000\\000\\000\\000\\003\\000\\000\\000\\000\\004\\000\\000\\000\\000\\005\\000\\000\\000\\000\\006\\000\\000\\000\\000\\032\\000\\000\\000\\001\\000\\000\\000\\020\\001\\000\\000\\000 \\000\\020\\000\\000\\000\\0007\\000\\000\\000\\000\\026\\000\\000\\000\\000\\\\\\000\\000\\000\\000[\\000\\000\\000\\000%\\000\\000\\000\\000@\\000\\000\\000\\000A\\000\\000\\000\\000\\025\\000\\000\\000\\000\\377\\377\\377\\377\\000#\\000\\000\\000\\000!\\000\\000\\000\\000\\014\\000\\000\\000\\000\\016\\000\\000\\000\\0001\\000\\000\\000\\0002\\000\\000\\000\\000F\\000\\000\\000\\000B\\000\\000\\000\\000\\013\\000\\000\\000\\000:\\000\\000\\000\\000"\\000\\000\\000\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377');
INSERT INTO "public"."player_configs" VALUES (5, 55, 3, 2, 0, 100, 60, 6, 50, 70, 0, 0, 0, 31, '', '', '', '', '', E'\\000\\012\\000\\000\\000\\000\\015\\000\\000\\000\\000 \\000\\000\\000\\000\\034\\000\\000\\000\\000,\\000\\000\\000\\000(\\000\\000\\000\\000&\\000\\000\\000\\000\\017\\000\\000\\000\\001\\001\\000\\000\\000\\001\\002\\000\\000\\000\\000\\033\\000\\000\\000\\000\\035\\000\\000\\000\\000\\001\\000\\000\\000\\000\\002\\000\\000\\000\\000\\003\\000\\000\\000\\000\\004\\000\\000\\000\\000\\005\\000\\000\\000\\000\\006\\000\\000\\000\\000\\032\\000\\000\\000\\001\\000\\000\\000\\020\\001\\000\\000\\000 \\000\\020\\000\\000\\000\\0007\\000\\000\\000\\000\\000\\000\\000\\000\\000\\\\\\000\\000\\000\\000[\\000\\000\\000\\000%\\000\\000\\000\\000@\\000\\000\\000\\000A\\000\\000\\000\\000\\025\\000\\000\\000\\000\\377\\377\\377\\377\\000#\\000\\000\\000\\000!\\000\\000\\000\\000\\014\\000\\000\\000\\000\\016\\000\\000\\000\\0001\\000\\000\\000\\0002\\000\\000\\000\\000F\\000\\000\\000\\000B\\000\\000\\000\\000\\013\\000\\000\\000\\000:\\000\\000\\000\\000"\\000\\000\\000\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377');
INSERT INTO "public"."player_configs" VALUES (9, 55, 1, 0, 0, 100, 60, 6, 50, 70, 0, 0, 0, 31, '', '', '', '', '', E'\\000\\012\\000\\000\\000\\000\\015\\000\\000\\000\\000 \\000\\000\\000\\000\\034\\000\\000\\000\\000,\\000\\000\\000\\000(\\000\\000\\000\\000&\\000\\000\\000\\000\\017\\000\\000\\000\\001\\001\\000\\000\\000\\001\\002\\000\\000\\000\\000\\033\\000\\000\\000\\000\\035\\000\\000\\000\\000\\001\\000\\000\\000\\000\\002\\000\\000\\000\\000\\003\\000\\000\\000\\000\\004\\000\\000\\000\\000\\005\\000\\000\\000\\000\\006\\000\\000\\000\\000\\032\\000\\000\\000\\001\\000\\000\\000\\020\\001\\000\\000\\000 \\000\\020\\000\\000\\000\\0007\\000\\000\\000\\000\\026\\000\\000\\000\\000\\\\\\000\\000\\000\\000[\\000\\000\\000\\000%\\000\\000\\000\\000@\\000\\000\\000\\000A\\000\\000\\000\\000\\025\\000\\000\\000\\000\\377\\377\\377\\377\\000#\\000\\000\\000\\000!\\000\\000\\000\\000\\014\\000\\000\\000\\000\\016\\000\\000\\000\\0001\\000\\000\\000\\0002\\000\\000\\000\\000F\\000\\000\\000\\000B\\000\\000\\000\\000\\013\\000\\000\\000\\000:\\000\\000\\000\\000"\\000\\000\\000\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377');
INSERT INTO "public"."player_configs" VALUES (7, 55, 3, 2, 0, 52, 40, 7, 50, 80, 0, 0, 0, 31, '', '', '', '', '', E'\\000\\012\\000\\000\\000\\000\\015\\000\\000\\000\\000 \\000\\000\\000\\000\\034\\000\\000\\000\\000,\\000\\000\\000\\000(\\000\\000\\000\\000&\\000\\000\\000\\000\\017\\000\\000\\000\\001\\001\\000\\000\\000\\001\\002\\000\\000\\000\\000\\033\\000\\000\\000\\000\\035\\000\\000\\000\\000\\001\\000\\000\\000\\000\\002\\000\\000\\000\\000\\003\\000\\000\\000\\000\\004\\000\\000\\000\\000\\005\\000\\000\\000\\000\\006\\000\\000\\000\\000\\032\\000\\000\\000\\001\\000\\000\\000\\020\\001\\000\\000\\000 \\000\\020\\000\\000\\000\\0007\\000\\000\\000\\000\\000\\000\\000\\000\\000\\\\\\000\\000\\000\\000[\\000\\000\\000\\000%\\000\\000\\000\\000@\\000\\000\\000\\000A\\000\\000\\000\\000\\025\\000\\000\\000\\000\\377\\377\\377\\377\\000#\\000\\000\\000\\000!\\000\\000\\000\\000\\014\\000\\000\\000\\000\\016\\000\\000\\000\\0001\\000\\000\\000\\0002\\000\\000\\000\\000F\\000\\000\\000\\000B\\000\\000\\000\\000\\013\\000\\000\\000\\000:\\000\\000\\000\\000"\\000\\000\\000\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377');
INSERT INTO "public"."player_configs" VALUES (8, 55, 1, 2, 0, 100, 60, 6, 50, 80, 0, 0, 0, 31, '', '', '', '', '', E'\\000\\012\\000\\000\\000\\000\\015\\000\\000\\000\\000 \\000\\000\\000\\000\\034\\000\\000\\000\\000,\\000\\000\\000\\000(\\000\\000\\000\\000&\\000\\000\\000\\000\\017\\000\\000\\000\\001\\001\\000\\000\\000\\001\\002\\000\\000\\000\\000\\033\\000\\000\\000\\000\\035\\000\\000\\000\\000\\001\\000\\000\\000\\000\\002\\000\\000\\000\\000\\003\\000\\000\\000\\000\\004\\000\\000\\000\\000\\005\\000\\000\\000\\000\\006\\000\\000\\000\\000\\032\\000\\000\\000\\001\\000\\000\\000\\020\\001\\000\\000\\000 \\000\\020\\000\\000\\000\\0007\\000\\000\\000\\000\\000\\000\\000\\000\\000\\\\\\000\\000\\000\\000[\\000\\000\\000\\000%\\000\\000\\000\\000@\\000\\000\\000\\000A\\000\\000\\000\\000\\025\\000\\000\\000\\000\\377\\377\\377\\377\\000#\\000\\000\\000\\000!\\000\\000\\000\\000\\014\\000\\000\\000\\000\\016\\000\\000\\000\\0001\\000\\000\\000\\0002\\000\\000\\000\\000F\\000\\000\\000\\000B\\000\\000\\000\\000\\013\\000\\000\\000\\000:\\000\\000\\000\\000"\\000\\000\\000\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377\\000\\377\\377\\377\\377');

-- ----------------------------
-- Table structure for player_dailyrecord
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_dailyrecord";
CREATE TABLE "public"."player_dailyrecord" (
  "player_id" int8 NOT NULL,
  "total" int4 NOT NULL DEFAULT 0,
  "wins" int4 NOT NULL DEFAULT 0,
  "loses" int4 NOT NULL DEFAULT 0,
  "draws" int4 NOT NULL DEFAULT 0,
  "kills" int4 NOT NULL DEFAULT 0,
  "deaths" int4 NOT NULL DEFAULT 0,
  "headshots" int4 NOT NULL DEFAULT 0,
  "point" int4 NOT NULL DEFAULT 0,
  "exp" int4 NOT NULL DEFAULT 0,
  "playtime" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of player_dailyrecord
-- ----------------------------
INSERT INTO "public"."player_dailyrecord" VALUES (9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_dailyrecord" VALUES (5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_dailyrecord" VALUES (6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_dailyrecord" VALUES (7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_dailyrecord" VALUES (8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- ----------------------------
-- Table structure for player_events
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_events";
CREATE TABLE "public"."player_events" (
  "player_id" int8 NOT NULL DEFAULT 0,
  "last_visit_event_id" int4 NOT NULL DEFAULT 0,
  "last_visit_sequence1" int4 NOT NULL DEFAULT 0,
  "last_visit_sequence2" int4 NOT NULL DEFAULT 0,
  "next_visit_date" int4 NOT NULL DEFAULT 0,
  "last_xmas_reward_date" int8 NOT NULL DEFAULT 0,
  "last_playtime_date" int8 NOT NULL DEFAULT 0,
  "last_playtime_value" int4 NOT NULL DEFAULT 0,
  "last_playtime_finish" int4 NOT NULL DEFAULT 0,
  "last_login_date" int8 NOT NULL DEFAULT 0,
  "last_quest_date" int8 NOT NULL DEFAULT 0,
  "last_quest_finish" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of player_events
-- ----------------------------
INSERT INTO "public"."player_events" VALUES (5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_events" VALUES (7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_events" VALUES (6, 0, 1, 0, 140419, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_events" VALUES (8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_events" VALUES (9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- ----------------------------
-- Table structure for player_friends
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_friends";
CREATE TABLE "public"."player_friends" (
  "owner_id" int8 NOT NULL DEFAULT 0,
  "friend_id" int8 NOT NULL DEFAULT 0,
  "state" int4 NOT NULL DEFAULT 0,
  "removed" bool NOT NULL DEFAULT false
)
;

-- ----------------------------
-- Records of player_friends
-- ----------------------------

-- ----------------------------
-- Table structure for player_items
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_items";
CREATE TABLE "public"."player_items" (
  "object_id" int8 NOT NULL DEFAULT nextval('items_id_seq'::regclass),
  "owner_id" int8 NOT NULL DEFAULT 0,
  "item_id" int4 NOT NULL DEFAULT 0,
  "item_name" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "count" int8 NOT NULL DEFAULT 0,
  "category" int4 NOT NULL DEFAULT 0,
  "equip" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of player_items
-- ----------------------------
INSERT INTO "public"."player_items" VALUES (5, 5, 601001, 'Red Bulls', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (6, 5, 602002, 'Acid Pol', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (66, 7, 601111, 'Rica Halloween (72 hours)', 259200, 2, 1);
INSERT INTO "public"."player_items" VALUES (33, 6, 601001, 'Red Bulls', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (34, 6, 602002, 'Acid Pol', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (35, 7, 601001, 'Red Bulls', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (36, 7, 602002, 'Acid Pol', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (37, 8, 601001, 'Red Bulls', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (38, 8, 602002, 'Acid Pol', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (39, 6, 2700014, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (40, 6, 2700016, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (41, 6, 2700015, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (42, 6, 2700017, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (43, 6, 2700018, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (46, 7, 601391, 'PBRangerTarantula (24 hours)', 86400, 2, 1);
INSERT INTO "public"."player_items" VALUES (50, 7, 601398, 'PsychoNurseViperRed (24 hours)', 86400, 2, 1);
INSERT INTO "public"."player_items" VALUES (47, 7, 602011, 'Chou (720 hours)', 2409242101, 2, 2);
INSERT INTO "public"."player_items" VALUES (55, 7, 602035, 'Leopard Bope (72 hours)', 2407300126, 2, 2);
INSERT INTO "public"."player_items" VALUES (58, 7, 602070, 'Wolf (72 hours)', 2407300128, 2, 2);
INSERT INTO "public"."player_items" VALUES (59, 7, 2700014, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (60, 7, 2700016, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (61, 7, 2700015, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (62, 7, 2700017, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (63, 7, 2700018, 'Title Reward', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (64, 9, 601001, 'Red Bulls', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (65, 9, 602002, 'Acid Pol', 1, 2, 3);
INSERT INTO "public"."player_items" VALUES (53, 7, 601124, 'Rica Zombie (72 hours)', 2407300417, 2, 2);
INSERT INTO "public"."player_items" VALUES (56, 7, 602195, 'Hide JumpSuit (72 hours)', 2407300417, 2, 2);

-- ----------------------------
-- Table structure for player_messages
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_messages";
CREATE TABLE "public"."player_messages" (
  "object_id" int4 NOT NULL DEFAULT nextval('message_id_seq'::regclass),
  "owner_id" int8 NOT NULL DEFAULT 0,
  "sender_id" int8 NOT NULL DEFAULT 0,
  "clan_id" int4 NOT NULL DEFAULT 0,
  "sender_name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "text" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "type" int4 NOT NULL DEFAULT 0,
  "state" int4 NOT NULL DEFAULT 1,
  "expire" int8 NOT NULL DEFAULT 0,
  "cb" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of player_messages
-- ----------------------------

-- ----------------------------
-- Table structure for player_missions
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_missions";
CREATE TABLE "public"."player_missions" (
  "owner_id" int8 NOT NULL DEFAULT 0,
  "actual_mission" int4 NOT NULL DEFAULT 0,
  "card1" int4 NOT NULL DEFAULT 0,
  "card2" int4 NOT NULL DEFAULT 0,
  "card3" int4 NOT NULL DEFAULT 0,
  "card4" int4 NOT NULL DEFAULT 0,
  "mission1" bytea NOT NULL DEFAULT '\x'::bytea,
  "mission2" bytea NOT NULL DEFAULT '\x'::bytea,
  "mission3" bytea NOT NULL DEFAULT '\x'::bytea,
  "mission4" bytea NOT NULL DEFAULT '\x'::bytea
)
;

-- ----------------------------
-- Records of player_missions
-- ----------------------------
INSERT INTO "public"."player_missions" VALUES (5, 0, 0, 0, 0, 0, '', '', '', '');
INSERT INTO "public"."player_missions" VALUES (8, 0, 0, 6, 0, 0, '', '', '', '');
INSERT INTO "public"."player_missions" VALUES (6, 0, 0, 1, 6, 0, '', '', '', '');
INSERT INTO "public"."player_missions" VALUES (9, 0, 0, 0, 0, 0, '', '', '', '');
INSERT INTO "public"."player_missions" VALUES (7, 1, 0, 0, 0, 0, '', '', '', '');

-- ----------------------------
-- Table structure for player_quickstart
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_quickstart";
CREATE TABLE "public"."player_quickstart" (
  "owner_id" int8 NOT NULL,
  "map_0" int4 DEFAULT 0,
  "rule_0" int4 DEFAULT 0,
  "stage_0" int4 DEFAULT 0,
  "type_0" int4 DEFAULT 0,
  "map_1" int4 DEFAULT 0,
  "rule_1" int4 DEFAULT 0,
  "stage_1" int4 DEFAULT 0,
  "type_1" int4 DEFAULT 0,
  "map_2" int4 DEFAULT 0,
  "rule_2" int4 DEFAULT 0,
  "stage_2" int4 DEFAULT 0,
  "type_2" int4 DEFAULT 0
)
;

-- ----------------------------
-- Records of player_quickstart
-- ----------------------------
INSERT INTO "public"."player_quickstart" VALUES (5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_quickstart" VALUES (6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_quickstart" VALUES (8, 4, 0, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_quickstart" VALUES (9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
INSERT INTO "public"."player_quickstart" VALUES (7, 0, 128, 1, 8, 0, 0, 0, 0, 0, 0, 0, 0);

-- ----------------------------
-- Table structure for player_titles
-- ----------------------------
DROP TABLE IF EXISTS "public"."player_titles";
CREATE TABLE "public"."player_titles" (
  "owner_id" int8 NOT NULL DEFAULT 0,
  "titleequiped1" int4 NOT NULL DEFAULT 0,
  "titleequiped2" int4 NOT NULL DEFAULT 0,
  "titleequiped3" int4 NOT NULL DEFAULT 0,
  "titleflags" int8 NOT NULL DEFAULT 0,
  "titleslots" int4 NOT NULL DEFAULT 1
)
;

-- ----------------------------
-- Records of player_titles
-- ----------------------------
INSERT INTO "public"."player_titles" VALUES (7, 4, 13, 29, 35184372088830, 3);
INSERT INTO "public"."player_titles" VALUES (6, 4, 13, 25, 3405039846398, 3);

-- ----------------------------
-- Table structure for players
-- ----------------------------
DROP TABLE IF EXISTS "public"."players";
CREATE TABLE "public"."players" (
  "login" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "password" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "player_id" int8 NOT NULL DEFAULT nextval('account_id_seq'::regclass),
  "player_name" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "name_color" int4 NOT NULL DEFAULT 0,
  "clan_id" int4 NOT NULL DEFAULT 0,
  "rank" int4 NOT NULL DEFAULT 0,
  "gp" int4 NOT NULL DEFAULT 5000000,
  "exp" int4 NOT NULL DEFAULT 0,
  "pc_cafe" int4 NOT NULL DEFAULT 0,
  "fights" int4 NOT NULL DEFAULT 0,
  "fights_win" int4 NOT NULL DEFAULT 0,
  "fights_lost" int4 NOT NULL DEFAULT 0,
  "kills_count" int4 NOT NULL DEFAULT 0,
  "deaths_count" int4 NOT NULL DEFAULT 0,
  "headshots_count" int4 NOT NULL DEFAULT 0,
  "escapes" int4 NOT NULL DEFAULT 0,
  "access_level" int4 NOT NULL DEFAULT 0,
  "lastip" varchar(32) COLLATE "pg_catalog"."default" NOT NULL DEFAULT 0,
  "email" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "last_rankup_date" int8 NOT NULL DEFAULT 1010000,
  "money" int4 NOT NULL DEFAULT 5000000,
  "online" bool NOT NULL DEFAULT false,
  "weapon_primary" int4 NOT NULL DEFAULT 104006,
  "weapon_secondary" int4 NOT NULL DEFAULT 202003,
  "weapon_melee" int4 NOT NULL DEFAULT 301001,
  "weapon_thrown_normal" int4 NOT NULL DEFAULT 407001,
  "weapon_thrown_special" int4 NOT NULL DEFAULT 508001,
  "char_red" int4 NOT NULL DEFAULT 601001,
  "char_blue" int4 NOT NULL DEFAULT 602002,
  "char_helmet" int4 NOT NULL DEFAULT 1000800000,
  "char_dino" int4 NOT NULL DEFAULT 1500511,
  "char_beret" int4 NOT NULL DEFAULT 0,
  "brooch" int4 NOT NULL DEFAULT 0,
  "insignia" int4 NOT NULL DEFAULT 0,
  "medal" int4 NOT NULL DEFAULT 0,
  "blue_order" int4 NOT NULL DEFAULT 0,
  "mission_id1" int4 NOT NULL DEFAULT 1,
  "clanaccess" int4 NOT NULL DEFAULT 0,
  "clandate" int4 NOT NULL DEFAULT 0,
  "effects" int8 NOT NULL DEFAULT 0,
  "fights_draw" int4 NOT NULL DEFAULT 0,
  "mission_id2" int4 NOT NULL DEFAULT 0,
  "mission_id3" int4 NOT NULL DEFAULT 0,
  "totalkills_count" int4 NOT NULL DEFAULT 0,
  "totalfights_count" int4 NOT NULL DEFAULT 0,
  "status" int8 NOT NULL DEFAULT '4294967295'::bigint,
  "last_login" int8 NOT NULL DEFAULT 0,
  "clan_game_pt" int4 NOT NULL DEFAULT 0,
  "clan_wins_pt" int4 NOT NULL DEFAULT 0,
  "last_mac" macaddr NOT NULL DEFAULT '00:00:00:00:00:00'::macaddr,
  "ban_obj_id" int8 NOT NULL DEFAULT 0,
  "token" varchar(255) COLLATE "pg_catalog"."default" DEFAULT ''::character varying,
  "hwid" varchar(255) COLLATE "pg_catalog"."default" DEFAULT ''::character varying,
  "coin" int4 NOT NULL DEFAULT 0,
  "age" int4 NOT NULL DEFAULT 0,
  "ranked_point" int4 NOT NULL DEFAULT 0,
  "assist" int4 NOT NULL DEFAULT 0,
  "face" int4 NOT NULL DEFAULT 1000700000,
  "jacket" int4 NOT NULL DEFAULT 1000900000,
  "poket" int4 NOT NULL DEFAULT 1001000000,
  "glove" int4 NOT NULL DEFAULT 1001100000,
  "belt" int4 NOT NULL DEFAULT 1001200000,
  "holster" int4 NOT NULL DEFAULT 1001300000,
  "skin" int4 NOT NULL DEFAULT 1001400000,
  "accessory" int4 NOT NULL DEFAULT 0,
  "mvp" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of players
-- ----------------------------
INSERT INTO "public"."players" VALUES ('rupb', 'rupb', 9, 'Ambasador', 0, 0, 0, 5000000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '127.0.0.1', '', 1010000, 5000000, 'f', 104006, 202003, 301001, 407001, 508001, 601001, 602002, 1000800000, 1500511, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4294967295, 0, 0, 0, '0c:de:0c:9d:1d:de', 0, 'rupb', '', 0, 0, 0, 0, 1000700000, 1000900000, 1001000000, 1001100000, 1001200000, 1001300000, 1001400000, 0, 0);
INSERT INTO "public"."players" VALUES ('token2', 'token2', 7, 'hELLO', 0, 232, 36, 4958200, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, '127.0.0.1', '', 1010000, 4957900, 't', 104006, 202003, 301001, 407001, 508001, 601001, 602002, 1000800000, 1500511, 0, 989, 874, 594, 849, 1, 0, 0, 0, 0, 5, 0, 0, 0, 4278255622, 0, 0, 0, '0c:de:0c:9d:1d:de', 0, 'token2', '', 0, 0, 0, 0, 1000700000, 1000900000, 1001000000, 1001100000, 1001200000, 1001300000, 1001400000, 0, 0);
INSERT INTO "public"."players" VALUES ('12345678', '12345678', 8, '11111', 0, 0, 1, 4999400, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, '127.0.0.1', '', 1010000, 5000000, 't', 104006, 202003, 301001, 407001, 508001, 601001, 602002, 1000800000, 1500511, 0, 999, 998, 997, 996, 1, 0, 0, 0, 0, 5, 0, 0, 0, 4278255615, 0, 0, 0, '00:00:00:00:00:00', 0, '12345678', '', 0, 0, 0, 0, 1000700000, 1000900000, 1001000000, 1001100000, 1001200000, 1001300000, 1001400000, 0, 0);
INSERT INTO "public"."players" VALUES ('token3', 'token3', 6, 'EmpireB', 0, 24, 1, 4994800, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, '127.0.0.1', '', 1010000, 5000000, 'f', 104006, 202003, 301001, 407001, 508001, 601001, 602002, 1000800000, 1500511, 0, 979, 874, 594, 849, 1, 1, 20140429, 0, 0, 5, 7, 0, 0, 4294967295, 0, 0, 0, '0c:de:0c:9d:1d:de', 0, 'token3', '', 0, 0, 0, 0, 1000700000, 1000900000, 1001000000, 1001100000, 1001200000, 1001300000, 1001400000, 0, 0);

-- ----------------------------
-- Table structure for server_cards
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_cards";
CREATE TABLE "public"."server_cards" (
  "mission_id" int4 NOT NULL DEFAULT 0,
  "price" int4 NOT NULL DEFAULT 0,
  "enable" bool NOT NULL DEFAULT false
)
;

-- ----------------------------
-- Records of server_cards
-- ----------------------------
INSERT INTO "public"."server_cards" VALUES (1, 0, 't');
INSERT INTO "public"."server_cards" VALUES (5, 0, 't');
INSERT INTO "public"."server_cards" VALUES (6, 0, 't');
INSERT INTO "public"."server_cards" VALUES (7, 0, 't');

-- ----------------------------
-- Table structure for server_cards_awards
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_cards_awards";
CREATE TABLE "public"."server_cards_awards" (
  "id" int4 NOT NULL,
  "blue_order" int4,
  "exp" int4,
  "point" int4
)
;

-- ----------------------------
-- Records of server_cards_awards
-- ----------------------------
INSERT INTO "public"."server_cards_awards" VALUES (1, 0, 0, 2000);
INSERT INTO "public"."server_cards_awards" VALUES (2, 0, 0, 0);
INSERT INTO "public"."server_cards_awards" VALUES (3, 0, 0, 0);
INSERT INTO "public"."server_cards_awards" VALUES (5, 1, 500, 0);
INSERT INTO "public"."server_cards_awards" VALUES (6, 1, 500, 0);
INSERT INTO "public"."server_cards_awards" VALUES (7, 1, 500, 0);
INSERT INTO "public"."server_cards_awards" VALUES (8, 1, 700, 0);
INSERT INTO "public"."server_cards_awards" VALUES (9, 1, 1000, 0);
INSERT INTO "public"."server_cards_awards" VALUES (10, 1, 2000, 0);
INSERT INTO "public"."server_cards_awards" VALUES (11, 1, 3000, 0);
INSERT INTO "public"."server_cards_awards" VALUES (12, 1, 4000, 0);
INSERT INTO "public"."server_cards_awards" VALUES (14, 0, 0, 0);
INSERT INTO "public"."server_cards_awards" VALUES (15, 0, 0, 0);
INSERT INTO "public"."server_cards_awards" VALUES (16, 0, 0, 0);
INSERT INTO "public"."server_cards_awards" VALUES (17, 0, 0, 0);

-- ----------------------------
-- Table structure for server_clan_ranks
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_clan_ranks";
CREATE TABLE "public"."server_clan_ranks" (
  "id" int4 NOT NULL,
  "next_level" int4,
  "all_exp" int4
)
;

-- ----------------------------
-- Records of server_clan_ranks
-- ----------------------------
INSERT INTO "public"."server_clan_ranks" VALUES (0, 24000, 0);
INSERT INTO "public"."server_clan_ranks" VALUES (1, 40000, 24000);
INSERT INTO "public"."server_clan_ranks" VALUES (2, 48000, 64000);
INSERT INTO "public"."server_clan_ranks" VALUES (3, 56000, 112000);
INSERT INTO "public"."server_clan_ranks" VALUES (4, 72000, 168000);
INSERT INTO "public"."server_clan_ranks" VALUES (5, 80000, 240000);
INSERT INTO "public"."server_clan_ranks" VALUES (6, 120000, 320000);
INSERT INTO "public"."server_clan_ranks" VALUES (7, 160000, 440000);
INSERT INTO "public"."server_clan_ranks" VALUES (8, 120000, 600000);
INSERT INTO "public"."server_clan_ranks" VALUES (9, 200000, 720000);
INSERT INTO "public"."server_clan_ranks" VALUES (10, 240000, 920000);
INSERT INTO "public"."server_clan_ranks" VALUES (11, 280000, 1160000);
INSERT INTO "public"."server_clan_ranks" VALUES (12, 320000, 1440000);
INSERT INTO "public"."server_clan_ranks" VALUES (13, 360000, 1760000);
INSERT INTO "public"."server_clan_ranks" VALUES (14, 360000, 2120000);
INSERT INTO "public"."server_clan_ranks" VALUES (15, 400000, 2480000);
INSERT INTO "public"."server_clan_ranks" VALUES (16, 480000, 2880000);
INSERT INTO "public"."server_clan_ranks" VALUES (17, 560000, 3360000);
INSERT INTO "public"."server_clan_ranks" VALUES (18, 640000, 3920000);
INSERT INTO "public"."server_clan_ranks" VALUES (19, 720000, 4560000);
INSERT INTO "public"."server_clan_ranks" VALUES (20, 560000, 5280000);
INSERT INTO "public"."server_clan_ranks" VALUES (21, 640000, 5840000);
INSERT INTO "public"."server_clan_ranks" VALUES (22, 720000, 6480000);
INSERT INTO "public"."server_clan_ranks" VALUES (23, 800000, 7200000);
INSERT INTO "public"."server_clan_ranks" VALUES (24, 880000, 8000000);
INSERT INTO "public"."server_clan_ranks" VALUES (25, 960000, 8880000);
INSERT INTO "public"."server_clan_ranks" VALUES (26, 1870000, 9840000);
INSERT INTO "public"."server_clan_ranks" VALUES (27, 1120000, 11710000);
INSERT INTO "public"."server_clan_ranks" VALUES (28, 1200000, 12830000);
INSERT INTO "public"."server_clan_ranks" VALUES (29, 1280000, 14030000);
INSERT INTO "public"."server_clan_ranks" VALUES (30, 1600000, 15310000);
INSERT INTO "public"."server_clan_ranks" VALUES (31, 1620000, 16910000);
INSERT INTO "public"."server_clan_ranks" VALUES (32, 1440000, 18530000);
INSERT INTO "public"."server_clan_ranks" VALUES (33, 2560000, 19970000);
INSERT INTO "public"."server_clan_ranks" VALUES (34, 2880000, 22530000);
INSERT INTO "public"."server_clan_ranks" VALUES (35, 3200000, 25410000);
INSERT INTO "public"."server_clan_ranks" VALUES (36, 3520000, 28610000);
INSERT INTO "public"."server_clan_ranks" VALUES (37, 3840000, 32130000);
INSERT INTO "public"."server_clan_ranks" VALUES (38, 4160000, 35970000);
INSERT INTO "public"."server_clan_ranks" VALUES (39, 4480000, 40130000);
INSERT INTO "public"."server_clan_ranks" VALUES (40, 4800000, 44610000);
INSERT INTO "public"."server_clan_ranks" VALUES (41, 5120000, 49410000);
INSERT INTO "public"."server_clan_ranks" VALUES (42, 5440000, 54530000);
INSERT INTO "public"."server_clan_ranks" VALUES (43, 5760000, 59970000);
INSERT INTO "public"."server_clan_ranks" VALUES (44, 6080000, 65730000);
INSERT INTO "public"."server_clan_ranks" VALUES (45, 6800000, 71810000);
INSERT INTO "public"."server_clan_ranks" VALUES (46, 7200000, 78610000);
INSERT INTO "public"."server_clan_ranks" VALUES (47, 7600000, 85810000);
INSERT INTO "public"."server_clan_ranks" VALUES (48, 9200000, 93410000);

-- ----------------------------
-- Table structure for server_effect_flags
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_effect_flags";
CREATE TABLE "public"."server_effect_flags" (
  "item_id" int4 NOT NULL,
  "effect_flag" int8 NOT NULL
)
;

-- ----------------------------
-- Records of server_effect_flags
-- ----------------------------
INSERT INTO "public"."server_effect_flags" VALUES (1600007, 1048576);
INSERT INTO "public"."server_effect_flags" VALUES (1600008, 262144);
INSERT INTO "public"."server_effect_flags" VALUES (1600017, 131072);
INSERT INTO "public"."server_effect_flags" VALUES (1600026, 32768);
INSERT INTO "public"."server_effect_flags" VALUES (1600027, 16384);
INSERT INTO "public"."server_effect_flags" VALUES (1600028, 8192);
INSERT INTO "public"."server_effect_flags" VALUES (1600029, 4096);
INSERT INTO "public"."server_effect_flags" VALUES (1600030, 2048);
INSERT INTO "public"."server_effect_flags" VALUES (1600031, 1024);
INSERT INTO "public"."server_effect_flags" VALUES (1600032, 512);
INSERT INTO "public"."server_effect_flags" VALUES (1600033, 65536);
INSERT INTO "public"."server_effect_flags" VALUES (1600034, 256);
INSERT INTO "public"."server_effect_flags" VALUES (1600035, 128);
INSERT INTO "public"."server_effect_flags" VALUES (1600036, 64);
INSERT INTO "public"."server_effect_flags" VALUES (1600040, 32);
INSERT INTO "public"."server_effect_flags" VALUES (1600044, 16);
INSERT INTO "public"."server_effect_flags" VALUES (1600064, 2097152);
INSERT INTO "public"."server_effect_flags" VALUES (1600065, 1);
INSERT INTO "public"."server_effect_flags" VALUES (1600077, 524288);
INSERT INTO "public"."server_effect_flags" VALUES (1600078, 8);
INSERT INTO "public"."server_effect_flags" VALUES (1600079, 4);
INSERT INTO "public"."server_effect_flags" VALUES (1600080, 4194304);
INSERT INTO "public"."server_effect_flags" VALUES (1600185, 8388608);
INSERT INTO "public"."server_effect_flags" VALUES (1600191, 67108864);

-- ----------------------------
-- Table structure for server_events_login
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_login";
CREATE TABLE "public"."server_events_login" (
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0,
  "reward_id" int4 NOT NULL DEFAULT 0,
  "reward_count" int4 NOT NULL DEFAULT 0,
  "reward_name" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of server_events_login
-- ----------------------------

-- ----------------------------
-- Table structure for server_events_mapbonus
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_mapbonus";
CREATE TABLE "public"."server_events_mapbonus" (
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0,
  "map_id" int4 NOT NULL DEFAULT 0,
  "stage_type" int4 NOT NULL DEFAULT 0,
  "percent_xp" int4 NOT NULL DEFAULT 0,
  "percent_gp" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of server_events_mapbonus
-- ----------------------------

-- ----------------------------
-- Table structure for server_events_playtime
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_playtime";
CREATE TABLE "public"."server_events_playtime" (
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0,
  "title" varchar(30) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "seconds_target" int8 NOT NULL DEFAULT 1000,
  "good_reward1" int4 NOT NULL DEFAULT 0,
  "good_reward2" int4 NOT NULL DEFAULT 0,
  "good_count1" int4 NOT NULL DEFAULT 0,
  "good_count2" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of server_events_playtime
-- ----------------------------

-- ----------------------------
-- Table structure for server_events_quest
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_quest";
CREATE TABLE "public"."server_events_quest" (
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of server_events_quest
-- ----------------------------

-- ----------------------------
-- Table structure for server_events_rankup
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_rankup";
CREATE TABLE "public"."server_events_rankup" (
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0,
  "percent_xp" int4 NOT NULL DEFAULT 0,
  "percent_gp" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of server_events_rankup
-- ----------------------------

-- ----------------------------
-- Table structure for server_events_visit
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_visit";
CREATE TABLE "public"."server_events_visit" (
  "event_id" int4 NOT NULL DEFAULT nextval('check_event_seq'::regclass),
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0,
  "title" varchar(59) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "checks" int4 NOT NULL DEFAULT 7,
  "goods1" varchar COLLATE "pg_catalog"."default" NOT NULL,
  "counts1" varchar COLLATE "pg_catalog"."default" NOT NULL,
  "goods2" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "counts2" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying
)
;

-- ----------------------------
-- Records of server_events_visit
-- ----------------------------
INSERT INTO "public"."server_events_visit" VALUES (1, 2404170000, 2404252359, 'It''s just space!', 8, '10464702,10347302,10464902,10347202,10532502,10615402,20215302,31503002', '1,1,1,1,1,1,1,1', '1,1,1,1,1,1,1,1', '86400,86400,86400,86400,86400,86400,86400,86400');

-- ----------------------------
-- Table structure for server_events_xmas
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_events_xmas";
CREATE TABLE "public"."server_events_xmas" (
  "start_date" int8 NOT NULL DEFAULT 0,
  "end_date" int8 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of server_events_xmas
-- ----------------------------

-- ----------------------------
-- Table structure for server_inventory_template
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_inventory_template";
CREATE TABLE "public"."server_inventory_template" (
  "acquisition" int4 NOT NULL,
  "item_id" int4 NOT NULL,
  "item_name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "item_count" int4 NOT NULL,
  "item_equip" int4 NOT NULL
)
;

-- ----------------------------
-- Records of server_inventory_template
-- ----------------------------
INSERT INTO "public"."server_inventory_template" VALUES (0, 104006, 'K-1', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 105003, 'SSG-69', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 202003, 'K-5', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 301001, 'M-7', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 407001, 'K-400', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 508001, 'Smoke', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1500511, 'Raptor', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1500512, 'String', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1500513, 'Acid', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1000700000, 'Character Face', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1000800000, 'Character Head', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1000900000, 'Character Jacket', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1001000000, 'Character Poket', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1001100000, 'Character Glove', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1001200000, 'Character Belt', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1001300000, 'Character Holster', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 1001400000, 'Character Skin', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (2, 601001, 'Red Bulls', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (2, 602002, 'Acid Pol', 1, 3);
INSERT INTO "public"."server_inventory_template" VALUES (0, 103004, 'K-2', 1, 3);

-- ----------------------------
-- Table structure for server_rank_awards
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_rank_awards";
CREATE TABLE "public"."server_rank_awards" (
  "rank_id" int4 NOT NULL,
  "item_id" int4 NOT NULL,
  "item_name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "item_count" int4 NOT NULL,
  "item_equip" int4 NOT NULL
)
;

-- ----------------------------
-- Records of server_rank_awards
-- ----------------------------
INSERT INTO "public"."server_rank_awards" VALUES (0, 103005, 'F2000_Ext. (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (0, 315001, 'Dual_Knife (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (1, 105026, 'L115A1_Black (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (1, 105068, 'XM-2010 (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (2, 105012, 'Dragunov_CG. (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (2, 601010, 'Rica (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (3, 105119, 'XM-2010_Prime (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (3, 103236, 'K2C (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (4, 104004, 'MP7_Ext. (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (4, 508002, 'FlashBang (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (5, 104001, 'MP5K_Ext. (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (5, 103174, 'XM8 (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (6, 103167, 'AN-94_G. (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (6, 104161, 'MP9_Ext._G. (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (7, 105001, 'Dragunov (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (7, 104003, 'K-1_Ext. (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (8, 106020, 'Kel-Tec_KSG-15 (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (8, 105094, 'SVU_G. (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (9, 103102, 'HK-417 (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (9, 301014, 'GH5007 (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (10, 508002, 'FlashBang (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (10, 104008, 'UMP46_Ext. (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (11, 213003, 'P99&Hak_D (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (11, 104029, 'P90_Ext._D (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (12, 104004, 'MP7_Ext. (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (12, 105159, 'AS-50_G. (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (13, 407004, 'K-413 (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (13, 508007, 'Yellow_Smoke_Grenade (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (14, 103123, 'TAR-21 (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (14, 105094, 'SVU_G. (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (15, 104001, 'MP5K_Ext.', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (15, 301017, 'Fang_Blade (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (16, 104352, 'MX4 (100 Qty)', 50, 1);
INSERT INTO "public"."server_rank_awards" VALUES (16, 105119, 'XM-2010_Prime (1 Day)', 86400, 1);
INSERT INTO "public"."server_rank_awards" VALUES (17, 103169, 'TAR-21_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (17, 103246, 'AK-12 (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (18, 301018, 'BallisticKnife (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (18, 103169, 'TAR-21_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (19, 106018, 'SPAS-15_MSC (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (19, 105006, 'Dragunov_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (20, 301018, 'BallisticKnife (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (20, 103166, 'SC-2010_D (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (21, 103095, 'SCAR-L_Recon (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (21, 800033, 'Mask_Red_Cross +2 dmg 5% (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (22, 105015, 'L115A1_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (22, 1707119, 'Points 150%', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (23, 105017, 'L115A1_D (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (23, 301083, 'Nunchaku (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (24, 103177, 'XM8_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (24, 103041, 'AK_SOPMOD_CG (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (25, 2700007, 'Red Star Beret (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (25, 301018, 'BallisticKnife (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (26, 1707119, 'Points 150%', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (26, 800036, 'Mask_Target +2 recoil control (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (27, 601020, 'Reinforced D-Fox (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (27, 407063, 'K-413_Ice (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (28, 800024, 'Mask_Green_Jungle +2 (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (28, 105010, 'Dragunov_SL. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (29, 103057, 'Vz._52 (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (29, 1730003, 'Exp 150%', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (30, 106012, 'SPAS-15_D (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (30, 103057, 'Vz._52 (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (31, 104075, 'P90_G (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (31, 105026, 'L115A1_Black (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (32, 104159, 'OA-93_D (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (32, 105159, 'AS-50_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (33, 508005, 'Pink_Smoke_Grenade (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (33, 104032, 'P90_M.C_D (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (34, 800033, 'Mask_Red_Cross +2 dmg 5% (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (34, 105123, 'Tactilite-T2 (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (35, 105012, 'Dragunov_CG. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (35, 105093, 'VSK94_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (36, 1800052, 'Change_Clan_Mark', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (36, 105095, 'DSR-1_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (37, 104162, 'PP-19_Bizon_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (37, 105011, 'Dragunov_CS. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (38, 508006, 'Blue_Smoke_Grenade (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (38, 106048, 'UTS-15_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (39, 103285, 'Groza_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (39, 1701027, 'Quick Reload Weapon 1d', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (40, 103177, 'XM8_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (40, 301043, 'GH5007_G (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (41, 106090, 'M1887_Beyond (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (41, 800025, 'Mask_Yellow_Desert +2 (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (42, 527001, 'WP_Smoke (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (42, 407007, 'K-413_G (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (43, 1730119, 'Points 150%', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (43, 800024, 'Mask_Green_Jungle +2 (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (44, 301014, 'GH5007 (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (44, 214004, 'Dual_D-Eagle_G (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (45, 214005, 'Dual_Handgun_D (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (45, 1730026, 'Quick Change Weapon 30', 1, 1);
INSERT INTO "public"."server_rank_awards" VALUES (46, 104075, 'P90_G (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (46, 106047, 'Cerberus (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (47, 105145, 'PGM_Hecate2 (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (47, 105159, 'AS-50_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (48, 301018, 'BallisticKnife (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (48, 105017, 'L115A1_D (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (49, 105095, 'DSR-1_G. (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (49, 103167, 'AN-94_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (50, 104219, 'P90_M.C_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (50, 214005, 'Dual_Handgun_D (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (51, 800022, 'Mask_Black +1 (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (51, 2700005, 'Beret_Cavalry (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (52, 105159, 'AS-50_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (52, 104039, 'Kriss_S.V_Black (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (53, 105030, 'Cheytac_M200 (7 Days)', 604800, 1);
INSERT INTO "public"."server_rank_awards" VALUES (53, 800036, 'Mask_Target +2 recoil control (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (54, 105010, 'Dragunov_SL. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (54, 106012, 'SPAS-15_D (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (55, 103221, 'AK_SOPMOD_G. (30 Days)', 2592000, 1);
INSERT INTO "public"."server_rank_awards" VALUES (55, 601022, 'Reinforced Viper Red (30 Days)', 2592000, 1);

-- ----------------------------
-- Table structure for server_ranks
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_ranks";
CREATE TABLE "public"."server_ranks" (
  "id" int4 NOT NULL,
  "next_level" int4,
  "point_up" int4,
  "all_exp" int4
)
;

-- ----------------------------
-- Records of server_ranks
-- ----------------------------
INSERT INTO "public"."server_ranks" VALUES (0, 2000, 0, 0);
INSERT INTO "public"."server_ranks" VALUES (1, 3000, 1000, 2000);
INSERT INTO "public"."server_ranks" VALUES (2, 4000, 2000, 5000);
INSERT INTO "public"."server_ranks" VALUES (3, 5000, 4000, 9000);
INSERT INTO "public"."server_ranks" VALUES (4, 7000, 6000, 14000);
INSERT INTO "public"."server_ranks" VALUES (5, 9000, 8000, 21000);
INSERT INTO "public"."server_ranks" VALUES (6, 11000, 8000, 30000);
INSERT INTO "public"."server_ranks" VALUES (7, 13500, 8000, 41000);
INSERT INTO "public"."server_ranks" VALUES (8, 16000, 10000, 54500);
INSERT INTO "public"."server_ranks" VALUES (9, 18500, 10000, 70500);
INSERT INTO "public"."server_ranks" VALUES (10, 21000, 10000, 89000);
INSERT INTO "public"."server_ranks" VALUES (11, 24000, 10000, 110000);
INSERT INTO "public"."server_ranks" VALUES (12, 27000, 12000, 134000);
INSERT INTO "public"."server_ranks" VALUES (13, 30000, 12000, 161000);
INSERT INTO "public"."server_ranks" VALUES (14, 33000, 12000, 191000);
INSERT INTO "public"."server_ranks" VALUES (15, 36000, 12000, 224000);
INSERT INTO "public"."server_ranks" VALUES (16, 41000, 12000, 260000);
INSERT INTO "public"."server_ranks" VALUES (17, 46000, 14000, 301000);
INSERT INTO "public"."server_ranks" VALUES (18, 51000, 14000, 347000);
INSERT INTO "public"."server_ranks" VALUES (19, 56000, 14000, 398000);
INSERT INTO "public"."server_ranks" VALUES (20, 62000, 14000, 454000);
INSERT INTO "public"."server_ranks" VALUES (21, 68000, 16000, 516000);
INSERT INTO "public"."server_ranks" VALUES (22, 74000, 16000, 584000);
INSERT INTO "public"."server_ranks" VALUES (23, 80000, 16000, 658000);
INSERT INTO "public"."server_ranks" VALUES (24, 86000, 16000, 738000);
INSERT INTO "public"."server_ranks" VALUES (25, 93000, 16000, 824000);
INSERT INTO "public"."server_ranks" VALUES (26, 100000, 18000, 917000);
INSERT INTO "public"."server_ranks" VALUES (27, 107000, 18000, 1017000);
INSERT INTO "public"."server_ranks" VALUES (28, 114000, 18000, 1124000);
INSERT INTO "public"."server_ranks" VALUES (29, 121000, 18000, 1238000);
INSERT INTO "public"."server_ranks" VALUES (30, 151000, 18000, 1359000);
INSERT INTO "public"."server_ranks" VALUES (31, 181000, 20000, 1510000);
INSERT INTO "public"."server_ranks" VALUES (32, 211000, 20000, 1691000);
INSERT INTO "public"."server_ranks" VALUES (33, 241000, 20000, 1902000);
INSERT INTO "public"."server_ranks" VALUES (34, 271000, 20000, 2143000);
INSERT INTO "public"."server_ranks" VALUES (35, 311000, 20000, 2414000);
INSERT INTO "public"."server_ranks" VALUES (36, 351000, 22000, 2725000);
INSERT INTO "public"."server_ranks" VALUES (37, 391000, 22000, 3076000);
INSERT INTO "public"."server_ranks" VALUES (38, 413000, 22000, 3467000);
INSERT INTO "public"."server_ranks" VALUES (39, 471000, 22000, 3898000);
INSERT INTO "public"."server_ranks" VALUES (40, 521000, 22000, 4369000);
INSERT INTO "public"."server_ranks" VALUES (41, 571000, 24000, 4890000);
INSERT INTO "public"."server_ranks" VALUES (42, 621000, 24000, 5461000);
INSERT INTO "public"."server_ranks" VALUES (43, 671000, 24000, 6082000);
INSERT INTO "public"."server_ranks" VALUES (44, 721000, 24000, 6753000);
INSERT INTO "public"."server_ranks" VALUES (45, 781000, 24000, 7474000);
INSERT INTO "public"."server_ranks" VALUES (46, 851000, 28000, 8255000);
INSERT INTO "public"."server_ranks" VALUES (47, 931000, 32000, 9106000);
INSERT INTO "public"."server_ranks" VALUES (48, 1021000, 36000, 10037000);
INSERT INTO "public"."server_ranks" VALUES (49, 1121000, 40000, 11058000);
INSERT INTO "public"."server_ranks" VALUES (50, 100000000, 60000, 12179000);
INSERT INTO "public"."server_ranks" VALUES (51, -1, 0, 0);
INSERT INTO "public"."server_ranks" VALUES (52, 0, 0, 0);
INSERT INTO "public"."server_ranks" VALUES (53, 0, 0, 0);
INSERT INTO "public"."server_ranks" VALUES (54, 0, 0, 0);
INSERT INTO "public"."server_ranks" VALUES (55, 0, 0, 0);
INSERT INTO "public"."server_ranks" VALUES (61, 200000000, 60000, 22179000);

-- ----------------------------
-- Table structure for server_settings
-- ----------------------------
DROP TABLE IF EXISTS "public"."server_settings";
CREATE TABLE "public"."server_settings" (
  "config_id" int4 NOT NULL DEFAULT 0,
  "only_gm" bool NOT NULL DEFAULT false,
  "enable_missions" bool NOT NULL DEFAULT true,
  "userfilelist" varchar(32) COLLATE "pg_catalog"."default" NOT NULL DEFAULT 0,
  "version" varchar(8) COLLATE "pg_catalog"."default" NOT NULL DEFAULT 0,
  "enable_gift" bool NOT NULL DEFAULT false,
  "exit_url" varchar(255) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "chat_color" int8 NOT NULL DEFAULT 0,
  "announce_color" int8 NOT NULL DEFAULT 0,
  "chat" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "announce" varchar COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "enable_clan" bool,
  "enable_greenblood" bool
)
;

-- ----------------------------
-- Records of server_settings
-- ----------------------------
INSERT INTO "public"."server_settings" VALUES (1, 'f', 't', '-1', '3.30', 't', 'http://127.0.0.1', 16711680, 16776960, 'Chat message can be changed from database!', 'Announce can be changed from database!', 't', 'f');

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."account_id_seq"', 9, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."accounts_id_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."auto_ban_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."ban_seq"', 10, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."channels_id_seq"', 10, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."check_event_seq"', 11, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."clan_seq"', 24, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."clans_id_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."contas_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."gameservers_id_seq"', 10, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."gift_id_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."ipsystem_id_seq"', 10, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."items_id_seq"', 66, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."jogador_amigo_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."jogador_inventario_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."jogador_mensagem_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."loja_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."message_id_seq"', 46, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."player_characters_id_seq"', 352, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."player_eqipment_id_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."player_friends_player_account_id_seq"', 10, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."player_topups_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."players_id_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."storage_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
SELECT setval('"public"."templates_id_seq"', 10, false);

-- ----------------------------
-- Primary Key structure for table clans
-- ----------------------------
ALTER TABLE "public"."clans" ADD CONSTRAINT "clan_data_pkey" PRIMARY KEY ("clan_id");

-- ----------------------------
-- Primary Key structure for table item_goods
-- ----------------------------
ALTER TABLE "public"."item_goods" ADD CONSTRAINT "item_goods_pkey" PRIMARY KEY ("item_id");

-- ----------------------------
-- Primary Key structure for table item_goods_effects
-- ----------------------------
ALTER TABLE "public"."item_goods_effects" ADD CONSTRAINT "item_goods_effects_pkey" PRIMARY KEY ("effect_id");

-- ----------------------------
-- Primary Key structure for table item_goods_sets
-- ----------------------------
ALTER TABLE "public"."item_goods_sets" ADD CONSTRAINT "item_goods_sets_pkey" PRIMARY KEY ("set_id");

-- ----------------------------
-- Primary Key structure for table item_goods_sets_items
-- ----------------------------
ALTER TABLE "public"."item_goods_sets_items" ADD CONSTRAINT "item_goods_sets_items_pkey" PRIMARY KEY ("set_id", "item_id");

-- ----------------------------
-- Primary Key structure for table item_goods_test
-- ----------------------------
ALTER TABLE "public"."item_goods_test" ADD CONSTRAINT "item_goods_copy1_pkey" PRIMARY KEY ("item_id");

-- ----------------------------
-- Primary Key structure for table item_repair
-- ----------------------------
ALTER TABLE "public"."item_repair" ADD CONSTRAINT "shop_item_repair_pkey" PRIMARY KEY ("item_id");

-- ----------------------------
-- Primary Key structure for table item_stats
-- ----------------------------
ALTER TABLE "public"."item_stats" ADD CONSTRAINT "items_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table permissions
-- ----------------------------
ALTER TABLE "public"."permissions" ADD CONSTRAINT "permissions_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table permissions_levels
-- ----------------------------
ALTER TABLE "public"."permissions_levels" ADD CONSTRAINT "permissions_levels_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table player_characters
-- ----------------------------
ALTER TABLE "public"."player_characters" ADD CONSTRAINT "player_characters_pkey" PRIMARY KEY ("object_id");

-- ----------------------------
-- Primary Key structure for table player_configs
-- ----------------------------
ALTER TABLE "public"."player_configs" ADD CONSTRAINT "player_configs_pkey" PRIMARY KEY ("owner_id");

-- ----------------------------
-- Primary Key structure for table player_quickstart
-- ----------------------------
ALTER TABLE "public"."player_quickstart" ADD CONSTRAINT "player_quickstart_pkey" PRIMARY KEY ("owner_id");

-- ----------------------------
-- Indexes structure for table players
-- ----------------------------
CREATE UNIQUE INDEX "player_id" ON "public"."players" USING btree (
  "player_id" "pg_catalog"."int8_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table players
-- ----------------------------
ALTER TABLE "public"."players" ADD CONSTRAINT "accounts_pkey" PRIMARY KEY ("player_id") WITH (fillfactor=23);

-- ----------------------------
-- Primary Key structure for table server_cards_awards
-- ----------------------------
ALTER TABLE "public"."server_cards_awards" ADD CONSTRAINT "server_cards_awards_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table server_clan_ranks
-- ----------------------------
ALTER TABLE "public"."server_clan_ranks" ADD CONSTRAINT "server_clan_ranks_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table server_ranks
-- ----------------------------
ALTER TABLE "public"."server_ranks" ADD CONSTRAINT "server_ranks_pkey" PRIMARY KEY ("id");
