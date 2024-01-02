\c HoneyRaes

INSERT INTO Customer (Name, Address) VALUES ('Amanda Dorado', '123 Firefly Lane');
INSERT INTO Customer (Name, Address) VALUES ('Zeke Dorado', '123 Oden Lane');
INSERT INTO Customer (Name, Address) VALUES ('Ely Dorado', '123 Jackson Lane');


INSERT INTO Employee (Name, Specialty) VALUES ('Bart Simpson', 'Keyboard Repairs');
INSERT INTO Employee (Name, Specialty) VALUES ('Jessica Simpson', 'Battery Replacement');
INSERT INTO Employee (Name, Specialty) VALUES ('Wendy Wu', 'Screen Repair');


INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted)
VALUES (1, 1, 'Dead Battery', true, '2023-11-29');

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency)
VALUES (2, NULL, 'Cracked Screen', false);

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted)
VALUES (3, 3, 'Green Screen of Death', true, '2023-12-29');

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency)
VALUES (1, NULL, 'Screen Doesnt Work', true);

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted)
VALUES (3, 2, 'Wont Charge', false, '2023-11-19');

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted)
VALUES (2, 1, 'Out of storage', false, '2024-01-01');