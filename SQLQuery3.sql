USE item1;

TRUNCATE TABLE item1;

ALTER TABLE item1 DROP COLUMN Quantity;

INSERT INTO item1 ( name, category, price, Quantity) VALUES ('Coke','Soft Drink','50',100);
INSERT INTO item1( name, category, price, Quantity) VALUES ('Sprite','Soft Drink','50',100);
INSERT INTO item1( name, category, price, Quantity) VALUES ('Mocha','Coffe','75',100);
INSERT INTO item1 ( name, category, price, Quantity) VALUES ('Cake','Pastry','750',100);
INSERT INTO item1 ( name, category, price, Quantity) VALUES ('Wintermelon','Milk Tea','99',100);
INSERT INTO item1 ( name, category, price, Quantity) VALUES ('Donut','Pastry','40',100);

ALTER TABLE item1 ADD Quantity INT NOT NULL;

SELECT * FROM item1