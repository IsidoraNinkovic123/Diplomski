ALTER TABLE Sprema
ADD CONSTRAINT Sprema_Jelo_FK FOREIGN KEY
(
Jelo_ID
)
REFERENCES Jelo
(
ID
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
