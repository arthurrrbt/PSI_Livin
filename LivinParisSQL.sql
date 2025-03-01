 -- Création de la table de données
CREATE DATABASE LivinParis;
USE LivinParis;
 -- Table Plat
CREATE TABLE Plat (
    IdPlat INT AUTO_INCREMENT,
    NomPlat VARCHAR(255) NOT NULL,
    Quantite INT NOT NULL,
    Categorie VARCHAR(50) NOT NULL,
    PRIMARY KEY (IdPlat)
);
 -- Table Particulier
CREATE TABLE Particulier (
    IdParticulier INT AUTO_INCREMENT,
    Nom VARCHAR(50) NOT NULL,
    Prenom VARCHAR(50) NOT NULL,
    Adresse VARCHAR(255) NOT NULL,
    NumTel VARCHAR(20) NOT NULL,
    Mdp VARCHAR(255) NOT NULL,
    PRIMARY KEY (IdParticulier)
);
 -- Table Entreprise Locale
CREATE TABLE Entreprise_Locale (
    IdEntreprise INT AUTO_INCREMENT,
    Nom VARCHAR(100) NOT NULL,
    NomReferent VARCHAR(100) NOT NULL,
    PRIMARY KEY (IdEntreprise)
);
 -- Table Avis
CREATE TABLE Avis (
    IdAvis INT AUTO_INCREMENT,
    Commentaire VARCHAR(255) NOT NULL,
    Note DECIMAL(2,1) NOT NULL CHECK (Note >= 0 AND Note <= 5),
    PRIMARY KEY (IdAvis)
);
 -- Table Adresse
CREATE TABLE Adresse (
    IdAdresse INT AUTO_INCREMENT,
    Adresse VARCHAR(255) NOT NULL,
    PRIMARY KEY (IdAdresse)
);
 -- Tabke Notification
CREATE TABLE Notification (
    IdNotification INT AUTO_INCREMENT,
    Message TEXT NOT NULL,
    MoyenEnvoi VARCHAR(50) NOT NULL,
    DateHeure DATETIME NOT NULL,
    Statut VARCHAR(50) NOT NULL,
    PRIMARY KEY (IdNotification)
);

-- Table Fidélité Client
CREATE TABLE Fidelite_Client (
    IdFidelite INT AUTO_INCREMENT,
    PointsDeFidelite INT NOT NULL DEFAULT 0,
    PRIMARY KEY (IdFidelite)
);

-- Table Recommandation Plat
CREATE TABLE Recommendation_Plat (
    IdRecommendation INT AUTO_INCREMENT,
    Nom VARCHAR(100) NOT NULL,
    PRIMARY KEY (IdRecommendation)
);

-- Table Client
CREATE TABLE Client (
    IdClient INT AUTO_INCREMENT,
    IdEntreprise INT NULL UNIQUE,
    IdParticulier INT NULL UNIQUE,
    PRIMARY KEY (IdClient),
    FOREIGN KEY (IdEntreprise) REFERENCES Entreprise_Locale(IdEntreprise) ON DELETE SET NULL,
    FOREIGN KEY (IdParticulier) REFERENCES Particulier(IdParticulier) ON DELETE SET NULL
);

-- Table Commande
CREATE TABLE Commande (
    IdCommande INT AUTO_INCREMENT,
    DateCommande DATE NOT NULL,
    MoyenPaiement VARCHAR(50) NOT NULL,
    IdAdresse INT NOT NULL,
    IdClient INT NOT NULL,
    PRIMARY KEY (IdCommande),
    FOREIGN KEY (IdAdresse) REFERENCES Adresse(IdAdresse) ON DELETE CASCADE,
    FOREIGN KEY (IdClient) REFERENCES Client(IdClient) ON DELETE CASCADE
);

