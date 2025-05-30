class RegistInfo
{
    /// <summary>
    /// IFのURL
    /// </summary>
    public string IfUrl
    {
        get
        {
            return this.IF_URL;
        }
    }

    /// <summary>
    /// メールアドレス
    /// </summary>
    public string Email
    {
        get {
            return this.EMAIL;
        }
    }

    /// <summary>
    /// パスワード
    /// </summary>
    public string Passward
    {
        get {
            return this.PASSWARD;
        }
    }

    /// <summary>
    /// 自分の名前
    /// </summary>
    public string YourName
    {
        get {
            return this.YOUR_NAME;
        }
    }
    
    public string WeeklyReportWorkContents
    {
        get
        {
            return this.WEEKLY_REPORT_WORK_CONTENTS;
        }
    }

    /// <summary>
    /// 週報の自由記入欄
    /// </summary>
    public string WeeklyReportFreeText
    {
        get
        {
            return this.WEEKLY_REPORT_FREE_TEXT;
        }
    }

    /// <summary>
    /// IFSNSのURL
    /// IFSNSのURLを入れてください
    /// </summary>
    private readonly string IF_URL = "";

    /// <summary>
    /// メールアドレス
    /// 自分のメールアドレスに書き換えてください
    /// </summary>
    private readonly string EMAIL = "";

    /// <summary>
    /// パスワード
    /// 自分のパスワードに書き換えてください
    /// </summary>
    private readonly string PASSWARD = "";
    
    /// <summary>
    /// 自分の名前
    /// </summary>
    private readonly string YOUR_NAME = "";

    /// <summary>
    /// 作業内容
    /// </summary>
    private readonly string WEEKLY_REPORT_WORK_CONTENTS = "";

    /// <summary>
    /// 週報の自由記入欄
    /// </summary>
    private readonly string WEEKLY_REPORT_FREE_TEXT =
    @"";
}
