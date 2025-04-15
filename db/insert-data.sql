USE `task_master`;

-- Insert sample data into Users table
INSERT INTO `Users` (`email`, `password`, `nom`, `prenom`) VALUES
('john.doe@example.com', 'password123', 'Doe', 'John'),
('jane.smith@example.com', 'password456', 'Smith', 'Jane');

-- Insert sample data into Tasks table
INSERT INTO `Tasks` (`titre`, `description`, `echeance`, `statut`, `priorite`, `auteur`, `realisateur`, `categorie`, `tags`) VALUES
('Task 1', 'Description for Task 1', '2025-04-15 12:00:00', 'a faire', 'moyenne', 1, 2, 'Work', 'tag1,tag2'),
('Task 2', 'Description for Task 2', '2025-04-20 12:00:00', 'en cours', 'haute', 2, 1, 'Personal', 'tag3,tag4');

-- Insert sample data into Comments table
INSERT INTO `Comments` (`idTask`, `idAuteur`, `contenu`) VALUES
(1, 1, 'This is a comment for Task 1'),
(2, 2, 'This is a comment for Task 2');

-- Insert sample data into SubTasks table
INSERT INTO `SubTasks` (`idTask`, `titre`, `status`, `echeance`) VALUES
(1, 'SubTask 1 for Task 1', 'a faire', '2025-04-10 12:00:00'),
(2, 'SubTask 1 for Task 2', 'en cours', '2025-04-18 12:00:00');