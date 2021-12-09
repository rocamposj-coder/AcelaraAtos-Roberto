namespace ApiRest.DAO_DAPPER
{
    public static class FabricaDAO
    {
        public static  IDAO_Aluno FabricarDAOAluno()
        {
            IDAO_Aluno idaoAluno;

            if(Configuracao.flagTesteUnitarioDAO) //Somente quando a configuração da flag é true 
                idaoAluno = new DAO_AlunoMock();
            else
                idaoAluno = new DAO_Aluno();

            return idaoAluno;
        }
    }
}
