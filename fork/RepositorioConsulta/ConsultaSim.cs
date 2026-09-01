using Sims3.Gameplay.Actors;
using Sims3.Gameplay.CAS;
using Sims3.SimIFace.CAS;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public enum TipoOcultismo
    {
        Nenhum,
        Vampiro,
        Lobisomem,
        Bruxa,
        Fantasma,
        Fada,
        Genio,
        Sereia,
        Zumbi,
        SimBot,
        Desconhecido
    }

    public enum TipoEspecie
    {
        Humano,
        Gato,
        Cachorro,
        Cavalo,
        Animal
    }

    public enum TipoCorpo
    {
        Magro,
        Medio,
        Gordo
    }

    public enum TipoTomDePele
    {
        Claro,
        Medio,
        Escuro
    }

    public static class ConsultaSim
    {
        public static bool EhSimValido(Sim sim)
        {
            return sim != null && sim.SimDescription != null;
        }

        public static Sim SimAtivo
        {
            get
            {
                object ativo = LeitorPorReflexaoUtil.LerPropriedade(typeof(Sim), "ActiveActor")
                              ?? LeitorPorReflexaoUtil.LerPropriedade(typeof(Sim), "ActiveSim");
                return ativo as Sim;
            }
        }

        public static CASAgeGenderFlags GeneroDoSimAtivo
        {
            get
            {
                return Genero(SimAtivo);
            }
        }

        public static CASAgeGenderFlags IdadeDoSimAtivo
        {
            get
            {
                return Idade(SimAtivo);
            }
        }

        public static string NomeDoSimAtivo
        {
            get
            {
                Sim sim = SimAtivo;
                if (sim == null)
                    return string.Empty;
                return sim.FullName;
            }
        }

        public static bool HaSimAtivo
        {
            get { return SimAtivo != null; }
        }

        public static bool AmbosSimsNaoSaoPets(Sim ator, Sim alvo)
        {
            return EhSimValidoDesconsiderandoPets(ator) && EhSimValidoDesconsiderandoPets(alvo);
        }

        public static bool AmbosSimsValidosSemPet(Sim ator, Sim alvo)
        {
            return EhSimValidoSemPet(ator) && EhSimValidoSemPet(alvo);
        }

        public static bool InteracaoJaRegistrada(Sim ator, Sim alvo)
        {
            if (!EhSimValido(ator) || !EhSimValido(alvo))
                return false;

            return ator.SimDescription.SimDescriptionId >= alvo.SimDescription.SimDescriptionId;
        }

        public static bool EhSimValidoDesconsiderandoPets(Sim sim)
        {
            return EhSimValidoSemPet(sim);
        }

        public static bool EhSimValidoSemPet(Sim sim)
        {
            if (sim == null) return false;
            if (sim.SimDescription == null) return false;

            object valorIsPet = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "IsPet");
            if (valorIsPet is bool && (bool)valorIsPet)
                return false;

            return true;
        }

        public static CASAgeGenderFlags Genero(Sim sim)
        {
            if (!EhSimValido(sim))
                return CASAgeGenderFlags.None;

            return sim.SimDescription.Gender;
        }

        public static CASAgeGenderFlags Idade(Sim sim)
        {
            if (!EhSimValido(sim))
                return CASAgeGenderFlags.None;

            return sim.SimDescription.Age;
        }

        public static string NomeCompleto(Sim sim)
        {
            return ObterNomeSim(sim);
        }

        public static string IdUnico(Sim sim)
        {
            return ObterIdDoSim(sim);
        }

        public static string ObterTipoRelacaoEntreSims(Sim ator, Sim alvo)
        {
            return ConsultaRelacionamentosDoSim.TipoRelacaoEmTexto(ator, alvo);
        }

        public static string TipoRelacaoEntreSims(Sim ator, Sim alvo)
        {
            return ObterTipoRelacaoEntreSims(ator, alvo);
        }

        public static string ObterNomeSim(Sim sim)
        {
            if (sim == null)
                return string.Empty;
            return sim.FullName;
        }

        public static string ObterGeneroEmTexto(Sim sim)
        {
            return GeneroEmTexto(sim);
        }

        public static string GeneroEmTexto(Sim sim)
        {
            if (sim == null || sim.SimDescription == null)
                return "desconhecido";

            return sim.SimDescription.IsFemale ? "feminino" : "masculino";
        }

        public static string PronomeSubjetivo(Sim sim)
        {
            if (!EhSimValido(sim)) return "ele";
            return sim.SimDescription.IsFemale ? "ela" : "ele";
        }

        public static string PronomePossessivo(Sim sim)
        {
            if (!EhSimValido(sim)) return "seu";
            return sim.SimDescription.IsFemale ? "sua" : "seu";
        }

        public static string IdadeEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return "desconhecida";

            CASAgeGenderFlags idade = sim.SimDescription.Age;
            switch (idade)
            {
                case CASAgeGenderFlags.Baby: return "bebê";
                case CASAgeGenderFlags.Toddler: return "criança pequena";
                case CASAgeGenderFlags.Child: return "criança";
                case CASAgeGenderFlags.Teen: return "adolescente";
                case CASAgeGenderFlags.YoungAdult: return "jovem adulto";
                case CASAgeGenderFlags.Adult: return "adulto";
                case CASAgeGenderFlags.Elder: return "idoso";
                default: return "desconhecida";
            }
        }

        public static bool EhSimJogavel(Sim sim)
        {
            Sim simAtivo = ConsultaSim.SimAtivo;
            if (sim == null || sim.Household == null || simAtivo == null || simAtivo.Household == null)
                return false;

            return sim.Household == simAtivo.Household;
        }

        public static string ObterIdDoSim(Sim sim)
        {
            if (sim == null || sim.SimDescription == null)
                return "desconhecido";

            return sim.SimDescription.SimDescriptionId.ToString();
        }

        public static string BioDoSim(Sim sim)
        {
            if (!EhSimValido(sim))
                return string.Empty;

            if (sim == null || sim.SimDescription == null)
                return string.Empty;

            object bio = sim.SimDescription.Bio;

            return bio == null ? string.Empty : bio.ToString();
        }

        public static string ApresentacaoNarrativa(Sim sim)
        {
            if (!EhSimValido(sim))
                return "sim desconhecido";

            string nome = NomeCompleto(sim);
            string idade = IdadeEmTexto(sim);
            string genero = GeneroEmTexto(sim);
            string especie = EspecieDoSimEmTexto(sim);
            string ocultismo = OcultismoDoSimEmTexto(sim);

            string texto = nome + ", " + idade + " " + genero;
            if (!string.IsNullOrEmpty(ocultismo))
                texto += " (" + ocultismo + ")";
            else if (especie != "humano")
                texto += " (" + especie + ")";

            return texto;
        }

        public static bool EstaGravida(Sim sim)
        {
            if (!EhSimValido(sim)) return false;
            bool? gravida = LeitorPorReflexaoUtil.LerBooleano(sim.SimDescription,
                "IsPregnant", "IsVisuallyPregnant", "mIsPregnant");
            return gravida ?? false;
        }

        public static string GravidezEmTexto(Sim sim)
        {
            return StatusDeGravidezEmTexto(sim);
        }

        public static string StatusDeGravidezEmTexto(Sim sim)
        {
            if (!EstaGravida(sim)) return string.Empty;
            object trimestre = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "PregnancyTrimester")
                            ?? LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Trimester");
            return trimestre != null
                ? "grávida (" + trimestre + "º trimestre)"
                : "grávida";
        }

        public static TipoOcultismo OcultismoDoSim(Sim sim)
        {
            if (!EhSimValido(sim)) return TipoOcultismo.Nenhum;

            object manager = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "OccultManager");
            if (manager == null) return TipoOcultismo.Nenhum;

            object tipos = LeitorPorReflexaoUtil.LerPropriedade(manager, "CurrentOccultTypes");
            if (tipos == null) return TipoOcultismo.Nenhum;

            string s = tipos.ToString();
            if (s == "None" || string.IsNullOrEmpty(s)) return TipoOcultismo.Nenhum;
            if (s.Contains("Vampire")) return TipoOcultismo.Vampiro;
            if (s.Contains("Werewolf")) return TipoOcultismo.Lobisomem;
            if (s.Contains("Witch")) return TipoOcultismo.Bruxa;
            if (s.Contains("Ghost")) return TipoOcultismo.Fantasma;
            if (s.Contains("Fairy")) return TipoOcultismo.Fada;
            if (s.Contains("Genie")) return TipoOcultismo.Genio;
            if (s.Contains("Mermaid")) return TipoOcultismo.Sereia;
            if (s.Contains("Zombie")) return TipoOcultismo.Zumbi;
            if (s.Contains("SimBot") || s.Contains("Robot")) return TipoOcultismo.SimBot;
            return TipoOcultismo.Desconhecido;
        }

        public static string OcultismoEmTexto(TipoOcultismo tipo)
        {
            switch (tipo)
            {
                case TipoOcultismo.Vampiro: return "vampiro";
                case TipoOcultismo.Lobisomem: return "lobisomem";
                case TipoOcultismo.Bruxa: return "bruxa/feiticeiro";
                case TipoOcultismo.Fantasma: return "fantasma";
                case TipoOcultismo.Fada: return "fada";
                case TipoOcultismo.Genio: return "gênio";
                case TipoOcultismo.Sereia: return "sereia";
                case TipoOcultismo.Zumbi: return "zumbi";
                case TipoOcultismo.SimBot: return "simbot";
                default: return string.Empty;
            }
        }

        public static string OcultismoDoSimEmTexto(Sim sim)
        {
            return OcultismoEmTexto(OcultismoDoSim(sim));
        }

        public static bool EhOcultista(Sim sim)
        {
            return OcultismoDoSim(sim) != TipoOcultismo.Nenhum;
        }

        public static TipoEspecie EspecieDoSim(Sim sim)
        {
            if (!EhSimValido(sim)) return TipoEspecie.Humano;

            object especie = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Species");
            if (especie == null) return TipoEspecie.Humano;

            string s = especie.ToString();
            if (s.Contains("Cat")) return TipoEspecie.Gato;
            if (s.Contains("Dog")) return TipoEspecie.Cachorro;
            if (s.Contains("Horse")) return TipoEspecie.Cavalo;
            if (s == "Human" || s == "None") return TipoEspecie.Humano;
            return TipoEspecie.Animal;
        }

        public static string EspecieDoSimEmTexto(Sim sim)
        {
            switch (EspecieDoSim(sim))
            {
                case TipoEspecie.Gato: return "gato";
                case TipoEspecie.Cachorro: return "cachorro";
                case TipoEspecie.Cavalo: return "cavalo";
                case TipoEspecie.Animal: return "animal";
                default: return "humano";
            }
        }

        public static bool EhPet(Sim sim)
        {
            return EspecieDoSim(sim) != TipoEspecie.Humano;
        }

        public static TipoCorpo CorpoDoSim(Sim sim)
        {
            if (!EhSimValido(sim)) return TipoCorpo.Medio;

            object bodyshape = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Bodyshape");
            if (bodyshape == null) return TipoCorpo.Medio;

            string s = bodyshape.ToString();
            if (s == "Thin") return TipoCorpo.Magro;
            if (s == "Fat") return TipoCorpo.Gordo;
            return TipoCorpo.Medio;
        }

        public static string CorpoDoSimEmTexto(Sim sim)
        {
            switch (CorpoDoSim(sim))
            {
                case TipoCorpo.Magro: return "magro";
                case TipoCorpo.Gordo: return "gordo";
                default: return "mediano";
            }
        }

        public static TipoTomDePele TomDePeleDoSim(Sim sim)
        {
            if (!EhSimValido(sim)) return TipoTomDePele.Medio;

            object skintone = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Skintone");
            if (skintone == null) return TipoTomDePele.Medio;

            string s = skintone.ToString();
            if (s == "Light") return TipoTomDePele.Claro;
            if (s == "Dark") return TipoTomDePele.Escuro;
            return TipoTomDePele.Medio;
        }

        public static string TomDePeleDoSimEmTexto(Sim sim)
        {
            switch (TomDePeleDoSim(sim))
            {
                case TipoTomDePele.Claro: return "pele clara";
                case TipoTomDePele.Escuro: return "pele escura";
                default: return "pele média";
            }
        }

        public static bool EhCelebridade(Sim sim)
        {
            if (!EhSimValido(sim)) return false;
            bool? valor = LeitorPorReflexaoUtil.LerBooleano(sim.SimDescription, "IsCelebrity");
            return valor ?? false;
        }

        public static int NivelCelebridade(Sim sim)
        {
            if (!EhSimValido(sim)) return 0;
            object nivel = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "CelebrityLevel");
            if (nivel == null) return 0;
            try { return System.Convert.ToInt32(nivel); } catch { return 0; }
        }

        public static string CelebridadeEmTexto(Sim sim)
        {
            int nivel = NivelCelebridade(sim);
            if (nivel <= 0) return string.Empty;
            return "celebridade nível " + nivel;
        }

        public static bool EhRico(Sim sim)
        {
            if (!EhSimValido(sim)) return false;
            bool? valor = LeitorPorReflexaoUtil.LerBooleano(sim.SimDescription, "IsRich");
            return valor ?? false;
        }

        public static string ReputacaoRomanticaEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;
            object reputacao = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Reputation");
            if (reputacao == null) return string.Empty;

            string s = reputacao.ToString();
            switch (s)
            {
                case "Faithful":
                case "EternallyFaithful": return "fiel";
                case "ExploringTheirOptions":
                case "Player":
                case "DonJuan": return "galanteador";
                case "Cheater":
                case "Dirtbag":
                case "Slimeball": return "traidor";
                case "Naughty":
                case "Manipulator":
                case "Casanova": return "manipulador";
                default: return string.Empty;
            }
        }

        public static int NumeroDeTraicoes(Sim sim)
        {
            if (!EhSimValido(sim)) return 0;
            object valor = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "NumberOfRomanticBetrayals");
            if (valor == null) return 0;
            try { return System.Convert.ToInt32(valor); } catch { return 0; }
        }

        public static bool JaTevePrimeiroBeijo(Sim sim)
            => LerFlag(sim, "HadFirstKiss");

        public static bool JaTevePrimeiroRomance(Sim sim)
            => LerFlag(sim, "HadFirstRomance");

        public static bool JaTeveWooHoo(Sim sim)
            => LerFlag(sim, "HadFirstWooHoo");

        public static bool JaCompletouDesejoDaVida(Sim sim)
            => LerFlag(sim, "HasCompletedLifetimeWish");

        public static bool EhFantasma(Sim sim)
            => LerFlag(sim, "IsGhost");

        public static bool EhZumbi(Sim sim)
            => LerFlag(sim, "IsZombie");

        public static bool FoiAdotado(Sim sim)
            => LerFlag(sim, "WasAdopted");

        public static bool EhAlienigena(Sim sim)
            => LerFlag(sim, "IsAlien");

        public static string FlagsNarrativasEmTexto(Sim sim)
        {
            if (sim == null) return string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (JaTevePrimeiroBeijo(sim)) AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "já teve primeiro beijo", ", ");
            if (JaCompletouDesejoDaVida(sim)) AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "realizou desejo da vida", ", ");
            if (EhFantasma(sim)) AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "é fantasma", ", ");
            if (EhZumbi(sim)) AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "é zumbi", ", ");

            string gravidez = StatusDeGravidezEmTexto(sim);
            if (!string.IsNullOrEmpty(gravidez)) AdaptadorTextoNarrativo.AdicionarComSeparador(sb, gravidez, ", ");

            return sb.Length > 0 ? sb.ToString() : "nenhuma flag especial";
        }

        public static string ParticularidadesEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string ocultismo = OcultismoDoSimEmTexto(sim);
            if (!string.IsNullOrEmpty(ocultismo))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, ocultismo, ", ");

            if (EhCelebridade(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, CelebridadeEmTexto(sim), ", ");

            if (EhRico(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "rico", ", ");

            string reputacao = ReputacaoRomanticaEmTexto(sim);
            if (!string.IsNullOrEmpty(reputacao))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "reputação: " + reputacao, ", ");

            if (JaCompletouDesejoDaVida(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "realizou desejo da vida", ", ");

            if (FoiAdotado(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "adotado", ", ");

            if (EhAlienigena(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "alienígena", ", ");

            string gravidez = GravidezEmTexto(sim);
            if (!string.IsNullOrEmpty(gravidez))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, gravidez, ", ");

            if (EhFantasma(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "fantasma", ", ");

            if (EhZumbi(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "zumbi", ", ");

            return sb.ToString();
        }

        public static bool EhCasado(Sim sim)
        {
            if (!EhSimValido(sim)) return false;
            bool? valor = LeitorPorReflexaoUtil.LerBooleano(sim.SimDescription, "IsMarried");
            return valor ?? false;
        }

        public static bool EhNoivo(Sim sim)
        {
            if (!EhSimValido(sim)) return false;
            bool? valor = LeitorPorReflexaoUtil.LerBooleano(sim.SimDescription, "IsEngaged");
            return valor ?? false;
        }

        public static bool TemParceiro(Sim sim)
        {
            if (!EhSimValido(sim)) return false;
            object parceiro = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Partner");
            return parceiro != null;
        }

        public static string NomeDoParceiro(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;
            object parceiro = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Partner");
            if (parceiro == null) return string.Empty;
            object nome = LeitorPorReflexaoUtil.LerPropriedade(parceiro, "FullName");
            return nome != null ? nome.ToString() : string.Empty;
        }

        public static string EstadoCivilEmTexto(Sim sim)
        {
            if (EhCasado(sim))
            {
                string parceiro = NomeDoParceiro(sim);
                return string.IsNullOrEmpty(parceiro) ? "casado" : "casado com " + parceiro;
            }

            if (EhNoivo(sim))
            {
                string parceiro = NomeDoParceiro(sim);
                return string.IsNullOrEmpty(parceiro) ? "noivo" : "noivo de " + parceiro;
            }

            if (TemParceiro(sim))
            {
                string parceiro = NomeDoParceiro(sim);
                return string.IsNullOrEmpty(parceiro) ? "em relacionamento" : "em relacionamento com " + parceiro;
            }

            return "solteiro";
        }

        public static string SignoDoSimEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;
            object signo = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "Zodiac");
            if (signo == null) return string.Empty;

            switch (signo.ToString())
            {
                case "Aries": return "Áries";
                case "Taurus": return "Touro";
                case "Gemini": return "Gêmeos";
                case "Cancer": return "Câncer";
                case "Leo": return "Leão";
                case "Virgo": return "Virgem";
                case "Libra": return "Libra";
                case "Scorpio": return "Escorpião";
                case "Sagittarius": return "Sagitário";
                case "Capricorn": return "Capricórnio";
                case "Aquarius": return "Aquário";
                case "Pisces": return "Peixes";
                default: return string.Empty;
            }
        }

        public static bool SignosSaoCompativeis(Sim simA, Sim simB)
        {
            if (!EhSimValido(simA) || !EhSimValido(simB)) return false;

            object signoA = LeitorPorReflexaoUtil.LerPropriedade(simA.SimDescription, "Zodiac");
            object signoB = LeitorPorReflexaoUtil.LerPropriedade(simB.SimDescription, "Zodiac");
            if (signoA == null || signoB == null) return false;

            return EhSignoDeFogoOuAr(signoA.ToString()) == EhSignoDeFogoOuAr(signoB.ToString());
        }

        public static string CarreiraEmTexto(Sim sim)
        {
            return ConsultaCarreiraDoSim.CarreiraEmTexto(sim);
        }

        public static bool EhDesempregado(Sim sim)
        {
            return !ConsultaCarreiraDoSim.EstaEmpregado(sim);
        }

        public static string PreferenciaSexualEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return "desconhecida";
            return PreferenciaSexualEmTexto(sim.SimDescription);
        }

        public static string PreferenciaSexualEmTexto(SimDescription simDescription)
        {
            if (simDescription == null) return "desconhecida";

            int preferenciaHomens = LerPontuacaoPreferencia(simDescription, "mGenderPreferenceMale", "GenderPreferenceMale");
            int preferenciaMulheres = LerPontuacaoPreferencia(simDescription, "mGenderPreferenceFemale", "GenderPreferenceFemale");

            if (preferenciaHomens <= 0 && preferenciaMulheres <= 0)
                return "sem preferência definida";

            if (preferenciaHomens > 0 && preferenciaMulheres > 0)
                return preferenciaHomens == preferenciaMulheres ? "bissexual" : (preferenciaHomens > preferenciaMulheres ? "prefere homens" : "prefere mulheres");

            return preferenciaHomens > 0 ? "prefere homens" : "prefere mulheres";
        }

        public static long PontosDeRecompensasDuradouras(Sim sim)
        {
            if (!EhSimValido(sim)) return 0;
            object valor = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "LifetimeHappiness");
            if (valor == null) return 0;
            try { return System.Convert.ToInt64(valor); } catch { return 0; }
        }

        public static string PontosDeRecompensasDuradourasEmTexto(Sim sim)
        {
            long pontos = PontosDeRecompensasDuradouras(sim);

            if (pontos >= 70000) return $"{pontos} pontos: lendário";
            if (pontos >= 50000) return $"{pontos} pontos: épico";
            if (pontos >= 30000) return $"{pontos} pontos: raro";
            if (pontos >= 10000) return $"{pontos} pontos: incomum";
            if (pontos >= 5000) return $"{pontos} pontos: comum";

            return $"{pontos} pontos: muito baixo";
        }

        public static string MusicaFavoritaEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;
            object musica = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "FavoriteMusic");
            return musica == null ? string.Empty : musica.ToString();
        }

        public static string ComidaFavoritaEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;
            object comida = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "FavoriteFood");
            return comida == null ? string.Empty : comida.ToString();
        }

        public static string CorFavoritaEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;
            object cor = LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "FavoriteColor");
            return cor == null ? string.Empty : cor.ToString();
        }

        public static string FavoritosEmTexto(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "comida: " + ComidaFavoritaEmTexto(sim), " | ");
            AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "música: " + MusicaFavoritaEmTexto(sim), " | ");
            AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "cor: " + CorFavoritaEmTexto(sim), " | ");
            return sb.ToString();
        }

        public static string ContextoDeVidaPessoal(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            AdaptadorTextoNarrativo.AdicionarComSeparador(sb, EstadoCivilEmTexto(sim), ", ");

            string carreira = CarreiraEmTexto(sim);
            if (!string.IsNullOrEmpty(carreira))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "trabalha como " + carreira, ", ");

            string signo = SignoDoSimEmTexto(sim);
            if (!string.IsNullOrEmpty(signo))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "signo: " + signo, ", ");

            string preferenciaSexual = PreferenciaSexualEmTexto(sim);
            if (!string.IsNullOrEmpty(preferenciaSexual))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, preferenciaSexual, ", ");

            string favoritos = FavoritosEmTexto(sim);
            if (!string.IsNullOrEmpty(favoritos))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, favoritos, ", ");

            AdaptadorTextoNarrativo.AdicionarComSeparador(sb, PontosDeRecompensasDuradourasEmTexto(sim), ", ");

            string particularidades = ParticularidadesEmTexto(sim);
            if (!string.IsNullOrEmpty(particularidades))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, particularidades, ", ");

            return sb.ToString();
        }

        public static string ResumoNarrativoPessoalDoSim(Sim sim)
        {
            if (!EhSimValido(sim)) return string.Empty;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            AdaptadorTextoNarrativo.AdicionarComSeparador(sb, EstadoCivilEmTexto(sim), ", ");

            if (!EhDesempregado(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, CarreiraEmTexto(sim), ", ");

            string reputacao = ReputacaoRomanticaEmTexto(sim);
            if (!string.IsNullOrEmpty(reputacao))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "reputação " + reputacao, ", ");

            if (EhCelebridade(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, CelebridadeEmTexto(sim), ", ");

            if (EstaGravida(sim))
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, GravidezEmTexto(sim), ", ");

            int tricoes = NumeroDeTraicoes(sim);
            if (tricoes > 0)
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, "traiu " + tricoes + " vez(es)", ", ");

            return sb.Length > 0 ? sb.ToString() : "nada de especial";
        }

        private static bool EhSignoDeFogoOuAr(string signo)
        {
            return signo == "Aries" || signo == "Gemini" || signo == "Leo"
                || signo == "Libra" || signo == "Sagittarius" || signo == "Aquarius";
        }

        private static int LerPontuacaoPreferencia(SimDescription simDescription, params string[] nomes)
        {
            object valor = null;
            foreach (string nome in nomes)
            {
                valor = LeitorPorReflexaoUtil.LerPropriedade(simDescription, nome);
                if (valor != null)
                    break;
            }

            if (valor == null)
                return 0;

            int convertido;
            if (AdaptadorConversaoDeValores.TentarConverterParaInt(valor, out convertido))
                return convertido;

            bool convertidoBool;
            if (AdaptadorConversaoDeValores.TentarConverterParaBooleano(valor, out convertidoBool))
                return convertidoBool ? 1 : 0;

            return 0;
        }

        private static bool LerFlag(Sim sim, string propriedade)
        {
            if (sim == null || sim.SimDescription == null) return false;
            bool? valor = LeitorPorReflexaoUtil.LerBooleano(sim.SimDescription, propriedade);
            return valor ?? false;
        }
    }
}
