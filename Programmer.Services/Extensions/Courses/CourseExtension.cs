namespace Programmer.Services.Extensions.Courses
{
    using Programmer.Services.Dtos;
    using System.Collections.Generic;

    using static CoursesRequiredSkill;

    public class CourseExtension
    {
        // TODO: refactor this
        public static IEnumerable<bool> CheckCourses(UserStatsViewModel user) 
        {
            var results = new List<bool>();

            results.Add(CheckForFundamentals(user));
            results.Add(CheckForAdvanced(user));
            results.Add(CheckForOop(user));
            results.Add(CheckForDataStructures(user));
            results.Add(CheckForAlgorithms(user));
            results.Add(CheckForTesting(user));
            results.Add(CheckForDatabase(user));
            results.Add(CheckForEfCore(user));
            results.Add(CheckForJavaScript(user));
            results.Add(CheckForHtml(user));
            results.Add(CheckForCss(user));
            results.Add(CheckForAspNetCore(user));
            results.Add(CheckForReact(user));
            results.Add(CheckForNodeJs(user));

            return results;
        }

        private static bool CheckForFundamentals(UserStatsViewModel user)
        {
            return user.CSharp >= FundamentalsCSharp && user.ProblemSolving >= FundamentalsProblemSolving;
        }

        private static bool CheckForAdvanced(UserStatsViewModel user)
        {
            return user.CSharp >= AdvancedCSharp && user.ProblemSolving >= AdvancedProblemSolving;
        }

        private static bool CheckForOop(UserStatsViewModel user)
        {
            return user.CSharp >= OopCSharp && user.ProblemSolving >= OopProblemSolving;
        }

        private static bool CheckForDataStructures(UserStatsViewModel user)
        {
            return user.DataStructures >= DataStructures && user.AbstractThinking >= DataStructuresAbstractThinking;
        }

        private static bool CheckForAlgorithms(UserStatsViewModel user)
        {
            return user.Algorithms >= Algorithms && user.ProblemSolving >= AlgorithmsProblemSolving;
        }

        private static bool CheckForTesting(UserStatsViewModel user)
        {
            return user.Testing >= Testing && user.AbstractThinking >= TestingAbstractThinking;
        }

        private static bool CheckForDatabase(UserStatsViewModel user)
        {
            return user.DatabasesAndSQL >= DatabaseAndSql && user.AbstractThinking >= DatabaseAndSqlAbstractThinking;
        }

        private static bool CheckForEfCore(UserStatsViewModel user)
        {
            // TODO: and db stats
            return user.EfCore >= EfCore && user.ProblemSolving >= EfCoreProblemSolving;
        }

        private static bool CheckForJavaScript(UserStatsViewModel user)
        {
            return user.VanillaJavaScript >= VanillaJavaScript && user.ProblemSolving >= VanillaJavaScriptProblemSolving;
        }

        private static bool CheckForHtml(UserStatsViewModel user)
        {
            return user.Html >= Html && user.Creativity >= HtmlCreativity;
        }

        private static bool CheckForCss(UserStatsViewModel user)
        {
            return user.Css >= Css && user.Creativity >= CssCreativity;
        }

        private static bool CheckForAspNetCore(UserStatsViewModel user)
        {
            return user.AspNetCore >= AspNetCore && user.AbstractThinking >= AspNetCoreAbstractThinking;
        }

        private static bool CheckForReact(UserStatsViewModel user) 
        {
            // and vanillaJs stat
            return user.React >= React && user.Creativity >= ReactCreativity;
        }

        private static bool CheckForNodeJs(UserStatsViewModel user) 
        {
            return user.NodeJs >= NodeJs && user.AbstractThinking >= NodeJsAbstractThinking;
        }
    }
}
