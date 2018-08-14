ALTER TABLE Pripada
    ADD CONSTRAINT Pripada_Jelo_FK FOREIGN KEY ( Jelo_ID )
        REFERENCES Jelo ( ID );