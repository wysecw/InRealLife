-- populate scenarios table with test data
/*

INSERT INTO Scenario (ScenarioName, ScenarioDescription)
VALUES 
('Flat Tire', 'The vehicle that you are driving in starts to wobble ...'), 
('Laundry', 'Your clothes start to pile up in the corner of your room ...'), 
('Hunger', 'You are feeling hungry, so you see some cereal but you are out of milk ...'), 
('Cleanliness', 'You smell in odor and your not sure where it is coming from ...'), 
('Priorities', 'A programming assignment due tomorrow and your friend is having a get together at his house ...');

*/


-- populate stages table with test data
/*

INSERT INTO Stage (ScenarioID, StageName, AudioFilePath, ImageFilePath, StageDescription)
VALUES 
(NULL, 'Pull Over or Keep Driving', 'C:\user\test\docs\audiofiles\audioFile1', 'C:\user\test\docs\imageFiles\imageFile1', 'You see a place to pull over on the busy highway or ...'),
(NULL, 'Safe Place or Keep Driving', 'C:\user\test\docs\audiofiles\audioFile2', 'C:\user\test\docs\imageFiles\imageFile2', 'You see a safe place to pull over away from busy highway or ...'),
(NULL, 'Turnup radio or turndown radio', 'C:\user\test\docs\audiofiles\audioFile4', 'C:\user\test\docs\imageFiles\imageFile4', 'Turn up radio and ignore or ...'),
(NULL, 'Inspect vehicle or call mom', 'C:\user\test\docs\audiofiles\audioFile3', 'C:\user\test\docs\imageFiles\imageFile3', 'Get out of vehicle and inspect for problems or ...'),
(NULL, 'mom AAA or fix it yourself', 'C:\user\test\docs\audiofiles\audioFile5', 'C:\user\test\docs\imageFiles\imageFile5', 'Mom is busy and says call AAA or ...'),
(NULL, 'Fixing a flat', 'C:\user\test\docs\audiofiles\audioFile6', 'C:\user\test\docs\imageFiles\imageFile6', 'Pull out the jack and lift vehicle or turn off vehicle and inspect the spare ...');

*/


-- populate answers	table
/*

INSERT INTO Answer (StageID, AnswerName, AnswerDescription, NextStageID)
VALUES (NULL, 'Pull Over', 'Pull your vehicle over on a busy highway', Null),
(NULL, 'Keep Driving', 'Keep driving and find a safer area', Null),
(NULL, 'Turn up radio', 'Turn up radio and speed up', Null),
(NULL, 'Turn down radio', 'Turn down radio and slow down', Null),
(NULL, 'Ignore', 'Ignore and keep driving', Null),
(NULL, 'Inspect vehicle', 'Inspect vehicle tires for proper working order', Null),
(NULL, 'Call Mom', 'Call mom even though you know she is in a meeting right now', Null);

*/