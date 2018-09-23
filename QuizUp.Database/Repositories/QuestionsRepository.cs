using Microsoft.EntityFrameworkCore;
using QuizUp.Models;
using QuizUp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuizUp.Database.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public QuestionsRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
            AddQuestions();
        }

        private async void AddQuestions()
        {
            var allQuestions = await _databaseContext.Questions.ToListAsync();
            Question question = new Question
            {
                ID = 1,
                Header = "Q: What is the capital of India?",
                Choice1 = "1: Delhi",
                Choice2 = "2: Mumbai",
                Choice3 = "3: Banglore",
                Choice4 = "4: Hyderabad",
                Answer = "1: Delhi"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 2,
                Header = "Q: Grand Central Terminal, Park Avenue, New York is the world's?",
                Choice1 = "1: Largest railway station",
                Choice2 = "2: Highest railway station",
                Choice3 = "3: Longest railway station",
                Choice4 = "4: None of these",
                Answer = "1: Largest railway station"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 3,
                Header = "Q: Entomology is the science that studies?",
                Choice1 = "1: Behavior of human beings",
                Choice2 = "2: Insects",
                Choice3 = "3: The origin and history of technical and scientific terms",
                Choice4 = "4: The formation of rocks",
                Answer = "2: Insects"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 4,
                Header = "Q: Eritrea, which became the 182nd member of the UN in 1993, is in the continent of?",
                Choice1 = "1: Asia",
                Choice2 = "2: Australia",
                Choice3 = "3: Europe",
                Choice4 = "4: Africa",
                Answer = "4: Africa"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 5,
                Header = "Q: Garampani sanctuary is located at?",
                Choice1 = "1: Junagarh, Gujarat",
                Choice2 = "2: Diphu, Assam",
                Choice3 = "3: Kohima, Nagaland",
                Choice4 = "4: Gangtok, Sikkim",
                Answer = "2: Diphu, Assam"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 6,
                Header = "Q: The ozone layer restricts?",
                Choice1 = "1: Infrared light",
                Choice2 = "2: Visible light",
                Choice3 = "3: Ultraviolet readiation",
                Choice4 = "4: X-Rays and Gamma rays",
                Answer = "3: Ultraviolet readiation"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 7,
                Header = "Q: Ecology deals with?",
                Choice1 = "1: Birds",
                Choice2 = "2: Cell formation",
                Choice3 = "3: Relation between organisms and their environment",
                Choice4 = "4: None of these",
                Answer = "3: Relation between organisms and their environment"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 8,
                Header = "Q: Goa Shipyard Limited(GSL) was established in?",
                Choice1 = "1: 1958",
                Choice2 = "2: 1957",
                Choice3 = "3: 1956",
                Choice4 = "4: 1955",
                Answer = "2: 1957"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 9,
                Header = "Q: GNLF stands for?",
                Choice1 = "1: Gorkha National Liberation Front",
                Choice2 = "2: Gross National Liberation Form",
                Choice3 = "3: Both Option A and B",
                Choice4 = "4: None of the above",
                Answer = "1: Gorkha National Liberation Front"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 10,
                Header = "Q: Filaria is caused by?",
                Choice1 = "1: Bacteria",
                Choice2 = "2: Virus",
                Choice3 = "3: Mosquito",
                Choice4 = "4: Protozoa",
                Answer = "3: Mosquito"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 11,
                Header = "Q: What is the number of states in India?",
                Choice1 = "1: 14",
                Choice2 = "2: 16",
                Choice3 = "3: 25",
                Choice4 = "4: 29",
                Answer = "4: 29"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 12,
                Header = "Q: Which is the first state to be formed on the basis of language?",
                Choice1 = "1: Andhra Pradesh",
                Choice2 = "2: Bombay",
                Choice3 = "3: Madhya Bharat",
                Choice4 = "4: Meghalaya",
                Answer = "1: Andhra Pradesh"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 13,
                Header = "Q: When was Burma was separated from India?",
                Choice1 = "1: 1948",
                Choice2 = "2: 1937",
                Choice3 = "3: 1950",
                Choice4 = "4: 1955",
                Answer = "2: 1937"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 14,
                Header = "Q: When did India become a republic?",
                Choice1 = "1: 1935",
                Choice2 = "2: 1947",
                Choice3 = "3: 1950",
                Choice4 = "4: 1961",
                Answer = "3: 1950"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 15,
                Header = "Q: Which state was divided into Maharashtra and Gujarat in 1960?",
                Choice1 = "1: Bombay",
                Choice2 = "2: Madras",
                Choice3 = "3: Mysore",
                Choice4 = "4: Hyderabad",
                Answer = "1: Bombay"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 16,
                Header = "Q: Who was the Speaker of the Lok Sabha before he became the President of India?",
                Choice1 = "1: R. Venkataraman",
                Choice2 = "2: A. P. J. Abdul Kalam",
                Choice3 = "3: N. Sanjeeva Reddy",
                Choice4 = "4: K. R. Narayanan",
                Answer = "3: N.Sanjeeva Reddy"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 17,
                Header = "Q: How was Tamil Nadu known?",
                Choice1 = "1: Mysore",
                Choice2 = "2: Madras",
                Choice3 = "3: Bombay",
                Choice4 = "4: Hyderabad",
                Answer = "2: Madras"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 18,
                Header = "Q: Which is the capital of Kerala?",
                Choice1 = "1: Calicut",
                Choice2 = "2: Cochin",
                Choice3 = "3: Ooty",
                Choice4 = "4: Thiruvananthapuram",
                Answer = "4: Thiruvananthapuram"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 19,
                Header = "Q: Nagaland was separated from which state?",
                Choice1 = "1: Orissa",
                Choice2 = "2: Punjab",
                Choice3 = "3: West Begal",
                Choice4 = "4: Assam",
                Answer = "4: Assam"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 20,
                Header = "Q: Which is the smallest state in terms of area?",
                Choice1 = "1: Punjab",
                Choice2 = "2: Sikkim",
                Choice3 = "3: Goa",
                Choice4 = "4: Tripura",
                Answer = "3: Goa"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 21,
                Header = "Q: Where is the tomb of Akbar located?",
                Choice1 = "1: Delhi",
                Choice2 = "2: Sikandra",
                Choice3 = "3: Lahore",
                Choice4 = "4: Fatehpur Sikri",
                Answer = "2: Sikandra"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 22,
                Header = "Q: Which is the national animal of India?",
                Choice1 = "1: Elephant",
                Choice2 = "2: Deer",
                Choice3 = "3: Cow",
                Choice4 = "4: Tiger",
                Answer = "4: Tiger"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 23,
                Header = "Q: Which is the national flower of India",
                Choice1 = "1: Lotus",
                Choice2 = "2: Rose",
                Choice3 = "3: Marigold",
                Choice4 = "4: Sunflower",
                Answer = "1: Lotus"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 24,
                Header = "Q: Who founded Indian National Congress?",
                Choice1 = "1: W. C. Banerjee",
                Choice2 = "2: A. O. Hume",
                Choice3 = "3: Annie Besant",
                Choice4 = "4: Motilal Nehru",
                Answer = "2: A.O.Hume"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 25,
                Header = "Q: Which former Indian Prime Minister’s birthday is on December 25?",
                Choice1 = "1: Rajiv Gandhi",
                Choice2 = "2: Atal Bihari Vajpayee",
                Choice3 = "3: Lal Bahadur Shastri",
                Choice4 = "4: P. V. Narsimha Rao",
                Answer = "2: Atal Bihari Vajpayee"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 26,
                Header = "Q: Which state was known as North East Frontier Agency?",
                Choice1 = "1: Mizoram",
                Choice2 = "2: Tripura",
                Choice3 = "3: Manipur",
                Choice4 = "4: Arunachal Pradesh",
                Answer = "4: Arunachal Pradesh"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 27,
                Header = "Q: Which state or union territory has French as an official language?",
                Choice1 = "1: Goa",
                Choice2 = "2: Lakshadweep",
                Choice3 = "3: Pondicherry",
                Choice4 = "4: Diu and Daman",
                Answer = "3: Pondicherry"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 28,
                Header = "Q: Which is the official language of Jammu and Kashmir?",
                Choice1 = "1: Kashmiri",
                Choice2 = "2: Pahadi",
                Choice3 = "3: Dogri",
                Choice4 = "4: Urdu",
                Answer = "4: Urdu"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 29,
                Header = "Q: Which state became part of India in 1975?",
                Choice1 = "1: Goa",
                Choice2 = "2: Manipur",
                Choice3 = "3: Tripura",
                Choice4 = "4: Sikkim",
                Answer = "4: Sikkim"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            question = new Question
            {
                ID = 30,
                Header = "Q: Which city was the summer capital of India during British Rule?",
                Choice1 = "1: Ooty",
                Choice2 = "2: Shimla",
                Choice3 = "3: Pachmarhi",
                Choice4 = "4: Matheran",
                Answer = "2: Shimla"
            };

            if (allQuestions.FirstOrDefault(q => q.ID == question.ID) == null)
            {
                _databaseContext.Add(question);
            }

            _databaseContext.SaveChanges();
        }

        public async Task<List<Question>> GetQuestions(int numberOfQuestions)
        {
            try
            {
                var questions = await _databaseContext.Questions.OrderBy(question => Guid.NewGuid().ToString()).Take(numberOfQuestions).ToListAsync();
                return questions;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
