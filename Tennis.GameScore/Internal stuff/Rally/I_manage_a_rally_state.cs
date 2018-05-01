namespace Tennis.GameScore
{
    internal interface I_manage_a_rally_state
    {
        I_manage_a_rally_state ServeOrReturnCorrectly();
        I_manage_a_rally_state ServeOrReturnFaulty();

        RallyBetween RallyBetween { get; }
    }
}
    