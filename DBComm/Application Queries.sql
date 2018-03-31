-- QUERIES FOR THE APPLICATION C# NEED TESTING

	-- QUERY FOR SCENARIO BUILDER MAIN MENU LISTVIEW
	-- "SELECT ScenarioID, ScenarioName FROM Scenario WHERE ScenarioID = "

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF PERFORMS SELECTED SCENARIO FROM LISTVIEW
		-- "SELECT ScenarioID, ScenarioName FROM Scenario WHERE ScenarioID = "

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF CREATES A NEW SCENARIO FROM LISTVIEW
		-- SEE "BELOW"

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF EDITS SELECTED SCENARIO FROM LISTVIEW
		-- "SELECT * FROM Scenario WHERE ScenarioID = "

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF DELETES SELECTED SCENARIO FROM LISTVIEW
		-- "DELETE * FROM Scenario WHERE ScenarioID = "
		
		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF RELATE SELECTED SCENARIO FROM LISTVIEW
		-- SEE "BELOW2"
		
		
	-- QUERY FOR STAGE BUILDER MAIN MENU LISTVIEW		
		-- QUERY FOR STAGE BUILDER MAIN MENU IF PERFORMS SELECTED STAGE FROM LISTVIEW
		-- "SELECT StageID, StageName FROM Stage WHERE StageID = "

		-- QUERY FOR STAGE BUILDER MAIN MENU IF CREATES A NEW STAGE FROM LISTVIEW
		-- SEE "BELOW"

		-- QUERY FOR STAGE BUILDER MAIN MENU IF EDITS SELECTED STAGE FROM LISTVIEW
		-- "SELECT * FROM Stage WHERE StageID = "

		-- QUERY FOR STAGE BUILDER MAIN MENU IF DELETES SELECTED STAGE FROM LISTVIEW
		-- "DELETE * FROM Stage WHERE StageID = "
		
		-- QUERY FOR STAGE BUILDER MAIN MENU IF RELATE SELECTED SCENARIO FROM LISTVIEW
		-- SEE "BELOW2"
		
		
	-- QUERY FOR ANSWER BUILDER MAIN MENU LISTVIEW		
		-- QUERY FOR ANSWER BUILDER MAIN MENU IF PERFORMS SELECTED ANSWER FROM LISTVIEW
		-- "SELECT AnswerID, AnswerName FROM Answer WHERE AnswerID = "

		-- QUERY FOR ANSWER BUILDER MAIN MENU IF CREATES A NEW ANSWER FROM LISTVIEW
		-- SEE "BELOW"

		-- QUERY FOR ANSWER BUILDER MAIN MENU IF EDITS SELECTED ANSWER FROM LISTVIEW
		-- "SELECT * FROM Answer WHERE AnswerID = "

		-- QUERY FOR ANSWER BUILDER MAIN MENU IF DELETES SELECTED ANSWER FROM LISTVIEW
		-- "DELETE * FROM Answer WHERE AnswerID = "
		
		
		
	-- ************* BELOW *************
	
		-- CREATE NEW	
			-- if user chooses update button to create new scenario form INSERT new scenario
			/*

			INSERT INTO Scenario (ScenarioName, ScenarioDescription)
			VALUES (value1, value2);

			*/
			

			-- if user chooses update button to create new stage form INSERT new stage
			/*

			INSERT INTO Stage (StageName, AudioFilePath, ImageFilePath, StageDescription)
			VALUES (value1, value2, value3, value4);

			*/
			
			
			-- if user chooses update button to create new answer form INSERT new answer
			/*

			INSERT INTO Answer (AnswerName, AnswerDescription)
			VALUES (value1, value2);
			
			*/		
		

		-- EDIT EXISTING
			-- if user chooses update button to edit existing scenario form UPDATE existing scenario
			/*

			UPDATE Scenario
			SET ScenarioName = value1, ScenarioDescription = value2
			WHERE ScenarioID = Value3; 

			/*			


			-- if user chooses update button to edit existing stage form UPDATE existing stage
			/*

			UPDATE Stage
			SET StageName = value1, AudioFilePath = value2, ImageFilePath = value3, StageDescription = value4
			WHERE StageID = Value5;

			/*
			

			-- if user chooses update button create existing stage form INSERT existing stage
			/*

			UPDATE Answer
			SET AnswerName = value1, AnswerDescription = value2
			WHERE StageID = Value3;

			/*
		
		
		-- PERFORM EXISTING
			-- if user chooses perform button to perform existing scenario from anywhere
			/*

			SELECT *
			FROM Scenario
			INNER JOIN Stage ON Scenario.ScenarioID = Stage.ScenarioID
			INNER JOIN Answer ON Stage.StageID = Answer.StageID
			WHERE Scenario.ScenarioID = value1;

			/*
			
			
	-- ************* BELOW2 *************
	
		-- tie together list boxes for relating stages to scenarios populate dropdown with all scenarios
			/*

		SELECT StageID, StageName
		FROM Stage	
	
			/*		


		-- tie together list boxes for relating answers to stages populate dropdown with all stages
			/*

		SELECT StageID, StageName
		FROM Stage

			/*		


		-- tie together list boxes for relating answers to next stage populate dropdown with all stages
			/*

		SELECT StageID, StageName
		FROM Stage

			/*