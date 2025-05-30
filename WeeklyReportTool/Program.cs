using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{

    static void Main(string[] args)
    {
        // Chromeドライバーの設定
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        var registInfo = new RegistInfo();

        if (string.IsNullOrEmpty(registInfo.IfUrl))
        {
            Console.WriteLine("IFSNSのURLを入力してください");
            return;
        }

        if (string.IsNullOrEmpty(registInfo.Email) || string.IsNullOrEmpty(registInfo.Passward))
            {
                Console.WriteLine("メールアドレス、パスワードを入力してください。");
                return;
            }

        IWebDriver driver = new ChromeDriver(options);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            // 指定されたURLにアクセス
            driver.Navigate().GoToUrl(registInfo.IfUrl);

            // メールアドレス入力
            // 別の書き方
            // var emailInput = driver.FindElement(By.Id("authMailAddress_mail_address"));
            var emailInput = wait.Until(d => d.FindElement(By.Id("authMailAddress_mail_address")));
            emailInput.SendKeys(registInfo.Email);
            Console.WriteLine("メールアドレス入力完了");

            // パスワード入力
            var passwordInput = wait.Until(d => d.FindElement(By.Id("authMailAddress_password")));
            passwordInput.SendKeys(registInfo.Passward);
            Console.WriteLine("パスワード入力完了");

            // ログインボタンクリック
            var loginButton = wait.Until(d => d.FindElement(By.CssSelector("input.input_submit[type='submit']")));
            loginButton.Click();
            Console.WriteLine("ログインボタンクリック完了");

            // ログイン処理の完了を待機
            Thread.Sleep(1500);

            // 週報ボタンの待機と取得
            var weeklyReportButton = wait.Until(d => d.FindElement(By.Id("default__weeklyreport_list")));
            if (weeklyReportButton == null)
            {
                Console.WriteLine("週報ボタンが見つかりませんでした。\nログインに失敗しているかもしれません。\nメールアドレスまたはパスワードを確認してください。");
                Console.ReadKey();
                return;
            }
            weeklyReportButton.Click();
            Console.WriteLine("週報ボタンクリック完了");

            // 週報入力ボタンの待機と取得
            var weeklyReportInput = wait.Until(d => d.FindElement(By.Id("weeklyreport__weeklyreport_input_list")));
            weeklyReportInput.Click();
            Console.WriteLine("週報入力ボタンクリック完了");

            // テーブル内の最初のリンクを探してクリック
            var firstLinkInTable = wait.Until(d => d.FindElement(By.XPath("//table//a[1]")));
            firstLinkInTable.Click();
            Console.WriteLine("週報リンククリック完了");

            // 週報入力欄が開くのを待つ
            Thread.Sleep(1500);

            // 週報自由記入欄の待機と取得
            var weeklyReportWorkContents = wait.Until(d => d.FindElement(By.Id("weekly_report_work_contents")));
            if (weeklyReportWorkContents == null)
            {
                Console.WriteLine("作業内容が見つかりません");
                Console.ReadLine();
                return;
            }
            weeklyReportWorkContents.SendKeys(registInfo.WeeklyReportWorkContents);
            Console.WriteLine("作業内容入力完了");

            // 週報自由記入欄の待機と取得
            var weeklyReportFreeText = wait.Until(d => d.FindElement(By.Id("weekly_report_free_text")));
            if (weeklyReportFreeText == null)
            {
                Console.WriteLine("備考欄が見つかりません");
                Console.ReadLine();
                return;
            }
            weeklyReportFreeText.SendKeys(registInfo.WeeklyReportFreeText);
            Console.WriteLine("週報自由記入欄入力完了");

            var saveButton = wait.Until(d => d.FindElement(By.XPath("//input[@class='input_submit' and @name='save']")));
            saveButton.Click();
            Console.WriteLine("保存ボタンクリック完了");

            // アラートダイアログの待機と処理
            Thread.Sleep(1000); 
            var alert = wait.Until(d => d.SwitchTo().Alert());
            Console.WriteLine("アラートダイアログを検出しました");
            alert.Accept();
            Console.WriteLine("アラートダイアログで「はい」を選択しました");

            Console.WriteLine("ログインが完了しました。ブラウザを閉じるには何かキーを押してください...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"エラーが発生しました: {ex.Message}");
            Console.WriteLine("ブラウザを閉じるには何かキーを押してください...");
            Console.ReadKey();
        }
        finally
        {
            driver.Quit();
        }
    }
}
