using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using meagbot.Models;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using Microsoft.Bot.Builder.Dialogs;
#pragma warning disable 649
// The SandwichOrder is the simple form you want to fill out.  It must be serializable so the bot can be stateless.
// The order of fields defines the default order in which questions will be asked.
// Enumerations shows the legal options for each field in the SandwichOrder and the order is the order values will be presented 
// in a conversation.
namespace meagbot.Bot
{


    [Serializable]
    public class BotLogic
    {
        //public string email { get; set; } user email 
        //public string skype { get; set; } user skype

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Wie möchten Sie Ihre Anlage tätigen? {||}" })]
        [Numeric (1,2)]
        public string answer1 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Ihre bisherigen Erfahrungen (seit wenigstens zwei Jahren getätigte Geschäfte) {||}" })]
        [Numeric(1, 3)]
        public string answer2 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Ihre Kenntnisse zur Geldanlage {||}" })]
        [Numeric(1, 3)]
        public string answer3 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Was sind Ihre Anlageziele? {||}" })]
        [Numeric(1, 4)]
        public string answer4 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Ihre Einstellung zur Wertentwicklung? {||}" })]
        [Numeric(1, 3)]
        public string answer5 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Die geplante Anlage entspricht ... \n (Einmalanlage oder Jahresvolumen bei regelm. Sparen) {||}" })]
        [Numeric(1, 3)]
        public string answer6 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Die geplante Anlage beträgt ... \n (Einmalanlage oder Jahresvolumen bei regelm. Sparen. Vermögen = Geld, Wertpapiere, Immobilien etc.abzüglich Kredite, Darlehen, Hypotheken etc.) {||}" })]
        [Numeric(1, 3)]
        public string answer7 { get; set; }

        [Template(TemplateUsage.EnumSelectOne, ChoiceStyle = ChoiceStyleOptions.PerLine)]
        //[Prompt(new string[] { "Die geplante Anlage beträgt ... \n (Einmalanlage oder Jahresvolumen bei regelm. Sparen. Vermögen = Geld, Wertpapiere, Immobilien etc.abzüglich Kredite, Darlehen, Hypotheken etc.) {||}" })]
        [Numeric(1, 3)]
        public string answer8 { get; set; }
        
        public static IForm<BotLogic> BuildForm()
        {
            meagbotContext db = new meagbotContext();

            OnCompletionAsyncDelegate<BotLogic> processFond = async (context, state) =>
            {
                await context.PostAsync(state.answer1);
                await context.PostAsync(state.answer2);
                await context.PostAsync(state.answer3);
                await context.PostAsync(state.answer4);
                await context.PostAsync(state.answer5);
                await context.PostAsync(state.answer6);
                await context.PostAsync(state.answer7);
                
            };

            return new FormBuilder<BotLogic>()                    
                    .Message("Welcome to the simple fond advisor bot!")
                    .Field(new FieldReflector<BotLogic>(nameof(answer1))
                            .SetFieldDescription(db.Questions.Find(1).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(1).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(1).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(2).Text)
                                    .AddTerms("2", "2");
                                return true;
                            }))
                    .Field(new FieldReflector<BotLogic>(nameof(answer2))
                            .SetFieldDescription(db.Questions.Find(2).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(2).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(3).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(4).Text)
                                    .AddTerms("2", "2")
                                    .AddDescription("3", db.Answers.Find(5).Text)
                                    .AddTerms("3", "3");
                                return true;
                            }))
                    .Field(new FieldReflector<BotLogic>(nameof(answer3))
                            .SetFieldDescription(db.Questions.Find(3).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(3).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(6).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(7).Text)
                                    .AddTerms("2", "2")
                                    .AddDescription("3", db.Answers.Find(8).Text)
                                    .AddTerms("3", "3");
                                return true;
                            }))
                    .Field(new FieldReflector<BotLogic>(nameof(answer4))
                            .SetFieldDescription(db.Questions.Find(4).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(4).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(9).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(10).Text)
                                    .AddTerms("2", "2")
                                    .AddDescription("3", db.Answers.Find(11).Text)
                                    .AddTerms("3", "3")
                                    .AddDescription("4", db.Answers.Find(12).Text)
                                    .AddTerms("4", "4");
                                return true;
                            }))
                    .Field(new FieldReflector<BotLogic>(nameof(answer5))
                            .SetFieldDescription(db.Questions.Find(5).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(5).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(13).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(14).Text)
                                    .AddTerms("2", "2")
                                    .AddDescription("3", db.Answers.Find(15).Text)
                                    .AddTerms("3", "3");
                                return true;
                            }))
                    .Field(new FieldReflector<BotLogic>(nameof(answer6))
                            .SetFieldDescription(db.Questions.Find(6).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(6).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(16).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(17).Text)
                                    .AddTerms("2", "2")
                                    .AddDescription("3", db.Answers.Find(18).Text)
                                    .AddTerms("3", "3");
                                return true;
                            }))
                    .Field(new FieldReflector<BotLogic>(nameof(answer7))
                            .SetFieldDescription(db.Questions.Find(7).Text)
                            .SetPrompt(new PromptAttribute(db.Questions.Find(7).Text + " {||}"))
                            .SetType(null)
                            .SetDefine(async (state, field) =>
                            {
                                field
                                    .AddDescription("1", db.Answers.Find(19).Text)
                                    .AddTerms("1", "1")
                                    .AddDescription("2", db.Answers.Find(20).Text)
                                    .AddTerms("2", "2")
                                    .AddDescription("3", db.Answers.Find(21).Text)
                                    .AddTerms("3", "3");
                                return true;
                            }))
                    .OnCompletion(processFond)
                    .Build();
        }
    };
}