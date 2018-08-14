CREATE
  TABLE Meni
  (
    ID          INTEGER NOT NULL IDENTITY(1,1) ,
    NAZ         VARCHAR (50) NOT NULL ,
    Restoran_ID INTEGER
  )
  ON "default"
GO
