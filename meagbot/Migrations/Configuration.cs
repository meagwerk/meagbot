namespace meagbot.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using meagbot.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<meagbot.Models.meagbotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "meagbot.Models.meagbotContext";
        }

        protected override void Seed(meagbot.Models.meagbotContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Messages.AddOrUpdate(p => p.MessageId,

                new Messages { MessageId = 1, UserId = "Test", AnswersBytes = 0x0, ContactMe = false}

                );
            context.Questions.AddOrUpdate(p => p.QuestionId,

                new Questions { QuestionId = 1, Text = "Wie möchten Sie Ihre Anlage tätigen?" },
                new Questions { QuestionId = 2, Text = "Ihre bisherigen Erfahrungen (seit wenigstens zwei Jahren getätigte Geschäfte)" },
                new Questions { QuestionId = 3, Text = "Ihre Kenntnisse zur Geldanlage" },
                new Questions { QuestionId = 4, Text = "Was sind Ihre Anlageziele?" },
                new Questions { QuestionId = 5, Text = "Ihre Einstellung zur Wertentwicklung?" },
                new Questions { QuestionId = 6, Text = "Die geplante Anlage entspricht ..." + Environment.NewLine + "(Einmalanlage oder Jahresvolumen bei regelm. Sparen)" },
                new Questions { QuestionId = 7, Text = "Die geplante Anlage beträgt ...  " + Environment.NewLine + "(Einmalanlage oder Jahresvolumen bei regelm. Sparen. Vermögen = Geld, Wertpapiere, Immobilien etc.abzüglich Kredite, Darlehen, Hypotheken etc.)" }
                );
            context.Answers.AddOrUpdate(p => p.AnswerId,
                new Answers { AnswerId = 1, Text = "1. Durch regelmäßiges Sparen (ggf. zusätzliche Ersteinzahlung)", Weight = 0, Question = context.Questions.Find(1) },
                new Answers { AnswerId = 2, Text = "2. Durch eine einmalige Zahlung(ohne Folgezahlungen)", Weight = 0, Question = context.Questions.Find(1) },
                new Answers { AnswerId = 3, Text = "1. Ich habe noch nie Wertpapiere gekauft.", Weight = 0x23, Question = context.Questions.Find(2) },
                new Answers { AnswerId = 4, Text = "2. Ich habe bislang nur in festverzinsliche Wertpapiere oder Immobilienfonds investiert.", Weight = 0x34, Question = context.Questions.Find(2) },
                new Answers { AnswerId = 5, Text = "3. Ich habe auch schon in Aktien, Aktienfonds oder gemischte Fonds mit Aktienanteil investiert.", Weight = 0x44, Question = context.Questions.Find(2) },
                new Answers { AnswerId = 6, Text = "1. Ich habe mich bislang nicht mit dem Thema Geldanlage beschäftigt.", Weight = 0x33, Question = context.Questions.Find(3) },
                new Answers { AnswerId = 7, Text = "2. Ich habe bislang nur geringe Kenntnisse, finde das Thema Geldanlage aber interessant.", Weight = 0x34, Question = context.Questions.Find(3) },
                new Answers { AnswerId = 8, Text = "3. Ich kenne mich auch mit Aktien oder Aktienfonds aus. Ich weiß, dass die Ertragsmöglichkeiten dieser Anlageform mit Verlustrisiken einher gehen.", Weight = 0x44, Question = context.Questions.Find(3) },
                new Answers { AnswerId = 9, Text = "1. Ich möchte liquide sein. Meine beabsichtigte Anlagedauer beträgt weniger als zwei Jahre.", Weight = 0x14, Question = context.Questions.Find(4) },
                new Answers { AnswerId = 10, Text = "2. Ich möchte mir bestimmte Wünsche erfüllen (z.B. Anschaffungen, Urlaub).", Weight = 0x24, Question = context.Questions.Find(4) },
                new Answers { AnswerId = 11, Text = "3. Ich beabsichtige das Geld ca. 5-8 Jahre anzulegen.", Weight = 0x34, Question = context.Questions.Find(4) },
                new Answers { AnswerId = 12, Text = "4. Ich möchte Vermögen aufbauen (z.B. finanzielle Unabhängigkeit, Altersvorsorge, Startkapital für Kinder, Immobilie). Ich beabsichtige das Geld mindestens 8 Jahre anzulegen.", Weight = 0x44, Question = context.Questions.Find(4) },
                new Answers { AnswerId = 13, Text = "1. Ich bin auf eine möglichst gleichmäßige Wertsteigerung meiner Anlage angewiesen. Sicherheit ist mir wichtiger als hohe Ertragserwartungen.", Weight = 0x23, Question = context.Questions.Find(5) },
                new Answers { AnswerId = 14, Text = "2. Für hohe Ertragserwartungen bin ich bereit, gewisse Schwankungsrisiken einzugehen.", Weight = 0x34, Question = context.Questions.Find(5) },
                new Answers { AnswerId = 15, Text = "3. Ich lege das Geld mit dem Ziel einer möglichst hohen Ertragserwartung an. Dafür bin ich auch bereit, hohe Schwankungsrisiken einzugehen.", Weight = 0x44, Question = context.Questions.Find(5) },
                new Answers { AnswerId = 16, Text = "1. Nur einem geringen Teil (unter 10%) meines derzeitigen jährlichen Bruttoeinkommens.", Weight = 0x44, Question = context.Questions.Find(6) },
                new Answers { AnswerId = 17, Text = "2. Ca. 10% - 30% meines jährlichen Bruttoeinkommens.", Weight = 0x44, Question = context.Questions.Find(6) },
                new Answers { AnswerId = 18, Text = "3. Über 30% meines jährlichen Bruttoeinkommens.", Weight = 0x34, Question = context.Questions.Find(6) },
                new Answers { AnswerId = 19, Text = "1. Weniger als 30% meines Vermögens.", Weight = 0x44, Question = context.Questions.Find(7) },
                new Answers { AnswerId = 20, Text = "2. Ca. 30%-100% meines Vermögens.", Weight = 0x33, Question = context.Questions.Find(7) },
                new Answers { AnswerId = 21, Text = "3. Stammt ganz oder teilweise aus Krediten.", Weight = 0x11, Question = context.Questions.Find(7) }
                );
        }
    }
}
