ALTER TABLE Nalazi_se
ADD CONSTRAINT Nalazi_se_Stavka_menija_FK FOREIGN KEY
(
Stavka_menija_ID
)
REFERENCES Stavka_menija
(
ID
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
