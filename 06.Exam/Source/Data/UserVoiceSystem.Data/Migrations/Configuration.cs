namespace UserVoiceSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using UserVoiceSystem.Common;

    public sealed class Configuration : DbMigrationsConfiguration<UserVoiceSystemDbContext>
    {
        private const string EmailSuffix = "@site.com";

        private const string AdministratorEmail = "admin@admin.com";
        private const string AdministratorPassword = AdministratorEmail;

        private const string UserPassword = "user1";
        private const string UserEmail = UserPassword + EmailSuffix;

        private Random random = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(UserVoiceSystemDbContext context)
        {
            this.SeedUsers(context);
            this.SeedIdeas(context);
        }

        private void SeedIdeas(UserVoiceSystemDbContext context)
        {
            if (context.Ideas.Any())
            {
                return;
            }

            var firstIdea = new Idea { Title = "XNA 5", Description = "Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!", AuthorIpAddress = this.GetRandomIpAddress() };
            var secondIdea = new Idea { Title = "Allow .NET games on Xbox One", Description = "Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One. Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin. As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components) Please make .NET a compelling game development alternative on Xbox One!", AuthorIpAddress = this.GetRandomIpAddress() };
            var thirdIdea = new Idea { Title = "Support web.config style Transforms on any file in any project type", Description = "Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other \"config\" files.Also, this functionality is needed in other project types - most notably SharePoint 2010 projects.", AuthorIpAddress = this.GetRandomIpAddress() };
            var fourthIdea = new Idea { Title = "Bring back Macros", Description = "I am amazed you've decided to remove Macros from Visual Studio. Not only are they useful for general programming, but they're a great way to be introduced to the Visual Studio APIs. If you are unwilling to put in the development time towards them, please release the source code and let the community maintain it as an extension.", AuthorIpAddress = this.GetRandomIpAddress() };
            var fifthIdea = new Idea { Title = "Open source Silverlight", Description = "Blog post at http://davidburela.wordpress.com/2013/11/22/is-it-time-to-open-source-silverlight/ For all intents and purposes Microsoft now views Silverlight as “Done”. While it is no longer in active development it is still being “supported” through to 2021(source). However there is still a section of the.Net community that would like to see further development done on the Silverlight framework.A quick look at some common request lists brings up the following stats: *5,720 + votes to release Silverlight 6 https://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/3556619-silverlight-6 *Feature requests for Silverlight http://dotnet.uservoice.com/forums/4325-silverlight-feature-suggestions *Microsoft connect list of active Silverlight feature requests: http://connect.microsoft.com/VisualStudio/SearchResults.aspx?KeywordSearchIn=2&SearchQuery=%22silverlight%22&FeedbackType=2&Status=1&Scope=0&SortOrder=10&TabView=1  Rather than letting Silverlight decay in a locked up source control in the Microsoft vaults, I call on them to instead release it into the hands of the community to see what they can build with it.Microsoft may no longer have a long term vision for it, but the community itself may find ways to extend it in ways Microsoft didn’t envision. Earlier this year Microsoft open sourced RIA Services on Outer Curve http://www.outercurve.org/Galleries/ASPNETOpenSourceGallery/OpenRIAServices, it would be great to see this extended to the entire Silverlight framework.", AuthorIpAddress = this.GetRandomIpAddress() };
            var sixthIdea = new Idea { Title = "Native DirectX 11 support for WPF", Description = "in 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF.Please, make nativa support for DX 11 in WOF by default and update D3DImage class to have possibility to work with nativa C++ DX 11 engine and make render directly to WPF control(controls) without pain with C++ dll.", AuthorIpAddress = this.GetRandomIpAddress() };
            var seventhIdea = new Idea { Title = "Make WPF open-source and accept pull-requests from the community", Description = "Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community.", AuthorIpAddress = this.GetRandomIpAddress() };
            var eighthIdea = new Idea { Title = "Fix 260 character file name length limitation", Description = "Same description as here: http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation", AuthorIpAddress = this.GetRandomIpAddress() };
            var ninthIdea = new Idea { Title = "Support for ES6 modules", Description = "Add support for the new JavaScript ES6 module syntax, including module definition and imports.", AuthorIpAddress = this.GetRandomIpAddress() };
            var tenthIdea = new Idea { Title = "Create a \"remove all remnants of Visual Studio from your system\" program.", Description = "I'm writing this on behalf of the thousands of other Visual Studio users out there who have had nightmares trying to uninstall previous versions of VS. Thus cumulatively losing hundreds of thousands of productive work hours. During this year, I had installed the following programs / components on my system:  *Visual Studio 2012 Express for Desktop * Visual Studio 2012 Express for Web * Team Foundation Server Express * SQL Server Express * SQL Server Data Tools * LightSwitch 2011 trial(which created a VS 2010 installation) * Visual Studio 2010 Tools for SQL Server Compact 3.5 SP2 * Entity Framework Designer for Visual Studio 2012 * Visual Studio Tools for Applications * Visual Studio Tools for Office * F# Tools for Visual Studio Express 2012 for Web Two weeks ago I discovered that third - party controls can't be added to the Express versions of VS. I'm disabled and live on a fixed income, so spending $500 for the Professional version, in order to continue my hobby programming with a third-party control, was a tough decision. But I bought it. When it arrived, I figured it would take an hour or two to remove the above programs and then I could install the Pro version. I wanted to have a clean file system and Registry for the new install of VS Pro. It's now SIX DAYS later, and my spending 12-14 hours a day working on this alone. Removing these programs was the biggest nightmare I have ever faced with Microsoft products in my 30 years of being a Microsoft customer. Each one of these products automatically installed 5, 10 or more additional components, along with many thousands of files and individual Registry entries. It took me four days alone, just to successfully remove the LightSwitch 2011 trial, and the entire VS 2010 product it installed.Restoring a 600 GB disk drive(5 hours) from backup after every removal attempt failed miserably.I finally gave up, spent 6 hours downloading the entire VS 2010 ISO and installed it. Only then, was I able to successfully uninstall LightSwitch 2011 and VS 2010. As for the remaining products listed above, the uninstall programs do NOT UNinstall everything that they automatically INstall. Every single, automatically INstalled component, had to be removed manually, one at a time.Along with manually creating a System Restore point before each removal attempt, in case it failed. In total, I spent 12 hours uninstalling the remaining products. I have a Registry search program where I can enter a search string and it will list ALL occurrences it finds in the Registry. I checked \"visual studio\", \"visualstudio\", \"vbexpress\", \"vcexpress\", \"SQL Server\", etc.I never finished searching for all the possible Visual Studio and SQL Server strings because the results being returned were eye - popping.Each search was returning 1, 000, 3, 000, even 7, 000 individual Registry entries that had NOT been removed by the individual uninstall processes.This is TENS of THOUSANDS of never to be used again Registry entries that these programs simply left behind.The size of my Registry file is now a stunning 691 MB! All of this frustration and wasted time is completely avoidable!And my case is not \"isolated\".There are hundreds of thousands of hits on Google regarding this problem, that point to Microsoft forums, MS Blog sites, and many independent Windows developer support forums on the web. Microsoft really should provide an uninstall program that actually works, by UNinstalling everything it INstalls-- for each product it sells-- including Visual Studio.The downloadable(from Microsoft) uninstall program for VS 2010 does not work correctly and does not remove everything that VS 2010 installs. When a program installs multiple individual components, tens of thousands of files and Registry entries, it SHOULD have an uninstaller that removes ALL of this, automatically, just like the install program.The OS and Registry keep track of dependencies and you folks know what the removal order should be for all of these products.So the team that creates the INstall program for each product, should also create the UNinstall program.And, the product should NOT ship until this program works correctly and fully. You have ONE install program for each version of Visual Studio, that asks the user what they want to install and then does it ALL automatically.You should also have ONE uninstall program that does the same thing in reverse... * Collect info on all the VS - related products and components currently installed * Ask the user what they want to remove * Determine if their selections make sense * Check for dependencies by using your knowledge and experience, along with the computer's stored information, and warn the user as needed  * Decide on the removal order *Then do it ALL automatically-- removing ALL files and ALL Registry entries When you release a new product version, ADD the new version and additional decision logic to this existing program, do NOT create a new uninstall program.This way, the user can also remove previous version products, components, etc.ONE uninstall program* should be* able to uninstall every version of Visual Studio released in the past 10 years, along with every single component that was available with it, AND all of the associated files and Registry entries. Please don't tell us why it CAN'T be done.Rather, figure out a way to do it, and then make it happen, just like every other software company out there has already done for their products. Even FREEware providers have better uninstall processes than Microsoft.This is a sad state for Microsoft and it should be rectified SOON. Thank you.", AuthorIpAddress = this.GetRandomIpAddress() };

            firstIdea.Comments = this.GetComments(10);
            secondIdea.Comments = this.GetComments(10);
            thirdIdea.Comments = this.GetComments(10);
            fourthIdea.Comments = this.GetComments(10);
            fifthIdea.Comments = this.GetComments(10);
            sixthIdea.Comments = this.GetComments(10);
            seventhIdea.Comments = this.GetComments(10);
            eighthIdea.Comments = this.GetComments(10);
            ninthIdea.Comments = this.GetComments(10);
            tenthIdea.Comments = this.GetComments(10);

            firstIdea.Votes = this.GetVotes(100);
            secondIdea.Votes = this.GetVotes(100);
            thirdIdea.Votes = this.GetVotes(100);
            fourthIdea.Votes = this.GetVotes(100);
            fifthIdea.Votes = this.GetVotes(100);
            sixthIdea.Votes = this.GetVotes(100);
            seventhIdea.Votes = this.GetVotes(100);
            eighthIdea.Votes = this.GetVotes(100);
            ninthIdea.Votes = this.GetVotes(100);
            tenthIdea.Votes = this.GetVotes(100);

            context.Ideas.Add(firstIdea);
            context.Ideas.Add(secondIdea);
            context.Ideas.Add(thirdIdea);
            context.Ideas.Add(fourthIdea);
            context.Ideas.Add(fifthIdea);
            context.Ideas.Add(sixthIdea);
            context.Ideas.Add(seventhIdea);
            context.Ideas.Add(eighthIdea);
            context.Ideas.Add(ninthIdea);
            context.Ideas.Add(tenthIdea);

            context.SaveChanges();
        }

        private ICollection<Vote> GetVotes(int count)
        {
            var result = new List<Vote>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Vote()
                {
                    Value = (short)this.random.Next(GlobalConstants.MinVoteValue, GlobalConstants.MaxVoteValue + 1),
                    VoterIpAddress = this.GetRandomIpAddress()
                });
            }

            return result;
        }

        private ICollection<Comment> GetComments(int count)
        {
            var result = new List<Comment>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Comment()
                {
                    Content = this.GetRandomAlphaNumericString(200),
                    AuthorIpAddress = this.GetRandomIpAddress(),
                    AuthorEmail = string.Concat(this.GetRandomAlphaString(5), EmailSuffix)
                });
            }

            return result;
        }

        private void SeedUsers(UserVoiceSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                userManager.UserValidator = new UserValidator<User>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                // Create admin role
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var admin = new User()
                {
                    UserName = AdministratorEmail,
                    Email = AdministratorEmail,
                    IpAddress = this.GetRandomIpAddress()
                };

                userManager.Create(admin, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);

                // Create sample user
                var user = new User()
                {
                    UserName = UserEmail,
                    Email = UserEmail,
                    IpAddress = this.GetRandomIpAddress()
                };

                userManager.Create(user, UserPassword);
            }

            context.SaveChanges();
        }

        private string GetRandomIpAddress()
        {
            const string IpAddressNumbersDivider = ".";
            string result = string.Join(IpAddressNumbersDivider, Enumerable.Repeat(this.random.Next(0, 256), 4));
            return result;
        }

        private string GetRandomAlphaNumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklemnopqrstuvwxyz0123456789";
            return new string(
                Enumerable.Repeat(chars, length)
              .Select(s => s[this.random.Next(s.Length)])
              .ToArray());
        }

        private string GetRandomAlphaString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklemnopqrstuvwxyz";
            return new string(
                Enumerable.Repeat(chars, length)
              .Select(s => s[this.random.Next(s.Length)])
              .ToArray());
        }
    }
}