-- Table Cuisinier
CREATE TABLE Cuisinier (
    IdCuisinier INT AUTO_INCREMENT,
    IdParticulier INT NOT NULL UNIQUE,
    PRIMARY KEY (IdCuisinier),
    FOREIGN KEY (IdParticulier) REFERENCES Particulier(IdParticulier) ON DELETE CASCADE
);

-- Table Livraison
CREATE TABLE Livraison (
    IdLivraison INT AUTO_INCREMENT,
    PositionLive VARCHAR(100) NOT NULL,
    IdAvis INT NOT NULL,
    IdNotification INT NOT NULL,
    IdAdresse INT NOT NULL,
    PRIMARY KEY (IdLivraison),
    FOREIGN KEY (IdAvis) REFERENCES Avis(IdAvis) ON DELETE CASCADE,
    FOREIGN KEY (IdNotification) REFERENCES Notification(IdNotification) ON DELETE CASCADE,
    FOREIGN KEY (IdAdresse) REFERENCES Adresse(IdAdresse) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Client (
    IdClient INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(50),
    Prenom VARCHAR(50),
    Rue VARCHAR(255),
    Numero INT,
    CodePostal VARCHAR(10),
    Ville VARCHAR(50),
    Tel VARCHAR(20),
    Email VARCHAR(100),
    MetroProche VARCHAR(50)
);

INSERT INTO Client (Nom, Prenom, Rue, Numero, CodePostal, Ville, Tel, Email, MetroProche)
VALUES 
('Durand', 'Medhy', 'Rue Cardinet', 15, '75017', 'Paris', '1234567890', 'Mdurand@gmail.com', 'Cardinet');

CREATE TABLE IF NOT EXISTS Cuisinier (
    IdCuisinier INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(50),
    Prenom VARCHAR(50),
    Rue VARCHAR(255),
    Numero INT,
    CodePostal VARCHAR(10),
    Ville VARCHAR(50),
    Tel VARCHAR(20),
    Email VARCHAR(100),
    MetroProche VARCHAR(50)
);

INSERT INTO Cuisinier (Nom, Prenom, Rue, Numero, CodePostal, Ville, Tel, Email, MetroProche)
VALUES 
('Dupond', 'Marie', 'Rue de la République', 30, '75011', 'Paris', '1234567890', 'Mdupond@gmail.com', 'République');

CREATE TABLE IF NOT EXISTS Commande (
    IdCommande INT AUTO_INCREMENT PRIMARY KEY,
    IdCuisinier INT,
    Nom VARCHAR(100),
    Prix DECIMAL(10,2),
    Quantite INT,
    TypePlat VARCHAR(50),
    DateFab DATE,
    DatePer DATE,
    Regime VARCHAR(50),
    Nature VARCHAR(50),
    Ingredient1 VARCHAR(50),
    Volume1 VARCHAR(20),
    Ingredient2 VARCHAR(50),
    Volume2 VARCHAR(20),
    Ingredient3 VARCHAR(50),
    Volume3 VARCHAR(20),
    Ingredient4 VARCHAR(50),
    Volume4 VARCHAR(20),
    FOREIGN KEY (IdCuisinier) REFERENCES Cuisinier(IdCuisinier)
);

INSERT INTO Commande (IdCuisinier, Nom, Prix, Quantite, TypePlat, DateFab, DatePer, Regime, Nature, 
                      Ingredient1, Volume1, Ingredient2, Volume2, Ingredient3, Volume3, Ingredient4, Volume4)
VALUES 
(1, 'Raclette', 10, 6, 'Plat', '2025-01-10', '2025-01-15', NULL, 'Française', 
 'raclette from', '250g', 'pommes_de_terre', '200g', 'jambon', '200g', 'cornichon', '3p'),
(1, 'Salade de fruit', 5, 6, 'Dessert', '2025-01-10', '2025-01-15', 'Végétarien', 'Indifférent', 
 'fraise', '100g', 'kiwi', '100g', 'sucre', '10g', NULL, NULL);
 
SELECT * FROM Commande;
SELECT * FROM Client;
SELECT * FROM Notification;





