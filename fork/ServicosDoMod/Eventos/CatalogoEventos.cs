namespace ZZZZitalo.TS3Mods.NarradorPorEventos.ServicosDoMod
{
    internal class CatalogoEventos
    {
        internal sealed class EventoNovoBebe : EventoCompleto
        {
            public override string EventoId => "kNewBaby";
            public override string LegendaPtBr => "Teve um bebê";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoGemeos : EventoCompleto
        {
            public override string EventoId => "kNewBabyTwins";
            public override string LegendaPtBr => "Teve gêmeos";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTripletos : EventoCompleto
        {
            public override string EventoId => "kNewBabyTriplets";
            public override string LegendaPtBr => "Teve trigêmeos";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoNovoBebeUnico : EventoCompleto
        {
            public override string EventoId => "kNewBabySingle";
            public override string LegendaPtBr => "Teve um bebê";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoBebeFantasma : EventoCompleto
        {
            public override string EventoId => "kHadGhostBaby";
            public override string LegendaPtBr => "Teve um bebê fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoEngravidou : EventoSimEFamilia
        {
            public override string EventoId => "kGotPregnant";
            public override string LegendaPtBr => "Engravidou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAdotouCrianca : EventoCompleto
        {
            public override string EventoId => "kAdoptedChild";
            public override string LegendaPtBr => "Adotou uma criança";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoCriancaLevadaTutelar : EventoCompleto
        {
            public override string EventoId => "kChildTakenBySocialWorker";
            public override string LegendaPtBr => "Criança levada pelo conselho tutelar";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoCriancaNasceuOuAdotada : EventoCompleto
        {
            public override string EventoId => "kChildBornOrAdopted";
            public override string LegendaPtBr => "Nasceu ou foi adotada uma criança";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFamiliaMudouParaCidade : EventoCompleto
        {
            public override string EventoId => "kFamilyMovedToTown";
            public override string LegendaPtBr => "Família mudou para a cidade";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFamiliaMudouDaCidade : EventoCompleto
        {
            public override string EventoId => "kFamilyMovedAwayFromTown";
            public override string LegendaPtBr => "Família mudou da cidade";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFamiliaMudouParaCasaNova : EventoCompleto
        {
            public override string EventoId => "kFamilyMovedInToNewHouse";
            public override string LegendaPtBr => "Família mudou para uma nova casa";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFamiliaSaiuDeCasa : EventoCompleto
        {
            public override string EventoId => "kFamilyMovedOutOfHouse";
            public override string LegendaPtBr => "Família saiu de uma casa";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoMudouJuntos : EventoSimEFamilia
        {
            public override string EventoId => "kMovedInTogether";
            public override string LegendaPtBr => "Mudaram juntos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSimEnvelheceuBem : EventoSimEFamilia
        {
            public override string EventoId => "kSimAgedUpWell";
            public override string LegendaPtBr => "Envelheceu bem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimMorreu : EventoCompleto
        {
            public override string EventoId => "kSimDied";
            public override string LegendaPtBr => "Sim morreu";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSimSelecionavelMorreu : EventoCompleto
        {
            public override string EventoId => "kSelectableSimDied";
            public override string LegendaPtBr => "Sim jogável morreu";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoViuSimMorrer : EventoSimEFamilia
        {
            public override string EventoId => "kSawSimDie";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Viu um Sim morrer";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRessuscitouSim : EventoCompleto
        {
            public override string EventoId => "kResurrectedSim";
            public override string LegendaPtBr => "Ressuscitou um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoQuaseMorreu : EventoSimEFamilia
        {
            public override string EventoId => "kAlmostDied";
            public override string LegendaPtBr => "Quase morreu";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimSelecionado : EventoRuido
        {
            public override string EventoId => "kEventSimSelected";
            public override string LegendaPtBr => "Foi selecionado";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 2 – RELACIONAMENTOS, AMOR E ROMANCE
        // =========================================================

        internal sealed class EventoRelacionamentoMudou : EventoSimEFamilia
        {
            public override string EventoId => "kRelationshipChanged";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Relacionamento mudou";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFlertando : EventoApenasSim
        {
            public override string EventoId => "kFlirting";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Flertou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoBrigando : EventoSimEFamilia
        {
            public override string EventoId => "kFighting";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Brigou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoInsultando : EventoSimEFamilia
        {
            public override string EventoId => "kInsulting";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Insultou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrigaViolenta : EventoCompleto
        {
            public override string EventoId => "kRowdyFight";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Briga violenta";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoComeçouNamorar : EventoCompleto
        {
            public override string EventoId => "kStartedDating";
            public override string LegendaPtBr => "Começou a namorar";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoNoivou : EventoCompleto
        {
            public override string EventoId => "kEngaged";
            public override string LegendaPtBr => "Ficou noivo(a)";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoCasamento : EventoCompleto
        {
            public override string EventoId => "kMarriage";
            public override string LegendaPtBr => "Casou";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSeparou : EventoCompleto
        {
            public override string EventoId => "kSplitUp";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Se separou";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTornaramSeInimigos : EventoCompleto
        {
            public override string EventoId => "kBecameEnemies";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Tornaram-se inimigos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPegouTraicao : EventoCompleto
        {
            public override string EventoId => "kCaughtCheatingOnPartner";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Flagrou traição do parceiro";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPrimeiroBejo : EventoApenasSim
        {
            public override string EventoId => "kHadFirstKiss";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Primeiro beijo";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPrimeiroWoohoo : EventoSimEFamilia
        {
            public override string EventoId => "kHadFirstWoohoo";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Primeiro woohoo";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWoohoo : EventoApenasSim
        {
            public override string EventoId => "kWooHooed";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Woohoo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTermino : EventoCompleto
        {
            public override string EventoId => "kBreakUp";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Término de relacionamento";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAniversarioCasamento : EventoSimEFamilia
        {
            public override string EventoId => "kWeddingAnniversary";
            public override string LegendaPtBr => "Aniversário de casamento";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCasamentoConturbado : EventoSimEFamilia
        {
            public override string EventoId => "kMarriageOnTheRocks";
            public override string LegendaPtBr => "Casamento conturbado";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 3 – CARREIRA, TRABALHO E DINHEIRO
        // =========================================================

        internal sealed class EventoPromocaoCarreira : EventoCompleto
        {
            public override string EventoId => "kEventCareerPromotion";
            public override string LegendaPtBr => "Promoção na carreira";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPromocaoOuRebaixamentoCarreira : EventoSimEFamilia
        {
            public override string EventoId => "kEventCareerPromoteOrDemote";
            public override string LegendaPtBr => "Mudança importante na carreira";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoContratado : EventoSimEFamilia
        {
            public override string EventoId => "kEventCareerHired";
            public override string LegendaPtBr => "Contratado";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDemitido : EventoCompleto
        {
            public override string EventoId => "kCareerFired";
            public override string LegendaPtBr => "Demitido";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoNovaCarreira : EventoSimEFamilia
        {
            public override string EventoId => "kCareerNewJob";
            public override string LegendaPtBr => "Começou um novo trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRebaixado : EventoSimEFamilia
        {
            public override string EventoId => "kCareerDemotion";
            public override string LegendaPtBr => "Rebaixado na carreira";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAumentoSalario : EventoSimEFamilia
        {
            public override string EventoId => "kCareerGotRaise";
            public override string LegendaPtBr => "Aumento de salário";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPediuDemissao : EventoSimEFamilia
        {
            public override string EventoId => "kCareerQuitJob";
            public override string LegendaPtBr => "Pediu demissão";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTransferiuCarreira : EventoSimEFamilia
        {
            public override string EventoId => "kCareerTransferJob";
            public override string LegendaPtBr => "Transferiu de emprego";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAposentou : EventoCompleto
        {
            public override string EventoId => "kCareerRetired";
            public override string LegendaPtBr => "Aposentou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFundosBaixos : EventoSimEFamilia
        {
            public override string EventoId => "kLowFamilyFunds";
            public override string LegendaPtBr => "Fundos familiares baixos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoFundosAltos : EventoSimEFamilia
        {
            public override string EventoId => "kHighFamilyFunds";
            public override string LegendaPtBr => "Fundos familiares altos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoVendeuRoteiro : EventoCompleto
        {
            public override string EventoId => "kSoldScreenplay";
            public override string LegendaPtBr => "Vendeu roteiro";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoComprarPropriedade : EventoSimEFamilia
        {
            public override string EventoId => "kBoughtProperty";
            public override string LegendaPtBr => "Comprou propriedade";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFaltouTrabalho : EventoApenasSim
        {
            public override string EventoId => "kSkippedWork";
            public override string LegendaPtBr => "Faltou ao trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoNegociouContrato : EventoSimEFamilia
        {
            public override string EventoId => "kNegotiateContract";
            public override string LegendaPtBr => "Negociou contrato";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // CATEGORIA 4 – HABILIDADES, TUTORIA E EDUCAÇÃO
        // =========================================================

        internal sealed class EventoSubiuNivelHabilidade : EventoApenasSim
        {
            public override string EventoId => "kSkillLevelUp";
            public override string LegendaPtBr => "Subiu de nível de habilidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoAprendeuHabilidade : EventoApenasSim
        {
            public override string EventoId => "kSkillLearnedSkill";
            public override string LegendaPtBr => "Aprendeu uma nova habilidade";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoFormou : EventoCompleto
        {
            public override string EventoId => "kGraduated";
            public override string LegendaPtBr => "Formou-se";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAdolescenteAprendeuDirigir : EventoSimEFamilia
        {
            public override string EventoId => "kTaughtTeenToDrive";
            public override string LegendaPtBr => "Adolescente aprendeu a dirigir";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMandouParaInternato : EventoSimEFamilia
        {
            public override string EventoId => "kSentSimToBoardingSchool";
            public override string LegendaPtBr => "Mandou para internato";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoMatriculadoUniversidade : EventoSimEFamilia
        {
            public override string EventoId => "kEnrolledInUniversity";
            public override string LegendaPtBr => "Matriculou-se na universidade";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFezProvaUniversitaria : EventoApenasSim
        {
            public override string EventoId => "kTakeUniversityTest";
            public override string LegendaPtBr => "Fez prova universitária";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoTerminouLicaoDeCasa : EventoApenasSim
        {
            public override string EventoId => "kFinishedHomework";
            public override string LegendaPtBr => "Terminou a lição de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 5 – ALIMENTAÇÃO E BEBIDAS (apenas relevantes)
        // =========================================================

        internal sealed class EventoComeuRestaurante : EventoApenasSim
        {
            public override string EventoId => "kAteAtRestaurant";
            public override string LegendaPtBr => "Comeu no restaurante";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoComeuRestauranteComOutros : EventoSimEFamilia
        {
            public override string EventoId => "kAteAtRestaurantWithOthers";
            public override string LegendaPtBr => "Comeu no restaurante com outros";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoComeuRestauranteComSim : EventoSimEFamilia
        {
            public override string EventoId => "kAteAtRestaurantWithSim";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Comeu no restaurante com um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAprendeuReceita : EventoApenasSim
        {
            public override string EventoId => "kLearnedRecipe";
            public override string LegendaPtBr => "Aprendeu uma receita";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoComeuFrutoDaVida : EventoApenasSim
        {
            public override string EventoId => "kAteLifefruit";
            public override string LegendaPtBr => "Comeu o Fruto da Vida";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // CATEGORIA 6 – SAÚDE E BEM-ESTAR
        // =========================================================

        internal sealed class EventoAtingiuFisicMaximo : EventoSimEFamilia
        {
            public override string EventoId => "kAchievedMaximumFitness";
            public override string LegendaPtBr => "Atingiu condicionamento físico máximo";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVomitou : EventoApenasSim
        {
            public override string EventoId => "kVomited";
            public override string LegendaPtBr => "Vomitou";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoCombustaoEspontanea : EventoCompleto
        {
            public override string EventoId => "kSpontaneouslyCombusted";
            public override string LegendaPtBr => "Combustão espontânea";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoCongelou : EventoSimEFamilia
        {
            public override string EventoId => "kFrozeSolid";
            public override string LegendaPtBr => "Congelou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // CATEGORIA 7 – EVENTOS SOCIAIS E FESTAS
        // =========================================================

        internal sealed class EventoDeuFesta : EventoSimEFamilia
        {
            public override string EventoId => "kThrewParty";
            public override string LegendaPtBr => "Deu uma festa";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFestaIminenteCasa : EventoApenasMundo
        {
            public override string EventoId => "kHousePartySoon";
            public override string LegendaPtBr => "Uma festa em casa vai começar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFestaIminenteForaLote : EventoApenasMundo
        {
            public override string EventoId => "kOffLotPartySoon";
            public override string LegendaPtBr => "Uma festa fora do lote vai começar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFestaComecou : EventoSimEFamilia
        {
            public override string EventoId => "kPartyBegan";
            public override string LegendaPtBr => "A festa começou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFestaTerminou : EventoSimEFamilia
        {
            public override string EventoId => "kPartyOver";
            public override string LegendaPtBr => "A festa terminou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoConvidouParaFesta : EventoApenasSim
        {
            public override string EventoId => "kInvitedSimToParty";
            public override string LegendaPtBr => "Convidou um Sim para festa";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoConvidouColegaParaFesta : EventoApenasSim
        {
            public override string EventoId => "kInvitedCoworkerToParty";
            public override string LegendaPtBr => "Convidou colega para festa";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoFestaBeneficente : EventoCompleto
        {
            public override string EventoId => "kThrewFundraiser";
            public override string LegendaPtBr => "Organizou festa beneficente";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoArrecadouMuitoDinheiro : EventoCompleto
        {
            public override string EventoId => "kRaisedTonsOfMoney";
            public override string LegendaPtBr => "Arrecadou muito dinheiro";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFoiAoBalFormatura : EventoSimEFamilia
        {
            public override string EventoId => "kWentToProm";
            public override string LegendaPtBr => "Foi ao baile de formatura";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChamouParaEncontro : EventoApenasSim
        {
            public override string EventoId => "kAskedOnDate";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Chamou alguém para encontro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoComecouEncontro : EventoSimEFamilia
        {
            public override string EventoId => "kStartedDate";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Começou um encontro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTerminouEncontro : EventoSimEFamilia
        {
            public override string EventoId => "kFinishedDate";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Terminou um encontro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPrimeiroRomance : EventoSimEFamilia
        {
            public override string EventoId => "kHadFirstRomance";
            public override string LegendaPtBr => "Teve o primeiro romance";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAssistiuJogoEsportivo : EventoApenasSim
        {
            public override string EventoId => "kAttendedProSportsGame";
            public override string LegendaPtBr => "Assistiu a jogo esportivo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoVenceuJogoProfissional : EventoSimEFamilia
        {
            public override string EventoId => "kWonProSportsGame";
            public override string LegendaPtBr => "Venceu jogo profissional";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerdeuJogoProfissional : EventoSimEFamilia
        {
            public override string EventoId => "kLostProSportsGame";
            public override string LegendaPtBr => "Perdeu jogo profissional";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerdeuJogoPorFalta : EventoApenasSim
        {
            public override string EventoId => "kMissedProSportsGame";
            public override string LegendaPtBr => "Perdeu jogo profissional por falta";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoDescobriuIlhaInexplorada : EventoCompleto
        {
            public override string EventoId => "kDiscoveredUnchartedIsland";
            public override string LegendaPtBr => "Descobriu ilha inexplorada";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAdolescenFugiu : EventoSimEFamilia
        {
            public override string EventoId => "kSnuckOutAfterCurfew";
            public override string LegendaPtBr => "Adolescente fugiu após toque de recolher";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoHospedouResort : EventoApenasSim
        {
            public override string EventoId => "kStayedAtResort";
            public override string LegendaPtBr => "Hospedou-se no resort";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoDeuFestaBachelor : EventoSimEFamilia
        {
            public override string EventoId => "kThrewBachelorParty";
            public override string LegendaPtBr => "Deu festa de despedida de solteiro";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        // =========================================================
        // CATEGORIA 9 – MORTE, CRIME E DESASTRES
        // =========================================================

        internal sealed class EventoFoiRoubado : EventoSimEFamilia
        {
            public override string EventoId => "kWasRobbed";
            public override string LegendaPtBr => "Foi roubado";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoIncendioEmCasa : EventoCompleto
        {
            public override string EventoId => "kHadFireAtHome";
            public override string LegendaPtBr => "Incêndio em casa";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoEnvolvidoEmIncendio : EventoCompleto
        {
            public override string EventoId => "kWasInvolvedInAFire";
            public override string LegendaPtBr => "Se envolveu em um incêndio";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoRoubouObjeto : EventoSimEFamilia
        {
            public override string EventoId => "kStoleObject";
            public override string LegendaPtBr => "Roubou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPickchutouPredio : EventoCompleto
        {
            public override string EventoId => "kTaggedBuilding";
            public override string LegendaPtBr => "Pichou prédio";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFezTravessura : EventoApenasSim
        {
            public override string EventoId => "kPullPrank";
            public override string LegendaPtBr => "Fez travessura";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoLamentouMorte : EventoSimEFamilia
        {
            public override string EventoId => "kMournedSim";
            public override string LegendaPtBr => "Lamentou a morte de um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBaniuFantasma : EventoSimEFamilia
        {
            public override string EventoId => "kBanishedGhost";
            public override string LegendaPtBr => "Baniu um fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSalvouSimDosEscombros : EventoCompleto
        {
            public override string EventoId => "kSavedSimFromRubble";
            public override string LegendaPtBr => "Salvou um Sim dos escombros";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTerminouEscola : EventoSimEFamilia
        {
            public override string EventoId => "kFinishedSchool";
            public override string LegendaPtBr => "Terminou o período escolar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // CATEGORIA 11 – OCULTOS, MAGIA E SOBRENATURAL
        // =========================================================

        internal sealed class EventoTransformouSim : EventoCompleto
        {
            public override string EventoId => "kTurnedSim";
            public override string LegendaPtBr => "Transformou um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoVampiroBebeuDeSim : EventoCompleto
        {
            public override string EventoId => "kVampireDrankFromSim";
            public override string LegendaPtBr => "Vampiro bebeu de um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoLancouFeitico : EventoSimEFamilia
        {
            public override string EventoId => "kCastSpell";
            public override string LegendaPtBr => "Lançou feitiço";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVenceuDueloFeiticos : EventoCompleto
        {
            public override string EventoId => "kWonASpellcastingDuel";
            public override string LegendaPtBr => "Venceu duelo de feitiços";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoMorteAoLancarFeitico : EventoCompleto
        {
            public override string EventoId => "kDiedFromCastingSpell";
            public override string LegendaPtBr => "Morreu ao lançar feitiço";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTornouSeZumbi : EventoCompleto
        {
            public override string EventoId => "kBecameZombie";
            public override string LegendaPtBr => "Tornou-se zumbi";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTornouSeOculto : EventoSimEFamilia
        {
            public override string EventoId => "kBecameOccult";
            public override string LegendaPtBr => "Tornou-se um ser oculto";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPerdeuStatusOculto : EventoSimEFamilia
        {
            public override string EventoId => "kLostOccult";
            public override string LegendaPtBr => "Perdeu o status oculto";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFoiMordido : EventoSimEFamilia
        {
            public override string EventoId => "kBitten";
            public override string LegendaPtBr => "Foi mordido";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornioBencao : EventoCompleto
        {
            public override string EventoId => "kSimBlessedByUnicorn";
            public override string LegendaPtBr => "Abençoado por unicórnio";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoUnicornioMaldicao : EventoCompleto
        {
            public override string EventoId => "kSimCursedByUnicorn";
            public override string LegendaPtBr => "Amaldiçoado por unicórnio";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoLobishomemUivou : EventoCompleto
        {
            public override string EventoId => "kHowlAtMoon";
            public override string LegendaPtBr => "Uivou para a lua";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDesejoDeFortuna : EventoSimEFamilia
        {
            public override string EventoId => "kWishForFortune";
            public override string LegendaPtBr => "Fez desejo de fortuna";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDesejoDePazMundial : EventoCompleto
        {
            public override string EventoId => "kWishForWorldPeace";
            public override string LegendaPtBr => "Fez desejo de paz mundial";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDesejoMiseriaMundial : EventoCompleto
        {
            public override string EventoId => "kWishForWorldMisery";
            public override string LegendaPtBr => "Fez desejo de miséria mundial";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        // =========================================================
        // CATEGORIA 12 – PESCA, CAÇA, JARDINAGEM E COLETA
        // =========================================================

        internal sealed class EventoPescouPeixe : EventoApenasSim
        {
            public override string EventoId => "kCaughtFish";
            public override string LegendaPtBr => "Pescou peixe";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoPescouTipoPrimeira : EventoApenasSim
        {
            public override string EventoId => "kCaughtFishTypeForFirstTime";
            public override string LegendaPtBr => "Pescou tipo de peixe pela primeira vez";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoColheuProduto : EventoApenasSim
        {
            public override string EventoId => "kHarvestedHarvestable";
            public override string LegendaPtBr => "Colheu produto da planta";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoEncontrouGema : EventoApenasSim
        {
            public override string EventoId => "kCollectedGem";
            public override string LegendaPtBr => "Coletou gema";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 14 – VIAGENS, FÉRIAS E AVENTURAS
        // =========================================================

        internal sealed class EventoSaiuDeFerias : EventoSimEFamilia
        {
            public override string EventoId => "kLeftForVacation";
            public override string LegendaPtBr => "Saiu de férias";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVoltouDeFerias : EventoSimEFamilia
        {
            public override string EventoId => "kReturnedFromVacation";
            public override string LegendaPtBr => "Voltou de férias";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoCompletouTumba : EventoCompleto
        {
            public override string EventoId => "kSimCompletedTomb";
            public override string LegendaPtBr => "Completou tumba";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAbroBauTesouro : EventoApenasSim
        {
            public override string EventoId => "kOpenedTreasureChest";
            public override string LegendaPtBr => "Abriu baú de tesouro";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoViajarParaFuturo : EventoCompleto
        {
            public override string EventoId => "kTravelToFuture";
            public override string LegendaPtBr => "Viajou para o futuro";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoMundoFuturoMudou : EventoCompleto
        {
            public override string EventoId => "kFutureWorldChanged";
            public override string LegendaPtBr => "Mundo futuro mudou";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAtacadoPorUrso : EventoSimEFamilia
        {
            public override string EventoId => "kGotMauledByBear";
            public override string LegendaPtBr => "Atacado por urso";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        // =========================================================
        // CATEGORIA 15 – CELEBRIDADE E REPUTAÇÃO
        // =========================================================

        internal sealed class EventoGanhouNivelCelebridade : EventoCompleto
        {
            public override string EventoId => "kGainCelebrityLevel";
            public override string LegendaPtBr => "Ganhou nível de celebridade";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAcaoDesonrosa : EventoCompleto
        {
            public override string EventoId => "kSimCommittedDisgracefulAction";
            public override string LegendaPtBr => "Cometeu ação desonrosa";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoRomanceVirtoso : EventoCompleto
        {
            public override string EventoId => "kHighlyVisibleVirtuousRomance";
            public override string LegendaPtBr => "Romance virtuoso bem visível";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoMultiplosRomances : EventoCompleto
        {
            public override string EventoId => "kMultipleVisibleRomances";
            public override string LegendaPtBr => "Múltiplos romances visíveis";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        // =========================================================
        // CATEGORIA 17 – ESTAÇÕES, CLIMA E FERIADOS
        // =========================================================

        internal sealed class EventoClimaComecou : EventoCompleto
        {
            public override string EventoId => "kWeatherStarted";
            public override string LegendaPtBr => "Evento climático começou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoClimaParou : EventoApenasMundo
        {
            public override string EventoId => "kWeatherStopped";
            public override string LegendaPtBr => "Evento climático terminou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoEstacaoIniciou : EventoApenasMundo
        {
            public override string EventoId => "kSeasonStarted";
            public override string LegendaPtBr => "Uma nova estação começou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTransicaoEstacao : EventoCompleto
        {
            public override string EventoId => "kSeasonTransition";
            public override string LegendaPtBr => "Transição de estação";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAtingidoPorRaio : EventoCompleto
        {
            public override string EventoId => "kStruckByLightning";
            public override string LegendaPtBr => "Atingido por raio";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFestivalComecou : EventoCompleto
        {
            public override string EventoId => "kFestivalStarted";
            public override string LegendaPtBr => "Festival começou";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDocesTravessuras : EventoApenasSim
        {
            public override string EventoId => "kWentTrickOrTreating";
            public override string LegendaPtBr => "Foi pedir doces ou travessuras";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoFogosDeArtificio : EventoSimEFamilia
        {
            public override string EventoId => "kPerformFireworkExtravaganza";
            public override string LegendaPtBr => "Espetáculo de fogos de artifício";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // CATEGORIA 18 – ESPORTES, JOGOS E COMPETIÇÕES
        // =========================================================

        internal sealed class EventoVenceuJogo : EventoApenasSim
        {
            public override string EventoId => "kGameWon";
            public override string LegendaPtBr => "Venceu jogo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoPerdeuJogo : EventoApenasSim
        {
            public override string EventoId => "kGameLost";
            public override string LegendaPtBr => "Perdeu jogo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoVenceuCompetcaoJardinagem : EventoCompleto
        {
            public override string EventoId => "kWinGardeningCompetition";
            public override string LegendaPtBr => "Venceu competição de jardinagem";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoVenceuSimfest : EventoCompleto
        {
            public override string EventoId => "kWinSimFest";
            public override string LegendaPtBr => "Venceu o Simfest";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoVenceuCompetcaoCavalo : EventoCompleto
        {
            public override string EventoId => "kWinHorseCompetition";
            public override string LegendaPtBr => "Venceu competição equestre";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoVenceuTrivia : EventoSimEFamilia
        {
            public override string EventoId => "kWonTriviaChallenge";
            public override string LegendaPtBr => "Venceu desafio de trivia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // CATEGORIA 19 – FOFOCA, SEGREDOS E DESCOBERTAS
        // =========================================================

        internal sealed class EventoConheceuSim : EventoApenasSim
        {
            public override string EventoId => "kMetSim";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Conheceu um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoDescobriuGravidez : EventoSimEFamilia
        {
            public override string EventoId => "kFoundOutThatSimIsPregnant";
            public override string LegendaPtBr => "Descobriu que Sim está grávida";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDescobriuConspiracy : EventoCompleto
        {
            public override string EventoId => "kDiscoveredConspiracy";
            public override string LegendaPtBr => "Descobriu conspiração";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoEncontrouPoteDeOuro : EventoCompleto
        {
            public override string EventoId => "kFoundPotOfGold";
            public override string LegendaPtBr => "Encontrou pote de ouro";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDescobriuEstrela : EventoSimEFamilia
        {
            public override string EventoId => "kDiscoveredStar";
            public override string LegendaPtBr => "Descobriu uma estrela";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDoouParaCaridade : EventoApenasSim
        {
            public override string EventoId => "kDonatedToCharity";
            public override string LegendaPtBr => "Doou para caridade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoAprendeuTracoOutroSim : EventoApenasSim
        {
            public override string EventoId => "kLearnedTraitOfOtherSim";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Aprendeu traço de outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 21 – PROGRESSÃO E OPORTUNIDADES
        // =========================================================

        internal sealed class EventoOportunidadeConcluida : EventoSimEFamilia
        {
            public override string EventoId => "kOpportunityCompleted";
            public override string LegendaPtBr => "Oportunidade concluída";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCriseDeIdade : EventoSimEFamilia
        {
            public override string EventoId => "kStartMidlifeCrisis";
            public override string LegendaPtBr => "Entrou em crise de meia-idade";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDesafioConcluido : EventoSimEFamilia
        {
            public override string EventoId => "kCompletedChallenge";
            public override string LegendaPtBr => "Desafio concluído";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoSonhoVidaPrometido : EventoSimEFamilia
        {
            public override string EventoId => "kPromisedLifetimeDream";
            public override string LegendaPtBr => "Sonho de vida prometido";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 22 – TECNOLOGIA AVANÇADA E FUTURO
        // =========================================================

        internal sealed class EventoCriouRobo : EventoSimEFamilia
        {
            public override string EventoId => "kCreatedBot";
            public override string LegendaPtBr => "Criou robô";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoGanhouNaLoteria : EventoCompleto
        {
            public override string EventoId => "kWinLotto";
            public override string LegendaPtBr => "Ganhou na loteria";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoMudancaGenero : EventoCompleto
        {
            public override string EventoId => "kChangeGeneder";
            public override string LegendaPtBr => "Mudou de gênero";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDescobertaCeleste : EventoCompleto
        {
            public override string EventoId => "kCelestialDiscovery";
            public override string LegendaPtBr => "Descoberta celestial";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoJetpackTrick : EventoApenasSim
        {
            public override string EventoId => "kDidJetPackTrick";
            public override string LegendaPtBr => "Fez manobra de jetpack";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        // =========================================================
        // CATEGORIA 23 – GRUPOS E BANDAS
        // =========================================================

        internal sealed class EventoFormouBanda : EventoCompleto
        {
            public override string EventoId => "kFormBand";
            public override string LegendaPtBr => "Formou banda";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSaiuDaBanda : EventoCompleto
        {
            public override string EventoId => "kQuitBand";
            public override string LegendaPtBr => "Saiu da banda";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        // =========================================================
        // CATEGORIA 24 – FAMA, PERFORMANCE E SHOWS
        // =========================================================

        internal sealed class EventoFezShow : EventoCompleto
        {
            public override string EventoId => "kPerformedConcert";
            public override string LegendaPtBr => "Fez show";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoCompletouApresentacao : EventoSimEFamilia
        {
            public override string EventoId => "kCompletedGig";
            public override string LegendaPtBr => "Completou apresentação";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVendeuAlbumRemix : EventoCompleto
        {
            public override string EventoId => "kSellRemixAlbum";
            public override string LegendaPtBr => "Vendeu álbum de remix";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoCantouPorGorjetas : EventoApenasSim
        {
            public override string EventoId => "kPerformForTipsAsSinger";
            public override string LegendaPtBr => "Cantou por gorjetas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoTocouGuitarraEmCasa : EventoApenasSim
        {
            public override string EventoId => "kPlayedGuitar";
            public override string LegendaPtBr => "Tocou guitarra";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoAprendeuComposicao : EventoApenasSim
        {
            public override string EventoId => "kLearnedComposition";
            public override string LegendaPtBr => "Aprendeu composição musical";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoDJMiniShow : EventoSimEFamilia
        {
            public override string EventoId => "kDJCompletedMiniShow";
            public override string LegendaPtBr => "DJ completou minishow";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRecebeuApresentacaoFixa : EventoSimEFamilia
        {
            public override string EventoId => "kReceivedSteadyGig";
            public override string LegendaPtBr => "Recebeu apresentação fixa";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoVendeuAlbumCantor : EventoCompleto
        {
            public override string EventoId => "kSoldSingerAlbum";
            public override string LegendaPtBr => "Vendeu álbum como cantor";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoAbductSimUFO : EventoCompleto
        {
            public override string EventoId => "kAbductSimUFO";
            public override string LegendaPtBr => "Sim foi abduzido por alienígenas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAccuseRational : EventoApenasSim
        {
            public override string EventoId => "kAccuseRational";
            public override string LegendaPtBr => "Sim acusou com lógica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoAcquiredRelic : EventoApenasSim
        {
            public override string EventoId => "kAcquiredRelic";
            public override string LegendaPtBr => "Sim obteve um artefato";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAcquiredRepuation : EventoApenasSim
        {
            public override string EventoId => "kAcquiredRepuation";
            public override string LegendaPtBr => "Sim conquistou reputação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoActivatedGroupScienceProject : EventoApenasSim
        {
            public override string EventoId => "kActivatedGroupScienceProject";
            public override string LegendaPtBr => "Sim ativou projeto científico";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoActiveCareerAdvanceLevel : EventoSimEFamilia
        {
            public override string EventoId => "kActiveCareerAdvanceLevel";
            public override string LegendaPtBr => "Sim avançou de nível na carreira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoActiveCareerDescribeServices : EventoSimEFamilia
        {
            public override string EventoId => "kActiveCareerDescribeServices";
            public override string LegendaPtBr => "Sim descreveu serviços";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoActiveCareerFindCustomer : EventoSimEFamilia
        {
            public override string EventoId => "kActiveCareerFindCustomer";
            public override string LegendaPtBr => "Sim encontrou cliente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoActiveCareerGetBetterAtMaxLevel : EventoSimEFamilia
        {
            public override string EventoId => "kActiveCareerGetBetterAtMaxLevel";
            public override string LegendaPtBr => "Sim melhorou no nível máximo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAddedHerbToBonfire : EventoApenasSim
        {
            public override string EventoId => "kAddedHerbToBonfire";
            public override string LegendaPtBr => "Sim adicionou erva à fogueira";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAddedHerbToFood : EventoApenasSim
        {
            public override string EventoId => "kAddedHerbToFood";
            public override string LegendaPtBr => "Sim adicionou erva à comida";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAdmireGroundMural : EventoApenasSim
        {
            public override string EventoId => "kAdmireGroundMural";
            public override string LegendaPtBr => "Sim admirou mural no chão";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAdmireWallMural : EventoApenasSim
        {
            public override string EventoId => "kAdmireWallMural";
            public override string LegendaPtBr => "Sim admirou mural na parede";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoAdoptWildHorse : EventoApenasSim
        {
            public override string EventoId => "kAdoptWildHorse";
            public override string LegendaPtBr => "Sim domou um cavalo selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAdviceTimeStatue : EventoApenasSim
        {
            public override string EventoId => "kAdviceTimeStatue";
            public override string LegendaPtBr => "Sim buscou conselhos da estátua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAgedUpWell : EventoApenasSim
        {
            public override string EventoId => "kAgedUpWell";
            public override string LegendaPtBr => "Sim envelheceu no poço mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAgeOptionChange : EventoApenasSim
        {
            public override string EventoId => "kAgeOptionChange";
            public override string LegendaPtBr => "Sim alterou opção de envelhecimento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAlchemyArtisan : EventoApenasSim
        {
            public override string EventoId => "kAlchemyArtisan";
            public override string LegendaPtBr => "Sim criou poção artesanal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAlienBoost : EventoCompleto
        {
            public override string EventoId => "kAlienBoost";
            public override string LegendaPtBr => "Sim recebeu energia alienígena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAlienDrain : EventoCompleto
        {
            public override string EventoId => "kAlienDrain";
            public override string LegendaPtBr => "Sim drenou energia alienígena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAlienLife : EventoCompleto
        {
            public override string EventoId => "kAlienLife";
            public override string LegendaPtBr => "Sim viveu experiência alienígena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAlienRepaired : EventoCompleto
        {
            public override string EventoId => "kAlienRepaired";
            public override string LegendaPtBr => "Sim consertou nave alienígena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAllTricksLearned : EventoApenasSim
        {
            public override string EventoId => "kAllTricksLearned";
            public override string LegendaPtBr => "Sim aprendeu todos os truques";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoAnalyzedObject : EventoApenasSim
        {
            public override string EventoId => "kAnalyzedObject";
            public override string LegendaPtBr => "Sim analisou um objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAnalyzeSpaceRocks : EventoApenasSim
        {
            public override string EventoId => "kAnalyzeSpaceRocks";
            public override string LegendaPtBr => "Sim analisou pedras espaciais";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAnalyzeStatistics : EventoApenasSim
        {
            public override string EventoId => "kAnalyzeStatistics";
            public override string LegendaPtBr => "Sim analisou estatísticas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAnyFairyAura : EventoApenasSim
        {
            public override string EventoId => "kAnyFairyAura";
            public override string LegendaPtBr => "Sim recebeu aura de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAppChangeRelationship : EventoApenasSim
        {
            public override string EventoId => "kAppChangeRelationship";
            public override string LegendaPtBr => "Sim alterou relacionamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAppliedHolidayHouseLights : EventoApenasSim
        {
            public override string EventoId => "kAppliedHolidayHouseLights";
            public override string LegendaPtBr => "Sim aplicou luzes festivas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAppMeetSim : EventoApenasSim
        {
            public override string EventoId => "kAppMeetSim";
            public override string LegendaPtBr => "Sim conheceu outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAquiredKeyFragment : EventoApenasSim
        {
            public override string EventoId => "kAquiredKeyFragment";
            public override string LegendaPtBr => "Sim obteve fragmento de chave";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoArkBuilder : EventoApenasSim
        {
            public override string EventoId => "kArkBuilder";
            public override string LegendaPtBr => "Sim construiu uma arca";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoArriveInFuture : EventoCompleto
        {
            public override string EventoId => "kArriveInFuture";
            public override string LegendaPtBr => "Sim chegou ao futuro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoArtAppraiserJob : EventoApenasSim
        {
            public override string EventoId => "kArtAppraiserJob";
            public override string LegendaPtBr => "Sim trabalhou como avaliador de arte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAskedForDonation : EventoApenasSim
        {
            public override string EventoId => "kAskedForDonation";
            public override string LegendaPtBr => "Sim pediu uma doação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAskForWerewolfCurse : EventoApenasSim
        {
            public override string EventoId => "kAskForWerewolfCurse";
            public override string LegendaPtBr => "Sim pediu a maldição de lobisomem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAskToJoin : EventoApenasSim
        {
            public override string EventoId => "kAskToJoin";
            public override string LegendaPtBr => "Sim pediu para entrar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteAGoodFortuneCookie : EventoApenasSim
        {
            public override string EventoId => "kAteAGoodFortuneCookie";
            public override string LegendaPtBr => "Sim comeu um biscoito da sorte";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoAteBugInDystopia : EventoApenasSim
        {
            public override string EventoId => "kAteBugInDystopia";
            public override string LegendaPtBr => "Sim comeu inseto distópico";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteFish : EventoApenasSim
        {
            public override string EventoId => "kAteFish";
            public override string LegendaPtBr => "Sim pescou um peixe";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteFlavorfullBugInDystopia : EventoApenasSim
        {
            public override string EventoId => "kAteFlavorfullBugInDystopia";
            public override string LegendaPtBr => "Sim comeu inseto saboroso";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteFromPetBowl : EventoApenasSim
        {
            public override string EventoId => "kAteFromPetBowl";
            public override string LegendaPtBr => "Sim comeu da tigela de pet";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteHarvestable : EventoApenasSim
        {
            public override string EventoId => "kAteHarvestable";
            public override string LegendaPtBr => "Sim colheu item do chão";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteHarvestableFromPlant : EventoApenasSim
        {
            public override string EventoId => "kAteHarvestableFromPlant";
            public override string LegendaPtBr => "Sim colheu de planta";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteHarvestPlant : EventoApenasSim
        {
            public override string EventoId => "kAteHarvestPlant";
            public override string LegendaPtBr => "Sim colheu planta";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteHay : EventoApenasSim
        {
            public override string EventoId => "kAteHay";
            public override string LegendaPtBr => "Sim comeu feno";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoAteMeal : EventoApenasSim
        {
            public override string EventoId => "kAteMeal";
            public override string LegendaPtBr => "Sim comeu refeição";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteMummySnack : EventoCompleto
        {
            public override string EventoId => "kAteMummySnack";
            public override string LegendaPtBr => "Sim comeu lanche de múmia";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAtePoisonedApple : EventoApenasSim
        {
            public override string EventoId => "kAtePoisonedApple";
            public override string LegendaPtBr => "Sim comeu maçã envenenada";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAteSynthMeal : EventoApenasSim
        {
            public override string EventoId => "kAteSynthMeal";
            public override string LegendaPtBr => "Sim comeu refeição sintética";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttackBird : EventoApenasSim
        {
            public override string EventoId => "kAttackBird";
            public override string LegendaPtBr => "Pássaro atacou Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttackedByBees : EventoApenasSim
        {
            public override string EventoId => "kAttackedByBees";
            public override string LegendaPtBr => "Abelhas atacaram Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttackedbyKraken : EventoApenasSim
        {
            public override string EventoId => "kAttackedbyKraken";
            public override string LegendaPtBr => "Sim foi atacado pela Kraken";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedAfterHoursStudySession : EventoApenasSim
        {
            public override string EventoId => "kAttendedAfterHoursStudySession";
            public override string LegendaPtBr => "Sim participou de estudo noturno";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedAudition : EventoApenasSim
        {
            public override string EventoId => "kAttendedAudition";
            public override string LegendaPtBr => "Sim compareceu à audição";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedFallFestival : EventoApenasMundo
        {
            public override string EventoId => "kAttendedFallFestival";
            public override string LegendaPtBr => "Sim foi ao Festival de Outono";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoAttendedProtest : EventoApenasSim
        {
            public override string EventoId => "kAttendedProtest";
            public override string LegendaPtBr => "Sim participou de protesto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedRecital : EventoApenasSim
        {
            public override string EventoId => "kAttendedRecital";
            public override string LegendaPtBr => "Sim foi a um recital";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedSpringFestival : EventoApenasMundo
        {
            public override string EventoId => "kAttendedSpringFestival";
            public override string LegendaPtBr => "Sim foi ao Festival da Primavera";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedSummerFestival : EventoApenasMundo
        {
            public override string EventoId => "kAttendedSummerFestival";
            public override string LegendaPtBr => "Sim foi ao Festival de Verão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedUniversityClass : EventoApenasSim
        {
            public override string EventoId => "kAttendedUniversityClass";
            public override string LegendaPtBr => "Sim frequentou aula universitária";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttendedWinterFestival : EventoApenasMundo
        {
            public override string EventoId => "kAttendedWinterFestival";
            public override string LegendaPtBr => "Sim foi ao Festival de Inverno";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoAttractSpaceObject : EventoApenasSim
        {
            public override string EventoId => "kAttractSpaceObject";
            public override string LegendaPtBr => "Sim atraiu objeto espacial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBabyToddlerSnuggle : EventoSimEFamilia
        {
            public override string EventoId => "kBabyToddlerSnuggle";
            public override string LegendaPtBr => "Bebê/Criança se aconchegou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBakeSaleTableItemSold : EventoApenasSim
        {
            public override string EventoId => "kBakeSaleTableItemSold";
            public override string LegendaPtBr => "Sim vendeu item na mesa de doação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBakeSaleTableRobbed : EventoApenasSim
        {
            public override string EventoId => "kBakeSaleTableRobbed";
            public override string LegendaPtBr => "Sim teve mesa de doação roubada";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }


        internal sealed class EventoBarkAt : EventoApenasSim
        {
            public override string EventoId => "kBarkAt";
            public override string LegendaPtBr => "Sim latiu para alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBassSerenaded : EventoApenasSim
        {
            public override string EventoId => "kBassSerenaded";
            public override string LegendaPtBr => "Sim serenou com baixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBathePet : EventoApenasSim
        {
            public override string EventoId => "kBathePet";
            public override string LegendaPtBr => "Sim deu banho no animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBeAnOccult : EventoApenasSim
        {
            public override string EventoId => "kBeAnOccult";
            public override string LegendaPtBr => "Sim se tornou oculto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBecameDaytime : EventoApenasSim
        {
            public override string EventoId => "kBecameDaytime";
            public override string LegendaPtBr => "Dia substituiu a noite";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBecameFriends : EventoApenasSim
        {
            public override string EventoId => "kBecameFriends";
            public override string LegendaPtBr => "Sims se tornaram amigos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoBecameInnerBeauty : EventoApenasSim
        {
            public override string EventoId => "kBecameInnerBeauty";
            public override string LegendaPtBr => "Sim desenvolveu beleza interior";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBecameNighttime : EventoApenasSim
        {
            public override string EventoId => "kBecameNighttime";
            public override string LegendaPtBr => "Noite substituiu o dia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoBecomeSelfEmployed : EventoApenasSim
        {
            public override string EventoId => "kBecomeSelfEmployed";
            public override string LegendaPtBr => "Sim se tornou autônomo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBehavedInappropriatelyWhileOnTheJob : EventoApenasSim
        {
            public override string EventoId => "kBehavedInappropriatelyWhileOnTheJob";
            public override string LegendaPtBr => "Sim agiu mal no trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBeLed : EventoApenasSim
        {
            public override string EventoId => "kBeLed";
            public override string LegendaPtBr => "Sim foi levado por alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoBladderFailure : EventoApenasSim
        {
            public override string EventoId => "kBladderFailure";
            public override string LegendaPtBr => "Sim urinou em público";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogChangeTheme : EventoApenasSim
        {
            public override string EventoId => "kBlogChangeTheme";
            public override string LegendaPtBr => "Sim alterou tema do blog";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogCreateOne : EventoApenasSim
        {
            public override string EventoId => "kBlogCreateOne";
            public override string LegendaPtBr => "Sim criou um blog";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogEarnFromDonations : EventoApenasSim
        {
            public override string EventoId => "kBlogEarnFromDonations";
            public override string LegendaPtBr => "Sim recebeu doações no blog";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogHaveFollowers : EventoApenasSim
        {
            public override string EventoId => "kBlogHaveFollowers";
            public override string LegendaPtBr => "Sim ganhou seguidores no blog";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogHaveStarBlog : EventoApenasSim
        {
            public override string EventoId => "kBlogHaveStarBlog";
            public override string LegendaPtBr => "Sim alcançou blog estrela";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogNewPost : EventoApenasSim
        {
            public override string EventoId => "kBlogNewPost";
            public override string LegendaPtBr => "Sim publicou um novo post";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogSell : EventoApenasSim
        {
            public override string EventoId => "kBlogSell";
            public override string LegendaPtBr => "Sim vendeu o blog";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBlogSellForSimoleans : EventoApenasSim
        {
            public override string EventoId => "kBlogSellForSimoleans";
            public override string LegendaPtBr => "Sim vendeu blog por simoleões";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBloomPlant : EventoApenasSim
        {
            public override string EventoId => "kBloomPlant";
            public override string LegendaPtBr => "Planta floresceu no jardim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoastGamerSkillz : EventoApenasSim
        {
            public override string EventoId => "kBoastGamerSkillz";
            public override string LegendaPtBr => "Sim se gabou da habilidade Gamer";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBobForApples : EventoApenasSim
        {
            public override string EventoId => "kBobForApples";
            public override string LegendaPtBr => "Sim colheu maçãs";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBodyAndMindFairyAura : EventoApenasSim
        {
            public override string EventoId => "kBodyAndMindFairyAura";
            public override string LegendaPtBr => "Sim recebeu aura da fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBonedUpOnAnatomy : EventoApenasSim
        {
            public override string EventoId => "kBonedUpOnAnatomy";
            public override string LegendaPtBr => "Sim estudou anatomia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBornFromTheSoil : EventoApenasSim
        {
            public override string EventoId => "kBornFromTheSoil";
            public override string LegendaPtBr => "Sim nasceu da terra";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtComic : EventoApenasSim
        {
            public override string EventoId => "kBoughtComic";
            public override string LegendaPtBr => "Sim comprou história em quadrinhos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtConcessionsStandFood : EventoApenasSim
        {
            public override string EventoId => "kBoughtConcessionsStandFood";
            public override string LegendaPtBr => "Sim comprou comida de barraca";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtConsignedObject : EventoApenasSim
        {
            public override string EventoId => "kBoughtConsignedObject";
            public override string LegendaPtBr => "Sim consignou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtImaginaryFriendPotion : EventoApenasSim
        {
            public override string EventoId => "kBoughtImaginaryFriendPotion";
            public override string LegendaPtBr => "Sim comprou poção de amigo imaginário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtLocationHome : EventoApenasSim
        {
            public override string EventoId => "kBoughtLocationHome";
            public override string LegendaPtBr => "Sim comprou casa em lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtObject : EventoApenasSim
        {
            public override string EventoId => "kBoughtObject";
            public override string LegendaPtBr => "Sim comprou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtObjectAtRabbithole : EventoApenasSim
        {
            public override string EventoId => "kBoughtObjectAtRabbithole";
            public override string LegendaPtBr => "Sim comprou em local de trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtObjectInEditTownMode : EventoApenasMundo
        {
            public override string EventoId => "kBoughtObjectInEditTownMode";
            public override string LegendaPtBr => "Sim comprou no modo de lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtObjectStageProp : EventoApenasSim
        {
            public override string EventoId => "kBoughtObjectStageProp";
            public override string LegendaPtBr => "Sim comprou adereço de palco";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtOutfitFromPedestal : EventoApenasSim
        {
            public override string EventoId => "kBoughtOutfitFromPedestal";
            public override string LegendaPtBr => "Sim comprou roupa no pedestal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoBoughtServoBot : EventoApenasSim
        {
            public override string EventoId => "kBoughtServoBot";
            public override string LegendaPtBr => "Sim comprou robô servo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtSomethingOnSale : EventoApenasSim
        {
            public override string EventoId => "kBoughtSomethingOnSale";
            public override string LegendaPtBr => "Sim comprou item em promoção";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBoughtSomethingWithACoupon : EventoApenasSim
        {
            public override string EventoId => "kBoughtSomethingWithACoupon";
            public override string LegendaPtBr => "Sim comprou com cupom";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBouncerDeniedAccess : EventoApenasSim
        {
            public override string EventoId => "kBouncerDeniedAccess";
            public override string LegendaPtBr => "Sim foi impedido de entrar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBowledGame : EventoApenasSim
        {
            public override string EventoId => "kBowledGame";
            public override string LegendaPtBr => "Sim jogou boliche";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBowledStrike : EventoApenasSim
        {
            public override string EventoId => "kBowledStrike";
            public override string LegendaPtBr => "Sim acertou strike";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBowledWithFriends : EventoApenasSim
        {
            public override string EventoId => "kBowledWithFriends";
            public override string LegendaPtBr => "Sim jogou boliche com amigos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrainGotEnhanced : EventoApenasSim
        {
            public override string EventoId => "kBrainGotEnhanced";
            public override string LegendaPtBr => "Sim aumentou a inteligência";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBravedHauntedHouse : EventoApenasSim
        {
            public override string EventoId => "kBravedHauntedHouse";
            public override string LegendaPtBr => "Sim enfrentou casa mal-assombrada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoBreathingShallowly : EventoApenasSim
        {
            public override string EventoId => "kBreathingShallowly";
            public override string LegendaPtBr => "Sim respirou superficialmente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBribeBouncerSuccess : EventoApenasSim
        {
            public override string EventoId => "kBribeBouncerSuccess";
            public override string LegendaPtBr => "Sim subornou o segurança";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBringDrinkTo : EventoApenasSim
        {
            public override string EventoId => "kBringDrinkTo";
            public override string LegendaPtBr => "Sim levou bebida para alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBringFoodTo : EventoApenasSim
        {
            public override string EventoId => "kBringFoodTo";
            public override string LegendaPtBr => "Sim levou comida para alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrokeBoard : EventoApenasSim
        {
            public override string EventoId => "kBrokeBoard";
            public override string LegendaPtBr => "Sim quebrou a prancha de skate";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrokeDown : EventoApenasSim
        {
            public override string EventoId => "kBrokeDown";
            public override string LegendaPtBr => "Carro quebrou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrokeSpaceRock : EventoApenasSim
        {
            public override string EventoId => "kBrokeSpaceRock";
            public override string LegendaPtBr => "Sim quebrou rocha espacial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBronzed : EventoApenasSim
        {
            public override string EventoId => "kBronzed";
            public override string LegendaPtBr => "Sim bronzeou a pele";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrood : EventoApenasSim
        {
            public override string EventoId => "kBrood";
            public override string LegendaPtBr => "Sim pensou sobre a vida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBrushedTeeth : EventoApenasSim
        {
            public override string EventoId => "kBrushedTeeth";
            public override string LegendaPtBr => "Sim escovou os dentes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuiltIgloo : EventoApenasSim
        {
            public override string EventoId => "kBuiltIgloo";
            public override string LegendaPtBr => "Sim construiu um iglu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuiltNanite : EventoApenasSim
        {
            public override string EventoId => "kBuiltNanite";
            public override string LegendaPtBr => "Sim construiu um nanito";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuiltSnowman : EventoApenasSim
        {
            public override string EventoId => "kBuiltSnowman";
            public override string LegendaPtBr => "Sim construiu um boneco de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuiltTraitChip : EventoApenasSim
        {
            public override string EventoId => "kBuiltTraitChip";
            public override string LegendaPtBr => "Sim construiu um chip de traço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBurnLeafPile : EventoApenasSim
        {
            public override string EventoId => "kBurnLeafPile";
            public override string LegendaPtBr => "Sim queimou uma pilha de folhas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBurntMeal : EventoApenasSim
        {
            public override string EventoId => "kBurntMeal";
            public override string LegendaPtBr => "Sim queimou a refeição";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyAppleBobbingTank : EventoApenasSim
        {
            public override string EventoId => "kBuyAppleBobbingTank";
            public override string LegendaPtBr => "Sim comprou tanque de maçãs";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyARoundForEveryoneFromProprietor : EventoApenasSim
        {
            public override string EventoId => "kBuyARoundForEveryoneFromProprietor";
            public override string LegendaPtBr => "Sim comprou bebidas para todos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyCandyBar : EventoApenasSim
        {
            public override string EventoId => "kBuyCandyBar";
            public override string LegendaPtBr => "Sim comprou uma barra de chocolate";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyFeaturedItemAlreadyOwned : EventoApenasSim
        {
            public override string EventoId => "kBuyFeaturedItemAlreadyOwned";
            public override string LegendaPtBr => "Sim tentou comprar item já possuído";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyFeaturedItemClicked : EventoApenasSim
        {
            public override string EventoId => "kBuyFeaturedItemClicked";
            public override string LegendaPtBr => "Sim clicou no item em destaque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyFeaturedItemDialogCanceled : EventoApenasSim
        {
            public override string EventoId => "kBuyFeaturedItemDialogCanceled";
            public override string LegendaPtBr => "Sim cancelou compra do item";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyFeaturedItemNotEnoughSimPoints : EventoApenasSim
        {
            public override string EventoId => "kBuyFeaturedItemNotEnoughSimPoints";
            public override string LegendaPtBr => "Sim não tinha pontos suficientes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyFeaturedItemSuccess : EventoApenasSim
        {
            public override string EventoId => "kBuyFeaturedItemSuccess";
            public override string LegendaPtBr => "Sim comprou o item em destaque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyFeaturedItemUnknownFailure : EventoApenasSim
        {
            public override string EventoId => "kBuyFeaturedItemUnknownFailure";
            public override string LegendaPtBr => "Sim não comprou item destacado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyHorse : EventoApenasSim
        {
            public override string EventoId => "kBuyHorse";
            public override string LegendaPtBr => "Sim comprou um cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyHotdogEatingBooth : EventoApenasSim
        {
            public override string EventoId => "kBuyHotdogEatingBooth";
            public override string LegendaPtBr => "Sim comprou barraca de cachorros-quentes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyPieEatingBooth : EventoApenasSim
        {
            public override string EventoId => "kBuyPieEatingBooth";
            public override string LegendaPtBr => "Sim comprou barraca de tortas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuySimPointsCancelClicked : EventoApenasSim
        {
            public override string EventoId => "kBuySimPointsCancelClicked";
            public override string LegendaPtBr => "Sim cancelou compra de pontos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuySimPointsOkClicked : EventoApenasSim
        {
            public override string EventoId => "kBuySimPointsOkClicked";
            public override string LegendaPtBr => "Sim comprou pontos de Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuySoda : EventoApenasSim
        {
            public override string EventoId => "kBuySoda";
            public override string LegendaPtBr => "Sim comprou refrigerante";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoBuyWeatherMachine : EventoApenasMundo
        {
            public override string EventoId => "kBuyWeatherMachine";
            public override string LegendaPtBr => "Sim comprou máquina do tempo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCalledSim : EventoApenasSim
        {
            public override string EventoId => "kCalledSim";
            public override string LegendaPtBr => "Sim telefonou para outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCallInSick : EventoApenasSim
        {
            public override string EventoId => "kCallInSick";
            public override string LegendaPtBr => "Sim ligou para faltar ao trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCannonballInPool : EventoApenasSim
        {
            public override string EventoId => "kCannonballInPool";
            public override string LegendaPtBr => "Sim fez cambalhota na piscina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCardioTimeAdded : EventoApenasSim
        {
            public override string EventoId => "kCardioTimeAdded";
            public override string LegendaPtBr => "Sim adicionou tempo de cardio";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCareerDataChanged : EventoSimEFamilia
        {
            public override string EventoId => "kCareerDataChanged";
            public override string LegendaPtBr => "Dados da carreira foram alterados";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }





        internal sealed class EventoCareerOpportunity_StayedLate : EventoSimEFamilia
        {
            public override string EventoId => "kCareerOpportunity_StayedLate";
            public override string LegendaPtBr => "Sim trabalhou até tarde";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCareerPerformanceChanged : EventoRuido
        {
            public override string EventoId => "kCareerPerformanceChanged";
            public override string LegendaPtBr => "Sim teve desempenho alterado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoCareerSlackOff : EventoSimEFamilia
        {
            public override string EventoId => "kCareerSlackOff";
            public override string LegendaPtBr => "Sim evitou trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoCarryCatToy : EventoApenasSim
        {
            public override string EventoId => "kCarryCatToy";
            public override string LegendaPtBr => "Sim carregou brinquedo de gato";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCarryMinorPet : EventoApenasSim
        {
            public override string EventoId => "kCarryMinorPet";
            public override string LegendaPtBr => "Sim carregou bichinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCarvedPumpkin : EventoApenasSim
        {
            public override string EventoId => "kCarvedPumpkin";
            public override string LegendaPtBr => "Sim esculpiu abóbora";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastCharm : EventoApenasSim
        {
            public override string EventoId => "kCastCharm";
            public override string LegendaPtBr => "Sim usou charme";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastConversion : EventoApenasSim
        {
            public override string EventoId => "kCastConversion";
            public override string LegendaPtBr => "Sim iniciou conversão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastConversionOnPlant : EventoApenasSim
        {
            public override string EventoId => "kCastConversionOnPlant";
            public override string LegendaPtBr => "Sim converteu planta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastFireBlast : EventoApenasSim
        {
            public override string EventoId => "kCastFireBlast";
            public override string LegendaPtBr => "Sim lançou rajada de fogo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastGoodLuckCharm : EventoApenasSim
        {
            public override string EventoId => "kCastGoodLuckCharm";
            public override string LegendaPtBr => "Sim lançou amuleto da sorte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastHauntingCurse : EventoApenasSim
        {
            public override string EventoId => "kCastHauntingCurse";
            public override string LegendaPtBr => "Sim lançou maldição assombração";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastIceBlast : EventoApenasSim
        {
            public override string EventoId => "kCastIceBlast";
            public override string LegendaPtBr => "Sim lançou rajada de gelo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastLoveCharm : EventoApenasSim
        {
            public override string EventoId => "kCastLoveCharm";
            public override string LegendaPtBr => "Sim lançou feitiço do amor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastPestilenceCurse : EventoApenasSim
        {
            public override string EventoId => "kCastPestilenceCurse";
            public override string LegendaPtBr => "Sim lançou maldição da peste";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastReanimation : EventoApenasSim
        {
            public override string EventoId => "kCastReanimation";
            public override string LegendaPtBr => "Sim reanimou um corpo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastRestoration : EventoApenasSim
        {
            public override string EventoId => "kCastRestoration";
            public override string LegendaPtBr => "Sim lançou feitiço de restauração";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoCastSunlightCharm : EventoApenasSim
        {
            public override string EventoId => "kCastSunlightCharm";
            public override string LegendaPtBr => "Sim lançou encanto da luz solar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCastToadify : EventoApenasSim
        {
            public override string EventoId => "kCastToadify";
            public override string LegendaPtBr => "Sim transformou em sapo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCatchBurglar : EventoApenasSim
        {
            public override string EventoId => "kCatchBurglar";
            public override string LegendaPtBr => "Sim pegou um ladrão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCatchFlies : EventoApenasSim
        {
            public override string EventoId => "kCatchFlies";
            public override string LegendaPtBr => "Sim pegou moscas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCatGroomSelf : EventoApenasSim
        {
            public override string EventoId => "kCatGroomSelf";
            public override string LegendaPtBr => "Gato se limpou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCatPlayInTub : EventoApenasSim
        {
            public override string EventoId => "kCatPlayInTub";
            public override string LegendaPtBr => "Gato brincou na banheira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCatPresentGift : EventoApenasSim
        {
            public override string EventoId => "kCatPresentGift";
            public override string LegendaPtBr => "Gato deu um presente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCaughtBug : EventoApenasSim
        {
            public override string EventoId => "kCaughtBug";
            public override string LegendaPtBr => "Sim pegou um inseto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCaughtButterflies : EventoApenasSim
        {
            public override string EventoId => "kCaughtButterflies";
            public override string LegendaPtBr => "Sim capturou borboletas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoCaughtCheatingWithSim : EventoApenasSim
        {
            public override string EventoId => "kCaughtCheatingWithSim";
            public override string LegendaPtBr => "Sim traiu o parceiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoCaughtMinorPet : EventoApenasSim
        {
            public override string EventoId => "kCaughtMinorPet";
            public override string LegendaPtBr => "Sim pegou um bichinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCaughtNanite : EventoApenasSim
        {
            public override string EventoId => "kCaughtNanite";
            public override string LegendaPtBr => "Sim coletou nanite";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCaughtSimCheatingOnMe : EventoApenasSim
        {
            public override string EventoId => "kCaughtSimCheatingOnMe";
            public override string LegendaPtBr => "Sim flagrou traição";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCausedSimToTwirl : EventoApenasSim
        {
            public override string EventoId => "kCausedSimToTwirl";
            public override string LegendaPtBr => "Sim fez outro dançar";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoChallengeCircumstanceFulfilled : EventoApenasSim
        {
            public override string EventoId => "kChallengeCircumstanceFulfilled";
            public override string LegendaPtBr => "Sim cumpriu circunstância";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChallengeSimToAppleBobbing : EventoApenasSim
        {
            public override string EventoId => "kChallengeSimToAppleBobbing";
            public override string LegendaPtBr => "Sim desafiou a bobar maçãs";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChallengeSimToHotdogContest : EventoApenasSim
        {
            public override string EventoId => "kChallengeSimToHotdogContest";
            public override string LegendaPtBr => "Sim desafiou a comer cachorros-quentes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChallengeSimToPieContest : EventoApenasSim
        {
            public override string EventoId => "kChallengeSimToPieContest";
            public override string LegendaPtBr => "Sim desafiou a comer tortas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChallengeToSimfest : EventoApenasSim
        {
            public override string EventoId => "kChallengeToSimfest";
            public override string LegendaPtBr => "Sim participou do festival";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChallengeToSpellcasting : EventoApenasSim
        {
            public override string EventoId => "kChallengeToSpellcasting";
            public override string LegendaPtBr => "Sim lançou feitiço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChangedInsideOutsideStatus : EventoRuido
        {
            public override string EventoId => "kChangedInsideOutsideStatus";
            public override string LegendaPtBr => "Sim entrou/saiu do ambiente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChangeFacialHair : EventoApenasSim
        {
            public override string EventoId => "kChangeFacialHair";
            public override string LegendaPtBr => "Sim mudou a barba";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoChangeHairstyle : EventoApenasSim
        {
            public override string EventoId => "kChangeHairstyle";
            public override string LegendaPtBr => "Sim mudou o penteado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChangeOutfit : EventoApenasSim
        {
            public override string EventoId => "kChangeOutfit";
            public override string LegendaPtBr => "Sim trocou de roupa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChargedPlantKindness : EventoApenasSim
        {
            public override string EventoId => "kChargedPlantKindness";
            public override string LegendaPtBr => "Planta recebeu bondade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChargedPlantLaughter : EventoApenasSim
        {
            public override string EventoId => "kChargedPlantLaughter";
            public override string LegendaPtBr => "Planta recebeu alegria";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChargedPlantLove : EventoApenasSim
        {
            public override string EventoId => "kChargedPlantLove";
            public override string LegendaPtBr => "Planta recebeu amor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChargedPlantRage : EventoApenasSim
        {
            public override string EventoId => "kChargedPlantRage";
            public override string LegendaPtBr => "Planta recebeu raiva";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChasedSim : EventoApenasSim
        {
            public override string EventoId => "kChasedSim";
            public override string LegendaPtBr => "Sim perseguiu outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChaseMailman : EventoApenasSim
        {
            public override string EventoId => "kChaseMailman";
            public override string LegendaPtBr => "Sim correu atrás do carteiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheatEntered : EventoApenasSim
        {
            public override string EventoId => "kCheatEntered";
            public override string LegendaPtBr => "Sim usou código de trapaça";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheckDeepSeaLifetime : EventoApenasSim
        {
            public override string EventoId => "kCheckDeepSeaLifetime";
            public override string LegendaPtBr => "Sim verificou ambição oceânica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheckedCurrentEvents : EventoApenasSim
        {
            public override string EventoId => "kCheckedCurrentEvents";
            public override string LegendaPtBr => "Sim verificou as notícias";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheckedSelfOutInMirror : EventoApenasSim
        {
            public override string EventoId => "kCheckedSelfOutInMirror";
            public override string LegendaPtBr => "Sim se observou no espelho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheckedWeather : EventoApenasMundo
        {
            public override string EventoId => "kCheckedWeather";
            public override string LegendaPtBr => "Sim observou a previsão do tempo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheckedWeatherOnTv : EventoApenasMundo
        {
            public override string EventoId => "kCheckedWeatherOnTv";
            public override string LegendaPtBr => "Sim viu o tempo na TV";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCheckLunarHoroscope : EventoApenasSim
        {
            public override string EventoId => "kCheckLunarHoroscope";
            public override string LegendaPtBr => "Sim consultou o horóscopo lunar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoChewFurniture : EventoApenasSim
        {
            public override string EventoId => "kChewFurniture";
            public override string LegendaPtBr => "Sim roeu o móvel";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoChoseDreamPodDream : EventoApenasSim
        {
            public override string EventoId => "kChoseDreamPodDream";
            public override string LegendaPtBr => "Sim escolheu um sonho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoCleanedObject : EventoApenasSim
        {
            public override string EventoId => "kCleanedObject";
            public override string LegendaPtBr => "Sim limpou um objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanedOrThrewAwayObject : EventoApenasSim
        {
            public override string EventoId => "kCleanedOrThrewAwayObject";
            public override string LegendaPtBr => "Sim limpou ou jogou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanedSink : EventoApenasSim
        {
            public override string EventoId => "kCleanedSink";
            public override string LegendaPtBr => "Sim limpou a pia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanedToilet : EventoApenasSim
        {
            public override string EventoId => "kCleanedToilet";
            public override string LegendaPtBr => "Sim limpou o vaso sanitário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanedUpStreetArt : EventoApenasSim
        {
            public override string EventoId => "kCleanedUpStreetArt";
            public override string LegendaPtBr => "Sim limpou a arte de rua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanLamp : EventoApenasSim
        {
            public override string EventoId => "kCleanLamp";
            public override string LegendaPtBr => "Sim limpou o abajur";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanMinorPet : EventoApenasSim
        {
            public override string EventoId => "kCleanMinorPet";
            public override string LegendaPtBr => "Animal de estimação se limpou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanSelf : EventoApenasSim
        {
            public override string EventoId => "kCleanSelf";
            public override string LegendaPtBr => "Sim se limpou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanSim : EventoApenasSim
        {
            public override string EventoId => "kCleanSim";
            public override string LegendaPtBr => "Sim limpou outra pessoa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanUpGraffiti : EventoApenasSim
        {
            public override string EventoId => "kCleanUpGraffiti";
            public override string LegendaPtBr => "Sim removeu pichação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanUpTaggedStatue : EventoApenasSim
        {
            public override string EventoId => "kCleanUpTaggedStatue";
            public override string LegendaPtBr => "Sim limpou estátua marcada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCleanUpTaggedWall : EventoApenasSim
        {
            public override string EventoId => "kCleanUpTaggedWall";
            public override string LegendaPtBr => "Sim limpou parede marcada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoClonedSim : EventoApenasSim
        {
            public override string EventoId => "kClonedSim";
            public override string LegendaPtBr => "Sim foi clonado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedDew : EventoApenasSim
        {
            public override string EventoId => "kCollectedDew";
            public override string LegendaPtBr => "Sim coletou orvalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedFestivalTickets : EventoApenasMundo
        {
            public override string EventoId => "kCollectedFestivalTickets";
            public override string LegendaPtBr => "Sim coletou ingressos do festival";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoCollectedGems : EventoApenasSim
        {
            public override string EventoId => "kCollectedGems";
            public override string LegendaPtBr => "Sim coletou gemas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedMetal : EventoApenasSim
        {
            public override string EventoId => "kCollectedMetal";
            public override string LegendaPtBr => "Sim coletou metal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedMushrooms : EventoApenasSim
        {
            public override string EventoId => "kCollectedMushrooms";
            public override string LegendaPtBr => "Sim coletou cogumelos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedPowerCells : EventoApenasSim
        {
            public override string EventoId => "kCollectedPowerCells";
            public override string LegendaPtBr => "Sim coletou células de energia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedRelic : EventoApenasSim
        {
            public override string EventoId => "kCollectedRelic";
            public override string LegendaPtBr => "Sim coletou relíquia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedRock : EventoApenasSim
        {
            public override string EventoId => "kCollectedRock";
            public override string LegendaPtBr => "Sim coletou uma pedra";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedSomeScrap : EventoApenasSim
        {
            public override string EventoId => "kCollectedSomeScrap";
            public override string LegendaPtBr => "Sim recolheu sucata";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectedWildFlower : EventoApenasSim
        {
            public override string EventoId => "kCollectedWildFlower";
            public override string LegendaPtBr => "Sim colheu uma flor silvestre";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectFairyDust : EventoApenasSim
        {
            public override string EventoId => "kCollectFairyDust";
            public override string LegendaPtBr => "Sim coletou pó de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCollectSeaLife : EventoApenasSim
        {
            public override string EventoId => "kCollectSeaLife";
            public override string LegendaPtBr => "Sim coletou vida marinha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCommittedDegreeProgress : EventoApenasSim
        {
            public override string EventoId => "kCommittedDegreeProgress";
            public override string LegendaPtBr => "Sim progrediu no curso";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoComplainAboutVideoGames : EventoApenasSim
        {
            public override string EventoId => "kComplainAboutVideoGames";
            public override string LegendaPtBr => "Sim reclamou dos jogos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoComplainAboutWorld : EventoApenasMundo
        {
            public override string EventoId => "kComplainAboutWorld";
            public override string LegendaPtBr => "Sim reclamou do mundo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoCompletedGroundMural : EventoApenasSim
        {
            public override string EventoId => "kCompletedGroundMural";
            public override string LegendaPtBr => "Sim finalizou mural no chão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCompletedSkillAchievement : EventoApenasSim
        {
            public override string EventoId => "kCompletedSkillAchievement";
            public override string LegendaPtBr => "Sim alcançou conquista de habilidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCompletedWallMural : EventoApenasSim
        {
            public override string EventoId => "kCompletedWallMural";
            public override string LegendaPtBr => "Sim finalizou mural na parede";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoComplimentSelf : EventoApenasSim
        {
            public override string EventoId => "kComplimentSelf";
            public override string LegendaPtBr => "Sim se elogiou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoComputerBroke : EventoApenasSim
        {
            public override string EventoId => "kComputerBroke";
            public override string LegendaPtBr => "Computador quebrou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoComputerImprovement : EventoApenasSim
        {
            public override string EventoId => "kComputerImprovement";
            public override string LegendaPtBr => "Sim melhorou a habilidade de computador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoContemplateMeaning : EventoApenasSim
        {
            public override string EventoId => "kContemplateMeaning";
            public override string LegendaPtBr => "Sim contemplou o significado da vida";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCookedMeal : EventoApenasSim
        {
            public override string EventoId => "kCookedMeal";
            public override string LegendaPtBr => "Sim preparou uma refeição";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCopiedHomework : EventoApenasSim
        {
            public override string EventoId => "kCopiedHomework";
            public override string LegendaPtBr => "Sim copiou a lição de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCorrelatedScientificData : EventoApenasSim
        {
            public override string EventoId => "kCorrelatedScientificData";
            public override string LegendaPtBr => "Sim correlacionou dados científicos";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCostumePartyScheduled : EventoSimEFamilia
        {
            public override string EventoId => "kCostumePartyScheduled";
            public override string LegendaPtBr => "Sim agendou uma festa a fantasia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreateAlchemyObject : EventoApenasSim
        {
            public override string EventoId => "kCreateAlchemyObject";
            public override string LegendaPtBr => "Sim criou um objeto de alquimia";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreateBabyWithSim : EventoSimEFamilia
        {
            public override string EventoId => "kCreateBabyWithSim";
            public override string LegendaPtBr => "Sim criou um bebê com outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoCreatedDrink : EventoApenasSim
        {
            public override string EventoId => "kCreatedDrink";
            public override string LegendaPtBr => "Sim criou uma bebida";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedFiveStarBlogEachType : EventoApenasSim
        {
            public override string EventoId => "kCreatedFiveStarBlogEachType";
            public override string LegendaPtBr => "Sim criou blog cinco estrelas";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedImaginaryFriendOffspring : EventoApenasSim
        {
            public override string EventoId => "kCreatedImaginaryFriendOffspring";
            public override string LegendaPtBr => "Sim criou descendente de amigo imaginário";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedInvention : EventoApenasSim
        {
            public override string EventoId => "kCreatedInvention";
            public override string LegendaPtBr => "Sim criou uma invenção";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedMonster : EventoApenasSim
        {
            public override string EventoId => "kCreatedMonster";
            public override string LegendaPtBr => "Sim criou um monstro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedWeather : EventoApenasMundo
        {
            public override string EventoId => "kCreatedWeather";
            public override string LegendaPtBr => "Sim criou o clima";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedWeatherFog : EventoApenasMundo
        {
            public override string EventoId => "kCreatedWeatherFog";
            public override string LegendaPtBr => "Névoa cobriu a vizinhança";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedWeatherHail : EventoApenasMundo
        {
            public override string EventoId => "kCreatedWeatherHail";
            public override string LegendaPtBr => "Granizo caiu sobre o chão";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedWeatherRain : EventoApenasMundo
        {
            public override string EventoId => "kCreatedWeatherRain";
            public override string LegendaPtBr => "Chuva molhou os Sims";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedWeatherSnow : EventoApenasMundo
        {
            public override string EventoId => "kCreatedWeatherSnow";
            public override string LegendaPtBr => "Neve cobriu o terreno";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreatedWeatherSunny : EventoApenasMundo
        {
            public override string EventoId => "kCreatedWeatherSunny";
            public override string LegendaPtBr => "Sol brilhou no céu";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreateStormWithUFO : EventoCompleto
        {
            public override string EventoId => "kCreateStormWithUFO";
            public override string LegendaPtBr => "Tempestade trouxe um OVNI";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCreativeFairyAura : EventoApenasSim
        {
            public override string EventoId => "kCreativeFairyAura";
            public override string LegendaPtBr => "Sim recebeu aura de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCritiqueArtwork : EventoApenasSim
        {
            public override string EventoId => "kCritiqueArtwork";
            public override string LegendaPtBr => "Sim avaliou a obra de arte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCrystalImbue : EventoApenasSim
        {
            public override string EventoId => "kCrystalImbue";
            public override string LegendaPtBr => "Sim imbuíu um cristal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCuddled : EventoApenasSim
        {
            public override string EventoId => "kCuddled";
            public override string LegendaPtBr => "Sim aconchegou-se ao outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCuredByTheSphinx : EventoApenasSim
        {
            public override string EventoId => "kCuredByTheSphinx";
            public override string LegendaPtBr => "Sim foi curado pela Esfinge";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCuredThroughAlchemy : EventoApenasSim
        {
            public override string EventoId => "kCuredThroughAlchemy";
            public override string LegendaPtBr => "Sim curou com alquimia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCurrentSeasonLengthChanged : EventoApenasMundo
        {
            public override string EventoId => "kCurrentSeasonLengthChanged";
            public override string LegendaPtBr => "Duração da estação mudou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoCutWeddingCake : EventoSimEFamilia
        {
            public override string EventoId => "kCutWeddingCake";
            public override string LegendaPtBr => "Sim cortou o bolo de casamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDanceAtFairyParty : EventoSimEFamilia
        {
            public override string EventoId => "kDanceAtFairyParty";
            public override string LegendaPtBr => "Sim dançou na festa de fadas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDanceAtSpringFestival : EventoApenasMundo
        {
            public override string EventoId => "kDanceAtSpringFestival";
            public override string LegendaPtBr => "Sim dançou no festival da primavera";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDancedInMocapSuit : EventoApenasSim
        {
            public override string EventoId => "kDancedInMocapSuit";
            public override string LegendaPtBr => "Sim dançou com traje de captura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDanceToDJMusic : EventoApenasSim
        {
            public override string EventoId => "kDanceToDJMusic";
            public override string LegendaPtBr => "Sim dançou para a música do DJ";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDeathByMurphyBed : EventoApenasSim
        {
            public override string EventoId => "kDeathByMurphyBed";
            public override string LegendaPtBr => "Sim morreu com cama Murphy";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDefeatedMummy : EventoCompleto
        {
            public override string EventoId => "kDefeatedMummy";
            public override string LegendaPtBr => "Sim derrotou o múmia";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDeliveredToSim : EventoApenasSim
        {
            public override string EventoId => "kDeliveredToSim";
            public override string LegendaPtBr => "Sim entregou objeto a outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDeniedThawing : EventoApenasSim
        {
            public override string EventoId => "kDeniedThawing";
            public override string LegendaPtBr => "Sim negou o descongelamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDescendantsChanged : EventoApenasSim
        {
            public override string EventoId => "kDescendantsChanged";
            public override string LegendaPtBr => "Descendentes mudaram características";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDescribeRadicalIdea : EventoApenasSim
        {
            public override string EventoId => "kDescribeRadicalIdea";
            public override string LegendaPtBr => "Sim descreveu ideia radical";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDesignedTraitChip : EventoApenasSim
        {
            public override string EventoId => "kDesignedTraitChip";
            public override string LegendaPtBr => "Sim projetou chip de traço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDestroyedSnowAngel : EventoApenasSim
        {
            public override string EventoId => "kDestroyedSnowAngel";
            public override string LegendaPtBr => "Sim destruiu boneco de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDestroyedSnowman : EventoApenasSim
        {
            public override string EventoId => "kDestroyedSnowman";
            public override string LegendaPtBr => "Sim destruiu boneco de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDestroyedTopiary : EventoApenasSim
        {
            public override string EventoId => "kDestroyedTopiary";
            public override string LegendaPtBr => "Sim destruiu topiário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDeterminedGenderOfBaby : EventoSimEFamilia
        {
            public override string EventoId => "kDeterminedGenderOfBaby";
            public override string LegendaPtBr => "Sim determinou gênero do bebê";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDetonatedObject : EventoApenasSim
        {
            public override string EventoId => "kDetonatedObject";
            public override string LegendaPtBr => "Sim detonou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDidCharmingIntroduction : EventoApenasSim
        {
            public override string EventoId => "kDidCharmingIntroduction";
            public override string LegendaPtBr => "Sim fez uma introdução encantadora";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDidGetToKnow : EventoApenasSim
        {
            public override string EventoId => "kDidGetToKnow";
            public override string LegendaPtBr => "Sim conheceu melhor alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDidHomework : EventoApenasSim
        {
            public override string EventoId => "kDidHomework";
            public override string LegendaPtBr => "Sim fez a tarefa de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoDidLaundry : EventoApenasSim
        {
            public override string EventoId => "kDidLaundry";
            public override string LegendaPtBr => "Sim lavou a roupa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDidMeanSocial : EventoApenasSim
        {
            public override string EventoId => "kDidMeanSocial";
            public override string LegendaPtBr => "Sim teve interação social negativa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDidSmoothRecovery : EventoApenasSim
        {
            public override string EventoId => "kDidSmoothRecovery";
            public override string LegendaPtBr => "Sim teve recuperação tranquila";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoDigThroughGarbage : EventoApenasSim
        {
            public override string EventoId => "kDigThroughGarbage";
            public override string LegendaPtBr => "Sim revirou o lixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDisarmedTrap : EventoApenasSim
        {
            public override string EventoId => "kDisarmedTrap";
            public override string LegendaPtBr => "Sim desarmou uma armadilha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDiscoveredAPotion : EventoApenasSim
        {
            public override string EventoId => "kDiscoveredAPotion";
            public override string LegendaPtBr => "Sim descobriu uma poção";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }


        internal sealed class EventoDiscoveredNewInvention : EventoApenasSim
        {
            public override string EventoId => "kDiscoveredNewInvention";
            public override string LegendaPtBr => "Sim descobriu uma nova invenção";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoDiscoveredNewPhotoCollection : EventoApenasSim
        {
            public override string EventoId => "kDiscoveredNewPhotoCollection";
            public override string LegendaPtBr => "Sim descobriu coleção de fotos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }



        internal sealed class EventoDiscussedFashion : EventoApenasSim
        {
            public override string EventoId => "kDiscussedFashion";
            public override string LegendaPtBr => "Sim discutiu sobre moda";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDisposedOfDocuments : EventoApenasSim
        {
            public override string EventoId => "kDisposedOfDocuments";
            public override string LegendaPtBr => "Sim descartou documentos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDiveInPool : EventoApenasSim
        {
            public override string EventoId => "kDiveInPool";
            public override string LegendaPtBr => "Sim mergulhou na piscina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoDoctorHelpedSimInMedicalEmergency : EventoApenasSim
        {
            public override string EventoId => "kDoctorHelpedSimInMedicalEmergency";
            public override string LegendaPtBr => "Médico ajudou sim em emergência";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDodgedTrap : EventoApenasSim
        {
            public override string EventoId => "kDodgedTrap";
            public override string LegendaPtBr => "Sim desviou de armadilha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDogChasedBall : EventoApenasSim
        {
            public override string EventoId => "kDogChasedBall";
            public override string LegendaPtBr => "Cachorro perseguiu a bola";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDogDigHole : EventoApenasSim
        {
            public override string EventoId => "kDogDigHole";
            public override string LegendaPtBr => "Cachorro cavou um buraco";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDonatedInsectToScience : EventoApenasSim
        {
            public override string EventoId => "kDonatedInsectToScience";
            public override string LegendaPtBr => "Sim doou inseto à ciência";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoDonatedToPlanTheFuture : EventoCompleto
        {
            public override string EventoId => "kDonatedToPlanTheFuture";
            public override string LegendaPtBr => "Sim doou para planejar o futuro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDonatedToUndermineCharity : EventoApenasSim
        {
            public override string EventoId => "kDonatedToUndermineCharity";
            public override string LegendaPtBr => "Sim prejudicou a caridade";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDoSmustle : EventoApenasSim
        {
            public override string EventoId => "kDoSmustle";
            public override string LegendaPtBr => "Sim fez um amassado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDrankFromToilet : EventoApenasSim
        {
            public override string EventoId => "kDrankFromToilet";
            public override string LegendaPtBr => "Sim bebeu da privada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDrankNectar : EventoApenasSim
        {
            public override string EventoId => "kDrankNectar";
            public override string LegendaPtBr => "Sim bebeu néctar mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDreamConditionsSatisfied : EventoApenasSim
        {
            public override string EventoId => "kDreamConditionsSatisfied";
            public override string LegendaPtBr => "Sim adormeceu em sonho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoDrinkFairyNectar : EventoApenasSim
        {
            public override string EventoId => "kDrinkFairyNectar";
            public override string LegendaPtBr => "Sim bebeu néctar de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDrinkFromPond : EventoApenasSim
        {
            public override string EventoId => "kDrinkFromPond";
            public override string LegendaPtBr => "Sim bebeu água do lago";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDrinkFromWaterTrough : EventoApenasSim
        {
            public override string EventoId => "kDrinkFromWaterTrough";
            public override string LegendaPtBr => "Sim bebeu água do trough";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDrinkSoda : EventoApenasSim
        {
            public override string EventoId => "kDrinkSoda";
            public override string LegendaPtBr => "Sim bebeu refrigerante";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoDrumsSerenaded : EventoApenasSim
        {
            public override string EventoId => "kDrumsSerenaded";
            public override string LegendaPtBr => "Sim serenou com bateria";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnedMoneyAsAstronomer : EventoApenasSim
        {
            public override string EventoId => "kEarnedMoneyAsAstronomer";
            public override string LegendaPtBr => "Sim ganhou dinheiro como astrônomo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnedMoneyAsSportsAgent : EventoApenasSim
        {
            public override string EventoId => "kEarnedMoneyAsSportsAgent";
            public override string LegendaPtBr => "Sim ganhou dinheiro como agente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnedMoneyFromMakeover : EventoApenasSim
        {
            public override string EventoId => "kEarnedMoneyFromMakeover";
            public override string LegendaPtBr => "Sim ganhou dinheiro com makeover";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnedMoneyFromSelfEployment : EventoApenasSim
        {
            public override string EventoId => "kEarnedMoneyFromSelfEployment";
            public override string LegendaPtBr => "Sim ganhou dinheiro empregado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnedSimoleonsFromData : EventoApenasSim
        {
            public override string EventoId => "kEarnedSimoleonsFromData";
            public override string LegendaPtBr => "Sim ganhou simoleons com dados";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnedTipFromTuneUp : EventoApenasSim
        {
            public override string EventoId => "kEarnedTipFromTuneUp";
            public override string LegendaPtBr => "Sim recebeu gorjeta com TuneUp";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnFromSellingAnswers : EventoApenasSim
        {
            public override string EventoId => "kEarnFromSellingAnswers";
            public override string LegendaPtBr => "Sim ganhou vendendo respostas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEarnXTipsWithYourDJBooth : EventoApenasSim
        {
            public override string EventoId => "kEarnXTipsWithYourDJBooth";
            public override string LegendaPtBr => "Sim ganhou gorjetas com DJ";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatAGhostChili : EventoApenasSim
        {
            public override string EventoId => "kEatAGhostChili";
            public override string LegendaPtBr => "Sim comeu pimenta fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatCandyBar : EventoApenasSim
        {
            public override string EventoId => "kEatCandyBar";
            public override string LegendaPtBr => "Sim comeu barra de chocolate";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatHotDog : EventoApenasSim
        {
            public override string EventoId => "kEatHotDog";
            public override string LegendaPtBr => "Sim comeu cachorro-quente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatIEdible : EventoApenasSim
        {
            public override string EventoId => "kEatIEdible";
            public override string LegendaPtBr => "Sim comeu algo comestível";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatIngredient : EventoApenasSim
        {
            public override string EventoId => "kEatIngredient";
            public override string LegendaPtBr => "Sim comeu um ingrediente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatMagicJellyBean : EventoApenasSim
        {
            public override string EventoId => "kEatMagicJellyBean";
            public override string LegendaPtBr => "Sim comeu feijão mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatPie : EventoApenasSim
        {
            public override string EventoId => "kEatPie";
            public override string LegendaPtBr => "Sim comeu torta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatRawFood : EventoApenasSim
        {
            public override string EventoId => "kEatRawFood";
            public override string LegendaPtBr => "Sim comeu comida crua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatSnowCone : EventoApenasSim
        {
            public override string EventoId => "kEatSnowCone";
            public override string LegendaPtBr => "Sim comeu raspadinha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatTrashPile : EventoApenasSim
        {
            public override string EventoId => "kEatTrashPile";
            public override string LegendaPtBr => "Sim comeu lixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEatVampireFruit : EventoApenasSim
        {
            public override string EventoId => "kEatVampireFruit";
            public override string LegendaPtBr => "Sim comeu fruta de vampiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEditGameMovedHouse : EventoApenasSim
        {
            public override string EventoId => "kEditGameMovedHouse";
            public override string LegendaPtBr => "Sim editou mudança de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnchantRoom : EventoApenasSim
        {
            public override string EventoId => "kEnchantRoom";
            public override string LegendaPtBr => "Sim encantou o cômodo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoEnsorcelSim : EventoApenasSim
        {
            public override string EventoId => "kEnsorcelSim";
            public override string LegendaPtBr => "Sim foi enfeitiçado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnteredCrashedShip : EventoApenasSim
        {
            public override string EventoId => "kEnteredCrashedShip";
            public override string LegendaPtBr => "Sim entrou na nave danificada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnteredHorseCompetition : EventoApenasSim
        {
            public override string EventoId => "kEnteredHorseCompetition";
            public override string LegendaPtBr => "Sim entrou na competição equestre";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnteredRabbithole : EventoApenasSim
        {
            public override string EventoId => "kEnteredRabbithole";
            public override string LegendaPtBr => "Sim entrou em um prédio não jogável";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnteredShell : EventoApenasSim
        {
            public override string EventoId => "kEnteredShell";
            public override string LegendaPtBr => "Sim entrou em um prédio cenográfico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnterGardeningCompetition : EventoApenasSim
        {
            public override string EventoId => "kEnterGardeningCompetition";
            public override string LegendaPtBr => "Sim entrou na competição de jardinagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnterHotdogContest : EventoApenasSim
        {
            public override string EventoId => "kEnterHotdogContest";
            public override string LegendaPtBr => "Sim entrou no concurso de cachorro-quente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnterInWorldSubState : EventoRuido
        {
            public override string EventoId => "kEnterInWorldSubState";
            public override string LegendaPtBr => "Sim entrou em sub-estado do mundo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnterMagicPortal : EventoApenasSim
        {
            public override string EventoId => "kEnterMagicPortal";
            public override string LegendaPtBr => "Sim entrou no portal mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnterPieContest : EventoApenasSim
        {
            public override string EventoId => "kEnterPieContest";
            public override string LegendaPtBr => "Sim entrou no concurso de tortas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnterTriviaCompetition : EventoApenasSim
        {
            public override string EventoId => "kEnterTriviaCompetition";
            public override string LegendaPtBr => "Sim entrou na competição de perguntas e respostas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEnthuseAboutComicBooks : EventoApenasSim
        {
            public override string EventoId => "kEnthuseAboutComicBooks";
            public override string LegendaPtBr => "Sim elogiou os quadrinhos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEpicScienceFail : EventoApenasSim
        {
            public override string EventoId => "kEpicScienceFail";
            public override string LegendaPtBr => "Experimento científico falhou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEquestrianCompetition : EventoApenasSim
        {
            public override string EventoId => "kEquestrianCompetition";
            public override string LegendaPtBr => "Sim participou de competição equestre";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEvacuatedTomb : EventoApenasSim
        {
            public override string EventoId => "kEvacuatedTomb";
            public override string LegendaPtBr => "Sim evacuou o túmulo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventCareerChanged : EventoSimEFamilia
        {
            public override string EventoId => "kEventCareerChanged";
            public override string LegendaPtBr => "Sim alterou sua carreira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoEventCareerLevelChanged : EventoSimEFamilia
        {
            public override string EventoId => "kEventCareerLevelChanged";
            public override string LegendaPtBr => "Sim subiu nível na carreira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoEventNone : EventoApenasSim
        {
            public override string EventoId => "kEventNone";
            public override string LegendaPtBr => "Nenhum evento ocorreu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventObjectDisposed : EventoApenasSim
        {
            public override string EventoId => "kEventObjectDisposed";
            public override string LegendaPtBr => "Objeto foi descartado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventSeedPlanted : EventoApenasSim
        {
            public override string EventoId => "kEventSeedPlanted";
            public override string LegendaPtBr => "Sim plantou semente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventSimMovedFromLot : EventoApenasSim
        {
            public override string EventoId => "kEventSimMovedFromLot";
            public override string LegendaPtBr => "Sim saiu do lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventSimMovedToLot : EventoRuido
        {
            public override string EventoId => "kEventSimMovedToLot";
            public override string LegendaPtBr => "Sim chegou a um lote";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventSimMovedToLotOfType : EventoLote
        {
            public override string EventoId => "kEventSimMovedToLotOfType";
            public override string LegendaPtBr => "Sim chegou a lote específico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoEventTakeBath : EventoApenasSim
        {
            public override string EventoId => "kEventTakeBath";
            public override string LegendaPtBr => "Sim tomou banho";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoEventTakeShower : EventoApenasSim
        {
            public override string EventoId => "kEventTakeShower";
            public override string LegendaPtBr => "Sim tomou banho de chuveiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExchangedRings : EventoApenasSim
        {
            public override string EventoId => "kExchangedRings";
            public override string LegendaPtBr => "Sims trocaram alianças";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExitedRabbithole : EventoApenasSim
        {
            public override string EventoId => "kExitedRabbithole";
            public override string LegendaPtBr => "Sim saiu do trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExitInWorldSubState : EventoApenasMundo
        {
            public override string EventoId => "kExitInWorldSubState";
            public override string LegendaPtBr => "Sim saiu do mundo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExorcisedGhost : EventoApenasSim
        {
            public override string EventoId => "kExorcisedGhost";
            public override string LegendaPtBr => "Sim expulsou um fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExploredDiveWell : EventoApenasSim
        {
            public override string EventoId => "kExploredDiveWell";
            public override string LegendaPtBr => "Sim explorou o poço de mergulho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExploredGeyserRift : EventoApenasSim
        {
            public override string EventoId => "kExploredGeyserRift";
            public override string LegendaPtBr => "Sim explorou a fenda do gêiser";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExploredTheMausoleum : EventoApenasSim
        {
            public override string EventoId => "kExploredTheMausoleum";
            public override string LegendaPtBr => "Sim explorou o mausoléu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExploredUnderwaterCave : EventoApenasSim
        {
            public override string EventoId => "kExploredUnderwaterCave";
            public override string LegendaPtBr => "Sim explorou a caverna subaquática";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExploredVaultOfAntiquity : EventoApenasSim
        {
            public override string EventoId => "kExploredVaultOfAntiquity";
            public override string LegendaPtBr => "Sim explorou o cofre da antiguidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExploreUnderObject : EventoApenasSim
        {
            public override string EventoId => "kExploreUnderObject";
            public override string LegendaPtBr => "Sim explorou sob o objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoExtinguisehdSim : EventoApenasSim
        {
            public override string EventoId => "kExtinguisehdSim";
            public override string LegendaPtBr => "Sim apagou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFailedAtMakingAMove : EventoApenasSim
        {
            public override string EventoId => "kFailedAtMakingAMove";
            public override string LegendaPtBr => "Sim falhou em fazer uma jogada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFairySetBoobyTrap : EventoApenasSim
        {
            public override string EventoId => "kFairySetBoobyTrap";
            public override string LegendaPtBr => "Fada armou uma armadilha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFairyTrickedSim : EventoApenasSim
        {
            public override string EventoId => "kFairyTrickedSim";
            public override string LegendaPtBr => "Fada enganou um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFallHolidayStarted : EventoApenasSim
        {
            public override string EventoId => "kFallHolidayStarted";
            public override string LegendaPtBr => "Festa de Outono começou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFamilyFundsChanged : EventoSimEFamilia
        {
            public override string EventoId => "kFamilyFundsChanged";
            public override string LegendaPtBr => "Fundos da família mudaram";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }





        internal sealed class EventoFeastPartyScheduled : EventoSimEFamilia
        {
            public override string EventoId => "kFeastPartyScheduled";
            public override string LegendaPtBr => "Festa de fartura foi agendada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFeaturedItemClicked : EventoApenasSim
        {
            public override string EventoId => "kFeaturedItemClicked";
            public override string LegendaPtBr => "Sim clicou no item destacado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFeaturedItemViewed : EventoApenasSim
        {
            public override string EventoId => "kFeaturedItemViewed";
            public override string LegendaPtBr => "Sim visualizou o item destacado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFedBees : EventoApenasSim
        {
            public override string EventoId => "kFedBees";
            public override string LegendaPtBr => "Sim alimentou as abelhas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFeedHorseByHand : EventoApenasSim
        {
            public override string EventoId => "kFeedHorseByHand";
            public override string LegendaPtBr => "Sim alimentou o cavalo à mão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFeedWildHorse : EventoApenasSim
        {
            public override string EventoId => "kFeedWildHorse";
            public override string LegendaPtBr => "Sim alimentou o cavalo selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFellInPool : EventoApenasSim
        {
            public override string EventoId => "kFellInPool";
            public override string LegendaPtBr => "Sim caiu na piscina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFellOffBoard : EventoApenasSim
        {
            public override string EventoId => "kFellOffBoard";
            public override string LegendaPtBr => "Sim caiu do tabuleiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFellOnTreadmill : EventoApenasSim
        {
            public override string EventoId => "kFellOnTreadmill";
            public override string LegendaPtBr => "Sim caiu na esteira";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFertilizedPlant : EventoApenasSim
        {
            public override string EventoId => "kFertilizedPlant";
            public override string LegendaPtBr => "Sim fertilizou a planta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoFilledPetBowl : EventoApenasSim
        {
            public override string EventoId => "kFilledPetBowl";
            public override string LegendaPtBr => "Sim encheu a tigela do animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFillWaterTrough : EventoApenasSim
        {
            public override string EventoId => "kFillWaterTrough";
            public override string LegendaPtBr => "Sim encheu o bebedouro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFindOutPetPregnant : EventoApenasSim
        {
            public override string EventoId => "kFindOutPetPregnant";
            public override string LegendaPtBr => "Sim descobriu que o animal está grávida";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoFinishedBook : EventoApenasSim
        {
            public override string EventoId => "kFinishedBook";
            public override string LegendaPtBr => "Sim terminou de ler o livro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoFinishedMyScheduledProtest : EventoApenasSim
        {
            public override string EventoId => "kFinishedMyScheduledProtest";
            public override string LegendaPtBr => "Sim terminou o protesto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFinishedPainting : EventoApenasSim
        {
            public override string EventoId => "kFinishedPainting";
            public override string LegendaPtBr => "Sim terminou a pintura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoFinishedWork : EventoApenasSim
        {
            public override string EventoId => "kFinishedWork";
            public override string LegendaPtBr => "Sim terminou o trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFireBlastStartedFire : EventoApenasSim
        {
            public override string EventoId => "kFireBlastStartedFire";
            public override string LegendaPtBr => "Magia causou um incêndio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFirefighterHandleEmergencies : EventoApenasSim
        {
            public override string EventoId => "kFirefighterHandleEmergencies";
            public override string LegendaPtBr => "Bombeiro atendeu emergências";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFirefighterImproveFireEngine : EventoApenasSim
        {
            public override string EventoId => "kFirefighterImproveFireEngine";
            public override string LegendaPtBr => "Bombeiro melhorou o caminhão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFirefighterPutOutFire : EventoApenasSim
        {
            public override string EventoId => "kFirefighterPutOutFire";
            public override string LegendaPtBr => "Bombeiro apagou o incêndio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFirefighterSaveSims : EventoApenasSim
        {
            public override string EventoId => "kFirefighterSaveSims";
            public override string LegendaPtBr => "Bombeiro salvou Sims";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFirefighterUpgradeExtinguisher : EventoApenasSim
        {
            public override string EventoId => "kFirefighterUpgradeExtinguisher";
            public override string LegendaPtBr => "Bombeiro aprimorou extintor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFireOrSmokeEmission : EventoApenasSim
        {
            public override string EventoId => "kFireOrSmokeEmission";
            public override string LegendaPtBr => "Sim emitiu fumaça e fogo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFitnessChanged : EventoApenasSim
        {
            public override string EventoId => "kFitnessChanged";
            public override string LegendaPtBr => "Sim alterou nível de condicionamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFiveStarBlogger : EventoApenasSim
        {
            public override string EventoId => "kFiveStarBlogger";
            public override string LegendaPtBr => "Sim se tornou blogueiro cinco estrelas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFixedProblemChild : EventoSimEFamilia
        {
            public override string EventoId => "kFixedProblemChild";
            public override string LegendaPtBr => "Sim corrigiu criança problemática";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoFlowerKiss : EventoApenasSim
        {
            public override string EventoId => "kFlowerKiss";
            public override string LegendaPtBr => "Sim beijou uma flor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFlyAround : EventoApenasSim
        {
            public override string EventoId => "kFlyAround";
            public override string LegendaPtBr => "Sim voou pelo ar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoalBottleFedBySim : EventoApenasSim
        {
            public override string EventoId => "kFoalBottleFedBySim";
            public override string LegendaPtBr => "Sim alimentou potrinho com garrafa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoalNursedFromMother : EventoApenasSim
        {
            public override string EventoId => "kFoalNursedFromMother";
            public override string LegendaPtBr => "Potrinho mamou da mãe";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoFought : EventoApenasSim
        {
            public override string EventoId => "kFought";
            public override string LegendaPtBr => "Sim lutou com outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoughtAShark : EventoApenasSim
        {
            public override string EventoId => "kFoughtAShark";
            public override string LegendaPtBr => "Sim lutou contra um tubarão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundAncientCoins : EventoApenasSim
        {
            public override string EventoId => "kFoundAncientCoins";
            public override string LegendaPtBr => "Sim encontrou moedas antigas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundAnyEgg : EventoApenasSim
        {
            public override string EventoId => "kFoundAnyEgg";
            public override string LegendaPtBr => "Sim encontrou um ovo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundDarkMatter : EventoApenasSim
        {
            public override string EventoId => "kFoundDarkMatter";
            public override string LegendaPtBr => "Sim encontrou matéria escura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundHiddenDoor : EventoApenasSim
        {
            public override string EventoId => "kFoundHiddenDoor";
            public override string LegendaPtBr => "Sim descobriu porta escondida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundMapFrag : EventoApenasSim
        {
            public override string EventoId => "kFoundMapFrag";
            public override string LegendaPtBr => "Sim achou fragmento de mapa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundObjectWhileSnorkeling : EventoApenasSim
        {
            public override string EventoId => "kFoundObjectWhileSnorkeling";
            public override string LegendaPtBr => "Sim encontrou objeto mergulhando";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundOutIfSimIsRich : EventoApenasSim
        {
            public override string EventoId => "kFoundOutIfSimIsRich";
            public override string LegendaPtBr => "Sim descobriu se é rico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoFoundSpecialEgg : EventoApenasSim
        {
            public override string EventoId => "kFoundSpecialEgg";
            public override string LegendaPtBr => "Sim achou ovo especial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFoundStarDust : EventoApenasSim
        {
            public override string EventoId => "kFoundStarDust";
            public override string LegendaPtBr => "Sim encontrou pó de estrelas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFrankensimLearned : EventoApenasSim
        {
            public override string EventoId => "kFrankensimLearned";
            public override string LegendaPtBr => "Frankensim aprendeu algo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFreakedOut : EventoApenasSim
        {
            public override string EventoId => "kFreakedOut";
            public override string LegendaPtBr => "Sim se assustou muito";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFreeGenie : EventoApenasSim
        {
            public override string EventoId => "kFreeGenie";
            public override string LegendaPtBr => "Sim libertou um gênio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFreeItemFromVendingMachine : EventoApenasSim
        {
            public override string EventoId => "kFreeItemFromVendingMachine";
            public override string LegendaPtBr => "Sim pegou item de máquina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFrozeGenieLamp : EventoApenasSim
        {
            public override string EventoId => "kFrozeGenieLamp";
            public override string LegendaPtBr => "Sim congelou a lâmpada do gênio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoFrozenSolid : EventoApenasSim
        {
            public override string EventoId => "kFrozenSolid";
            public override string LegendaPtBr => "Sim congelou completamente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoFullMoonTransformation : EventoApenasSim
        {
            public override string EventoId => "kFullMoonTransformation";
            public override string LegendaPtBr => "Sim se transformou na lua cheia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoGainCelebrityPoints : EventoApenasSim
        {
            public override string EventoId => "kGainCelebrityPoints";
            public override string LegendaPtBr => "Sim ganhou pontos de fama";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGainedReinforcementTrait : EventoApenasSim
        {
            public override string EventoId => "kGainedReinforcementTrait";
            public override string LegendaPtBr => "Sim obteve traço de reforço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGainedTimeStatue : EventoApenasSim
        {
            public override string EventoId => "kGainedTimeStatue";
            public override string LegendaPtBr => "Sim recebeu estátua do tempo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevAttendVideoGameConvention : EventoApenasSim
        {
            public override string EventoId => "kGameDevAttendVideoGameConvention";
            public override string LegendaPtBr => "Dev jogou em convenção";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevBarThenCrunch : EventoApenasSim
        {
            public override string EventoId => "kGameDevBarThenCrunch";
            public override string LegendaPtBr => "Dev bebeu e trabalhou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDeveloperJob : EventoApenasSim
        {
            public override string EventoId => "kGameDeveloperJob";
            public override string LegendaPtBr => "Dev começou trabalho de desenvolvedor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevHoldConvention : EventoApenasSim
        {
            public override string EventoId => "kGameDevHoldConvention";
            public override string LegendaPtBr => "Dev organizou convenção";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevPlayArcadeGame : EventoApenasSim
        {
            public override string EventoId => "kGameDevPlayArcadeGame";
            public override string LegendaPtBr => "Dev jogou fliperama";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevPlayComputerGame : EventoApenasSim
        {
            public override string EventoId => "kGameDevPlayComputerGame";
            public override string LegendaPtBr => "Dev jogou computador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevPlayConsoleGame : EventoApenasSim
        {
            public override string EventoId => "kGameDevPlayConsoleGame";
            public override string LegendaPtBr => "Dev jogou console";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGameDevWorkAtHome : EventoApenasSim
        {
            public override string EventoId => "kGameDevWorkAtHome";
            public override string LegendaPtBr => "Dev trabalhou em casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoGamePlayed : EventoApenasSim
        {
            public override string EventoId => "kGamePlayed";
            public override string LegendaPtBr => "Sim jogou um jogo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoGardened : EventoApenasSim
        {
            public override string EventoId => "kGardened";
            public override string LegendaPtBr => "Sim cuidou do jardim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGaveAFairyGift : EventoApenasSim
        {
            public override string EventoId => "kGaveAFairyGift";
            public override string LegendaPtBr => "Sim ofereceu um presente de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGaveEducationLecture : EventoApenasSim
        {
            public override string EventoId => "kGaveEducationLecture";
            public override string LegendaPtBr => "Sim ministrou aula de educação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGaveFashionAdvice : EventoApenasSim
        {
            public override string EventoId => "kGaveFashionAdvice";
            public override string LegendaPtBr => "Sim deu conselhos de moda";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGaveHorseHug : EventoApenasSim
        {
            public override string EventoId => "kGaveHorseHug";
            public override string LegendaPtBr => "Sim abraçou um cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGaveMakeover : EventoApenasSim
        {
            public override string EventoId => "kGaveMakeover";
            public override string LegendaPtBr => "Sim fez um makeover";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGavePetFleaBath : EventoApenasSim
        {
            public override string EventoId => "kGavePetFleaBath";
            public override string LegendaPtBr => "Sim deu banho no pet";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGavePrivateReading : EventoApenasSim
        {
            public override string EventoId => "kGavePrivateReading";
            public override string LegendaPtBr => "Sim fez uma leitura privada";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGenderPreferencesChanged : EventoApenasSim
        {
            public override string EventoId => "kGenderPreferencesChanged";
            public override string LegendaPtBr => "Sim mudou preferências de gênero";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGetGeniusIQ : EventoApenasSim
        {
            public override string EventoId => "kGetGeniusIQ";
            public override string LegendaPtBr => "Sim obteve QI de gênio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGetLoveLetterFromSim : EventoApenasSim
        {
            public override string EventoId => "kGetLoveLetterFromSim";
            public override string LegendaPtBr => "Sim recebeu carta de amor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGetMailSuccess : EventoApenasSim
        {
            public override string EventoId => "kGetMailSuccess";
            public override string LegendaPtBr => "Sim recebeu a correspondência";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGetMetalsSmelted : EventoApenasSim
        {
            public override string EventoId => "kGetMetalsSmelted";
            public override string LegendaPtBr => "Sim fundiu minérios";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGetNCutGems : EventoApenasSim
        {
            public override string EventoId => "kGetNCutGems";
            public override string LegendaPtBr => "Sim cortou gemas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGetPetToyFromCrate : EventoApenasSim
        {
            public override string EventoId => "kGetPetToyFromCrate";
            public override string LegendaPtBr => "Sim pegou brinquedo do cesto";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGhostHunterCaptureXSpirits : EventoApenasSim
        {
            public override string EventoId => "kGhostHunterCaptureXSpirits";
            public override string LegendaPtBr => "Caçador capturou espíritos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGhostHunterDonateXSpirits : EventoApenasSim
        {
            public override string EventoId => "kGhostHunterDonateXSpirits";
            public override string LegendaPtBr => "Caçador doou espíritos";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGhostHunterLookForSpirits : EventoApenasSim
        {
            public override string EventoId => "kGhostHunterLookForSpirits";
            public override string LegendaPtBr => "Caçador procurou espíritos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGiftGivingPartyScheduled : EventoSimEFamilia
        {
            public override string EventoId => "kGiftGivingPartyScheduled";
            public override string LegendaPtBr => "Sim agendou festa de presentes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGiftSentToFriend : EventoApenasSim
        {
            public override string EventoId => "kGiftSentToFriend";
            public override string LegendaPtBr => "Sim enviou presente ao amigo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGiveSimATrackMix : EventoApenasSim
        {
            public override string EventoId => "kGiveSimATrackMix";
            public override string LegendaPtBr => "Sim deu mix de faixas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGiveSimWerewolfCurse : EventoApenasSim
        {
            public override string EventoId => "kGiveSimWerewolfCurse";
            public override string LegendaPtBr => "Sim deu maldição de lobisomem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGiveSimWhatFor : EventoApenasSim
        {
            public override string EventoId => "kGiveSimWhatFor";
            public override string LegendaPtBr => "Sim deu um tapa no outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoFishingCat : EventoApenasSim
        {
            public override string EventoId => "kGoFishingCat";
            public override string LegendaPtBr => "Gato foi pescar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoHomeButtonClicked : EventoApenasSim
        {
            public override string EventoId => "kGoHomeButtonClicked";
            public override string LegendaPtBr => "Sim clicou em \"ir para casa\"";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoHotTubbing : EventoApenasSim
        {
            public override string EventoId => "kGoHotTubbing";
            public override string LegendaPtBr => "Sim foi para a banheira de hidromassagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoHuntingCat : EventoApenasSim
        {
            public override string EventoId => "kGoHuntingCat";
            public override string LegendaPtBr => "Gato foi caçar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGolfBreakTeeRecord : EventoApenasSim
        {
            public override string EventoId => "kGolfBreakTeeRecord";
            public override string LegendaPtBr => "Sim quebrou recorde no tee";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGolfPlaySomeGolf : EventoApenasSim
        {
            public override string EventoId => "kGolfPlaySomeGolf";
            public override string LegendaPtBr => "Sim jogou golfe";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoneWindsurfing : EventoApenasSim
        {
            public override string EventoId => "kGoneWindsurfing";
            public override string LegendaPtBr => "Sim praticou windsurf";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoOnAnEggHunt : EventoApenasSim
        {
            public override string EventoId => "kGoOnAnEggHunt";
            public override string LegendaPtBr => "Sim participou da caça aos ovos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoSkinnyDipping : EventoApenasSim
        {
            public override string EventoId => "kGoSkinnyDipping";
            public override string LegendaPtBr => "Sim nadou nu em lago";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoStreaking : EventoApenasSim
        {
            public override string EventoId => "kGoStreaking";
            public override string LegendaPtBr => "Sim correu nu na rua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGoStreakingDuringDay : EventoApenasSim
        {
            public override string EventoId => "kGoStreakingDuringDay";
            public override string LegendaPtBr => "Sim correu nu durante o dia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotAFairyGift : EventoApenasSim
        {
            public override string EventoId => "kGotAFairyGift";
            public override string LegendaPtBr => "Sim recebeu presente de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotAllergyShot : EventoApenasSim
        {
            public override string EventoId => "kGotAllergyShot";
            public override string LegendaPtBr => "Sim tomou injeção contra alergia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotBuff : EventoRuido
        {
            public override string EventoId => "kGotBuff";
            public override string LegendaPtBr => "Sim recebeu um efeito";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoGotChildAndAgeTransition : EventoSimEFamilia
        {
            public override string EventoId => "kGotChildAndAgeTransition";
            public override string LegendaPtBr => "Sim mudou de idade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotColdShowerBuff : EventoApenasSim
        {
            public override string EventoId => "kGotColdShowerBuff";
            public override string LegendaPtBr => "Sim recebeu banho frio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoGotFleaBath : EventoApenasSim
        {
            public override string EventoId => "kGotFleaBath";
            public override string LegendaPtBr => "Sim tomou banho para pulgas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotFleas : EventoApenasSim
        {
            public override string EventoId => "kGotFleas";
            public override string LegendaPtBr => "Sim pegou pulgas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotFluShot : EventoApenasSim
        {
            public override string EventoId => "kGotFluShot";
            public override string LegendaPtBr => "Sim tomou vacina contra gripe";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotInABarBrawl : EventoApenasSim
        {
            public override string EventoId => "kGotInABarBrawl";
            public override string LegendaPtBr => "Sim brigou em um bar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotMakeover : EventoApenasSim
        {
            public override string EventoId => "kGotMakeover";
            public override string LegendaPtBr => "Sim recebeu um makeover";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotMassage : EventoApenasSim
        {
            public override string EventoId => "kGotMassage";
            public override string LegendaPtBr => "Sim recebeu uma massagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoGotMoneyFromGig : EventoApenasSim
        {
            public override string EventoId => "kGotMoneyFromGig";
            public override string LegendaPtBr => "Sim ganhou dinheiro com trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotNewPersonality : EventoApenasSim
        {
            public override string EventoId => "kGotNewPersonality";
            public override string LegendaPtBr => "Sim adquiriu nova personalidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotNoResponseToForumPost : EventoApenasSim
        {
            public override string EventoId => "kGotNoResponseToForumPost";
            public override string LegendaPtBr => "Sim não obteve resposta no fórum";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotPaid : EventoApenasSim
        {
            public override string EventoId => "kGotPaid";
            public override string LegendaPtBr => "Sim recebeu pagamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoGotResponseToForumPost : EventoApenasSim
        {
            public override string EventoId => "kGotResponseToForumPost";
            public override string LegendaPtBr => "Sim obteve resposta no fórum";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotRoundedUp : EventoApenasSim
        {
            public override string EventoId => "kGotRoundedUp";
            public override string LegendaPtBr => "Sim foi preso por autoridades";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotSavedByDeathFlower : EventoApenasSim
        {
            public override string EventoId => "kGotSavedByDeathFlower";
            public override string LegendaPtBr => "Sim foi salvo pela Flor da Morte";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoGotSprayTan : EventoApenasSim
        {
            public override string EventoId => "kGotSprayTan";
            public override string LegendaPtBr => "Sim fez bronzeamento artificial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotTattoo : EventoApenasSim
        {
            public override string EventoId => "kGotTattoo";
            public override string LegendaPtBr => "Sim fez uma tatuagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotTips : EventoApenasSim
        {
            public override string EventoId => "kGotTips";
            public override string LegendaPtBr => "Sim recebeu gorjetas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotTipsFromSpellcasting : EventoApenasSim
        {
            public override string EventoId => "kGotTipsFromSpellcasting";
            public override string LegendaPtBr => "Sim recebeu dicas de feitiçaria";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotTrappedInElevatorDoors : EventoApenasSim
        {
            public override string EventoId => "kGotTrappedInElevatorDoors";
            public override string LegendaPtBr => "Sim ficou preso nas portas do elevador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotWeddingGift : EventoSimEFamilia
        {
            public override string EventoId => "kGotWeddingGift";
            public override string LegendaPtBr => "Sim recebeu presente de casamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGotWeeklyRoyaltyRate : EventoApenasSim
        {
            public override string EventoId => "kGotWeeklyRoyaltyRate";
            public override string LegendaPtBr => "Sim recebeu taxa de realeza semanal";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGrabbedByUnderwaterCaveTentacle : EventoApenasSim
        {
            public override string EventoId => "kGrabbedByUnderwaterCaveTentacle";
            public override string LegendaPtBr => "Sim foi agarrado por tentáculo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoGrantedWishToFreeGenie : EventoApenasSim
        {
            public override string EventoId => "kGrantedWishToFreeGenie";
            public override string LegendaPtBr => "Sim libertou um gênio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoGreenGardens : EventoApenasSim
        {
            public override string EventoId => "kGreenGardens";
            public override string LegendaPtBr => "Sim obteve jardins verdes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGreetDescendant : EventoApenasSim
        {
            public override string EventoId => "kGreetDescendant";
            public override string LegendaPtBr => "Sim cumprimentou um descendente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGrewHarvestable : EventoApenasSim
        {
            public override string EventoId => "kGrewHarvestable";
            public override string LegendaPtBr => "Sim colheu algo cultivado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGrewPlantToMaturity : EventoApenasSim
        {
            public override string EventoId => "kGrewPlantToMaturity";
            public override string LegendaPtBr => "Sim viu planta amadurecer";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGrilled : EventoApenasSim
        {
            public override string EventoId => "kGrilled";
            public override string LegendaPtBr => "Sim grelhava comida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGroupingWithSim : EventoApenasSim
        {
            public override string EventoId => "kGroupingWithSim";
            public override string LegendaPtBr => "Sim interagiu com outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGuardHome : EventoApenasSim
        {
            public override string EventoId => "kGuardHome";
            public override string LegendaPtBr => "Sim guardou a casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGuardObject : EventoApenasSim
        {
            public override string EventoId => "kGuardObject";
            public override string LegendaPtBr => "Sim guardou um objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoGuitarSerenaded : EventoApenasSim
        {
            public override string EventoId => "kGuitarSerenaded";
            public override string LegendaPtBr => "Sim serenou com violão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHacked : EventoApenasSim
        {
            public override string EventoId => "kHacked";
            public override string LegendaPtBr => "Sim invadiu o computador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHackedOntoClubListings : EventoApenasSim
        {
            public override string EventoId => "kHackedOntoClubListings";
            public override string LegendaPtBr => "Sim hackeou lista de clubes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHadADrink : EventoApenasSim
        {
            public override string EventoId => "kHadADrink";
            public override string LegendaPtBr => "Sim bebeu uma bebida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHadAPicnic : EventoApenasSim
        {
            public override string EventoId => "kHadAPicnic";
            public override string LegendaPtBr => "Sim fez um piquenique";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHadBaby : EventoSimEFamilia
        {
            public override string EventoId => "kHadBaby";
            public override string LegendaPtBr => "Sim teve um bebê";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHadDream : EventoApenasSim
        {
            public override string EventoId => "kHadDream";
            public override string LegendaPtBr => "Sim teve um sonho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }





        internal sealed class EventoHadFortuneTold : EventoApenasSim
        {
            public override string EventoId => "kHadFortuneTold";
            public override string LegendaPtBr => "Sim teve a sorte lida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoHarassWithCane : EventoApenasSim
        {
            public override string EventoId => "kHarassWithCane";
            public override string LegendaPtBr => "Sim aterrorizou com o chicote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoHarvestedHoney : EventoApenasSim
        {
            public override string EventoId => "kHarvestedHoney";
            public override string LegendaPtBr => "Sim colheu mel da colmeia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHarvestPlantKindness : EventoApenasSim
        {
            public override string EventoId => "kHarvestPlantKindness";
            public override string LegendaPtBr => "Sim colheu planta da bondade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHarvestPlantLaughter : EventoApenasSim
        {
            public override string EventoId => "kHarvestPlantLaughter";
            public override string LegendaPtBr => "Sim colheu planta da alegria";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHarvestPlantLove : EventoApenasSim
        {
            public override string EventoId => "kHarvestPlantLove";
            public override string LegendaPtBr => "Sim colheu planta do amor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHarvestPlantRage : EventoApenasSim
        {
            public override string EventoId => "kHarvestPlantRage";
            public override string LegendaPtBr => "Sim colheu planta da raiva";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHasLamp : EventoApenasSim
        {
            public override string EventoId => "kHasLamp";
            public override string LegendaPtBr => "Sim possui uma luminária";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHasNegativeEnvironmentScore : EventoRuido
        {
            public override string EventoId => "kHasNegativeEnvironmentScore";
            public override string LegendaPtBr => "Sim teve nota baixa no ambiente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveDewFight : EventoApenasSim
        {
            public override string EventoId => "kHaveDewFight";
            public override string LegendaPtBr => "Sim brigou em uma luta de orvalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveFacePainted : EventoApenasSim
        {
            public override string EventoId => "kHaveFacePainted";
            public override string LegendaPtBr => "Sim teve o rosto pintado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveFortuneTold : EventoApenasSim
        {
            public override string EventoId => "kHaveFortuneTold";
            public override string LegendaPtBr => "Sim teve a sorte lida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveGrade : EventoApenasSim
        {
            public override string EventoId => "kHaveGrade";
            public override string LegendaPtBr => "Sim obteve uma nota na escola";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveGreatGrouping : EventoApenasSim
        {
            public override string EventoId => "kHaveGreatGrouping";
            public override string LegendaPtBr => "Sim teve um ótimo agrupamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveSnowballFight : EventoApenasSim
        {
            public override string EventoId => "kHaveSnowballFight";
            public override string LegendaPtBr => "Sim brigou em uma guerra de bolas de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHaveWaterBalloonFight : EventoApenasSim
        {
            public override string EventoId => "kHaveWaterBalloonFight";
            public override string LegendaPtBr => "Sim brigou em uma guerra de balões d'água";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHeardSimCry : EventoApenasSim
        {
            public override string EventoId => "kHeardSimCry";
            public override string LegendaPtBr => "Sim ouviu outro Sim chorar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHeatedGenieLamp : EventoApenasSim
        {
            public override string EventoId => "kHeatedGenieLamp";
            public override string LegendaPtBr => "Sim desejou algo da lâmpada";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHeckleSim : EventoApenasSim
        {
            public override string EventoId => "kHeckleSim";
            public override string LegendaPtBr => "Sim zombou de outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHeldPsychicConvention : EventoApenasSim
        {
            public override string EventoId => "kHeldPsychicConvention";
            public override string LegendaPtBr => "Sim presidiu convenção psíquica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHeldSuccessfulFreeClinic : EventoApenasSim
        {
            public override string EventoId => "kHeldSuccessfulFreeClinic";
            public override string LegendaPtBr => "Sim realizou clínica gratuita";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHeldSuccessfulVaccinationSession : EventoApenasSim
        {
            public override string EventoId => "kHeldSuccessfulVaccinationSession";
            public override string LegendaPtBr => "Sim realizou sessão de vacinação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHelpedWithHomework : EventoApenasSim
        {
            public override string EventoId => "kHelpedWithHomework";
            public override string LegendaPtBr => "Sim ajudou com o dever";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoHighFiveSim : EventoApenasSim
        {
            public override string EventoId => "kHighFiveSim";
            public override string LegendaPtBr => "Sim deu um high five";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoHighTechCollector : EventoApenasSim
        {
            public override string EventoId => "kHighTechCollector";
            public override string LegendaPtBr => "Sim colecionou tecnologia avançada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHissAt : EventoApenasSim
        {
            public override string EventoId => "kHissAt";
            public override string LegendaPtBr => "Sim sibilou para outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHistoryLessonAtVaultOfAntiquity : EventoApenasSim
        {
            public override string EventoId => "kHistoryLessonAtVaultOfAntiquity";
            public override string LegendaPtBr => "Sim aprendeu história no cofre";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHitWithCloudBy : EventoApenasSim
        {
            public override string EventoId => "kHitWithCloudBy";
            public override string LegendaPtBr => "Sim foi atingido por nuvem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHomeValueIncreasedInBB : EventoApenasSim
        {
            public override string EventoId => "kHomeValueIncreasedInBB";
            public override string LegendaPtBr => "Valor da casa aumentou no BB";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHopOn : EventoApenasSim
        {
            public override string EventoId => "kHopOn";
            public override string LegendaPtBr => "Sim subiu em algo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseGraze : EventoApenasSim
        {
            public override string EventoId => "kHorseGraze";
            public override string LegendaPtBr => "Cavalo pastou na relva";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseNap : EventoApenasSim
        {
            public override string EventoId => "kHorseNap";
            public override string LegendaPtBr => "Cavalo tirou uma soneca";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseNickerAt : EventoApenasSim
        {
            public override string EventoId => "kHorseNickerAt";
            public override string LegendaPtBr => "Cavalo relinchou para alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorsePlayedWithBall : EventoApenasSim
        {
            public override string EventoId => "kHorsePlayedWithBall";
            public override string LegendaPtBr => "Cavalo brincou com a bola";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseReceivedHug : EventoApenasSim
        {
            public override string EventoId => "kHorseReceivedHug";
            public override string LegendaPtBr => "Sim abraçou o cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseRodeBySim : EventoApenasSim
        {
            public override string EventoId => "kHorseRodeBySim";
            public override string LegendaPtBr => "Sim montou no cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseScratchBack : EventoApenasSim
        {
            public override string EventoId => "kHorseScratchBack";
            public override string LegendaPtBr => "Cavalo coçou as costas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHorseWinny : EventoApenasSim
        {
            public override string EventoId => "kHorseWinny";
            public override string LegendaPtBr => "Cavalo berrou alto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHotSpotSelected : EventoApenasSim
        {
            public override string EventoId => "kHotSpotSelected";
            public override string LegendaPtBr => "Sim selecionou um ponto de interação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHouseholdCreated : EventoApenasSim
        {
            public override string EventoId => "kHouseholdCreated";
            public override string LegendaPtBr => "Família foi criada";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHouseholdMerged : EventoApenasSim
        {
            public override string EventoId => "kHouseholdMerged";
            public override string LegendaPtBr => "Famílias se uniram";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHouseholdSelected : EventoApenasSim
        {
            public override string EventoId => "kHouseholdSelected";
            public override string LegendaPtBr => "Família foi selecionada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHouseholdSplit : EventoApenasSim
        {
            public override string EventoId => "kHouseholdSplit";
            public override string LegendaPtBr => "Família se separou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoHunt : EventoApenasSim
        {
            public override string EventoId => "kHunt";
            public override string LegendaPtBr => "Sim caçou animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingAskToFindSomething : EventoApenasSim
        {
            public override string EventoId => "kHuntingAskToFindSomething";
            public override string LegendaPtBr => "Sim pediu para procurar algo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingDugUpSomething : EventoApenasSim
        {
            public override string EventoId => "kHuntingDugUpSomething";
            public override string LegendaPtBr => "Sim desenterrou algo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingFetchedDate : EventoApenasSim
        {
            public override string EventoId => "kHuntingFetchedDate";
            public override string LegendaPtBr => "Sim buscou algo para caçar";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingFoundGem : EventoApenasSim
        {
            public override string EventoId => "kHuntingFoundGem";
            public override string LegendaPtBr => "Sim encontrou uma gema";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingFoundMetal : EventoApenasSim
        {
            public override string EventoId => "kHuntingFoundMetal";
            public override string LegendaPtBr => "Sim encontrou metal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingFoundRock : EventoApenasSim
        {
            public override string EventoId => "kHuntingFoundRock";
            public override string LegendaPtBr => "Sim encontrou uma rocha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingFoundSpecial : EventoApenasSim
        {
            public override string EventoId => "kHuntingFoundSpecial";
            public override string LegendaPtBr => "Sim encontrou algo especial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingHadPetFetchDate : EventoApenasSim
        {
            public override string EventoId => "kHuntingHadPetFetchDate";
            public override string LegendaPtBr => "Animal buscou para caçar";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntingTaughtToHunt : EventoApenasSim
        {
            public override string EventoId => "kHuntingTaughtToHunt";
            public override string LegendaPtBr => "Sim ensinou a caçar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoHuntWithPack : EventoApenasSim
        {
            public override string EventoId => "kHuntWithPack";
            public override string LegendaPtBr => "Sim caçou com o bando";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoImpliedMotherIsLlama : EventoApenasSim
        {
            public override string EventoId => "kImpliedMotherIsLlama";
            public override string LegendaPtBr => "Mãe é uma lhama";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoImpressedCelebritySim : EventoApenasSim
        {
            public override string EventoId => "kImpressedCelebritySim";
            public override string LegendaPtBr => "Sim impressionou celebridade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoImprovedFoodSynthesizer : EventoApenasSim
        {
            public override string EventoId => "kImprovedFoodSynthesizer";
            public override string LegendaPtBr => "Sim melhorou o sintetizador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoImprovedProtestEvent : EventoApenasSim
        {
            public override string EventoId => "kImprovedProtestEvent";
            public override string LegendaPtBr => "Sim melhorou evento de protesto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInspectedMysteriousDoor : EventoApenasSim
        {
            public override string EventoId => "kInspectedMysteriousDoor";
            public override string LegendaPtBr => "Sim examinou a porta misteriosa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInspectedTimePortal : EventoApenasSim
        {
            public override string EventoId => "kInspectedTimePortal";
            public override string LegendaPtBr => "Sim inspecionou o portal temporal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInstalledTraitChip : EventoApenasSim
        {
            public override string EventoId => "kInstalledTraitChip";
            public override string LegendaPtBr => "Sim instalou o chip de traço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInstructedExplainFunction : EventoApenasSim
        {
            public override string EventoId => "kInstructedExplainFunction";
            public override string LegendaPtBr => "Sim explicou a função";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoInteractionCanceled : EventoApenasSim
        {
            public override string EventoId => "kInteractionCanceled";
            public override string LegendaPtBr => "Sim cancelou a interação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteractionSuccess : EventoRuido
        {
            public override string EventoId => "kInteractionSuccess";
            public override string LegendaPtBr => "Sim completou a interação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignAssignmentCompleted : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignAssignmentCompleted";
            public override string LegendaPtBr => "Sim finalizou o projeto de design";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignBadReview : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignBadReview";
            public override string LegendaPtBr => "Sim recebeu crítica negativa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignGoodReview : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignGoodReview";
            public override string LegendaPtBr => "Sim recebeu crítica positiva";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignGreatReview : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignGreatReview";
            public override string LegendaPtBr => "Sim recebeu ótima crítica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignPlacedDirtyBrokenObject : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignPlacedDirtyBrokenObject";
            public override string LegendaPtBr => "Sim posicionou objeto quebrado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignPlacedHomemadeObject : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignPlacedHomemadeObject";
            public override string LegendaPtBr => "Sim posicionou objeto caseiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInteriorDesignPlacedPersonalizedObject : EventoApenasSim
        {
            public override string EventoId => "kInteriorDesignPlacedPersonalizedObject";
            public override string LegendaPtBr => "Sim posicionou objeto personalizado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoIntroducedRainbowDew : EventoApenasSim
        {
            public override string EventoId => "kIntroducedRainbowDew";
            public override string LegendaPtBr => "Sim apresentou o Orvalho Arco-Íris";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInvadeCommunityLotUFO : EventoCompleto
        {
            public override string EventoId => "kInvadeCommunityLotUFO";
            public override string LegendaPtBr => "OVNI invadiu o lote comunitário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInventorMadeTimeMachine : EventoApenasSim
        {
            public override string EventoId => "kInventorMadeTimeMachine";
            public override string LegendaPtBr => "Inventor construiu máquina do tempo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInventorMadeWidget : EventoApenasSim
        {
            public override string EventoId => "kInventorMadeWidget";
            public override string LegendaPtBr => "Inventor criou um widget";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInventoryObjectAdded : EventoApenasSim
        {
            public override string EventoId => "kInventoryObjectAdded";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Objeto foi adicionado ao inventário";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoInventoryObjectRemoved : EventoApenasSim
        {
            public override string EventoId => "kInventoryObjectRemoved";
            public override string LegendaPtBr => "Objeto foi removido do inventário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoInvitedSimOver : EventoApenasSim
        {
            public override string EventoId => "kInvitedSimOver";
            public override string LegendaPtBr => "Sim foi convidado para visita";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoInvitedSimToStay : EventoApenasSim
        {
            public override string EventoId => "kInvitedSimToStay";
            public override string LegendaPtBr => "Sim foi convidado para ficar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoIssueTriviaChallenge : EventoApenasSim
        {
            public override string EventoId => "kIssueTriviaChallenge";
            public override string LegendaPtBr => "Sim participou de quiz";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoItemStuckInVendingMachine : EventoApenasSim
        {
            public override string EventoId => "kItemStuckInVendingMachine";
            public override string LegendaPtBr => "Item ficou preso na máquina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJamWithSim : EventoApenasSim
        {
            public override string EventoId => "kJamWithSim";
            public override string LegendaPtBr => "Sim tocou junto com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJetPackFlyAround : EventoApenasSim
        {
            public override string EventoId => "kJetPackFlyAround";
            public override string LegendaPtBr => "Sim voou com jetpack";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJockeyEvent : EventoApenasSim
        {
            public override string EventoId => "kJockeyEvent";
            public override string LegendaPtBr => "Sim participou de corrida de cavalos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJogged : EventoApenasSim
        {
            public override string EventoId => "kJogged";
            public override string LegendaPtBr => "Sim correu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJoggingTimeAdded : EventoApenasSim
        {
            public override string EventoId => "kJoggingTimeAdded";
            public override string LegendaPtBr => "Sim correu na esteira";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJoinGameWardenBranch : EventoApenasSim
        {
            public override string EventoId => "kJoinGameWardenBranch";
            public override string LegendaPtBr => "Sim se juntou à Guarda";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJoinMechanicBranch : EventoApenasSim
        {
            public override string EventoId => "kJoinMechanicBranch";
            public override string LegendaPtBr => "Sim se juntou ao Mecânico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJuiceKegPerformKegStand : EventoApenasSim
        {
            public override string EventoId => "kJuiceKegPerformKegStand";
            public override string LegendaPtBr => "Sim fez cambalhota no barril";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJuiceKegPourJuice : EventoApenasSim
        {
            public override string EventoId => "kJuiceKegPourJuice";
            public override string LegendaPtBr => "Sim serviu suco do barril";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJumpedObject : EventoApenasSim
        {
            public override string EventoId => "kJumpedObject";
            public override string LegendaPtBr => "Sim pulou no objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJumpedOnTrampoline : EventoApenasSim
        {
            public override string EventoId => "kJumpedOnTrampoline";
            public override string LegendaPtBr => "Sim pulou no trampolim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoJumpEvent : EventoApenasSim
        {
            public override string EventoId => "kJumpEvent";
            public override string LegendaPtBr => "Sim pulou para longe";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoKissedUnderFullMoon : EventoApenasSim
        {
            public override string EventoId => "kKissedUnderFullMoon";
            public override string LegendaPtBr => "Sim beijou sob a lua cheia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoKissedUnderMistletoe : EventoApenasSim
        {
            public override string EventoId => "kKissedUnderMistletoe";
            public override string LegendaPtBr => "Sim beijou embaixo de visco";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoKissingBoothKiss : EventoApenasSim
        {
            public override string EventoId => "kKissingBoothKiss";
            public override string LegendaPtBr => "Sim beijou no quiosque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLaidSimToRestInGraveyard : EventoApenasSim
        {
            public override string EventoId => "kLaidSimToRestInGraveyard";
            public override string LegendaPtBr => "Sim repousou Sim no cemitério";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLargeBirdDied : EventoApenasSim
        {
            public override string EventoId => "kLargeBirdDied";
            public override string LegendaPtBr => "Grande pássaro morreu";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoLaserHarpSerenaded : EventoApenasSim
        {
            public override string EventoId => "kLaserHarpSerenaded";
            public override string LegendaPtBr => "Sim serenou com a harpa a laser";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLeadHorse : EventoApenasSim
        {
            public override string EventoId => "kLeadHorse";
            public override string LegendaPtBr => "Sim liderou o cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnAlchemyObject : EventoApenasSim
        {
            public override string EventoId => "kLearnAlchemyObject";
            public override string LegendaPtBr => "Sim aprendeu alquimia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedBait : EventoApenasSim
        {
            public override string EventoId => "kLearnedBait";
            public override string LegendaPtBr => "Sim aprendeu a preparar iscas";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedBassComposition : EventoApenasSim
        {
            public override string EventoId => "kLearnedBassComposition";
            public override string LegendaPtBr => "Sim aprendeu composição de baixo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLearnedDrumsComposition : EventoApenasSim
        {
            public override string EventoId => "kLearnedDrumsComposition";
            public override string LegendaPtBr => "Sim aprendeu composição de bateria";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedFavoriteFood : EventoApenasSim
        {
            public override string EventoId => "kLearnedFavoriteFood";
            public override string LegendaPtBr => "Sim aprendeu comida favorita";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedLaserHarpComposition : EventoApenasSim
        {
            public override string EventoId => "kLearnedLaserHarpComposition";
            public override string LegendaPtBr => "Sim aprendeu composição de harpa laser";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedMindMeld : EventoApenasSim
        {
            public override string EventoId => "kLearnedMindMeld";
            public override string LegendaPtBr => "Sim aprendeu a telepatia";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedOccupationOfOtherSim : EventoApenasSim
        {
            public override string EventoId => "kLearnedOccupationOfOtherSim";
            public override string LegendaPtBr => "Sim aprendeu profissão alheia";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnedPianoComposition : EventoApenasSim
        {
            public override string EventoId => "kLearnedPianoComposition";
            public override string LegendaPtBr => "Sim aprendeu composição de piano";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLearnedSign : EventoApenasSim
        {
            public override string EventoId => "kLearnedSign";
            public override string LegendaPtBr => "Sim aprendeu a ler sinais";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLearnTofuRecipe : EventoApenasSim
        {
            public override string EventoId => "kLearnTofuRecipe";
            public override string LegendaPtBr => "Sim aprendeu receita de tofu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnTrickShotCup : EventoApenasSim
        {
            public override string EventoId => "kLearnTrickShotCup";
            public override string LegendaPtBr => "Sim aprendeu truque com xícaras";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnTrickShotEP6Trick1 : EventoApenasSim
        {
            public override string EventoId => "kLearnTrickShotEP6Trick1";
            public override string LegendaPtBr => "Sim aprendeu arremesso de truque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnTrickShotEP6Trick2 : EventoApenasSim
        {
            public override string EventoId => "kLearnTrickShotEP6Trick2";
            public override string LegendaPtBr => "Sim aprendeu arremesso de truque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLearnTrickShotXylophone : EventoApenasSim
        {
            public override string EventoId => "kLearnTrickShotXylophone";
            public override string LegendaPtBr => "Sim aprendeu tocar xilofone";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLeftConversation : EventoRuido
        {
            public override string EventoId => "kLeftConversation";
            public override string LegendaPtBr => "Sim abandonou a conversa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLeftJob : EventoApenasSim
        {
            public override string EventoId => "kLeftJob";
            public override string LegendaPtBr => "Sim deixou o emprego";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLhsCheckRequested : EventoApenasSim
        {
            public override string EventoId => "kLhsCheckRequested";
            public override string LegendaPtBr => "Sim solicitou verificação de necessidades";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLickedSaltLick : EventoApenasSim
        {
            public override string EventoId => "kLickedSaltLick";
            public override string LegendaPtBr => "Sim lambeu a lixívia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLieDown : EventoApenasSim
        {
            public override string EventoId => "kLieDown";
            public override string LegendaPtBr => "Sim deitou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLieDownInPetHouse : EventoApenasSim
        {
            public override string EventoId => "kLieDownInPetHouse";
            public override string LegendaPtBr => "Sim deitou na casinha de pet";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLieDownPetBed : EventoApenasSim
        {
            public override string EventoId => "kLieDownPetBed";
            public override string LegendaPtBr => "Sim deitou na caminha de pet";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLifeguardRescue : EventoApenasSim
        {
            public override string EventoId => "kLifeguardRescue";
            public override string LegendaPtBr => "Salvador resgatou um Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLightFirecracker : EventoApenasSim
        {
            public override string EventoId => "kLightFirecracker";
            public override string LegendaPtBr => "Sim acendeu um estouro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLightFirework : EventoApenasSim
        {
            public override string EventoId => "kLightFirework";
            public override string LegendaPtBr => "Sim acendeu fogos de artifício";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLightMultipleFirecrackers : EventoApenasSim
        {
            public override string EventoId => "kLightMultipleFirecrackers";
            public override string LegendaPtBr => "Sim acendeu vários estouros";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoListAlchemyObjectForConsignment : EventoApenasSim
        {
            public override string EventoId => "kListAlchemyObjectForConsignment";
            public override string LegendaPtBr => "Sim listou objeto alquímico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLoadingScreenDisposed : EventoApenasSim
        {
            public override string EventoId => "kLoadingScreenDisposed";
            public override string LegendaPtBr => "Tela de carregamento desapareceu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLoginDialogCancelClicked : EventoApenasSim
        {
            public override string EventoId => "kLoginDialogCancelClicked";
            public override string LegendaPtBr => "Sim cancelou diálogo de login";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLoginDialogOKClicked : EventoApenasSim
        {
            public override string EventoId => "kLoginDialogOKClicked";
            public override string LegendaPtBr => "Sim confirmou diálogo de login";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLookDivingWorkBistro : EventoApenasSim
        {
            public override string EventoId => "kLookDivingWorkBistro";
            public override string LegendaPtBr => "Sim observou trabalho no bistrô";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLookDivingWorkCityHall : EventoApenasMundo
        {
            public override string EventoId => "kLookDivingWorkCityHall";
            public override string LegendaPtBr => "Sim observou trabalho na prefeitura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLookDivingWorkScienceLab : EventoApenasSim
        {
            public override string EventoId => "kLookDivingWorkScienceLab";
            public override string LegendaPtBr => "Sim observou trabalho no laboratório";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLookUpSim : EventoApenasSim
        {
            public override string EventoId => "kLookUpSim";
            public override string LegendaPtBr => "Sim olhou para outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLootAJunkPile : EventoApenasSim
        {
            public override string EventoId => "kLootAJunkPile";
            public override string LegendaPtBr => "Sim vasculhou um monte de lixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLooted : EventoApenasSim
        {
            public override string EventoId => "kLooted";
            public override string LegendaPtBr => "Sim saqueou algo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLoseArenaMatch : EventoApenasSim
        {
            public override string EventoId => "kLoseArenaMatch";
            public override string LegendaPtBr => "Sim perdeu luta na arena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLoseReinforcementTrait : EventoApenasSim
        {
            public override string EventoId => "kLoseReinforcementTrait";
            public override string LegendaPtBr => "Sim perdeu traço de reforço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLostDartGame : EventoApenasSim
        {
            public override string EventoId => "kLostDartGame";
            public override string LegendaPtBr => "Sim perdeu jogo de dardos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLostPingPongGame : EventoApenasSim
        {
            public override string EventoId => "kLostPingPongGame";
            public override string LegendaPtBr => "Sim perdeu jogo de ping pong";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLostUntrainedTrait : EventoApenasSim
        {
            public override string EventoId => "kLostUntrainedTrait";
            public override string LegendaPtBr => "Sim perdeu traço não treinado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoLotChosenForActiveHousehold : EventoApenasSim
        {
            public override string EventoId => "kLotChosenForActiveHousehold";
            public override string LegendaPtBr => "Lote escolhido para família";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoLowLevelPoliceWork : EventoApenasSim
        {
            public override string EventoId => "kLowLevelPoliceWork";
            public override string LegendaPtBr => "Sim fez trabalho policial básico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeAPotion : EventoApenasSim
        {
            public override string EventoId => "kMadeAPotion";
            public override string LegendaPtBr => "Sim preparou uma poção";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeBed : EventoApenasSim
        {
            public override string EventoId => "kMadeBed";
            public override string LegendaPtBr => "Sim fez a cama";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeMoneyBartending : EventoApenasSim
        {
            public override string EventoId => "kMadeMoneyBartending";
            public override string LegendaPtBr => "Sim ganhou dinheiro como barman";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeMostLifetime : EventoApenasSim
        {
            public override string EventoId => "kMadeMostLifetime";
            public override string LegendaPtBr => "Sim fez a maior parte da vida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeNectar : EventoApenasSim
        {
            public override string EventoId => "kMadeNectar";
            public override string LegendaPtBr => "Sim fez um néctar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeOut : EventoApenasSim
        {
            public override string EventoId => "kMadeOut";
            public override string LegendaPtBr => "Sim fez um beijo apaixonado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeSimThinkOfMe : EventoApenasSim
        {
            public override string EventoId => "kMadeSimThinkOfMe";
            public override string LegendaPtBr => "Sim fez outro sim pensar nele";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMadeSnowAngel : EventoApenasSim
        {
            public override string EventoId => "kMadeSnowAngel";
            public override string LegendaPtBr => "Sim fez um boneco de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMagicBroomArenaRide : EventoApenasSim
        {
            public override string EventoId => "kMagicBroomArenaRide";
            public override string LegendaPtBr => "Sim voou na arena de vassoura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMagicBroomArenaStunt : EventoApenasSim
        {
            public override string EventoId => "kMagicBroomArenaStunt";
            public override string LegendaPtBr => "Sim fez acrobacias na arena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMagicGnomeCreated : EventoApenasSim
        {
            public override string EventoId => "kMagicGnomeCreated";
            public override string LegendaPtBr => "Gnomo mágico apareceu no jardim";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMagicMakeovers : EventoApenasSim
        {
            public override string EventoId => "kMagicMakeovers";
            public override string LegendaPtBr => "Sim recebeu makeover mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMailedImaginaryFriendRgm : EventoApenasSim
        {
            public override string EventoId => "kMailedImaginaryFriendRgm";
            public override string LegendaPtBr => "Sim recebeu amigo imaginário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMaintainedObject : EventoApenasSim
        {
            public override string EventoId => "kMaintainedObject";
            public override string LegendaPtBr => "Sim manteve objeto em bom estado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMaintenenceLevelDropped : EventoApenasSim
        {
            public override string EventoId => "kMaintenenceLevelDropped";
            public override string LegendaPtBr => "Nível de manutenção diminuiu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMakeSnowCone : EventoApenasSim
        {
            public override string EventoId => "kMakeSnowCone";
            public override string LegendaPtBr => "Sim fez raspadinha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMakeXSellingRemixAlbums : EventoApenasSim
        {
            public override string EventoId => "kMakeXSellingRemixAlbums";
            public override string LegendaPtBr => "Sim criou álbuns para vender";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoMarried : EventoApenasSim
        {
            public override string EventoId => "kMarried";
            public override string LegendaPtBr => "Sims oficializaram o casamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMarriedAndSawSim : EventoRuido
        {
            public override string EventoId => "kMarriedAndSawSim";
            public override string LegendaPtBr => "Sims casados viram outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMasterOfTheDarkArts : EventoApenasSim
        {
            public override string EventoId => "kMasterOfTheDarkArts";
            public override string LegendaPtBr => "Sim dominou as artes das trevas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMasterOfTheLightArts : EventoApenasSim
        {
            public override string EventoId => "kMasterOfTheLightArts";
            public override string LegendaPtBr => "Sim dominou as artes da luz";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMauledByShark : EventoApenasSim
        {
            public override string EventoId => "kMauledByShark";
            public override string LegendaPtBr => "Sim foi atacado por tubarão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMeasureCheer : EventoApenasSim
        {
            public override string EventoId => "kMeasureCheer";
            public override string LegendaPtBr => "Sim mediu o humor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMeditated : EventoApenasSim
        {
            public override string EventoId => "kMeditated";
            public override string LegendaPtBr => "Sim meditou profundamente";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMeetAttractiveSim : EventoApenasSim
        {
            public override string EventoId => "kMeetAttractiveSim";
            public override string LegendaPtBr => "Sim conheceu um Sim atraente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMermaidDehydrated : EventoApenasSim
        {
            public override string EventoId => "kMermaidDehydrated";
            public override string LegendaPtBr => "Sereia desidratou rapidamente";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMetCompatibleSign : EventoApenasSim
        {
            public override string EventoId => "kMetCompatibleSign";
            public override string LegendaPtBr => "Sim conheceu um Sim compatível";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoMindMeldWithSim : EventoApenasSim
        {
            public override string EventoId => "kMindMeldWithSim";
            public override string LegendaPtBr => "Sim conectou a mente com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMinedUpObject : EventoApenasSim
        {
            public override string EventoId => "kMinedUpObject";
            public override string LegendaPtBr => "Sim removeu objeto do chão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMiningAdventure : EventoApenasSim
        {
            public override string EventoId => "kMiningAdventure";
            public override string LegendaPtBr => "Sim teve aventura minerando";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMiniSimDied : EventoApenasSim
        {
            public override string EventoId => "kMiniSimDied";
            public override string LegendaPtBr => "Mini Sim morreu inesperadamente";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }


        internal sealed class EventoMixedDrink : EventoApenasSim
        {
            public override string EventoId => "kMixedDrink";
            public override string LegendaPtBr => "Sim preparou bebida misturada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMoodTransformation : EventoRuido
        {
            public override string EventoId => "kMoodTransformation";
            public override string LegendaPtBr => "Sim mudou seu humor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoMoonChangeEvent : EventoApenasSim
        {
            public override string EventoId => "kMoonChangeEvent";
            public override string LegendaPtBr => "Lua passou por transformação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMoonRise : EventoApenasSim
        {
            public override string EventoId => "kMoonRise";
            public override string LegendaPtBr => "Lua surgiu no horizonte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMopped : EventoApenasSim
        {
            public override string EventoId => "kMopped";
            public override string LegendaPtBr => "Sim limpou o chão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMoreMachine : EventoApenasSim
        {
            public override string EventoId => "kMoreMachine";
            public override string LegendaPtBr => "Sim usou a máquina de doces";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMotherNearFoal : EventoApenasSim
        {
            public override string EventoId => "kMotherNearFoal";
            public override string LegendaPtBr => "Égua se aproximou da mãe";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMotherNursedFoal : EventoApenasSim
        {
            public override string EventoId => "kMotherNursedFoal";
            public override string LegendaPtBr => "Égua amamentou o potro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoMovedHousehold : EventoApenasSim
        {
            public override string EventoId => "kMovedHousehold";
            public override string LegendaPtBr => "Família mudou-se para outro lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMovedHouses : EventoApenasSim
        {
            public override string EventoId => "kMovedHouses";
            public override string LegendaPtBr => "Várias famílias mudaram-se";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMovedIntoApartment : EventoApenasSim
        {
            public override string EventoId => "kMovedIntoApartment";
            public override string LegendaPtBr => "Sim mudou-se para apartamento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoMovedIntoLot : EventoApenasSim
        {
            public override string EventoId => "kMovedIntoLot";
            public override string LegendaPtBr => "Sim mudou-se para um lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoMovedIntoPenthouse : EventoApenasSim
        {
            public override string EventoId => "kMovedIntoPenthouse";
            public override string LegendaPtBr => "Sim mudou-se para cobertura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoMysticHealer : EventoApenasSim
        {
            public override string EventoId => "kMysticHealer";
            public override string LegendaPtBr => "Sim praticou cura mística";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNamedDrinkAfter : EventoApenasSim
        {
            public override string EventoId => "kNamedDrinkAfter";
            public override string LegendaPtBr => "Sim nomeou bebida em homenagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNamedStarAfterSim : EventoApenasSim
        {
            public override string EventoId => "kNamedStarAfterSim";
            public override string LegendaPtBr => "Sim nomeou estrela em homenagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNameImaginaryFriend : EventoApenasSim
        {
            public override string EventoId => "kNameImaginaryFriend";
            public override string LegendaPtBr => "Sim deu nome ao amigo imaginário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNameMinorPet : EventoApenasSim
        {
            public override string EventoId => "kNameMinorPet";
            public override string LegendaPtBr => "Sim nomeou filhote menor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNapInRockingChair : EventoApenasSim
        {
            public override string EventoId => "kNapInRockingChair";
            public override string LegendaPtBr => "Sim dormiu na cadeira de balanço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }






        internal sealed class EventoNewOffspring : EventoApenasSim
        {
            public override string EventoId => "kNewOffspring";
            public override string LegendaPtBr => "Sim teve um rebento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNewOffspringPet : EventoApenasSim
        {
            public override string EventoId => "kNewOffspringPet";
            public override string LegendaPtBr => "Sim teve filhote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNewPet : EventoApenasSim
        {
            public override string EventoId => "kNewPet";
            public override string LegendaPtBr => "Sim adotou um animal de estimação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNewspaperDelivered : EventoApenasSim
        {
            public override string EventoId => "kNewspaperDelivered";
            public override string LegendaPtBr => "Sim recebeu jornal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNewStarConstellation : EventoApenasSim
        {
            public override string EventoId => "kNewStarConstellation";
            public override string LegendaPtBr => "Sim viu nova constelação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNextShiftStarted : EventoApenasSim
        {
            public override string EventoId => "kNextShiftStarted";
            public override string LegendaPtBr => "Sim começou o turno de trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNotAtWork : EventoRuido
        {
            public override string EventoId => "kNotAtWork";
            public override string LegendaPtBr => "Sim não estava no trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNudgeCatToy : EventoApenasSim
        {
            public override string EventoId => "kNudgeCatToy";
            public override string LegendaPtBr => "Sim cutucou brinquedo de gato";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoNumEvents : EventoApenasSim
        {
            public override string EventoId => "kNumEvents";
            public override string LegendaPtBr => "Sim gerou um evento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoObjectMovedToTreasureComponent : EventoApenasSim
        {
            public override string EventoId => "kObjectMovedToTreasureComponent";
            public override string LegendaPtBr => "Objeto foi para o baú";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoObjectStateChanged : EventoRuido
        {
            public override string EventoId => "kObjectStateChanged";
            public override string LegendaPtBr => "Estado do objeto mudou";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoObservedBrainEnhancer : EventoApenasSim
        {
            public override string EventoId => "kObservedBrainEnhancer";
            public override string LegendaPtBr => "Sim observou aprimorador cerebral";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationEndOfWorkDay : EventoApenasSim
        {
            public override string EventoId => "kOccupationEndOfWorkDay";
            public override string LegendaPtBr => "Sim terminou o dia de trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationJobCompleted : EventoApenasSim
        {
            public override string EventoId => "kOccupationJobCompleted";
            public override string LegendaPtBr => "Sim completou o trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationJobMissed : EventoApenasSim
        {
            public override string EventoId => "kOccupationJobMissed";
            public override string LegendaPtBr => "Sim perdeu o trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationShouldHaveWorkedToday : EventoApenasSim
        {
            public override string EventoId => "kOccupationShouldHaveWorkedToday";
            public override string LegendaPtBr => "Sim deveria ter trabalhado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationStartedWorkDay : EventoApenasSim
        {
            public override string EventoId => "kOccupationStartedWorkDay";
            public override string LegendaPtBr => "Sim começou o dia de trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationTookPaidTimeOff : EventoApenasSim
        {
            public override string EventoId => "kOccupationTookPaidTimeOff";
            public override string LegendaPtBr => "Sim tirou licença remunerada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOccupationTookUnpaidTimeOff : EventoApenasSim
        {
            public override string EventoId => "kOccupationTookUnpaidTimeOff";
            public override string LegendaPtBr => "Sim tirou licença não remunerada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoOnlineDatingBrowseProfiles : EventoApenasSim
        {
            public override string EventoId => "kOnlineDatingBrowseProfiles";
            public override string LegendaPtBr => "Sim navegou perfis online";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOnlineDatingCheckMessages : EventoApenasSim
        {
            public override string EventoId => "kOnlineDatingCheckMessages";
            public override string LegendaPtBr => "Sim verificou mensagens online";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOnlineDatingCreateProfile : EventoApenasSim
        {
            public override string EventoId => "kOnlineDatingCreateProfile";
            public override string LegendaPtBr => "Sim criou perfil online";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOnlineDatingEditProfile : EventoApenasSim
        {
            public override string EventoId => "kOnlineDatingEditProfile";
            public override string LegendaPtBr => "Sim editou seu perfil de namoro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOnlineDatingMeetSomeone : EventoApenasSim
        {
            public override string EventoId => "kOnlineDatingMeetSomeone";
            public override string LegendaPtBr => "Sim conheceu alguém online";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOpenBirdCage : EventoApenasSim
        {
            public override string EventoId => "kOpenBirdCage";
            public override string LegendaPtBr => "Sim abriu a gaiola de pássaros";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoOpenEP10TreasureChest : EventoApenasSim
        {
            public override string EventoId => "kOpenEP10TreasureChest";
            public override string LegendaPtBr => "Sim abriu baú de tesouro Selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOpenGiftPileGift : EventoApenasSim
        {
            public override string EventoId => "kOpenGiftPileGift";
            public override string LegendaPtBr => "Sim abriu um presente da pilha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoOpportunityTracked : EventoApenasSim
        {
            public override string EventoId => "kOpportunityTracked";
            public override string LegendaPtBr => "Sim rastreou uma oportunidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderAJuiceForSimFromPropreitor : EventoApenasSim
        {
            public override string EventoId => "kOrderAJuiceForSimFromPropreitor";
            public override string LegendaPtBr => "Sim pediu suco do proprietário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderAJuiceFromProprietor : EventoApenasSim
        {
            public override string EventoId => "kOrderAJuiceFromProprietor";
            public override string LegendaPtBr => "Sim pediu suco do proprietário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderedARound : EventoApenasSim
        {
            public override string EventoId => "kOrderedARound";
            public override string LegendaPtBr => "Sim pediu uma rodada de bebidas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderedDrinkFor : EventoApenasSim
        {
            public override string EventoId => "kOrderedDrinkFor";
            public override string LegendaPtBr => "Sim pediu bebida para outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderedFood : EventoApenasSim
        {
            public override string EventoId => "kOrderedFood";
            public override string LegendaPtBr => "Sim pediu comida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderedService : EventoApenasSim
        {
            public override string EventoId => "kOrderedService";
            public override string LegendaPtBr => "Sim pediu um serviço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderedSynthDrink : EventoApenasSim
        {
            public override string EventoId => "kOrderedSynthDrink";
            public override string LegendaPtBr => "Sim pediu uma bebida sintética";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOrderedSynthFood : EventoApenasSim
        {
            public override string EventoId => "kOrderedSynthFood";
            public override string LegendaPtBr => "Sim comeu comida sintética.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOverseeProduction : EventoApenasSim
        {
            public override string EventoId => "kOverseeProduction";
            public override string LegendaPtBr => "Sim supervisionou a produção.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOwnSimoleonsInCutGems : EventoApenasSim
        {
            public override string EventoId => "kOwnSimoleonsInCutGems";
            public override string LegendaPtBr => "Sim encontrou gemas valiosas.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoOwnSimoleonsInIngots : EventoApenasSim
        {
            public override string EventoId => "kOwnSimoleonsInIngots";
            public override string LegendaPtBr => "Sim acumulou lingotes.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPainted : EventoApenasSim
        {
            public override string EventoId => "kPainted";
            public override string LegendaPtBr => "Sim pintou a tela.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPaintedPortrait : EventoApenasSim
        {
            public override string EventoId => "kPaintedPortrait";
            public override string LegendaPtBr => "Sim pintou um retrato.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPaintedStillLife : EventoApenasSim
        {
            public override string EventoId => "kPaintedStillLife";
            public override string LegendaPtBr => "Sim pintou uma natureza morta.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoParentAdded : EventoSimEFamilia
        {
            public override string EventoId => "kParentAdded";
            public override string LegendaPtBr => "Sim ganhou um pai.";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyArrivedGuest : EventoSimEFamilia
        {
            public override string EventoId => "kPartyArrivedGuest";
            public override string LegendaPtBr => "Sim chegou convidado à festa.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyArrivedOnLot : EventoSimEFamilia
        {
            public override string EventoId => "kPartyArrivedOnLot";
            public override string LegendaPtBr => "Sim chegou na festa.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPartyBeInvitedTo : EventoSimEFamilia
        {
            public override string EventoId => "kPartyBeInvitedTo";
            public override string LegendaPtBr => "Sim recebeu um convite para festa.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyBeNotInvitedTo : EventoSimEFamilia
        {
            public override string EventoId => "kPartyBeNotInvitedTo";
            public override string LegendaPtBr => "Sim foi ignorado na festa.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyCelebArrivedOnLot : EventoSimEFamilia
        {
            public override string EventoId => "kPartyCelebArrivedOnLot";
            public override string LegendaPtBr => "Sim celebrou a chegada de um famoso.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyInviteCeleb : EventoSimEFamilia
        {
            public override string EventoId => "kPartyInviteCeleb";
            public override string LegendaPtBr => "Sim enviou convite para celebridade.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPartyYouShouldDance : EventoSimEFamilia
        {
            public override string EventoId => "kPartyYouShouldDance";
            public override string LegendaPtBr => "Sim deveria dançar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyYouShouldJoke : EventoSimEFamilia
        {
            public override string EventoId => "kPartyYouShouldJoke";
            public override string LegendaPtBr => "Sim deveria fazer piada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPartyYouShouldKiss : EventoSimEFamilia
        {
            public override string EventoId => "kPartyYouShouldKiss";
            public override string LegendaPtBr => "Sim deveria beijar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPassportHostSimPerformedGig : EventoApenasSim
        {
            public override string EventoId => "kPassportHostSimPerformedGig";
            public override string LegendaPtBr => "Sim apresentou-se no show";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPassportSentSimLeftWorld : EventoApenasMundo
        {
            public override string EventoId => "kPassportSentSimLeftWorld";
            public override string LegendaPtBr => "Sim deixou o mundo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPassportSentSimReturned : EventoApenasSim
        {
            public override string EventoId => "kPassportSentSimReturned";
            public override string LegendaPtBr => "Sim retornou ao mundo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPassportShowStarted : EventoApenasSim
        {
            public override string EventoId => "kPassportShowStarted";
            public override string LegendaPtBr => "Show começou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPastBedTime : EventoApenasSim
        {
            public override string EventoId => "kPastBedTime";
            public override string LegendaPtBr => "Sim passou da hora de dormir";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformanceEvent : EventoApenasSim
        {
            public override string EventoId => "kPerformanceEvent";
            public override string LegendaPtBr => "Sim apresentou-se";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedCelebrationSingagram : EventoApenasSim
        {
            public override string EventoId => "kPerformedCelebrationSingagram";
            public override string LegendaPtBr => "Sim cantou parabéns";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedCheerUpSingagram : EventoApenasSim
        {
            public override string EventoId => "kPerformedCheerUpSingagram";
            public override string LegendaPtBr => "Sim cantou para animar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPerformedExperiment : EventoApenasSim
        {
            public override string EventoId => "kPerformedExperiment";
            public override string LegendaPtBr => "Sim conduziu um experimento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedGuitar : EventoApenasSim
        {
            public override string EventoId => "kPerformedGuitar";
            public override string LegendaPtBr => "Sim tocou violão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedInkBlotTest : EventoApenasSim
        {
            public override string EventoId => "kPerformedInkBlotTest";
            public override string LegendaPtBr => "Sim fez teste de manchas de tinta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedRomanticSingagram : EventoApenasSim
        {
            public override string EventoId => "kPerformedRomanticSingagram";
            public override string LegendaPtBr => "Sim cantou serenata romântica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedSong : EventoApenasSim
        {
            public override string EventoId => "kPerformedSong";
            public override string LegendaPtBr => "Sim cantou uma música";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedStimulusResponseTest : EventoApenasSim
        {
            public override string EventoId => "kPerformedStimulusResponseTest";
            public override string LegendaPtBr => "Sim fez teste de resposta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedTrick : EventoApenasSim
        {
            public override string EventoId => "kPerformedTrick";
            public override string LegendaPtBr => "Sim fez uma travessura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformedYouAreSpecialSingagram : EventoApenasSim
        {
            public override string EventoId => "kPerformedYouAreSpecialSingagram";
            public override string LegendaPtBr => "Sim cantou parabéns";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPerformForTipsAsDJ : EventoApenasSim
        {
            public override string EventoId => "kPerformForTipsAsDJ";
            public override string LegendaPtBr => "Sim tocou como DJ";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformForTipsAsMagician : EventoApenasSim
        {
            public override string EventoId => "kPerformForTipsAsMagician";
            public override string LegendaPtBr => "Sim fez truques de mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformForTipsAsPerformanceArtist : EventoApenasSim
        {
            public override string EventoId => "kPerformForTipsAsPerformanceArtist";
            public override string LegendaPtBr => "Sim se apresentou como artista";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPerformInSimFest : EventoApenasSim
        {
            public override string EventoId => "kPerformInSimFest";
            public override string LegendaPtBr => "Sim se apresentou no festival";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformProTuneUp : EventoApenasSim
        {
            public override string EventoId => "kPerformProTuneUp";
            public override string LegendaPtBr => "Sim fez ajuste profissional";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformSchoolCheer : EventoApenasSim
        {
            public override string EventoId => "kPerformSchoolCheer";
            public override string LegendaPtBr => "Sim fez torcida escolar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPerformSweetMove : EventoApenasSim
        {
            public override string EventoId => "kPerformSweetMove";
            public override string LegendaPtBr => "Sim fez um movimento doce";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetAdoption : EventoApenasSim
        {
            public override string EventoId => "kPetAdoption";
            public override string LegendaPtBr => "Sim adotou um animal de estimação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetAgedDown : EventoApenasSim
        {
            public override string EventoId => "kPetAgedDown";
            public override string LegendaPtBr => "Animal de estimação envelheceu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetBeAdopted : EventoApenasSim
        {
            public override string EventoId => "kPetBeAdopted";
            public override string LegendaPtBr => "Animal de estimação foi adotado";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPetHadOffspring : EventoApenasSim
        {
            public override string EventoId => "kPetHadOffspring";
            public override string LegendaPtBr => "Animal de estimação teve filhotes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetPlayedWithPet : EventoApenasSim
        {
            public override string EventoId => "kPetPlayedWithPet";
            public override string LegendaPtBr => "Sim brincou com o animal";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetSavedSimFromDeath : EventoApenasSim
        {
            public override string EventoId => "kPetSavedSimFromDeath";
            public override string LegendaPtBr => "Animal salvou Sim da morte";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoPetSingAlong : EventoApenasSim
        {
            public override string EventoId => "kPetSingAlong";
            public override string LegendaPtBr => "Animal cantou junto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetTakenBySocialWorker : EventoApenasSim
        {
            public override string EventoId => "kPetTakenBySocialWorker";
            public override string LegendaPtBr => "Animal foi levado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetWildHorse : EventoApenasSim
        {
            public override string EventoId => "kPetWildHorse";
            public override string LegendaPtBr => "Sim domou um cavalo selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPetWooHooed : EventoApenasSim
        {
            public override string EventoId => "kPetWooHooed";
            public override string LegendaPtBr => "Animal teve romance";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPhotosynthesize : EventoApenasSim
        {
            public override string EventoId => "kPhotosynthesize";
            public override string LegendaPtBr => "Sim realizou fotossíntese";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPianoSerenaded : EventoApenasSim
        {
            public override string EventoId => "kPianoSerenaded";
            public override string LegendaPtBr => "Sim serenou ao piano";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPickedUpBeetles : EventoApenasSim
        {
            public override string EventoId => "kPickedUpBeetles";
            public override string LegendaPtBr => "Sim coletou besouros";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPickedUpPet : EventoApenasSim
        {
            public override string EventoId => "kPickedUpPet";
            public override string LegendaPtBr => "Sim pegou um animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPickedUpSeeds : EventoApenasSim
        {
            public override string EventoId => "kPickedUpSeeds";
            public override string LegendaPtBr => "Sim coletou sementes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPickedUpSim : EventoApenasSim
        {
            public override string EventoId => "kPickedUpSim";
            public override string LegendaPtBr => "Sim pegou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPiggyPetAteHarvestable : EventoApenasSim
        {
            public override string EventoId => "kPiggyPetAteHarvestable";
            public override string LegendaPtBr => "Porquinho comeu colheita";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPiggyPetAteSomething : EventoApenasSim
        {
            public override string EventoId => "kPiggyPetAteSomething";
            public override string LegendaPtBr => "Porquinho comeu algo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlacedBlueprint : EventoApenasSim
        {
            public override string EventoId => "kPlacedBlueprint";
            public override string LegendaPtBr => "Sim posicionou planta baixa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlacedNectarBottle : EventoApenasSim
        {
            public override string EventoId => "kPlacedNectarBottle";
            public override string LegendaPtBr => "Sim colocou garrafa de néctar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlacedPainting : EventoApenasSim
        {
            public override string EventoId => "kPlacedPainting";
            public override string LegendaPtBr => "Sim posicionou pintura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlacedPhotograph : EventoApenasSim
        {
            public override string EventoId => "kPlacedPhotograph";
            public override string LegendaPtBr => "Sim posicionou fotografia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlacedRelic : EventoApenasSim
        {
            public override string EventoId => "kPlacedRelic";
            public override string LegendaPtBr => "Sim posicionou relíquia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlacedSculpture : EventoApenasSim
        {
            public override string EventoId => "kPlacedSculpture";
            public override string LegendaPtBr => "Sim posicionou escultura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlannedOutfit : EventoApenasSim
        {
            public override string EventoId => "kPlannedOutfit";
            public override string LegendaPtBr => "Sim planejou roupa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlannedOutfitPet : EventoApenasSim
        {
            public override string EventoId => "kPlannedOutfitPet";
            public override string LegendaPtBr => "Sim planejou roupa de pet";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlantChangedGrowthState : EventoApenasSim
        {
            public override string EventoId => "kPlantChangedGrowthState";
            public override string LegendaPtBr => "Planta mudou de estado";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlantedObject : EventoApenasSim
        {
            public override string EventoId => "kPlantedObject";
            public override string LegendaPtBr => "Sim plantou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayAFourPlayerGameOfPool : EventoApenasSim
        {
            public override string EventoId => "kPlayAFourPlayerGameOfPool";
            public override string LegendaPtBr => "Sim jogou sinuca";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayArcade : EventoApenasSim
        {
            public override string EventoId => "kPlayArcade";
            public override string LegendaPtBr => "Sim jogou fliperama";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayArcade2P : EventoApenasSim
        {
            public override string EventoId => "kPlayArcade2P";
            public override string LegendaPtBr => "Sims jogaram fliperama juntos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayArenaMatch : EventoApenasSim
        {
            public override string EventoId => "kPlayArenaMatch";
            public override string LegendaPtBr => "Sim jogou partida na arena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayCollegiateSports : EventoApenasSim
        {
            public override string EventoId => "kPlayCollegiateSports";
            public override string LegendaPtBr => "Sim praticou esporte universitário";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayDarts : EventoApenasSim
        {
            public override string EventoId => "kPlayDarts";
            public override string LegendaPtBr => "Sim jogou dardos com precisão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayDomino : EventoApenasSim
        {
            public override string EventoId => "kPlayDomino";
            public override string LegendaPtBr => "Sim jogou dominó sozinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayDomino4P : EventoApenasSim
        {
            public override string EventoId => "kPlayDomino4P";
            public override string LegendaPtBr => "Sims jogaram dominó em grupo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayDominoWith : EventoApenasSim
        {
            public override string EventoId => "kPlayDominoWith";
            public override string LegendaPtBr => "Sim jogou dominó com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedBassGuitar : EventoApenasSim
        {
            public override string EventoId => "kPlayedBassGuitar";
            public override string LegendaPtBr => "Sim tocou contrabaixo com estilo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedCatchWithBaseball : EventoApenasSim
        {
            public override string EventoId => "kPlayedCatchWithBaseball";
            public override string LegendaPtBr => "Sim arremessou bola de beisebol";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedCatchWithBeachball : EventoApenasSim
        {
            public override string EventoId => "kPlayedCatchWithBeachball";
            public override string LegendaPtBr => "Sim arremessou bola de praia";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedCatchWithFlyingDisc : EventoApenasSim
        {
            public override string EventoId => "kPlayedCatchWithFlyingDisc";
            public override string LegendaPtBr => "Sim arremessou disco voador";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedCatchWithFootball : EventoApenasSim
        {
            public override string EventoId => "kPlayedCatchWithFootball";
            public override string LegendaPtBr => "Sim arremessou bola de futebol";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedChess : EventoApenasSim
        {
            public override string EventoId => "kPlayedChess";
            public override string LegendaPtBr => "Sim jogou xadrez estrategicamente";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedDrums : EventoApenasSim
        {
            public override string EventoId => "kPlayedDrums";
            public override string LegendaPtBr => "Sim tocou bateria com ritmo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedGamesAtNerdShop : EventoApenasSim
        {
            public override string EventoId => "kPlayedGamesAtNerdShop";
            public override string LegendaPtBr => "Sims jogaram em loja nerd";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedGnubb : EventoApenasSim
        {
            public override string EventoId => "kPlayedGnubb";
            public override string LegendaPtBr => "Sim jogou Gnubb";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPlayedHackyWithFriends : EventoApenasSim
        {
            public override string EventoId => "kPlayedHackyWithFriends";
            public override string LegendaPtBr => "Sim jogou hacky com amigos";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedInToilet : EventoApenasSim
        {
            public override string EventoId => "kPlayedInToilet";
            public override string LegendaPtBr => "Sim brincou no vaso sanitário";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedInTreehouse : EventoApenasSim
        {
            public override string EventoId => "kPlayedInTreehouse";
            public override string LegendaPtBr => "Sim brincou na casinha da árvore";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedJuicePong : EventoApenasSim
        {
            public override string EventoId => "kPlayedJuicePong";
            public override string LegendaPtBr => "Sim jogou Juice Pong";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedLaserHarp : EventoApenasSim
        {
            public override string EventoId => "kPlayedLaserHarp";
            public override string LegendaPtBr => "Sim tocou laser harp";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedOnlineGame : EventoApenasSim
        {
            public override string EventoId => "kPlayedOnlineGame";
            public override string LegendaPtBr => "Sim jogou online";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedPiano : EventoApenasSim
        {
            public override string EventoId => "kPlayedPiano";
            public override string LegendaPtBr => "Sim tocou piano";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedPingPongWithFriend : EventoApenasSim
        {
            public override string EventoId => "kPlayedPingPongWithFriend";
            public override string LegendaPtBr => "Sim jogou ping pong com amigo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedQuarters : EventoApenasSim
        {
            public override string EventoId => "kPlayedQuarters";
            public override string LegendaPtBr => "Sim jogou Quarters";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedRankedChessMatch : EventoApenasSim
        {
            public override string EventoId => "kPlayedRankedChessMatch";
            public override string LegendaPtBr => "Sim jogou xadrez ranqueado";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedRhythmChallenge : EventoApenasSim
        {
            public override string EventoId => "kPlayedRhythmChallenge";
            public override string LegendaPtBr => "Sim fez desafio de ritmo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedShuffleboard : EventoApenasSim
        {
            public override string EventoId => "kPlayedShuffleboard";
            public override string LegendaPtBr => "Sim jogou Shuffleboard";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedVideoOrComputerGame : EventoApenasSim
        {
            public override string EventoId => "kPlayedVideoOrComputerGame";
            public override string LegendaPtBr => "Sim jogou videogame";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedWithFire : EventoApenasSim
        {
            public override string EventoId => "kPlayedWithFire";
            public override string LegendaPtBr => "Sim brincou com fogo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayedWithToy : EventoApenasSim
        {
            public override string EventoId => "kPlayedWithToy";
            public override string LegendaPtBr => "Sim brincou com brinquedo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayHopscotch : EventoApenasSim
        {
            public override string EventoId => "kPlayHopscotch";
            public override string LegendaPtBr => "Sim jogou amarelinha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayHorseshoes : EventoApenasSim
        {
            public override string EventoId => "kPlayHorseshoes";
            public override string LegendaPtBr => "Sim jogou malha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInACostume : EventoApenasSim
        {
            public override string EventoId => "kPlayInACostume";
            public override string LegendaPtBr => "Sim brincou fantasiado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInLeafPile : EventoApenasSim
        {
            public override string EventoId => "kPlayInLeafPile";
            public override string LegendaPtBr => "Sim brincou em pilha de folhas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInOcean : EventoApenasSim
        {
            public override string EventoId => "kPlayInOcean";
            public override string LegendaPtBr => "Sim brincou no oceano";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInOceanWith : EventoApenasSim
        {
            public override string EventoId => "kPlayInOceanWith";
            public override string LegendaPtBr => "Sim brincou no oceano com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInPuddle : EventoApenasSim
        {
            public override string EventoId => "kPlayInPuddle";
            public override string LegendaPtBr => "Sim brincou em poça d'água";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInTrashPile : EventoApenasSim
        {
            public override string EventoId => "kPlayInTrashPile";
            public override string LegendaPtBr => "Sim brincou em lixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayInWaterfall : EventoApenasSim
        {
            public override string EventoId => "kPlayInWaterfall";
            public override string LegendaPtBr => "Sim brincou em cachoeira";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayOnCarpet : EventoApenasSim
        {
            public override string EventoId => "kPlayOnCarpet";
            public override string LegendaPtBr => "Sim brincou no tapete";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayPoolAlone : EventoApenasSim
        {
            public override string EventoId => "kPlayPoolAlone";
            public override string LegendaPtBr => "Sim nadou sozinho na piscina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlaySportsAtStadium : EventoApenasSim
        {
            public override string EventoId => "kPlaySportsAtStadium";
            public override string LegendaPtBr => "Sim jogou esporte no estádio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayTrackOnDJBooth : EventoApenasSim
        {
            public override string EventoId => "kPlayTrackOnDJBooth";
            public override string LegendaPtBr => "Sim dançou no DJ booth";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayWhacASupernatural : EventoApenasSim
        {
            public override string EventoId => "kPlayWhacASupernatural";
            public override string LegendaPtBr => "Sim golpeou o fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayWithCatDancerToy : EventoApenasSim
        {
            public override string EventoId => "kPlayWithCatDancerToy";
            public override string LegendaPtBr => "Sim brincou com o brinquedo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayWithCatToy : EventoApenasSim
        {
            public override string EventoId => "kPlayWithCatToy";
            public override string LegendaPtBr => "Sim brincou com o gato";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPlayWithMinorPet : EventoApenasSim
        {
            public override string EventoId => "kPlayWithMinorPet";
            public override string LegendaPtBr => "Sim brincou com o bichinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPoolTableCupTrick : EventoApenasSim
        {
            public override string EventoId => "kPoolTableCupTrick";
            public override string LegendaPtBr => "Sim fez truque com a taça";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPoolTableEP6Trick1 : EventoApenasSim
        {
            public override string EventoId => "kPoolTableEP6Trick1";
            public override string LegendaPtBr => "Sim fez truque de bilhar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPoolTableEP6Trick2 : EventoApenasSim
        {
            public override string EventoId => "kPoolTableEP6Trick2";
            public override string LegendaPtBr => "Sim fez truque de bilhar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPoolTableXylophoneTrick : EventoApenasSim
        {
            public override string EventoId => "kPoolTableXylophoneTrick";
            public override string LegendaPtBr => "Sim fez truque com xilofone";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPostedPhotoToBlog : EventoApenasSim
        {
            public override string EventoId => "kPostedPhotoToBlog";
            public override string LegendaPtBr => "Sim postou foto no blog";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPostedToForum : EventoApenasSim
        {
            public override string EventoId => "kPostedToForum";
            public override string LegendaPtBr => "Sim postou no fórum";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPostLoadFuture : EventoCompleto
        {
            public override string EventoId => "kPostLoadFuture";
            public override string LegendaPtBr => "Sim viu o futuro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPottyTrainedSim : EventoApenasSim
        {
            public override string EventoId => "kPottyTrainedSim";
            public override string LegendaPtBr => "Sim se fez no vasinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticedSkill : EventoApenasSim
        {
            public override string EventoId => "kPracticedSkill";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Sim praticou uma habilidade";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticedSpeech : EventoApenasSim
        {
            public override string EventoId => "kPracticedSpeech";
            public override string LegendaPtBr => "Sim praticou a oratória";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticedSpellcasting : EventoApenasSim
        {
            public override string EventoId => "kPracticedSpellcasting";
            public override string LegendaPtBr => "Sim praticou feitiçaria";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticedSpellcastingForTips : EventoApenasSim
        {
            public override string EventoId => "kPracticedSpellcastingForTips";
            public override string LegendaPtBr => "Sim praticou feitiçaria para dicas";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticeHuntingOnCatnipToy : EventoApenasSim
        {
            public override string EventoId => "kPracticeHuntingOnCatnipToy";
            public override string LegendaPtBr => "Sim caçou com brinquedo de catnip";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticeSchoolCheer : EventoApenasSim
        {
            public override string EventoId => "kPracticeSchoolCheer";
            public override string LegendaPtBr => "Sim praticou torcida escolar";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPracticeSketching : EventoApenasSim
        {
            public override string EventoId => "kPracticeSketching";
            public override string LegendaPtBr => "Sim praticou desenho";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPrankedASim : EventoApenasSim
        {
            public override string EventoId => "kPrankedASim";
            public override string LegendaPtBr => "Sim pregou uma peça em outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPrankSchool : EventoApenasSim
        {
            public override string EventoId => "kPrankSchool";
            public override string LegendaPtBr => "Sim pregou uma peça na escola";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPregnancyContractionsStarted : EventoApenasSim
        {
            public override string EventoId => "kPregnancyContractionsStarted";
            public override string LegendaPtBr => "Sim sentiu contrações de parto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPresentedBusinessPlan : EventoApenasSim
        {
            public override string EventoId => "kPresentedBusinessPlan";
            public override string LegendaPtBr => "Sim apresentou plano de negócios";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPreyRarityCaught : EventoApenasSim
        {
            public override string EventoId => "kPreyRarityCaught";
            public override string LegendaPtBr => "Sim capturou presa rara";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPreyTypeCaught : EventoApenasSim
        {
            public override string EventoId => "kPreyTypeCaught";
            public override string LegendaPtBr => "Sim capturou tipo de presa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoProjectedHologram : EventoApenasSim
        {
            public override string EventoId => "kProjectedHologram";
            public override string LegendaPtBr => "Sim projetou holograma";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPromisedDreamCompleted : EventoSimEFamilia
        {
            public override string EventoId => "kPromisedDreamCompleted";
            public override string LegendaPtBr => "Sim prometeu sonho realizado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }


        internal sealed class EventoPromoteCompetition : EventoSimEFamilia
        {
            public override string EventoId => "kPromoteCompetition";
            public override string LegendaPtBr => "Sim promoveu competição";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPromotedNewMovie : EventoSimEFamilia
        {
            public override string EventoId => "kPromotedNewMovie";
            public override string LegendaPtBr => "Sim lançou novo filme";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoProtectedPetHouse : EventoApenasSim
        {
            public override string EventoId => "kProtectedPetHouse";
            public override string LegendaPtBr => "Sim protegeu a casa do animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoProtectPetBed : EventoApenasSim
        {
            public override string EventoId => "kProtectPetBed";
            public override string LegendaPtBr => "Sim protegeu a cama do animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoPunishmentForgaveChild : EventoSimEFamilia
        {
            public override string EventoId => "kPunishmentForgaveChild";
            public override string LegendaPtBr => "Sim perdoou a criança";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPunishmentSnuckOut : EventoApenasSim
        {
            public override string EventoId => "kPunishmentSnuckOut";
            public override string LegendaPtBr => "Sim escapou sem permissão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPunishmentWasGrounded : EventoApenasSim
        {
            public override string EventoId => "kPunishmentWasGrounded";
            public override string LegendaPtBr => "Sim ficou impedido de sair";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPunishmentWasScolded : EventoApenasSim
        {
            public override string EventoId => "kPunishmentWasScolded";
            public override string LegendaPtBr => "Sim recebeu uma bronca";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPutFishInFishbowl : EventoApenasSim
        {
            public override string EventoId => "kPutFishInFishbowl";
            public override string LegendaPtBr => "Sim colocou peixe no aquário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPutOutSnackBowl : EventoApenasSim
        {
            public override string EventoId => "kPutOutSnackBowl";
            public override string LegendaPtBr => "Sim colocou petiscos na tigela";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPutPetToysAway : EventoApenasSim
        {
            public override string EventoId => "kPutPetToysAway";
            public override string LegendaPtBr => "Sim guardou os brinquedos do animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoPutPetUpForAdoption : EventoApenasSim
        {
            public override string EventoId => "kPutPetUpForAdoption";
            public override string LegendaPtBr => "Sim ofereceu animal para adoção";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoQuestionFateBall : EventoApenasSim
        {
            public override string EventoId => "kQuestionFateBall";
            public override string LegendaPtBr => "Sim questionou o destino com a bola";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoRaisedDefenseGrid : EventoApenasSim
        {
            public override string EventoId => "kRaisedDefenseGrid";
            public override string LegendaPtBr => "Sim aumentou a grade de defesa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoRakeLeafPile : EventoApenasSim
        {
            public override string EventoId => "kRakeLeafPile";
            public override string LegendaPtBr => "Sim recolheu folhas do monte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRanJumpingCourse : EventoApenasSim
        {
            public override string EventoId => "kRanJumpingCourse";
            public override string LegendaPtBr => "Sim completou o percurso de saltos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReachedNewLevelOfRhythmSkillTournamentRank : EventoApenasSim
        {
            public override string EventoId => "kReachedNewLevelOfRhythmSkillTournamentRank";
            public override string LegendaPtBr => "Sim avançou no torneio de ritmo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReadBook : EventoApenasSim
        {
            public override string EventoId => "kReadBook";
            public override string LegendaPtBr => "Sim leu um livro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReadInRockingChair : EventoApenasSim
        {
            public override string EventoId => "kReadInRockingChair";
            public override string LegendaPtBr => "Sim leu na cadeira de balanço";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReadInscriptionTimeStatue : EventoApenasSim
        {
            public override string EventoId => "kReadInscriptionTimeStatue";
            public override string LegendaPtBr => "Sim leu a inscrição da estátua";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReadMinds : EventoApenasSim
        {
            public override string EventoId => "kReadMinds";
            public override string LegendaPtBr => "Sim leu os pensamentos";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReadToSleep : EventoApenasSim
        {
            public override string EventoId => "kReadToSleep";
            public override string LegendaPtBr => "Sim leu para dormir";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRecalibratedDefenseGrid : EventoApenasSim
        {
            public override string EventoId => "kRecalibratedDefenseGrid";
            public override string LegendaPtBr => "Sim recalibrou a grade de defesa";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceiveCandyBar : EventoApenasSim
        {
            public override string EventoId => "kReceiveCandyBar";
            public override string LegendaPtBr => "Sim recebeu uma barra de chocolate";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceivedMysteryBoxFromFriend_BaseGame : EventoApenasSim
        {
            public override string EventoId => "kReceivedMysteryBoxFromFriend_BaseGame";
            public override string LegendaPtBr => "Sim recebeu caixa de amigo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceivedMysteryBoxFromFriend_EP7 : EventoApenasSim
        {
            public override string EventoId => "kReceivedMysteryBoxFromFriend_EP7";
            public override string LegendaPtBr => "Sim recebeu caixa de amigo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceivedPerfectSync : EventoApenasSim
        {
            public override string EventoId => "kReceivedPerfectSync";
            public override string LegendaPtBr => "Sim obteve sincronia perfeita";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceivedPotionFromFriend : EventoApenasSim
        {
            public override string EventoId => "kReceivedPotionFromFriend";
            public override string LegendaPtBr => "Sim recebeu poção de amigo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceivedRabbitHoleTreatment : EventoApenasSim
        {
            public override string EventoId => "kReceivedRabbitHoleTreatment";
            public override string LegendaPtBr => "Sim recebeu tratamento do buraco de coelho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReceivedSeasonalGnome : EventoApenasMundo
        {
            public override string EventoId => "kReceivedSeasonalGnome";
            public override string LegendaPtBr => "Sim recebeu gnomo da estação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoReceiveSoda : EventoApenasSim
        {
            public override string EventoId => "kReceiveSoda";
            public override string LegendaPtBr => "Sim recebeu refrigerante";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRecievedMeanSocial : EventoApenasSim
        {
            public override string EventoId => "kRecievedMeanSocial";
            public override string LegendaPtBr => "Sim recebeu interação negativa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReconstructedAMap : EventoApenasSim
        {
            public override string EventoId => "kReconstructedAMap";
            public override string LegendaPtBr => "Sim reconstruiu um mapa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRedeemFestivalTickets : EventoApenasMundo
        {
            public override string EventoId => "kRedeemFestivalTickets";
            public override string LegendaPtBr => "Sim resgatou ingressos do festival";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoRelationshipLTRChanged : EventoRuido
        {
            public override string EventoId => "kRelationshipLTRChanged";
            public override string LegendaPtBr => "Relacionamento sofreu atualização";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRelaxInPoolLounger : EventoApenasSim
        {
            public override string EventoId => "kRelaxInPoolLounger";
            public override string LegendaPtBr => "Sim relaxou na espreguiçadeira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemotelyViewedASim : EventoApenasSim
        {
            public override string EventoId => "kRemotelyViewedASim";
            public override string LegendaPtBr => "Sim observou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemotelyViewedSpecificSim : EventoApenasSim
        {
            public override string EventoId => "kRemotelyViewedSpecificSim";
            public override string LegendaPtBr => "Sim observou Sim específico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemovedRainbowDew : EventoApenasSim
        {
            public override string EventoId => "kRemovedRainbowDew";
            public override string LegendaPtBr => "Sim removeu orvalho de arco-íris";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemovedSimFromBoardingSchool : EventoApenasSim
        {
            public override string EventoId => "kRemovedSimFromBoardingSchool";
            public override string LegendaPtBr => "Sim deixou a escola interna";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemovedSimFromPassport : EventoApenasSim
        {
            public override string EventoId => "kRemovedSimFromPassport";
            public override string LegendaPtBr => "Sim removeu Sim do passaporte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemovedTraitChip : EventoApenasSim
        {
            public override string EventoId => "kRemovedTraitChip";
            public override string LegendaPtBr => "Sim removeu chip de traço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRemoveSim : EventoApenasSim
        {
            public override string EventoId => "kRemoveSim";
            public override string LegendaPtBr => "Sim deixou de existir";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRepairedObject : EventoApenasSim
        {
            public override string EventoId => "kRepairedObject";
            public override string LegendaPtBr => "Objeto foi consertado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRepairedTimePortal : EventoApenasSim
        {
            public override string EventoId => "kRepairedTimePortal";
            public override string LegendaPtBr => "Portal do tempo foi reparado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReplaceScratchingPost : EventoApenasSim
        {
            public override string EventoId => "kReplaceScratchingPost";
            public override string LegendaPtBr => "Arranhador foi substituído";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReportWritten : EventoApenasSim
        {
            public override string EventoId => "kReportWritten";
            public override string LegendaPtBr => "Sim escreveu um relatório";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRequestedAFairyGift : EventoApenasSim
        {
            public override string EventoId => "kRequestedAFairyGift";
            public override string LegendaPtBr => "Sim pediu um presente de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoResearchedInteriorDesign : EventoApenasSim
        {
            public override string EventoId => "kResearchedInteriorDesign";
            public override string LegendaPtBr => "Sim pesquisou design de interiores";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoResearchedSample : EventoApenasSim
        {
            public override string EventoId => "kResearchedSample";
            public override string LegendaPtBr => "Sim analisou uma amostra";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoResearchScience : EventoApenasSim
        {
            public override string EventoId => "kResearchScience";
            public override string LegendaPtBr => "Sim pesquisou ciência";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoResortEmpireLifetime : EventoApenasSim
        {
            public override string EventoId => "kResortEmpireLifetime";
            public override string LegendaPtBr => "Sim completou um objetivo de resort";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoResortRatingUpdated : EventoApenasSim
        {
            public override string EventoId => "kResortRatingUpdated";
            public override string LegendaPtBr => "Classificação do resort foi atualizada";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoResortTowerUpgraded : EventoApenasSim
        {
            public override string EventoId => "kResortTowerUpgraded";
            public override string LegendaPtBr => "Torre do resort foi aprimorada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRestoredGhost : EventoApenasSim
        {
            public override string EventoId => "kRestoredGhost";
            public override string LegendaPtBr => "Fantasma foi restaurado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoReturnedStolenObject : EventoApenasSim
        {
            public override string EventoId => "kReturnedStolenObject";
            public override string LegendaPtBr => "Sim recuperou objeto roubado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReturnedToSurface : EventoApenasSim
        {
            public override string EventoId => "kReturnedToSurface";
            public override string LegendaPtBr => "Sim retornou à superfície";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoReversedEngineerANanite : EventoApenasSim
        {
            public override string EventoId => "kReversedEngineerANanite";
            public override string LegendaPtBr => "Sim reverteu engenharia de Nanite";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRewardPurchased : EventoApenasSim
        {
            public override string EventoId => "kRewardPurchased";
            public override string LegendaPtBr => "Sim comprou recompensa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideBroomToLot : EventoApenasSim
        {
            public override string EventoId => "kRideBroomToLot";
            public override string LegendaPtBr => "Sim voou para o lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideEDS : EventoApenasSim
        {
            public override string EventoId => "kRideEDS";
            public override string LegendaPtBr => "Sim andou no EDS";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideHoverboard : EventoApenasSim
        {
            public override string EventoId => "kRideHoverboard";
            public override string LegendaPtBr => "Sim usou o hoverboard";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideInElevator : EventoApenasSim
        {
            public override string EventoId => "kRideInElevator";
            public override string LegendaPtBr => "Sim entrou no elevador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideMechanicalBullOnBuckingBronco : EventoApenasSim
        {
            public override string EventoId => "kRideMechanicalBullOnBuckingBronco";
            public override string LegendaPtBr => "Sim montou no touro mecânico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideMechanicalBullOnCrazyCowboy : EventoApenasSim
        {
            public override string EventoId => "kRideMechanicalBullOnCrazyCowboy";
            public override string LegendaPtBr => "Sim montou no touro mecânico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideMechanicalBullOnEasyRider : EventoApenasSim
        {
            public override string EventoId => "kRideMechanicalBullOnEasyRider";
            public override string LegendaPtBr => "Sim montou no touro mecânico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideRockingRider : EventoApenasSim
        {
            public override string EventoId => "kRideRockingRider";
            public override string LegendaPtBr => "Sim andou no cavalo de balanço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRideSpringRider : EventoApenasSim
        {
            public override string EventoId => "kRideSpringRider";
            public override string LegendaPtBr => "Sim andou no cavalinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRoadWetnessChanged : EventoApenasSim
        {
            public override string EventoId => "kRoadWetnessChanged";
            public override string LegendaPtBr => "Estrada ficou molhada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRockWithBabyInRockingChair : EventoSimEFamilia
        {
            public override string EventoId => "kRockWithBabyInRockingChair";
            public override string LegendaPtBr => "Sim embalou bebê na cadeira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoRodeHoverboardHours : EventoApenasSim
        {
            public override string EventoId => "kRodeHoverboardHours";
            public override string LegendaPtBr => "Sim andou de hoverboard";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoRunAround : EventoApenasSim
        {
            public override string EventoId => "kRunAround";
            public override string LegendaPtBr => "Sim correu pela casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSalvageBrokenObject : EventoApenasSim
        {
            public override string EventoId => "kSalvageBrokenObject";
            public override string LegendaPtBr => "Sim consertou objeto quebrado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSalvageBurnedObject : EventoApenasSim
        {
            public override string EventoId => "kSalvageBurnedObject";
            public override string LegendaPtBr => "Sim salvou objeto queimado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSawAGhost : EventoApenasSim
        {
            public override string EventoId => "kSawAGhost";
            public override string LegendaPtBr => "Sim viu um fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawBrokenObject : EventoApenasSim
        {
            public override string EventoId => "kSawBrokenObject";
            public override string LegendaPtBr => "Sim notou objeto quebrado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawCelebrity : EventoApenasSim
        {
            public override string EventoId => "kSawCelebrity";
            public override string LegendaPtBr => "Sim viu uma celebridade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawDirtyObject : EventoApenasSim
        {
            public override string EventoId => "kSawDirtyObject";
            public override string LegendaPtBr => "Sim viu objeto sujo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawEmptyOrDirtyDishes : EventoApenasSim
        {
            public override string EventoId => "kSawEmptyOrDirtyDishes";
            public override string LegendaPtBr => "Sim viu louça suja";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawEmptyPetBowl : EventoApenasSim
        {
            public override string EventoId => "kSawEmptyPetBowl";
            public override string LegendaPtBr => "Sim viu comedouro vazio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawFullTrashCan : EventoApenasSim
        {
            public override string EventoId => "kSawFullTrashCan";
            public override string LegendaPtBr => "Sim viu lixeira cheia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawIndoorRopes : EventoApenasSim
        {
            public override string EventoId => "kSawIndoorRopes";
            public override string LegendaPtBr => "Sim viu cordas dentro de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawPetVomit : EventoApenasSim
        {
            public override string EventoId => "kSawPetVomit";
            public override string LegendaPtBr => "Sim viu vômito de animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawPuddleOrBurntSpot : EventoRuido
        {
            public override string EventoId => "kSawPuddleOrBurntSpot";
            public override string LegendaPtBr => "Sim notou poça ou mancha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawServoCompetition : EventoApenasSim
        {
            public override string EventoId => "kSawServoCompetition";
            public override string LegendaPtBr => "Sim viu competição de Servos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawShowType : EventoApenasSim
        {
            public override string EventoId => "kSawShowType";
            public override string LegendaPtBr => "Sim assistiu a um show";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawSim : EventoRuido
        {
            public override string EventoId => "kSawSim";
            public override string LegendaPtBr => "Sim observou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSawTrashPile : EventoApenasSim
        {
            public override string EventoId => "kSawTrashPile";
            public override string LegendaPtBr => "Sim viu um monte de lixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSawUnmadeBed : EventoLote
        {
            public override string EventoId => "kSawUnmadeBed";
            public override string LegendaPtBr => "Sim viu a cama desfeita";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScannedWorkOfArt : EventoApenasSim
        {
            public override string EventoId => "kScannedWorkOfArt";
            public override string LegendaPtBr => "Sim analisou obra de arte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScaredByScarecrow : EventoApenasSim
        {
            public override string EventoId => "kScaredByScarecrow";
            public override string LegendaPtBr => "Sim se assustou com espantalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScaredGhost : EventoApenasSim
        {
            public override string EventoId => "kScaredGhost";
            public override string LegendaPtBr => "Sim se assustou com fantasma";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScaredSim : EventoApenasSim
        {
            public override string EventoId => "kScaredSim";
            public override string LegendaPtBr => "Sim se assustou com outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScaredSimWithMegaphone : EventoApenasSim
        {
            public override string EventoId => "kScaredSimWithMegaphone";
            public override string LegendaPtBr => "Sim se assustou com megafone";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScatteredHay : EventoApenasSim
        {
            public override string EventoId => "kScatteredHay";
            public override string LegendaPtBr => "Sim espalhou feno";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSchedulePoolParty : EventoSimEFamilia
        {
            public override string EventoId => "kSchedulePoolParty";
            public override string LegendaPtBr => "Sim agendou festa na piscina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScientificSpecialist : EventoApenasSim
        {
            public override string EventoId => "kScientificSpecialist";
            public override string LegendaPtBr => "Sim se tornou especialista científico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScoutRobotTribute : EventoApenasSim
        {
            public override string EventoId => "kScoutRobotTribute";
            public override string LegendaPtBr => "Sim ofereceu tributo ao robô";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScrappedNovel : EventoApenasSim
        {
            public override string EventoId => "kScrappedNovel";
            public override string LegendaPtBr => "Sim escreveu romance inacabado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScrappedPainting : EventoApenasSim
        {
            public override string EventoId => "kScrappedPainting";
            public override string LegendaPtBr => "Sim pintou quadro descartado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScratchFurniture : EventoApenasSim
        {
            public override string EventoId => "kScratchFurniture";
            public override string LegendaPtBr => "Sim arranhou móvel";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScratchOnCatCondo : EventoApenasSim
        {
            public override string EventoId => "kScratchOnCatCondo";
            public override string LegendaPtBr => "Sim arranhou o condomínio felino";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScratchScratchingPost : EventoApenasSim
        {
            public override string EventoId => "kScratchScratchingPost";
            public override string LegendaPtBr => "Sim arranhou o poste arranhador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoScubaDived : EventoApenasSim
        {
            public override string EventoId => "kScubaDived";
            public override string LegendaPtBr => "Sim mergulhou para explorar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSculptureMade : EventoApenasSim
        {
            public override string EventoId => "kSculptureMade";
            public override string LegendaPtBr => "Sim criou uma escultura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSculptureSold : EventoApenasSim
        {
            public override string EventoId => "kSculptureSold";
            public override string LegendaPtBr => "Sim vendeu a escultura";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSearchedGalaxy : EventoApenasSim
        {
            public override string EventoId => "kSearchedGalaxy";
            public override string LegendaPtBr => "Sim pesquisou a galáxia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSearchForFairies : EventoApenasSim
        {
            public override string EventoId => "kSearchForFairies";
            public override string LegendaPtBr => "Sim procurou por fadas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSeasonShutdown : EventoApenasMundo
        {
            public override string EventoId => "kSeasonShutdown";
            public override string LegendaPtBr => "Estação chegou ao fim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoSeedTaken : EventoApenasSim
        {
            public override string EventoId => "kSeedTaken";
            public override string LegendaPtBr => "Sim pegou uma semente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSeeWildHorse : EventoApenasSim
        {
            public override string EventoId => "kSeeWildHorse";
            public override string LegendaPtBr => "Sim observou cavalo selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSeeWildHorsePet : EventoApenasSim
        {
            public override string EventoId => "kSeeWildHorsePet";
            public override string LegendaPtBr => "Sim viu cavalo selvagem (pet)";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSelectableSimAutonomousActionInsertedIntoQueue : EventoApenasSim
        {
            public override string EventoId => "kSelectableSimAutonomousActionInsertedIntoQueue";
            public override string LegendaPtBr => "Sim executou ação autônoma";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSellHorse : EventoApenasSim
        {
            public override string EventoId => "kSellHorse";
            public override string LegendaPtBr => "Sim vendeu cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSendLoveLetterToSim : EventoApenasSim
        {
            public override string EventoId => "kSendLoveLetterToSim";
            public override string LegendaPtBr => "Sim enviou carta de amor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSentSimToArtSchool : EventoApenasSim
        {
            public override string EventoId => "kSentSimToArtSchool";
            public override string LegendaPtBr => "Sim foi para a escola de arte";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSentSimToMilitarySchool : EventoApenasSim
        {
            public override string EventoId => "kSentSimToMilitarySchool";
            public override string LegendaPtBr => "Sim foi para a escola militar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSentSimToNewFreeSchool : EventoApenasSim
        {
            public override string EventoId => "kSentSimToNewFreeSchool";
            public override string LegendaPtBr => "Sim foi para a escola livre";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSentSimToPrepSchool : EventoApenasSim
        {
            public override string EventoId => "kSentSimToPrepSchool";
            public override string LegendaPtBr => "Sim foi para a escola preparatória";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSentSimToSportsAcademy : EventoApenasSim
        {
            public override string EventoId => "kSentSimToSportsAcademy";
            public override string LegendaPtBr => "Sim foi para a academia esportiva";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSentText : EventoApenasSim
        {
            public override string EventoId => "kSentText";
            public override string LegendaPtBr => "Sim enviou mensagem de texto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoServiceNPCFired : EventoApenasSim
        {
            public override string EventoId => "kServiceNPCFired";
            public override string LegendaPtBr => "NPC de serviço foi demitido";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoServoBotCompetitionCompleted : EventoApenasSim
        {
            public override string EventoId => "kServoBotCompetitionCompleted";
            public override string LegendaPtBr => "Sim venceu a competição de Servobots";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSetBirdFree : EventoApenasSim
        {
            public override string EventoId => "kSetBirdFree";
            public override string LegendaPtBr => "Sim libertou um pássaro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSetBoobyTrap : EventoApenasSim
        {
            public override string EventoId => "kSetBoobyTrap";
            public override string LegendaPtBr => "Sim armou uma armadilha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSetOffAnyFirework : EventoApenasSim
        {
            public override string EventoId => "kSetOffAnyFirework";
            public override string LegendaPtBr => "Sim acendeu um fogaréu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShakeVendingMachine : EventoApenasSim
        {
            public override string EventoId => "kShakeVendingMachine";
            public override string LegendaPtBr => "Sim sacudiu a máquina de vendas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSharedHolidayGreetingCardPhoto : EventoApenasSim
        {
            public override string EventoId => "kSharedHolidayGreetingCardPhoto";
            public override string LegendaPtBr => "Sim compartilhou foto de cartão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShellCollected : EventoApenasSim
        {
            public override string EventoId => "kShellCollected";
            public override string LegendaPtBr => "Sim coletou uma concha";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShockedByObject : EventoApenasSim
        {
            public override string EventoId => "kShockedByObject";
            public override string LegendaPtBr => "Sim recebeu choque de objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShooedStray : EventoApenasSim
        {
            public override string EventoId => "kShooedStray";
            public override string LegendaPtBr => "Sim espantou um cão de rua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShooPetFromFurniture : EventoApenasSim
        {
            public override string EventoId => "kShooPetFromFurniture";
            public override string LegendaPtBr => "Sim expulsou animal do móvel";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShootCloudAt : EventoApenasSim
        {
            public override string EventoId => "kShootCloudAt";
            public override string LegendaPtBr => "Sim atirou na nuvem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShotBRollFootage : EventoApenasSim
        {
            public override string EventoId => "kShotBRollFootage";
            public override string LegendaPtBr => "Sim gravou filme de rolo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShowedGrossVideo : EventoApenasSim
        {
            public override string EventoId => "kShowedGrossVideo";
            public override string LegendaPtBr => "Sim exibiu vídeo nojento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShowGrossVideo : EventoApenasSim
        {
            public override string EventoId => "kShowGrossVideo";
            public override string LegendaPtBr => "Sim mostrou vídeo repugnante";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoShowOffGizmo : EventoApenasSim
        {
            public override string EventoId => "kShowOffGizmo";
            public override string LegendaPtBr => "Sim exibiu um aparelho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSignedUpForAfterschoolActivity : EventoApenasSim
        {
            public override string EventoId => "kSignedUpForAfterschoolActivity";
            public override string LegendaPtBr => "Sim se inscreveu em atividade extraescolar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSignUpChildForAfterschoolActivity : EventoSimEFamilia
        {
            public override string EventoId => "kSignUpChildForAfterschoolActivity";
            public override string LegendaPtBr => "Pai inscreveu filho em atividade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimAcceptedReward : EventoApenasSim
        {
            public override string EventoId => "kSimAcceptedReward";
            public override string LegendaPtBr => "Sim aceitou recompensa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimAgedPetDown : EventoApenasSim
        {
            public override string EventoId => "kSimAgedPetDown";
            public override string LegendaPtBr => "Animal de estimação envelheceu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimAgeTransition : EventoApenasSim
        {
            public override string EventoId => "kSimAgeTransition";
            public override string LegendaPtBr => "Sim mudou de idade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSimBottleFedFoal : EventoApenasSim
        {
            public override string EventoId => "kSimBottleFedFoal";
            public override string LegendaPtBr => "Sim alimentou potro com garrafa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimBrokeBoulderOnLot : EventoApenasSim
        {
            public override string EventoId => "kSimBrokeBoulderOnLot";
            public override string LegendaPtBr => "Sim quebrou pedra no lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSimCompletedOccupationTask : EventoApenasSim
        {
            public override string EventoId => "kSimCompletedOccupationTask";
            public override string LegendaPtBr => "Sim completou tarefa de trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSimCuredByUnicorn : EventoApenasSim
        {
            public override string EventoId => "kSimCuredByUnicorn";
            public override string LegendaPtBr => "Sim foi curado por unicórnio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSimDanced : EventoApenasSim
        {
            public override string EventoId => "kSimDanced";
            public override string LegendaPtBr => "Sim dançou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimDescriptionDisposed : EventoApenasSim
        {
            public override string EventoId => "kSimDescriptionDisposed";
            public override string LegendaPtBr => "Sim descartou descrição";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimDestroyed : EventoApenasSim
        {
            public override string EventoId => "kSimDestroyed";
            public override string LegendaPtBr => "Sim foi destruído";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSimDismountsHorse : EventoApenasSim
        {
            public override string EventoId => "kSimDismountsHorse";
            public override string LegendaPtBr => "Sim desmontou do cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimEnteredTomb : EventoApenasSim
        {
            public override string EventoId => "kSimEnteredTomb";
            public override string LegendaPtBr => "Sim entrou na tumba";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimEnteredVacationWorld : EventoApenasMundo
        {
            public override string EventoId => "kSimEnteredVacationWorld";
            public override string LegendaPtBr => "Sim entrou no mundo de férias";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimEnterSpecificLot : EventoApenasSim
        {
            public override string EventoId => "kSimEnterSpecificLot";
            public override string LegendaPtBr => "Sim entrou no lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimEnterSpecificTombRoom : EventoApenasSim
        {
            public override string EventoId => "kSimEnterSpecificTombRoom";
            public override string LegendaPtBr => "Sim entrou na sala da tumba";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimEnterTombRoomOnSpecificLot : EventoApenasSim
        {
            public override string EventoId => "kSimEnterTombRoomOnSpecificLot";
            public override string LegendaPtBr => "Sim entrou na tumba do lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimFellAsleep : EventoApenasSim
        {
            public override string EventoId => "kSimFellAsleep";
            public override string LegendaPtBr => "Sim adormeceu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimFullyExploredTombForFirstTime : EventoApenasSim
        {
            public override string EventoId => "kSimFullyExploredTombForFirstTime";
            public override string LegendaPtBr => "Sim explorou a tumba pela primeira vez";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimGettingOld : EventoApenasSim
        {
            public override string EventoId => "kSimGettingOld";
            public override string LegendaPtBr => "Sim envelheceu";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimInstantiated : EventoRuido
        {
            public override string EventoId => "kSimInstantiated";
            public override string LegendaPtBr => "Sim foi instanciado";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimIsMartialArtsGrandMaster : EventoApenasSim
        {
            public override string EventoId => "kSimIsMartialArtsGrandMaster";
            public override string LegendaPtBr => "Sim é mestre em artes marciais";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimIsNinjaMaster : EventoApenasSim
        {
            public override string EventoId => "kSimIsNinjaMaster";
            public override string LegendaPtBr => "Sim é mestre ninja";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimJammed : EventoApenasSim
        {
            public override string EventoId => "kSimJammed";
            public override string LegendaPtBr => "Sim travou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimKissed : EventoApenasSim
        {
            public override string EventoId => "kSimKissed";
            public override string LegendaPtBr => "Sim beijou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimMeditatedAtLot : EventoApenasSim
        {
            public override string EventoId => "kSimMeditatedAtLot";
            public override string LegendaPtBr => "Sim meditou no lote";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimMountsHorse : EventoApenasSim
        {
            public override string EventoId => "kSimMountsHorse";
            public override string LegendaPtBr => "Sim montou em um cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimMovedAwayFromTown : EventoApenasMundo
        {
            public override string EventoId => "kSimMovedAwayFromTown";
            public override string LegendaPtBr => "Sim mudou de cidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimoleansMadeFromTrickExhibition : EventoApenasSim
        {
            public override string EventoId => "kSimoleansMadeFromTrickExhibition";
            public override string LegendaPtBr => "Sim ganhou com truques";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimoleonsEarnedFromSellingSamples : EventoApenasSim
        {
            public override string EventoId => "kSimoleonsEarnedFromSellingSamples";
            public override string LegendaPtBr => "Sim vendeu amostras";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimOpenedTreasureChest : EventoApenasSim
        {
            public override string EventoId => "kSimOpenedTreasureChest";
            public override string LegendaPtBr => "Sim abriu um baú do tesouro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimOrderedDrinkFromBar : EventoApenasSim
        {
            public override string EventoId => "kSimOrderedDrinkFromBar";
            public override string LegendaPtBr => "Sim pediu bebida no bar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimPassedOut : EventoApenasSim
        {
            public override string EventoId => "kSimPassedOut";
            public override string LegendaPtBr => "Sim desmaiou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimPerformedAtGig : EventoApenasSim
        {
            public override string EventoId => "kSimPerformedAtGig";
            public override string LegendaPtBr => "Sim tocou em um show";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimPerformedCelebrityActivity : EventoApenasSim
        {
            public override string EventoId => "kSimPerformedCelebrityActivity";
            public override string LegendaPtBr => "Sim fez atividade de celebridade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimPleadToSphinx : EventoApenasSim
        {
            public override string EventoId => "kSimPleadToSphinx";
            public override string LegendaPtBr => "Sim implorou à Esfinge";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimReturnedFromVacationWorld : EventoApenasMundo
        {
            public override string EventoId => "kSimReturnedFromVacationWorld";
            public override string LegendaPtBr => "Sim voltou de viagem mundial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimRodeHorse : EventoApenasSim
        {
            public override string EventoId => "kSimRodeHorse";
            public override string LegendaPtBr => "Sim andou a cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimRodeHorseBareback : EventoApenasSim
        {
            public override string EventoId => "kSimRodeHorseBareback";
            public override string LegendaPtBr => "Sim andou a cavalo sem sela";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimSeekedCleansing : EventoApenasSim
        {
            public override string EventoId => "kSimSeekedCleansing";
            public override string LegendaPtBr => "Sim buscou limpeza espiritual";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimStartedGig : EventoApenasSim
        {
            public override string EventoId => "kSimStartedGig";
            public override string LegendaPtBr => "Sim iniciou trabalho temporário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimTookPhotograph : EventoApenasSim
        {
            public override string EventoId => "kSimTookPhotograph";
            public override string LegendaPtBr => "Sim tirou uma fotografia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimWokeUp : EventoApenasSim
        {
            public override string EventoId => "kSimWokeUp";
            public override string LegendaPtBr => "Sim acordou da cama";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSimWonSparTournamentMatch : EventoApenasSim
        {
            public override string EventoId => "kSimWonSparTournamentMatch";
            public override string LegendaPtBr => "Sim venceu partida de dardos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSingKaraoke : EventoApenasSim
        {
            public override string EventoId => "kSingKaraoke";
            public override string LegendaPtBr => "Sim cantou em karaokê";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSingKaraokeWith : EventoApenasSim
        {
            public override string EventoId => "kSingKaraokeWith";
            public override string LegendaPtBr => "Sim cantou karaokê com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSingToImaginaryFriend : EventoApenasSim
        {
            public override string EventoId => "kSingToImaginaryFriend";
            public override string LegendaPtBr => "Sim cantou para amigo imaginário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSitOnLap : EventoApenasSim
        {
            public override string EventoId => "kSitOnLap";
            public override string LegendaPtBr => "Sim sentou no colo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkateIce : EventoApenasSim
        {
            public override string EventoId => "kSkateIce";
            public override string LegendaPtBr => "Sim patinou no gelo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkateRoller : EventoApenasSim
        {
            public override string EventoId => "kSkateRoller";
            public override string LegendaPtBr => "Sim andou de patins";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkateSpin : EventoApenasSim
        {
            public override string EventoId => "kSkateSpin";
            public override string LegendaPtBr => "Sim girou em patins";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkeeBallScore : EventoApenasSim
        {
            public override string EventoId => "kSkeeBallScore";
            public override string LegendaPtBr => "Sim marcou pontos no Skee-Ball";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSketchedAStillLife : EventoApenasSim
        {
            public override string EventoId => "kSketchedAStillLife";
            public override string LegendaPtBr => "Sim desenhou natureza morta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkilledCareerMadeAGrand : EventoSimEFamilia
        {
            public override string EventoId => "kSkilledCareerMadeAGrand";
            public override string LegendaPtBr => "Sim fez um grande no trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoSkillTutoredSim : EventoApenasSim
        {
            public override string EventoId => "kSkillTutoredSim";
            public override string LegendaPtBr => "Sim ensinou habilidade a outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkippedUniversityClass : EventoApenasSim
        {
            public override string EventoId => "kSkippedUniversityClass";
            public override string LegendaPtBr => "Sim faltou aula na universidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSkippingWork : EventoApenasSim
        {
            public override string EventoId => "kSkippingWork";
            public override string LegendaPtBr => "Sim está faltando ao trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkyFalling : EventoApenasSim
        {
            public override string EventoId => "kSkyFalling";
            public override string LegendaPtBr => "Chuva de meteoros atingiu a vizinhança";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSkyNotFalling : EventoApenasSim
        {
            public override string EventoId => "kSkyNotFalling";
            public override string LegendaPtBr => "Céu limpo e ensolarado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSlamVendingMachine : EventoApenasSim
        {
            public override string EventoId => "kSlamVendingMachine";
            public override string LegendaPtBr => "Sim esmurrou a máquina de vendas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSleepOn : EventoApenasSim
        {
            public override string EventoId => "kSleepOn";
            public override string LegendaPtBr => "Sim dormiu em um objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSleepPetBed : EventoApenasSim
        {
            public override string EventoId => "kSleepPetBed";
            public override string LegendaPtBr => "Sim dormiu na cama de animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSleptInPetHouse : EventoApenasSim
        {
            public override string EventoId => "kSleptInPetHouse";
            public override string LegendaPtBr => "Sim dormiu na casinha de cachorro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSlideDownWaterslide : EventoApenasSim
        {
            public override string EventoId => "kSlideDownWaterslide";
            public override string LegendaPtBr => "Sim deslizou no toboágua";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSlideOnWaterSlide : EventoApenasSim
        {
            public override string EventoId => "kSlideOnWaterSlide";
            public override string LegendaPtBr => "Sim escorregou no escorregador";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSlowDanced : EventoApenasSim
        {
            public override string EventoId => "kSlowDanced";
            public override string LegendaPtBr => "Sim dançou lentamente com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSneakATaste : EventoApenasSim
        {
            public override string EventoId => "kSneakATaste";
            public override string LegendaPtBr => "Sim provou a torta na geladeira.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSneakOutAfterCurfew : EventoApenasSim
        {
            public override string EventoId => "kSneakOutAfterCurfew";
            public override string LegendaPtBr => "Sim saiu após toque de recolher";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSniffedSim : EventoApenasSim
        {
            public override string EventoId => "kSniffedSim";
            public override string LegendaPtBr => "Sim farejou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnowboard : EventoApenasSim
        {
            public override string EventoId => "kSnowboard";
            public override string LegendaPtBr => "Sim praticou snowboard";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnowboardTrick : EventoApenasSim
        {
            public override string EventoId => "kSnowboardTrick";
            public override string LegendaPtBr => "Sim executou manobra de snowboard";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnowDay : EventoApenasSim
        {
            public override string EventoId => "kSnowDay";
            public override string LegendaPtBr => "Sim aproveitou o dia de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnowLevelChanged : EventoApenasSim
        {
            public override string EventoId => "kSnowLevelChanged";
            public override string LegendaPtBr => "Nível de neve mudou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnubbedSim : EventoApenasSim
        {
            public override string EventoId => "kSnubbedSim";
            public override string LegendaPtBr => "Sim ignorou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnubStarted : EventoApenasSim
        {
            public override string EventoId => "kSnubStarted";
            public override string LegendaPtBr => "Sim começou a ignorar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSnuckPastBouncer : EventoApenasSim
        {
            public override string EventoId => "kSnuckPastBouncer";
            public override string LegendaPtBr => "Sim passou pelo segurança";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSnugglePetBed : EventoApenasSim
        {
            public override string EventoId => "kSnugglePetBed";
            public override string LegendaPtBr => "Sim aconchegou-se na cama do pet";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSocialFeatureEventID : EventoApenasSim
        {
            public override string EventoId => "kSocialFeatureEventID";
            public override string LegendaPtBr => "Sim interagiu socialmente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSocialInteraction : EventoApenasSim
        {
            public override string EventoId => "kSocialInteraction";
            public override bool IncluirAlvoNaTraducao => true;
            public override string LegendaPtBr => "Sim teve interação social";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSoldConsignedObject : EventoApenasSim
        {
            public override string EventoId => "kSoldConsignedObject";
            public override string LegendaPtBr => "Sim vendeu objeto consignado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSoldObject : EventoApenasSim
        {
            public override string EventoId => "kSoldObject";
            public override string LegendaPtBr => "Sim vendeu objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSoldProduce : EventoApenasSim
        {
            public override string EventoId => "kSoldProduce";
            public override string LegendaPtBr => "Sim vendeu produto da horta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSoldServoBot : EventoApenasSim
        {
            public override string EventoId => "kSoldServoBot";
            public override string LegendaPtBr => "Sim vendeu robô mordomo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoSoleSurvivorAchievement : EventoApenasSim
        {
            public override string EventoId => "kSoleSurvivorAchievement";
            public override string LegendaPtBr => "Sim sobreviveu sozinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSolicitedGig : EventoApenasSim
        {
            public override string EventoId => "kSolicitedGig";
            public override string LegendaPtBr => "Sim solicitou trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSoloHunted : EventoApenasSim
        {
            public override string EventoId => "kSoloHunted";
            public override string LegendaPtBr => "Sim caçou sozinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSolvedCase : EventoApenasSim
        {
            public override string EventoId => "kSolvedCase";
            public override string LegendaPtBr => "Sim resolveu o caso";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSoothingFairyAura : EventoApenasSim
        {
            public override string EventoId => "kSoothingFairyAura";
            public override string LegendaPtBr => "Sim recebeu aura de fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSoupedUpSpeakers : EventoApenasSim
        {
            public override string EventoId => "kSoupedUpSpeakers";
            public override string LegendaPtBr => "Sim melhorou sistema de som";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSpaceRockConsumed : EventoApenasSim
        {
            public override string EventoId => "kSpaceRockConsumed";
            public override string LegendaPtBr => "Sim consumiu rocha espacial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSparred : EventoApenasSim
        {
            public override string EventoId => "kSparred";
            public override string LegendaPtBr => "Sim trocou golpes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSpentMoneyAtDaySpa : EventoApenasSim
        {
            public override string EventoId => "kSpentMoneyAtDaySpa";
            public override string LegendaPtBr => "Sim gastou dinheiro no spa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoSportsAgentJob : EventoApenasSim
        {
            public override string EventoId => "kSportsAgentJob";
            public override string LegendaPtBr => "Sim iniciou carreira de agente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSpringHolidayStarted : EventoApenasSim
        {
            public override string EventoId => "kSpringHolidayStarted";
            public override string LegendaPtBr => "Festival da Primavera começou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSpriteSocial : EventoApenasSim
        {
            public override string EventoId => "kSpriteSocial";
            public override string LegendaPtBr => "Sim interagiu com duende";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStakeoutCompleted : EventoApenasSim
        {
            public override string EventoId => "kStakeoutCompleted";
            public override string LegendaPtBr => "Sim completou vigilância";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoStartedPainting : EventoApenasSim
        {
            public override string EventoId => "kStartedPainting";
            public override string LegendaPtBr => "Sim começou a pintar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStartedWritingNovel : EventoApenasSim
        {
            public override string EventoId => "kStartedWritingNovel";
            public override string LegendaPtBr => "Sim começou a escrever romance";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStartHavingTeenMoodSwing : EventoApenasSim
        {
            public override string EventoId => "kStartHavingTeenMoodSwing";
            public override string LegendaPtBr => "Sim teve mudança de humor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }



        internal sealed class EventoStealFoodPet : EventoApenasSim
        {
            public override string EventoId => "kStealFoodPet";
            public override string LegendaPtBr => "Sim roubou comida do animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStockMinorPet : EventoApenasSim
        {
            public override string EventoId => "kStockMinorPet";
            public override string LegendaPtBr => "Sim cuidou de animal menor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStoleCandyFromBaby : EventoApenasSim
        {
            public override string EventoId => "kStoleCandyFromBaby";
            public override string LegendaPtBr => "Sim roubou doce de bebê.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoStompedPumpkin : EventoApenasSim
        {
            public override string EventoId => "kStompedPumpkin";
            public override string LegendaPtBr => "Sim pisou na abóbora";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStoppedWorkingOut : EventoApenasSim
        {
            public override string EventoId => "kStoppedWorkingOut";
            public override string LegendaPtBr => "Sim parou de malhar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStoryProgressionMergedHouseholds : EventoApenasSim
        {
            public override string EventoId => "kStoryProgressionMergedHouseholds";
            public override string LegendaPtBr => "Famílias se uniram";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStoryProgressionMovedInWithPartner : EventoApenasSim
        {
            public override string EventoId => "kStoryProgressionMovedInWithPartner";
            public override string LegendaPtBr => "Sim mudou com parceiro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStreetArtLifetime : EventoApenasSim
        {
            public override string EventoId => "kStreetArtLifetime";
            public override string LegendaPtBr => "Sim criou arte de rua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoStrengthTimeAdded : EventoApenasSim
        {
            public override string EventoId => "kStrengthTimeAdded";
            public override string LegendaPtBr => "Sim ganhou tempo de força";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoStudied : EventoApenasSim
        {
            public override string EventoId => "kStudied";
            public override string LegendaPtBr => "Sim estudou";
            public override PesoNarrativo Peso => PesoNarrativo.MuitoAlto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoSuccessfullFirewalk : EventoApenasSim
        {
            public override string EventoId => "kSuccessfullFirewalk";
            public override string LegendaPtBr => "Sim andou no fogo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSuccessfullyPetRaccoon : EventoApenasSim
        {
            public override string EventoId => "kSuccessfullyPetRaccoon";
            public override string LegendaPtBr => "Sim acariciou guaxinim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSuctionedObject : EventoApenasSim
        {
            public override string EventoId => "kSuctionedObject";
            public override string LegendaPtBr => "Sim sugou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSummerHolidayStarted : EventoApenasSim
        {
            public override string EventoId => "kSummerHolidayStarted";
            public override string LegendaPtBr => "Férias de verão começaram";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSummonFood : EventoApenasSim
        {
            public override string EventoId => "kSummonFood";
            public override string LegendaPtBr => "Sim invocou comida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSurveyCatCondo : EventoApenasSim
        {
            public override string EventoId => "kSurveyCatCondo";
            public override string LegendaPtBr => "Sim pesquisou condomínio de gatos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSweetenedDessert : EventoApenasSim
        {
            public override string EventoId => "kSweetenedDessert";
            public override string LegendaPtBr => "Sim adoçou sobremesa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoSwimming : EventoApenasSim
        {
            public override string EventoId => "kSwimming";
            public override string LegendaPtBr => "Sim nadou na piscina";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoTaggedStatue : EventoApenasSim
        {
            public override string EventoId => "kTaggedStatue";
            public override string LegendaPtBr => "Sim marcou estátua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTakeMinorPet : EventoApenasSim
        {
            public override string EventoId => "kTakeMinorPet";
            public override string LegendaPtBr => "Sim pegou animal de estimação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTakenPhotoInPhotoBooth : EventoApenasSim
        {
            public override string EventoId => "kTakenPhotoInPhotoBooth";
            public override string LegendaPtBr => "Sim tirou foto na cabine";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTakenUnderwaterCamera : EventoApenasSim
        {
            public override string EventoId => "kTakenUnderwaterCamera";
            public override string LegendaPtBr => "Sim tirou foto subaquática";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTakePhotoWithFriend : EventoApenasSim
        {
            public override string EventoId => "kTakePhotoWithFriend";
            public override string LegendaPtBr => "Sim tirou foto com amigo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoTalkAboutDJSkills : EventoApenasSim
        {
            public override string EventoId => "kTalkAboutDJSkills";
            public override string LegendaPtBr => "Sim falou sobre habilidades DJ";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTalkAboutImaginaryFriend : EventoApenasSim
        {
            public override string EventoId => "kTalkAboutImaginaryFriend";
            public override string LegendaPtBr => "Sim falou sobre amigo imaginário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTalkAboutWeatherWithSim : EventoApenasMundo
        {
            public override string EventoId => "kTalkAboutWeatherWithSim";
            public override string LegendaPtBr => "Sim falou sobre o tempo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTalkedToSelf : EventoApenasSim
        {
            public override string EventoId => "kTalkedToSelf";
            public override string LegendaPtBr => "Sim conversou consigo mesmo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTalkToPlant : EventoApenasSim
        {
            public override string EventoId => "kTalkToPlant";
            public override string LegendaPtBr => "Sim conversou com planta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTalkWithBird : EventoApenasSim
        {
            public override string EventoId => "kTalkWithBird";
            public override string LegendaPtBr => "Sim conversou com pássaro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoTeachBirdToTalk : EventoApenasSim
        {
            public override string EventoId => "kTeachBirdToTalk";
            public override string LegendaPtBr => "Sim ensinou pássaro a falar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTeachingTeenToDrive : EventoApenasSim
        {
            public override string EventoId => "kTeachingTeenToDrive";
            public override string LegendaPtBr => "Sim ensina adolescente a dirigir";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTeachSimToTalk : EventoApenasSim
        {
            public override string EventoId => "kTeachSimToTalk";
            public override string LegendaPtBr => "Sim ensinou sim a falar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTeachSimToWalk : EventoApenasSim
        {
            public override string EventoId => "kTeachSimToWalk";
            public override string LegendaPtBr => "Sim ensinou sim a andar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTeenBreakingCurfew : EventoApenasSim
        {
            public override string EventoId => "kTeenBreakingCurfew";
            public override string LegendaPtBr => "Adolescente quebrou o toque de recolher";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTeenLearnedToDrive : EventoApenasSim
        {
            public override string EventoId => "kTeenLearnedToDrive";
            public override string LegendaPtBr => "Adolescente aprendeu a dirigir";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTeenLearningToDrive : EventoApenasSim
        {
            public override string EventoId => "kTeenLearningToDrive";
            public override string LegendaPtBr => "Adolescente aprende dirigindo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTestedSkeletalStructure : EventoApenasSim
        {
            public override string EventoId => "kTestedSkeletalStructure";
            public override string LegendaPtBr => "Sim testou estrutura esquelética";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTextureCompositorUsed : EventoApenasSim
        {
            public override string EventoId => "kTextureCompositorUsed";
            public override string LegendaPtBr => "Sim usou compositor de texturas";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoThrewBonfireParty : EventoSimEFamilia
        {
            public override string EventoId => "kThrewBonfireParty";
            public override string LegendaPtBr => "Sim organizou festa na fogueira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoThrewJuiceKeggerParty : EventoSimEFamilia
        {
            public override string EventoId => "kThrewJuiceKeggerParty";
            public override string LegendaPtBr => "Sim organizou festa de suco";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrewMasqueradeBall : EventoApenasSim
        {
            public override string EventoId => "kThrewMasqueradeBall";
            public override string LegendaPtBr => "Sim organizou baile de máscaras";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoThrewTailgatingParty : EventoSimEFamilia
        {
            public override string EventoId => "kThrewTailgatingParty";
            public override string LegendaPtBr => "Sim fez festa de carreata";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrewVictoryParty : EventoSimEFamilia
        {
            public override string EventoId => "kThrewVictoryParty";
            public override string LegendaPtBr => "Sim celebrou vitória com festa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrewVideoGameLANParty : EventoSimEFamilia
        {
            public override string EventoId => "kThrewVideoGameLANParty";
            public override string LegendaPtBr => "Sim promoveu festa de jogos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrowATestTube : EventoApenasSim
        {
            public override string EventoId => "kThrowATestTube";
            public override string LegendaPtBr => "Sim arremessou tubo de ensaio";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrowEggs : EventoApenasSim
        {
            public override string EventoId => "kThrowEggs";
            public override string LegendaPtBr => "Sim jogou ovos em alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrowFairyParty : EventoSimEFamilia
        {
            public override string EventoId => "kThrowFairyParty";
            public override string LegendaPtBr => "Sim preparou festa de fadas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrowFlyingDisc : EventoApenasSim
        {
            public override string EventoId => "kThrowFlyingDisc";
            public override string LegendaPtBr => "Sim lançou disco voador";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoThrownFromHorse : EventoApenasSim
        {
            public override string EventoId => "kThrownFromHorse";
            public override string LegendaPtBr => "Sim caiu de um cavalo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTimeMachineTravelFuture : EventoCompleto
        {
            public override string EventoId => "kTimeMachineTravelFuture";
            public override string LegendaPtBr => "Sim viajou para o futuro";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTimeMachineTravelPast : EventoCompleto
        {
            public override string EventoId => "kTimeMachineTravelPast";
            public override string LegendaPtBr => "Sim viajou para o passado";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTinkeredWithObject : EventoApenasSim
        {
            public override string EventoId => "kTinkeredWithObject";
            public override string LegendaPtBr => "Sim mexeu em um objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoToddlerAttackWithClaw : EventoApenasSim
        {
            public override string EventoId => "kToddlerAttackWithClaw";
            public override string LegendaPtBr => "Toddler atacou com as garras";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoToddlerChat : EventoApenasSim
        {
            public override string EventoId => "kToddlerChat";
            public override string LegendaPtBr => "Toddler conversou com alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoToddlerTickle : EventoApenasSim
        {
            public override string EventoId => "kToddlerTickle";
            public override string LegendaPtBr => "Toddler fez cócegas em alguém";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoToddlerTossInAir : EventoApenasSim
        {
            public override string EventoId => "kToddlerTossInAir";
            public override string LegendaPtBr => "Pequeno foi arremessado ao ar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTodified : EventoApenasSim
        {
            public override string EventoId => "kTodified";
            public override string LegendaPtBr => "Sim se transformou em criança";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTombObjectTrigger : EventoApenasSim
        {
            public override string EventoId => "kTombObjectTrigger";
            public override string LegendaPtBr => "Sim interagiu com tumba";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookBubbleBath : EventoApenasSim
        {
            public override string EventoId => "kTookBubbleBath";
            public override string LegendaPtBr => "Sim tomou banho de bolhas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookDNASample : EventoApenasSim
        {
            public override string EventoId => "kTookDNASample";
            public override string LegendaPtBr => "Sim coletou amostra de DNA";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookGenieLampUnderground : EventoApenasSim
        {
            public override string EventoId => "kTookGenieLampUnderground";
            public override string LegendaPtBr => "Sim pegou lâmpada de gênio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookHolidayGreetingCardPhoto : EventoApenasSim
        {
            public override string EventoId => "kTookHolidayGreetingCardPhoto";
            public override string LegendaPtBr => "Sim tirou foto de cartão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookOutTrash : EventoApenasSim
        {
            public override string EventoId => "kTookOutTrash";
            public override string LegendaPtBr => "Sim tirou o lixo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookPhoto : EventoApenasSim
        {
            public override string EventoId => "kTookPhoto";
            public override string LegendaPtBr => "Sim tirou uma fotografia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookSkillClass : EventoApenasSim
        {
            public override string EventoId => "kTookSkillClass";
            public override string LegendaPtBr => "Sim frequentou aula de habilidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTookWalkWithDog : EventoApenasSim
        {
            public override string EventoId => "kTookWalkWithDog";
            public override string LegendaPtBr => "Sim passeou com cachorro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrained : EventoApenasSim
        {
            public override string EventoId => "kTrained";
            public override string LegendaPtBr => "Sim foi treinado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrainedBot : EventoApenasSim
        {
            public override string EventoId => "kTrainedBot";
            public override string LegendaPtBr => "Robô foi treinado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrainedForRacing : EventoApenasSim
        {
            public override string EventoId => "kTrainedForRacing";
            public override string LegendaPtBr => "Sim treinou para corrida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrainedSim : EventoApenasSim
        {
            public override string EventoId => "kTrainedSim";
            public override string LegendaPtBr => "Sim treinou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTraitGained : EventoApenasSim
        {
            public override string EventoId => "kTraitGained";
            public override string LegendaPtBr => "Sim obteve um novo traço";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTraitReinforced : EventoApenasSim
        {
            public override string EventoId => "kTraitReinforced";
            public override string LegendaPtBr => "Sim reforçou um traço existente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTransformation : EventoApenasSim
        {
            public override string EventoId => "kTransformation";
            public override string LegendaPtBr => "Sim se transformou em animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTransmuted : EventoApenasSim
        {
            public override string EventoId => "kTransmuted";
            public override string LegendaPtBr => "Objeto foi transmutado em outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrashTalkedEnvironment : EventoApenasSim
        {
            public override string EventoId => "kTrashTalkedEnvironment";
            public override string LegendaPtBr => "Sim insultou o ambiente";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoTravelToPresent : EventoCompleto
        {
            public override string EventoId => "kTravelToPresent";
            public override string LegendaPtBr => "Sim retornou ao presente";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTravelToSpaceUFO : EventoCompleto
        {
            public override string EventoId => "kTravelToSpaceUFO";
            public override string LegendaPtBr => "Sim foi abduzido por alienígenas";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoTrickedByFairy : EventoApenasSim
        {
            public override string EventoId => "kTrickedByFairy";
            public override string LegendaPtBr => "Sim foi enganado por fada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrickEvent : EventoApenasSim
        {
            public override string EventoId => "kTrickEvent";
            public override string LegendaPtBr => "Sim executou um truque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrickExhibitionPerformed : EventoApenasSim
        {
            public override string EventoId => "kTrickExhibitionPerformed";
            public override string LegendaPtBr => "Sim fez apresentação de truques";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrickLearned : EventoApenasSim
        {
            public override string EventoId => "kTrickLearned";
            public override string LegendaPtBr => "Sim aprendeu um novo truque";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTrickTaught : EventoApenasSim
        {
            public override string EventoId => "kTrickTaught";
            public override string LegendaPtBr => "Sim ensinou um truque";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTriggeredCauseEffectWorldChange : EventoApenasMundo
        {
            public override string EventoId => "kTriggeredCauseEffectWorldChange";
            public override string LegendaPtBr => "Mudança mundial foi ativada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTriggerTutorialDream : EventoApenasSim
        {
            public override string EventoId => "kTriggerTutorialDream";
            public override string LegendaPtBr => "Sim teve sonho tutorial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }


        internal sealed class EventoTurnedThroughAlchemy : EventoApenasSim
        {
            public override string EventoId => "kTurnedThroughAlchemy";
            public override string LegendaPtBr => "Sim virou por alquimia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTurnImaginaryFriendReal : EventoApenasSim
        {
            public override string EventoId => "kTurnImaginaryFriendReal";
            public override string LegendaPtBr => "Amigo imaginário se tornou real";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutoredSim : EventoApenasSim
        {
            public override string EventoId => "kTutoredSim";
            public override string LegendaPtBr => "Sim ensinou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutoredSimInSkill : EventoApenasSim
        {
            public override string EventoId => "kTutoredSimInSkill";
            public override string LegendaPtBr => "Sim ensinou habilidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutorialTriggerEnter : EventoApenasSim
        {
            public override string EventoId => "kTutorialTriggerEnter";
            public override string LegendaPtBr => "Sim iniciou tutorial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutorialTriggerFindOwnPlace : EventoApenasSim
        {
            public override string EventoId => "kTutorialTriggerFindOwnPlace";
            public override string LegendaPtBr => "Sim encontrou seu lugar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutorialTriggerFinish : EventoApenasSim
        {
            public override string EventoId => "kTutorialTriggerFinish";
            public override string LegendaPtBr => "Sim finalizou tutorial";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutorialTriggerMeetSim : EventoApenasSim
        {
            public override string EventoId => "kTutorialTriggerMeetSim";
            public override string LegendaPtBr => "Sim conheceu outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTutorialTriggerReadBook : EventoApenasSim
        {
            public override string EventoId => "kTutorialTriggerReadBook";
            public override string LegendaPtBr => "Sim leu um livro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoTVBroke : EventoApenasSim
        {
            public override string EventoId => "kTVBroke";
            public override string LegendaPtBr => "Televisão quebrou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornBlessPlant : EventoApenasSim
        {
            public override string EventoId => "kUnicornBlessPlant";
            public override string LegendaPtBr => "Unicórnio abençoou planta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornBlessSim : EventoApenasSim
        {
            public override string EventoId => "kUnicornBlessSim";
            public override string LegendaPtBr => "Unicórnio abençoou Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornCureSim : EventoApenasSim
        {
            public override string EventoId => "kUnicornCureSim";
            public override string LegendaPtBr => "Unicórnio curou Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornCursePlant : EventoApenasSim
        {
            public override string EventoId => "kUnicornCursePlant";
            public override string LegendaPtBr => "Unicórnio amaldiçoou planta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornCurseSim : EventoApenasSim
        {
            public override string EventoId => "kUnicornCurseSim";
            public override string LegendaPtBr => "Sim foi amaldiçoado unicórnio";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornIgniteFire : EventoApenasSim
        {
            public override string EventoId => "kUnicornIgniteFire";
            public override string LegendaPtBr => "Unicórnio incendiou algo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUnicornTeleport : EventoApenasSim
        {
            public override string EventoId => "kUnicornTeleport";
            public override string LegendaPtBr => "Unicórnio se teleportou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUniqueObjectTaken : EventoApenasSim
        {
            public override string EventoId => "kUniqueObjectTaken";
            public override string LegendaPtBr => "Sim pegou objeto único";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUniqueUpgrade : EventoApenasSim
        {
            public override string EventoId => "kUniqueUpgrade";
            public override string LegendaPtBr => "Sim obteve upgrade único";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUpgradedObject : EventoApenasSim
        {
            public override string EventoId => "kUpgradedObject";
            public override string LegendaPtBr => "Objeto foi aprimorado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUpgradeLaserCAnnonsUFO : EventoCompleto
        {
            public override string EventoId => "kUpgradeLaserCAnnonsUFO";
            public override string LegendaPtBr => "Sim aprimorou canhões laser UFO";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUpgradeMagicWardrobe : EventoApenasSim
        {
            public override string EventoId => "kUpgradeMagicWardrobe";
            public override string LegendaPtBr => "Sim aprimorou armário mágico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUpgradeSpaceTravelUFO : EventoCompleto
        {
            public override string EventoId => "kUpgradeSpaceTravelUFO";
            public override string LegendaPtBr => "Sim aprimorou viagem espacial UFO";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoUpgradeWaterTrough : EventoApenasSim
        {
            public override string EventoId => "kUpgradeWaterTrough";
            public override string LegendaPtBr => "Sim aprimorou bebedouro";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUseAlchemyObject : EventoApenasSim
        {
            public override string EventoId => "kUseAlchemyObject";
            public override string LegendaPtBr => "Sim usou objeto alquímico";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUseBonfire : EventoApenasSim
        {
            public override string EventoId => "kUseBonfire";
            public override string LegendaPtBr => "Sim usou fogueira";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUseClawMachine : EventoApenasSim
        {
            public override string EventoId => "kUseClawMachine";
            public override string LegendaPtBr => "Sim usou garra mecânica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedBoardBreaker : EventoApenasSim
        {
            public override string EventoId => "kUsedBoardBreaker";
            public override string LegendaPtBr => "Sim usou quebra-tabuas";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedComputer : EventoApenasSim
        {
            public override string EventoId => "kUsedComputer";
            public override string LegendaPtBr => "Sim usou computador";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedDew : EventoApenasSim
        {
            public override string EventoId => "kUsedDew";
            public override string LegendaPtBr => "Sim usou orvalho";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedDewOnSelf : EventoApenasSim
        {
            public override string EventoId => "kUsedDewOnSelf";
            public override string LegendaPtBr => "Sim usou orvalho em si";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoUsedDontBreakASweatTone : EventoApenasSim
        {
            public override string EventoId => "kUsedDontBreakASweatTone";
            public override string LegendaPtBr => "Sim usou tom \"Sem Suor\"";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedFoodSynthesizer : EventoApenasSim
        {
            public override string EventoId => "kUsedFoodSynthesizer";
            public override string LegendaPtBr => "Sim usou sintetizador de comida";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedHappinessBeam : EventoApenasSim
        {
            public override string EventoId => "kUsedHappinessBeam";
            public override string LegendaPtBr => "Sim usou feixe de felicidade";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedHoloDisc : EventoApenasSim
        {
            public override string EventoId => "kUsedHoloDisc";
            public override string LegendaPtBr => "Sim usou disco holográfico";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedObect : EventoRuido
        {
            public override string EventoId => "kUsedObect";
            public override string LegendaPtBr => "Sim usou objeto";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedPottyChair : EventoApenasSim
        {
            public override string EventoId => "kUsedPottyChair";
            public override string LegendaPtBr => "Sim usou cadeira de higiene";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedPushSelfTone : EventoApenasSim
        {
            public override string EventoId => "kUsedPushSelfTone";
            public override string LegendaPtBr => "Sim usou tom \"Empurrão\"";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedQuickBurstTone : EventoApenasSim
        {
            public override string EventoId => "kUsedQuickBurstTone";
            public override string LegendaPtBr => "Sim usou tom \"Explosão Rápida\"";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedRainbowDewOnSelf : EventoApenasSim
        {
            public override string EventoId => "kUsedRainbowDewOnSelf";
            public override string LegendaPtBr => "Sim usou orvalho arco-íris em si";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoUsedSadnessBeam : EventoApenasSim
        {
            public override string EventoId => "kUsedSadnessBeam";
            public override string LegendaPtBr => "Sim usou feixe de tristeza";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedTelescope : EventoApenasSim
        {
            public override string EventoId => "kUsedTelescope";
            public override string LegendaPtBr => "Sim usou telescópio";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedTrainingDummy : EventoApenasSim
        {
            public override string EventoId => "kUsedTrainingDummy";
            public override string LegendaPtBr => "Sim usou manequim de treino";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedVehicle : EventoApenasSim
        {
            public override string EventoId => "kUsedVehicle";
            public override string LegendaPtBr => "Sim usou veículo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUsedWeatherMachine : EventoApenasMundo
        {
            public override string EventoId => "kUsedWeatherMachine";
            public override string LegendaPtBr => "Sim alterou o clima";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUseImaginationObject : EventoApenasSim
        {
            public override string EventoId => "kUseImaginationObject";
            public override string LegendaPtBr => "Sim brincou com a imaginação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUserDirectedInteraction : EventoApenasSim
        {
            public override string EventoId => "kUserDirectedInteraction";
            public override string LegendaPtBr => "Sim interagiu com outro";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUserDirectedInteractionName : EventoApenasSim
        {
            public override string EventoId => "kUserDirectedInteractionName";
            public override string LegendaPtBr => "Sim fez ação específica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUseRockingChair : EventoApenasSim
        {
            public override string EventoId => "kUseRockingChair";
            public override string LegendaPtBr => "Sim embalou o bebê";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoUseStinkBomb : EventoApenasSim
        {
            public override string EventoId => "kUseStinkBomb";
            public override string LegendaPtBr => "Sim jogou bomba fedorenta";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVacationTelemetryInfo : EventoCompleto
        {
            public override string EventoId => "kVacationTelemetryInfo";
            public override string LegendaPtBr => "Sim coletou dados de férias";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoVampireHunted : EventoApenasSim
        {
            public override string EventoId => "kVampireHunted";
            public override string LegendaPtBr => "Vampiro caçou outro Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVampireInSun : EventoApenasSim
        {
            public override string EventoId => "kVampireInSun";
            public override string LegendaPtBr => "Vampiro se expôs ao sol";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVampireLifetimeEvent : EventoApenasSim
        {
            public override string EventoId => "kVampireLifetimeEvent";
            public override string LegendaPtBr => "Vampiro teve evento de vida";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoViewHoloAdventure : EventoApenasSim
        {
            public override string EventoId => "kViewHoloAdventure";
            public override string LegendaPtBr => "Sim assistiu aventura holográfica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoViewMoonDial : EventoApenasSim
        {
            public override string EventoId => "kViewMoonDial";
            public override string LegendaPtBr => "Sim observou o dial da lua";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVisaLevelChanged : EventoApenasSim
        {
            public override string EventoId => "kVisaLevelChanged";
            public override string LegendaPtBr => "Nível de visto mudou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVisitedRabbitHole : EventoApenasSim
        {
            public override string EventoId => "kVisitedRabbitHole";
            public override string LegendaPtBr => "Sim visitou local secreto";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVisitedRabbitHoleWithPet : EventoApenasSim
        {
            public override string EventoId => "kVisitedRabbitHoleWithPet";
            public override string LegendaPtBr => "Sim visitou buraco de coelho com animal";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVisitedShell : EventoApenasSim
        {
            public override string EventoId => "kVisitedShell";
            public override string LegendaPtBr => "Sim encontrou concha na praia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVisitLot : EventoApenasSim
        {
            public override string EventoId => "kVisitLot";
            public override string LegendaPtBr => "Sim visitou outro lote";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoVisitWasteLandStore : EventoApenasSim
        {
            public override string EventoId => "kVisitWasteLandStore";
            public override string LegendaPtBr => "Sim comprou sucata na loja";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWashedHands : EventoApenasSim
        {
            public override string EventoId => "kWashedHands";
            public override string LegendaPtBr => "Sim lavou as mãos na pia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWashedOneDish : EventoApenasSim
        {
            public override string EventoId => "kWashedOneDish";
            public override string LegendaPtBr => "Sim lavou um prato na pia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWasInvitedOver : EventoApenasSim
        {
            public override string EventoId => "kWasInvitedOver";
            public override string LegendaPtBr => "Sim foi convidado para uma festa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWasKicked : EventoApenasSim
        {
            public override string EventoId => "kWasKicked";
            public override string LegendaPtBr => "Sim foi chutado durante briga";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWatchAnts : EventoApenasSim
        {
            public override string EventoId => "kWatchAnts";
            public override string LegendaPtBr => "Sim observou formigas no chão";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchAShark : EventoApenasSim
        {
            public override string EventoId => "kWatchAShark";
            public override string LegendaPtBr => "Sim viu tubarão no oceano";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchCatInCatJungleGym : EventoApenasSim
        {
            public override string EventoId => "kWatchCatInCatJungleGym";
            public override string LegendaPtBr => "Sim observou gato no parquinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchCatPlayWithCatToy : EventoApenasSim
        {
            public override string EventoId => "kWatchCatPlayWithCatToy";
            public override string LegendaPtBr => "Sim viu gato brincar com brinquedo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedGroundArt : EventoApenasSim
        {
            public override string EventoId => "kWatchedGroundArt";
            public override string LegendaPtBr => "Sim observou a arte no chão";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedLaserHarp : EventoApenasSim
        {
            public override string EventoId => "kWatchedLaserHarp";
            public override string LegendaPtBr => "Sim apreciou a harpa a laser";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedScarecrow : EventoApenasSim
        {
            public override string EventoId => "kWatchedScarecrow";
            public override string LegendaPtBr => "Sim observou o espantalho";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedSportsChannel : EventoApenasSim
        {
            public override string EventoId => "kWatchedSportsChannel";
            public override string LegendaPtBr => "Sim assistiu ao canal esportivo";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedStadiumGame : EventoApenasSim
        {
            public override string EventoId => "kWatchedStadiumGame";
            public override string LegendaPtBr => "Sim viu o jogo no estádio";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedStars : EventoApenasSim
        {
            public override string EventoId => "kWatchedStars";
            public override string LegendaPtBr => "Sim contemplou as estrelas";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedTv : EventoApenasSim
        {
            public override string EventoId => "kWatchedTv";
            public override string LegendaPtBr => "Sim assistiu televisão";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchedWallArt : EventoApenasSim
        {
            public override string EventoId => "kWatchedWallArt";
            public override string LegendaPtBr => "Sim admirou a arte na parede";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchFishInBowl : EventoApenasSim
        {
            public override string EventoId => "kWatchFishInBowl";
            public override string LegendaPtBr => "Sim observou peixes no aquário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchGig : EventoApenasSim
        {
            public override string EventoId => "kWatchGig";
            public override string LegendaPtBr => "Sim assistiu a apresentação musical";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchMinorPet : EventoApenasSim
        {
            public override string EventoId => "kWatchMinorPet";
            public override string LegendaPtBr => "Sim observou o animal de estimação";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchNPCAnimal : EventoApenasSim
        {
            public override string EventoId => "kWatchNPCAnimal";
            public override string LegendaPtBr => "Sim viu animal não jogável";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchSimFest : EventoApenasSim
        {
            public override string EventoId => "kWatchSimFest";
            public override string LegendaPtBr => "Sim viu o festival de Sims";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchSnowboarding : EventoApenasSim
        {
            public override string EventoId => "kWatchSnowboarding";
            public override string LegendaPtBr => "Sim observou o snowboard";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchWildHorse : EventoApenasSim
        {
            public override string EventoId => "kWatchWildHorse";
            public override string LegendaPtBr => "Sim viu o cavalo selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWatchWildHorsePet : EventoApenasSim
        {
            public override string EventoId => "kWatchWildHorsePet";
            public override string LegendaPtBr => "Sim observou cavalo selvagem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWateredPlant : EventoApenasSim
        {
            public override string EventoId => "kWateredPlant";
            public override string LegendaPtBr => "Sim regou a planta";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWearACostume : EventoApenasSim
        {
            public override string EventoId => "kWearACostume";
            public override string LegendaPtBr => "Sim vestiu fantasia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }



        internal sealed class EventoWeatherTerrainTypeChanged : EventoApenasMundo
        {
            public override string EventoId => "kWeatherTerrainTypeChanged";
            public override string LegendaPtBr => "Terreno mudou com o clima";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWeededPlant : EventoApenasSim
        {
            public override string EventoId => "kWeededPlant";
            public override string LegendaPtBr => "Sim removeu ervas daninhas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWeightChanged : EventoApenasSim
        {
            public override string EventoId => "kWeightChanged";
            public override string LegendaPtBr => "Sim alterou seu peso";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentFishing : EventoApenasSim
        {
            public override string EventoId => "kWentFishing";
            public override string LegendaPtBr => "Sim foi pescar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentForHorseRide : EventoApenasSim
        {
            public override string EventoId => "kWentForHorseRide";
            public override string LegendaPtBr => "Sim cavalgou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentOnFieldTrip : EventoApenasSim
        {
            public override string EventoId => "kWentOnFieldTrip";
            public override string LegendaPtBr => "Sim foi em excursão escolar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentOnStrollWithUsingStroller : EventoApenasSim
        {
            public override string EventoId => "kWentOnStrollWithUsingStroller";
            public override string LegendaPtBr => "Sim passeou com carrinho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentOut : EventoApenasSim
        {
            public override string EventoId => "kWentOut";
            public override string LegendaPtBr => "Sim saiu de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentSnorkeling : EventoApenasSim
        {
            public override string EventoId => "kWentSnorkeling";
            public override string LegendaPtBr => "Sim foi fazer mergulho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWentThroughVelvetRopes : EventoApenasSim
        {
            public override string EventoId => "kWentThroughVelvetRopes";
            public override string LegendaPtBr => "Sim atravessou cordas de veludo";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWentToWork : EventoApenasSim
        {
            public override string EventoId => "kWentToWork";
            public override string LegendaPtBr => "Sim foi trabalhar";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWereWolfHunt : EventoApenasSim
        {
            public override string EventoId => "kWereWolfHunt";
            public override string LegendaPtBr => "Sim participou da caçada";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWerewolfLifeEvent : EventoApenasSim
        {
            public override string EventoId => "kWerewolfLifeEvent";
            public override string LegendaPtBr => "Sim teve evento de lobisomem";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWerewolfScratchFurniture : EventoApenasSim
        {
            public override string EventoId => "kWerewolfScratchFurniture";
            public override string LegendaPtBr => "Sim arranhou os móveis";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWhacASupernaturalScore : EventoApenasSim
        {
            public override string EventoId => "kWhacASupernaturalScore";
            public override string LegendaPtBr => "Sim obteve pontuação sobrenatural";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinAppleBobbingContest : EventoApenasSim
        {
            public override string EventoId => "kWinAppleBobbingContest";
            public override string LegendaPtBr => "Sim venceu a pescaria de maçãs";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinArenaMatch : EventoApenasSim
        {
            public override string EventoId => "kWinArenaMatch";
            public override string LegendaPtBr => "Sim venceu a luta na arena";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinEggHunt : EventoApenasSim
        {
            public override string EventoId => "kWinEggHunt";
            public override string LegendaPtBr => "Sim venceu a caça aos ovos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinGameOfPool : EventoApenasSim
        {
            public override string EventoId => "kWinGameOfPool";
            public override string LegendaPtBr => "Sim venceu o jogo de sinuca";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWinHorseshoes : EventoApenasSim
        {
            public override string EventoId => "kWinHorseshoes";
            public override string LegendaPtBr => "Sim venceu o arremesso de ferraduras";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinHotdogContest : EventoApenasSim
        {
            public override string EventoId => "kWinHotdogContest";
            public override string LegendaPtBr => "Sim venceu o concurso de cachorros-quentes";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWinPieContest : EventoApenasSim
        {
            public override string EventoId => "kWinPieContest";
            public override string LegendaPtBr => "Sim venceu a competição de tortas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }


        internal sealed class EventoWinSnowballFight : EventoApenasSim
        {
            public override string EventoId => "kWinSnowballFight";
            public override string LegendaPtBr => "Sim venceu a briga de bolas de neve";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinSpringFestival : EventoApenasMundo
        {
            public override string EventoId => "kWinSpringFestival";
            public override string LegendaPtBr => "Sim ganhou o Festival da Primavera";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinterHolidayStarted : EventoApenasSim
        {
            public override string EventoId => "kWinterHolidayStarted";
            public override string LegendaPtBr => "Festa de Inverno começou";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinTriviaCompetition : EventoApenasSim
        {
            public override string EventoId => "kWinTriviaCompetition";
            public override string LegendaPtBr => "Sim venceu a competição de trivia";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWinWaterBalloonFight : EventoApenasSim
        {
            public override string EventoId => "kWinWaterBalloonFight";
            public override string LegendaPtBr => "Sim venceu a briga de balões d'água";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWishForBeauty : EventoApenasSim
        {
            public override string EventoId => "kWishForBeauty";
            public override string LegendaPtBr => "Sim desejou beleza";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }


        internal sealed class EventoWishForHappiness : EventoApenasSim
        {
            public override string EventoId => "kWishForHappiness";
            public override string LegendaPtBr => "Sim desejou felicidade";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoWishForLargeFamily : EventoSimEFamilia
        {
            public override string EventoId => "kWishForLargeFamily";
            public override string LegendaPtBr => "Sim desejou uma família grande";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoWishForLongLife : EventoApenasSim
        {
            public override string EventoId => "kWishForLongLife";
            public override string LegendaPtBr => "Sim desejou vida longa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoWishForLove : EventoApenasSim
        {
            public override string EventoId => "kWishForLove";
            public override string LegendaPtBr => "Sim desejou amor";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }

        internal sealed class EventoWishForMoreWishes : EventoApenasSim
        {
            public override string EventoId => "kWishForMoreWishes";
            public override string LegendaPtBr => "Sim desejou mais desejos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento;
        }



        internal sealed class EventoWonABarBrawl : EventoApenasSim
        {
            public override string EventoId => "kWonABarBrawl";
            public override string LegendaPtBr => "Sim venceu briga no bar";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }


        internal sealed class EventoWonChessGame : EventoApenasSim
        {
            public override string EventoId => "kWonChessGame";
            public override string LegendaPtBr => "Sim venceu partida de xadrez";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoWonDartGame : EventoApenasSim
        {
            public override string EventoId => "kWonDartGame";
            public override string LegendaPtBr => "Sim venceu jogo de dardos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoWonFightWithShark : EventoApenasSim
        {
            public override string EventoId => "kWonFightWithShark";
            public override string LegendaPtBr => "Sim venceu luta com tubarão";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoWonGameAgainstSim : EventoApenasSim
        {
            public override string EventoId => "kWonGameAgainstSim";
            public override string LegendaPtBr => "Sim venceu jogo contra Sim";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoWonHopscotch : EventoApenasSim
        {
            public override string EventoId => "kWonHopscotch";
            public override string LegendaPtBr => "Sim venceu jogo de amarelinha";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoWonHorseCompetition : EventoApenasSim
        {
            public override string EventoId => "kWonHorseCompetition";
            public override string LegendaPtBr => "Sim venceu competição de cavalos";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }

        internal sealed class EventoWonPingPongGame : EventoApenasSim
        {
            public override string EventoId => "kWonPingPongGame";
            public override string LegendaPtBr => "Sim venceu partida de ping pong";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }


        internal sealed class EventoWonShuffleboardGame : EventoApenasSim
        {
            public override string EventoId => "kWonShuffleboardGame";
            public override string LegendaPtBr => "Sim venceu jogo de shuffleboard";
            public override PesoNarrativo Peso => PesoNarrativo.Alto;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Conto;
        }



        internal sealed class EventoWooHooedInTheFairyHouse : EventoApenasSim
        {
            public override string EventoId => "kWooHooedInTheFairyHouse";
            public override string LegendaPtBr => "Sim teve romance na casa élfica";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWooHooedInTheVardo : EventoApenasSim
        {
            public override string EventoId => "kWooHooedInTheVardo";
            public override string LegendaPtBr => "Sim se amou no vardo cigano";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWooHooInAllInOneBathroom : EventoApenasSim
        {
            public override string EventoId => "kWooHooInAllInOneBathroom";
            public override string LegendaPtBr => "Sim flertou no banheiro conjugado.";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWoohooInHayStack : EventoApenasSim
        {
            public override string EventoId => "kWoohooInHayStack";
            public override string LegendaPtBr => "Sim se amou no fardo de feno";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWoohooInLeafPile : EventoApenasSim
        {
            public override string EventoId => "kWoohooInLeafPile";
            public override string LegendaPtBr => "Sim se amou na pilha de folhas";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWoohooInPhotoBooth : EventoApenasSim
        {
            public override string EventoId => "kWoohooInPhotoBooth";
            public override string LegendaPtBr => "Sim se beijou na cabine de fotos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWooHooInUnderwaterCave : EventoApenasSim
        {
            public override string EventoId => "kWooHooInUnderwaterCave";
            public override string LegendaPtBr => "Sim se amou na gruta subaquática";
            public override PesoNarrativo Peso => PesoNarrativo.Baixo;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWoohooInWardrobe : EventoApenasSim
        {
            public override string EventoId => "kWoohooInWardrobe";
            public override string LegendaPtBr => "Sim se amou no armário";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkAnniversary : EventoApenasSim
        {
            public override string EventoId => "kWorkAnniversary";
            public override string LegendaPtBr => "Sim celebrou aniversário no trabalho";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkCanceled : EventoApenasSim
        {
            public override string EventoId => "kWorkCanceled";
            public override string LegendaPtBr => "Sim teve trabalho cancelado";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkedAsBartender : EventoApenasSim
        {
            public override string EventoId => "kWorkedAsBartender";
            public override string LegendaPtBr => "Sim trabalhou como barman";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkedFromHome : EventoApenasSim
        {
            public override string EventoId => "kWorkedFromHome";
            public override string LegendaPtBr => "Sim trabalhou de casa";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkedOnBusinessPlan : EventoApenasSim
        {
            public override string EventoId => "kWorkedOnBusinessPlan";
            public override string LegendaPtBr => "Sim elaborou plano de negócios";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkedOnNovel : EventoApenasSim
        {
            public override string EventoId => "kWorkedOnNovel";
            public override string LegendaPtBr => "Sim escreveu um romance";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkedOut : EventoApenasSim
        {
            public override string EventoId => "kWorkedOut";
            public override string LegendaPtBr => "Sim fez exercícios";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkoutComplete : EventoApenasSim
        {
            public override string EventoId => "kWorkoutComplete";
            public override string LegendaPtBr => "Sim terminou o treino";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorkoutFatigued : EventoApenasSim
        {
            public override string EventoId => "kWorkoutFatigued";
            public override string LegendaPtBr => "Sim sentiu fadiga muscular";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWorldFreezingOrMelting : EventoRuido
        {
            public override string EventoId => "kWorldFreezingOrMelting";
            public override string LegendaPtBr => "Mundo sofreu mudança climática";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWroteBookOfGenre : EventoApenasSim
        {
            public override string EventoId => "kWroteBookOfGenre";
            public override string LegendaPtBr => "Sim escreveu livro de gênero";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWroteBookWithRoyaltyAmount : EventoApenasSim
        {
            public override string EventoId => "kWroteBookWithRoyaltyAmount";
            public override string LegendaPtBr => "Sim escreveu livro com direitos";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWroteScreenplay : EventoApenasSim
        {
            public override string EventoId => "kWroteScreenplay";
            public override string LegendaPtBr => "Sim escreveu roteiro de filme";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoWroteThankYouNote : EventoApenasSim
        {
            public override string EventoId => "kWroteThankYouNote";
            public override string LegendaPtBr => "Sim escreveu bilhete de agradecimento";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        internal sealed class EventoZombieMaster : EventoApenasSim
        {
            public override string EventoId => "kZombieMaster";
            public override string LegendaPtBr => "Sim se tornou mestre zumbi";
            public override PesoNarrativo Peso => PesoNarrativo.Neutro;
            public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Generico;
        }

        // =========================================================
        // EVENTOS DE INFRAESTRUTURA (RUÍDO)
        // =========================================================

        internal sealed class EventoRuidoSimHeartbeat : EventoRuido { public override string EventoId => "kSimHeartbeat"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoDnPSynchronizeEvent : EventoRuido { public override string EventoId => "kDnPSynchronizeEvent"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoRelationshipInteractionBitAdded : EventoRuido { public override string EventoId => "kRelationshipInteractionBitAdded"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoRelationshipBitAdded : EventoRuido { public override string EventoId => "kRelationshipBitAdded"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimTimeChanged : EventoRuido { public override string EventoId => "kSimTimeChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimClockUpdate : EventoRuido { public override string EventoId => "kSimClockUpdate"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoWorldTimeStep : EventoRuido { public override string EventoId => "kWorldTimeStep"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimPeriodicUpdate : EventoRuido { public override string EventoId => "kSimPeriodicUpdate"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimSelected : EventoRuido { public override string EventoId => "kSimSelected"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoUiModeChanged : EventoRuido { public override string EventoId => "kUiModeChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimTooltipChanged : EventoRuido { public override string EventoId => "kSimTooltipChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimOutfitChanged : EventoRuido { public override string EventoId => "kSimOutfitChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimThoughtBalloonShown : EventoRuido { public override string EventoId => "kSimThoughtBalloonShown"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimRouteStarted : EventoRuido { public override string EventoId => "kSimRouteStarted"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimRouteFinished : EventoRuido { public override string EventoId => "kSimRouteFinished"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimRouteFailed : EventoRuido { public override string EventoId => "kSimRouteFailed"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimRoutePathFailed : EventoRuido { public override string EventoId => "kSimRoutePathFailed"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimNavigationStarted : EventoRuido { public override string EventoId => "kSimNavigationStarted"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimNavigationFinished : EventoRuido { public override string EventoId => "kSimNavigationFinished"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimNavigationFailed : EventoRuido { public override string EventoId => "kSimNavigationFailed"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimEnteringRoom : EventoRuido { public override string EventoId => "kSimEnteringRoom"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimExitingRoom : EventoRuido { public override string EventoId => "kSimExitingRoom"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoRoomChanged : EventoRuido { public override string EventoId => "kRoomChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimMotiveChanged : EventoRuido { public override string EventoId => "kSimMotiveChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimMotiveUpdate : EventoRuido { public override string EventoId => "kSimMotiveUpdate"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimMoodletUpdate : EventoRuido { public override string EventoId => "kSimMoodletUpdate"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimSkillChange : EventoRuido { public override string EventoId => "kSimSkillChange"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimMoodChange : EventoRuido { public override string EventoId => "kSimMoodChange"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimStatChange : EventoRuido { public override string EventoId => "kSimStatChange"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoRelationshipValueModified : EventoRuido { public override string EventoId => "kRelationshipValueModified"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimAnimationStarted : EventoRuido { public override string EventoId => "kSimAnimationStarted"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimAnimationFinished : EventoRuido { public override string EventoId => "kSimAnimationFinished"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimAnimationLoop : EventoRuido { public override string EventoId => "kSimAnimationLoop"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimAnimationEvent : EventoRuido { public override string EventoId => "kSimAnimationEvent"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimEffectEvent : EventoRuido { public override string EventoId => "kSimEffectEvent"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimSoundEvent : EventoRuido { public override string EventoId => "kSimSoundEvent"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimVfxPlayed : EventoRuido { public override string EventoId => "kSimVfxPlayed"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimSocializing : EventoRuido { public override string EventoId => "kSimSocializing"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimTalking : EventoRuido { public override string EventoId => "kSimTalking"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimListening : EventoRuido { public override string EventoId => "kSimListening"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSocialInteractionPulse : EventoRuido { public override string EventoId => "kSocialInteractionPulse"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSocialInteractionProgress : EventoRuido { public override string EventoId => "kSocialInteractionProgress"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoObjectStateUpdated : EventoRuido { public override string EventoId => "kObjectStateUpdated"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoObjectArrived : EventoRuido { public override string EventoId => "kObjectArrived"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoObjectDeparted : EventoRuido { public override string EventoId => "kObjectDeparted"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoTopicChanged : EventoRuido { public override string EventoId => "kTopicChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimSocialHeartbeat : EventoRuido { public override string EventoId => "kSimSocialHeartbeat"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimAgingPulse : EventoRuido { public override string EventoId => "kSimAgingPulse"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimStatIncrement : EventoRuido { public override string EventoId => "kSimStatIncrement"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimStateChanged : EventoRuido { public override string EventoId => "kSimStateChanged"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimEffectAdded : EventoRuido { public override string EventoId => "kSimEffectAdded"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimEffectRemoved : EventoRuido { public override string EventoId => "kSimEffectRemoved"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimSoundPlayed : EventoRuido { public override string EventoId => "kSimSoundPlayed"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }
        internal sealed class EventoRuidoSimKnowledgeDiscovery : EventoRuido { public override string EventoId => "kSimKnowledgeDiscovery"; public override string LegendaPtBr => "Ruído de infraestrutura"; public override PesoNarrativo Peso => PesoNarrativo.MuitoBaixo; public override CategoriaEventoNarrativo Categoria => CategoriaEventoNarrativo.Pensamento; }

    }
}
