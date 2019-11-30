CREATE TABLE "Character" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"currentHealth"	INTEGER NOT NULL DEFAULT 0,
	"maxHealth"	INTEGER NOT NULL DEFAULT 1,
	"currentXP"	INTEGER NOT NULL DEFAULT 0,
	"background"	TEXT,
	"gender"	TEXT
);

CREATE TABLE "Proficiency" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"description"	TEXT,
	"primaryProficiencyId"	INTEGER,
	"category"	TEXT,
	"linkedId"	INTEGER,
	FOREIGN KEY("primaryProficiencyId") REFERENCES "Proficiency"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "CharacterProficiency" (
	"charId"	INTEGER NOT NULL,
	"proficiencyId"	INTEGER NOT NULL,
	"proficiencyLevel"	INTEGER NOT NULL,
	"passiveValue"	INTEGER NOT NULL,
	FOREIGN KEY("proficiencyId") REFERENCES "Proficiency"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	PRIMARY KEY("charId","proficiencyId"),
	FOREIGN KEY("charId") REFERENCES "Character"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "Property" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"description"	TEXT,
	"autoCalculate"	INTEGER NOT NULL DEFAULT 0,
	"calcType"	TEXT,
	"calcValue"	TEXT,
	"calcId"	INTEGER,
	"minLevel"	INTEGER NOT NULL DEFAULT 0,
	"maxLevel"	INTEGER NOT NULL DEFAULT 9999,
	"category"	TEXT NOT NULL,
	"useCounter"	INTEGER
);

CREATE TABLE "LinkedProperty" (
	"linkedId"	INTEGER,
	"linkedType"	TEXT,
	"propertyId"	INTEGER,
	PRIMARY KEY("linkedId","propertyId","linkedType")
);

CREATE TABLE "Alignment" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"description"	TEXT
);

CREATE TABLE "Size" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"description"	TEXT,
	"avgWidth"	INTEGER NOT NULL,
	"avgHeight"	INTEGER,
	"carryModifier"	NUMERIC NOT NULL
);

CREATE TABLE "Race" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"shortDescription"	TEXT,
	"description"	TEXT,
	"age"	NUMERIC,
	"alignmentId"	INTEGER,
	"sizeId"	INTEGER NOT NULL,
	"speed"	INTEGER NOT NULL,
	"variantId"	INTEGER,
	FOREIGN KEY("alignmentId") REFERENCES "Alignment"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("sizeId") REFERENCES "Size"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("variantId") REFERENCES "Race"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "CharacterRace" (
	"charId"	INTEGER,
	"raceId"	INTEGER,
	PRIMARY KEY("charId","raceId"),
	FOREIGN KEY("raceId") REFERENCES "Race"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("charId") REFERENCES "Character"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "Class" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL,
	"description"	TEXT,
	"hitDicePerLevel"	TEXT NOT NULL,
	"isPrimary"	INTEGER NOT NULL DEFAULT 1,
	"primaryClassId"	INTEGER,
	FOREIGN KEY("primaryClassId") REFERENCES "Class"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "CharacterClass" (
	"charId"	INTEGER,
	"itemId"	INTEGER,
	"level"	INTEGER NOT NULL DEFAULT 1,
	FOREIGN KEY("charId") REFERENCES "Character"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	PRIMARY KEY("charId","itemId"),
	FOREIGN KEY("itemId") REFERENCES "Class"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "Item" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"description"	INTEGER,
	"weight"	NUMERIC NOT NULL DEFAULT 0,
	"category"	TEXT NOT NULL DEFAULT 'Other'
);

CREATE TABLE "ClassStartItem" (
	"classId"	INTEGER NOT NULL,
	"itemId"	INTEGER NOT NULL,
	"alternativeEquipId"	INTEGER,
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	FOREIGN KEY("classId") REFERENCES "Class"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("alternativeEquipId") REFERENCES "ClassStartItem"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("itemId") REFERENCES "Item"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "CharacterItem" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"charId"	INTEGER NOT NULL,
	"itemId"	INTEGER NOT NULL,
	"amount"	NUMERIC NOT NULL DEFAULT 1,
	FOREIGN KEY("charId") REFERENCES "Character"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("itemId") REFERENCES "Item"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "DamageTypes" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT,
	"description"	TEXT
);

CREATE TABLE "Weapon" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"itemId"	INTEGER NOT NULL,
	"damage"	TEXT NOT NULL DEFAULT 0,
	"damageTypeId"	INTEGER,
	"type"	TEXT NOT NULL,
	FOREIGN KEY("itemId") REFERENCES "Item"("id") ON UPDATE CASCADE ON DELETE RESTRICT,
	FOREIGN KEY("type") REFERENCES "DamageTypes"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE "Armor" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"itemId"	INTEGER NOT NULL,
	"AC"	INTEGER NOT NULL,
	FOREIGN KEY("itemId") REFERENCES "Item"("id") ON UPDATE CASCADE ON DELETE RESTRICT
);

INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("STR", "Strength", NULL, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("DEX", "Dexterity", NULL, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("CON", "Constitution", NULL, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("INT", "Intelligence", NULL, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("WIS", "Wisdom", NULL, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("CHA", "Charisma", NULL, "Skill")

INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Athletics", "Athletics", 1, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Acrobatics", "Acrobatics", 2, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Sleight of Hand", "Sleight of Hand", 2, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Stealth", "Stealth", 2, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Arcana", "Arcana", 4, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("History", "History", 4, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Investigation", "Investigation", 4, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Nature", "Nature", 4, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Religion", "Religion", 4, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Animal Handling", "Animal Handling", 5, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Insight", "Insight", 5, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Medicine", "Medicine", 5, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Perception", "Perception", 5, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Survival", "Survival", 5, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Deception", "Deception", 6, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Intimidation", "Intimidation", 6, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Performance", "Performance", 6, "Skill")
INSERT INTO Proficiency (name, description, primaryProficiencyId, category) VALUES ("Persuasion", "Persuasion", 6, "Skill")