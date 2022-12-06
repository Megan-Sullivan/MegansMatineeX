using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using MegansMatineeX.Models;

namespace MegansMatineeX.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MegansMatineeXContext context)
        {
            
            // Look for any lead actors/actresses.
            if (context.LeadActs.Any())
            {
                return;   // DB has been seeded
            }
            // Look for any directors.
            if (context.Directors.Any())
            {
                return;   // DB has been seeded
            }

            var BillMurray = new LeadAct
            {
                LeadActName = "Bill Murray",
                Birthdate = DateTime.Parse("1950-9-21"),
                LeadActDetails = "Bill Murray is an American actor, comedian, and writer. The fifth of nine children, he was born William James Murray in Wilmette, Illinois, to Lucille (Collins), a mailroom clerk, and Edward Joseph Murray II, who sold lumber. He is of Irish descent. Among his siblings are actors Brian Doyle-Murray, Joel Murray, and John Murray. He and most of his siblings worked as caddies, which paid his tuition to Loyola Academy, a Jesuit school.",
                AdditionalInfo = "https://www.imdb.com/name/nm0000195/bio"
            };

            var JamieClayton = new LeadAct
            {
                LeadActName = "Jamie Clayton",
                Birthdate = DateTime.Parse("1978-1-15"),
                LeadActDetails = "Jamie Clayton is an American actress and model. Clayton is best known for starring as Nomi Marks in the Netflix original series Sense8, Sasha Booker in the third season of Designated Survivor and Tess Van De Berg in Showtime's The L Word: Generation Q. She portrays Pinhead in the 2022 Hellraiser film.",
                AdditionalInfo = "https://www.imdb.com/name/nm3911870/"
            };

            var CaroleLaure = new LeadAct
            {
                LeadActName = "Carole Laure",
                Birthdate = DateTime.Parse("1950-8-5"),
                LeadActDetails = "Before she became an actress Carole Laure was a teacher. She was born on August 5, 1950 in Montreal (Québec) Canada. The profession she has chosen did not give her any satisfaction. She met some young Canadian film makers, that resulted in her first appearance as an actress, age twenty, in Mon enfance à Montréal (1971), directed by Jean Chabot. Three years later, she met director Gilles Carle, who helped her career. Her exotic beauty (her mother has Indian blood), her charm and spontaneity, her dark eyes with light melancholy look, made her a star in French-Canadian cinema. She is not only acting but also sings. Carole has recorded several LPs in French and English, collaborating with Lewis Furey. She also sings in the filmmusical Fantastica (1980) directed by her old friend, Gilles.",
                AdditionalInfo = "https://www.imdb.com/name/nm0491021/bio?ref_=nm_ql_1"
            };

            var HarrisMilstead = new LeadAct
            {
                LeadActName = "Harris Glenn Milstead aka Divine",
                Birthdate = DateTime.Parse("1945-10-19"),
                LeadActDetails = "Originally born Harris Glen Milstead just after the end of WWII, Baltimore's most outrageous resident eventually became the international icon of bad taste cinema, as the always shocking and highly entertaining transvestite performer, Divine.",
                AdditionalInfo = "https://www.imdb.com/name/nm0001145/bio?ref_=nm_ql_1"
            };

            var JamesLorinz = new LeadAct
            {
                LeadActName = "James Lorinz",
                Birthdate = DateTime.Parse("1964-5-22"),
                LeadActDetails = "James Lorinz was born on May 22, 1964 in New York City, New York, USA. He is an actor and writer, known for Frankenhooker (1990), Street Trash (1987) and King of New York (1990).",
                AdditionalInfo = "https://www.imdb.com/name/nm0521033/bio?ref_=nm_ql_1"
            };

            var TimCurry = new LeadAct
            {
                LeadActName = "Tim Curry",
                Birthdate = DateTime.Parse("1946-4-19"),
                LeadActDetails = "Timothy James Curry was born on April 19, 1946 in Grappenhall, Cheshire, England. His mother, Maura Patricia (Langmead), was a school secretary, and his father, James Curry, was a Methodist Royal Navy chaplain. Curry studied Drama and English at Birmingham University, from which he graduated with Combined Honors. His first professional success was in the London production of \"Hair\", followed by more work in the Royal Shakespeare Company, the Glasgow Civic Repertory Company, and the Royal Court Theatre where he created the role of Dr. Frank-N-Furter in \"The Rocky Horror Show\". He recreated the role in the Los Angeles and Broadway productions and starred in the screen version entitled The Rocky Horror Picture Show (1975). Curry continued his career on the New York and London stages with starring roles in \"Travesties\", \"Amadeus\", \"The Pirates of Penzance\", \"The Rivals\", \"Love for Love\", \"Dalliance\", \"The Threepenny Opera\", \"The Art of Success\" and \"My Favorite Year\". He also starred in the United States tour of \"Me and My Girl\". He has received two Tony Award nominations for best actor and won the Royal Variety Club Award as \"Stage Actor of the Year\".",
                AdditionalInfo = "https://www.imdb.com/name/nm0000347/bio?ref_=nm_ql_1"
            };

            var leadacts = new LeadAct[]
            {
                BillMurray,
                JamieClayton,
                CaroleLaure,
                HarrisMilstead,
                JamesLorinz,
                TimCurry
            };

            context.AddRange(leadacts);

            var IvanReitman = new Director
            {
                DirectorName = "Ivan Reitman",
                Birthdate = DateTime.Parse("1946-10-27"),
                DirectorDetails = "Czechoslovak-born Canadian filmmaker.",
                AdditionalInfo = "https://www.imdb.com/name/nm0718645/?ref_=nv_sr_srsg_0"
            };

            var DavidBruckner = new Director
            {
                DirectorName = "David Bruckner",
                Birthdate = DateTime.Parse("1988-1-20"),
                DirectorDetails = "David Brückner was born on January 20, 1988. He is an actor and producer, known for Dead Survivors (2010), Glauchau sehen... und sterben? (2008) and Alp (2017). He has been married to Jennifer Trommer since October 1, 2022.",
                AdditionalInfo = "https://www.imdb.com/name/nm4103556/bio"
            };

            var DusanMakavejev = new Director
            {
                DirectorName = "Dušan Makavejev",
                Birthdate = DateTime.Parse("1932-10-13"),
                DirectorDetails = "Dusan Makavejev is the premier figure in Yugoslavian film history; his films are deeply rooted in his nation's painful postwar experiences and draw on important Yugoslavian cinematic and cultural models. Makavejev's work has violated many political and sexual taboos and invited censorship in dozens of nations. In the 1950s, after studying psychology at Belgrade University, Makavejev became involved in the activities of various film societies and festivals and studied direction at the Academy for Radio, Television and Film. As early as 1953, he began making short films and documentaries and would work in various capacities at both the Zagreb and Avala studios during the late 50s and early 60s. The documentary impulse remains powerful in Makavejev's work, as does the tendency to intercut undigested segments from other films into longer works.",
                AdditionalInfo = "https://www.imdb.com/name/nm0538445/bio?ref_=nm_ql_1"
            };

            var JohnWaters = new Director
            {
                DirectorName = "John Waters",
                Birthdate = DateTime.Parse("1946-4-22"),
                DirectorDetails = "John Samuel Waters Jr. is an American filmmaker, writer, actor, and artist. He rose to fame in the early 1970s for his transgressive cult films, including Multiple Maniacs, Pink Flamingos and Female Trouble.",
                AdditionalInfo = "https://www.imdb.com/name/nm0000691/bio?ref_=nm_ql_1"
            };

            var FrankHenenlotter = new Director
            {
                DirectorName = "Frank Henenlotter",
                Birthdate = DateTime.Parse("1950-8-29"),
                DirectorDetails = "Writer/director Frank Henenlotter was born August 29, 1950, in New York City. He gleefully \"misspent\" his youth watching a large array of blithely cheap'n'cheesy low-budget exploitation flicks in various seedy grindhouse theaters on Mahattan's 42nd St. He began making 8mm films as a teenager. His 16mm black-and-white short Slash of the Knife (1972) actually played at a 42nd St. grindhouse midnight show with John Waters' Pink Flamingos (1972). He briefly worked as a commercial artist and graphic designer prior to embarking on a career as a filmmaker. Henenlotter's pictures are distinguished by their offbeat plots, cheerfully lowbrow humor, excessive gore and pervasively sordid atmosphere. He made a smashing horror film debut with the marvelously gruesome and sleazy monster splatter gem Basket Case (1982), which delivered a surprisingly substantial amount of touching pathos along with the expected over-the-top explicit violence and hilariously scuzzy humor.",
                AdditionalInfo = "https://www.imdb.com/name/nm0376963/bio?ref_=nm_ql_1"
            };

            var JimSharman = new Director
            {
                DirectorName = "Jim Sharman",
                Birthdate = DateTime.Parse("1945-3-12"),
                DirectorDetails = "Jim Sharman spent much of his young life at the circus, where his father and grandfather ran a travelling boxing sideshow. Taking an interest in theatre, he attended the National Institute of Dramatic Art in Sydney, graduating in 1966. Sharman became interested in directing experimental theatre. While directing the Sydney production of Hair in 1970, he met a young architectural student named Brian Thomson, who would become his longtime set designer. His local production of Jesus Christ Superstar caught the attention of lyricist Tim Rice, who brought him and Thomson to London in 1972 to stage the production, which included Richard O'Brien. Directing the stage production of \"The Rocky Horror Show\" gave Sharman the opportunity to direct its film version The Rocky Horror Picture Show (1975) and its sequel Shock Treatment (1981). Sharman went on to become one of Australia's most respected theatre directors.",
                AdditionalInfo = "https://www.imdb.com/name/nm0788940/bio?ref_=nm_ql_1"
            };

            var directors = new Director[]
            {
                IvanReitman,
                DavidBruckner,
                DusanMakavejev,
                JohnWaters,
                FrankHenenlotter,
                JimSharman
            };

            context.AddRange(directors);

            var FoxEntertainment = new Producer
            {
                ProducerName = "Fox Entertainment"
            };

            var producers = new Producer[]
            {
                FoxEntertainment
            };

            context.AddRange(producers);

            var siteAssignments = new SiteAssignment[]
            {
                new SiteAssignment{
                    Producer = FoxEntertainment,
                    Location = "Hollywood" }
            };

            context.AddRange(siteAssignments);

            var FoxStudios = new Production
            {
                Name = "Fox Studios",
                Budget = 1000000,
                StartDate = DateTime.Parse("2022-12-3"),
                Administrator = FoxEntertainment
            };

            var productions = new Production[]
            {
                FoxStudios
            };

            context.AddRange(productions);

            var ghostbusters = new Movie
            {
                MovieID = 0001,
                Title = "Ghostbusters",
                Director = "Ivan Reitman",
                LeadAct = "Bill Murray",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = GenreType.Comedy,
                WhereToWatch = "https://www.netflix.com/",
                Rating = RatingType.G,
                Review = "\"Ghostbusters\" is a head - on collision between two comic approaches that have rarely worked together very successfully.This time, they do.It\'s (1) a special-effects blockbuster, and (2) a sly dialogue movie, in which everybody talks to each other like smart graduate students who are in on the joke. In the movie\'s climactic scenes, an apocalyptic psychic mindquake is rocking Manhattan, and the experts talk like Bob and Ray. You can find the rest of this review at <a href='https://www.rogerebert.com/reviews/ghostbusters-1984'>https://www.rogerebert.com/reviews/ghostbusters-1984</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment}
            };

            var ghostbusters2 = new Movie
            {
                MovieID = 0002,
                Title = "Ghostbusters 2",
                Director = "Ivan Reitman",
                LeadAct = "Bill Murray",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = GenreType.Comedy,
                WhereToWatch = "https://www.hulu.com/",
                Rating = RatingType.G,
                Review = "Ghostbusters II might not have the reputation of the 1984 original, but it deserves more love than it gets.  Read full professional review at <a href='https://www.denofgeek.com/movies/in-defense-of-ghostbusters-ii/'>https://www.denofgeek.com/movies/in-defense-of-ghostbusters-ii/</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment }
            };

            var hellraiser = new Movie
            {
                MovieID = 0003,
                Title = "Hellraiser",
                Director = "David Bruckner",
                LeadAct = "Jamie Clayton",
                ReleaseDate = DateTime.Parse("2022-10-7"),
                Genre = GenreType.Horror,
                WhereToWatch = "https://www.hulu.com/",
                Rating = RatingType.R,
                Review = "David Bruckner's Hellraiser is an excitably reverent retooling of Clive Barker's original horror classic and the author's novella, The Hellbound Heart. Writers Ben Collins and Luke Piotrowski take David S. Goyer's story treatment into alternate realms of sensual punishment, far from Kirsty Cotton's encounter with the Lament Configuration. Barker's Hellraiser favors ‘80s horror tendencies of a more stripped but graphic nature — Bruckner's able to expand storytelling and scope, going with a \"bigger\" mentality that still writhes with infernal carnal pleasures. It's respectfully indebted to Barker's psycho-sexual confrontation of eroticism and violent punishments. Yet, Bruckner never attempts to retrace what Barker's already colored outside typical horror lines — Hellraiser 2022 thematically raises hell on his newly renovated terms. Read full review at <a href='https://www.ign.com/articles/hellraiser-review-2022-hulu'>https://www.ign.com/articles/hellraiser-review-2022-hulu</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment }
            };

            var sweetmovie = new Movie
            {
                MovieID = 0004,
                Title = "Sweet Movie",
                Director = "Dušan Makavejev",
                LeadAct = "Carole Laure",
                ReleaseDate = DateTime.Parse("1975-10-9"),
                Genre = GenreType.Comedy,
                WhereToWatch = "https://www.amazon.com/",
                Rating = RatingType.NA,
                Review = "Dusan Makavejev's \"Sweet Movie\" begins with what looks like a garden-variety National Lampoon function (an oil millionaire named Mr. Kapital is holding a global beauty contest to select himself a virgin bride) and develops into one of the most challenging, shocking and provocative films of recent years. Especially in its final 45 minutes, the movie presents almost pure experience. Makavejev shows us a commune where the members collectively immerse themselves in the fundamental processes of the body: eating, drinking, suckling, sex, vomiting, urinating, defecating, touching, screaming, hitting, caressing. Read full review at <a href='https://www.rogerebert.com/reviews/sweet-movie-1975'>https://www.rogerebert.com/reviews/sweet-movie-1975</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment }
            };

            var pinkflamingos = new Movie
            {
                MovieID = 0005,
                Title = "Pink Flamingos",
                Director = "John Waters",
                LeadAct = "Harris Glenn Milstead aka Divine",
                ReleaseDate = DateTime.Parse("1972-3-17"),
                Genre = GenreType.Comedy,
                WhereToWatch = "https://www.amazon.com/",
                Rating = RatingType.NC17,
                Review = "The plot involves a rivalry between two competing factions for the title of Filthiest People Alive. In one corner: A transvestite named Divine (who dresses like a combination of showgirl, dominatrix and Bozo); her mentally-ill mother (sits in a crib eating eggs and making messes); her son (likes to involve chickens in his sex life with strange women); and her lover (likes to watch son with strange women and chickens). In the other corner: Mr. and Mrs. Marble, who kidnap hippies, chain them in a dungeon, and force their butler to impregnate them so that after they die in childbirth their babies can be sold to lesbian couples. You can find the full review at <a href='https://www.rogerebert.com/reviews/pink-flamingos-1997'>https://www.rogerebert.com/reviews/pink-flamingos-1997</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment }
            };

            var frankenhooker = new Movie
            {
                MovieID = 0006,
                Title = "Frankenhooker",
                Director = "Frank Henenlotter",
                LeadAct = "James Lorinz",
                ReleaseDate = DateTime.Parse("1990-6-1"),
                Genre = GenreType.Comedy,
                WhereToWatch = "https://www.amazon.com/",
                Rating = RatingType.R,
                Review = "Medical school reject, Jeffrey Franken, conducts amateur medical experiments in his part-time. When his fiancé Elizabeth dies in a freak self-driving lawnmower accident, he becomes obsessed with resurrecting her. He succeeds, but she’s no longer the Elizabeth he knows, she’s become Frankenhooker! Read the full review at <a href='https://90sreviewer.com/frankenhooker-review/'>https://90sreviewer.com/frankenhooker-review/</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment }
            };

            var rhps = new Movie
            {
                MovieID = 0007,
                Title = "The Rocky Horror Picture Show",
                Director = "Jim Sharman",
                LeadAct = "Tim Curry",
                ReleaseDate = DateTime.Parse("1975-9-26"),
                Genre = GenreType.SciFi,
                WhereToWatch = "https://www.hulu.com/",
                Rating = RatingType.R,
                Review = "\"The Rocky Horror Picture Show\" would be more fun, I suspect, if it weren't a picture show. It belongs on a stage, with the performers and audience joining in a collective send-up. It's been running for something like three years in a former movie theater on King's Rd. in London - and it's found the right home here at the Three Penny on Lincoln. Trouble is, it should have opened there as a play. That's a rather unfair way to approach it as a movie, but then \"Rocky Horror\" remains very much a filmed play. The choreography, the compositions and even the attitudes of the cast imply a stage ambiance. And it invites the kind of laughter and audience participation that makes sense only if the performers are there on the stage, creating mutual karma. Read full review at <a href='https://www.rogerebert.com/reviews/the-rocky-horror-picture-show-1976'>https://www.rogerebert.com/reviews/the-rocky-horror-picture-show-1976</a>",
                Production = FoxStudios,
                Producers = new List<Producer> { FoxEntertainment }
            };

            var movies = new Movie[]
            {
                ghostbusters,
                ghostbusters2,
                hellraiser,
                sweetmovie,
                pinkflamingos,
                frankenhooker,
                rhps
            };

            context.AddRange(movies);

            var moviecasts = new MovieCast[]
            {
                new MovieCast
                    {
                        LeadActID = 1,
                        MovieID = 0001,
                        Rank = Rank.A
                    },
                
                new MovieCast
                    {
                        LeadActID = 1,
                        MovieID = 0002,
                        Rank = Rank.B
                    },
                
                new MovieCast
                    {
                        LeadActID = 2,
                        MovieID = 0003,
                        Rank = Rank.B
                    },
                
                new MovieCast
                    {
                        LeadActID = 3,
                        MovieID = 0004,
                        Rank = Rank.B
                    },
                
                new MovieCast
                    {
                        LeadActID = 4,
                        MovieID = 0005,
                        Rank = Rank.C
                    },
                
                new MovieCast
                    {
                        LeadActID = 5,
                        MovieID = 0006,
                        Rank = Rank.C
                    },
                
                new MovieCast
                    {
                        LeadActID = 6,
                        MovieID = 0007,
                        Rank = Rank.A
                    }
            };

            context.MovieCasts.AddRange(moviecasts);
            context.SaveChanges();

            var moviedirectors = new MovieDirector[]
            {

                 new MovieDirector
                    {
                        DirectorID = 1,
                        MovieID = 0001,
                        Rank2 = Rank2.A
                    },

                 new MovieDirector
                    {
                        DirectorID = 1,
                        MovieID = 0002,
                        Rank2 = Rank2.B
                    },

                new MovieDirector
                    {
                        DirectorID = 2,
                        MovieID = 0003,
                        Rank2 = Rank2.B
                    },

                new MovieDirector
                    {
                        DirectorID = 3,
                        MovieID = 0004,
                        Rank2 = Rank2.B
                    },
                
                new MovieDirector
                    {
                        DirectorID = 4,
                        MovieID = 0005,
                        Rank2 = Rank2.C
                    },
                
                new MovieDirector
                    {
                        DirectorID = 5,
                        MovieID = 0006,
                        Rank2 = Rank2.C
                    },
                
                new MovieDirector
                    {
                        DirectorID = 6,
                        MovieID = 0007,
                        Rank2 = Rank2.A
                    }
            };

            context.MovieDirectors.AddRange(moviedirectors);
            context.SaveChanges();
        }
    }
}
