CREATE
  TABLE Stavka_menija
  (
    ID      VARCHAR (50) NOT NULL ,
    NAZ     VARCHAR (50) NOT NULL ,
    CENA    DECIMAL (18,2) NOT NULL ,
    Meni_ID INTEGER
  )
  ON "default"
GO
