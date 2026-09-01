using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Core;
using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public enum TipoDeLote
    {
        Residencial,
        Comunitario,
        Trabalho,
        Desconhecido
    }

    public static class ConsultaAmbiente
    {
        public static string NomeLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null) return "lote desconhecido";

            string nome = lote.Name;
            if (string.IsNullOrEmpty(nome))
                nome = lote.RawName;

            return string.IsNullOrEmpty(nome) ? "sem nome" : nome;
        }

        public static string DescricaoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return string.Empty;

            string descricao = lote.Description;
            return string.IsNullOrEmpty(descricao) ? string.Empty : descricao;
        }

        public static TipoDeLote TipoDoLoteAtual(Sim sim)
        {
            if (sim == null || sim.LotCurrent == null) return TipoDeLote.Desconhecido;
            Lot lote = sim.LotCurrent;
            if (lote.IsWorldLot) return TipoDeLote.Desconhecido;
            if (lote.IsCommunityLot) return TipoDeLote.Comunitario;
            if (lote.IsResidentialLot) return TipoDeLote.Residencial;
            return TipoDeLote.Trabalho;
        }

        public static string TipoDoLoteEmTexto(TipoDeLote tipo)
        {
            switch (tipo)
            {
                case TipoDeLote.Residencial: return "residencial";
                case TipoDeLote.Comunitario: return "comunitário";
                case TipoDeLote.Trabalho: return "trabalho";
                default: return "desconhecido";
            }
        }

        public static string SubtipoDoLoteAtualEmTexto(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return "desconhecido";

            if (lote.IsResidentialLot)
                return lote.ResidentialLotSubType.ToString();

            if (lote.IsCommunityLot)
                return lote.CommercialLotSubType.ToString();

            return "desconhecido";
        }

        public static string EstadoLimpezaLoteEmTexto(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return "indisponível";

            try
            {
                if (lote.HasCleanAllAblePuddlesOrBurntTiles())
                    return "sujo";

                List<GameObject> objetosParaLimpar = lote.FindAllObjectsToClean();
                if (objetosParaLimpar != null && objetosParaLimpar.Count > 0)
                    return "sujo";

                if (lote.HasUnmadeBed())
                    return "desarrumado";

                return "limpo";
            }
            catch
            {
                return "indisponível";
            }
        }

        public static bool SimEmQuartoPublico(Sim sim)
        {
            if (sim == null || sim.LotCurrent == null)
                return false;

            return sim.LotCurrent.IsRoomPublic(sim.RoomId);
        }

        public static int ContarCamasNoLoteAtual(Sim sim)
        {
            Lot.LotMetrics metrica = default(Lot.LotMetrics);
            if (!TentarObterMetricasLote(sim, ref metrica))
                return 0;

            return metrica.BedCount;
        }

        public static int ContarGeladeirasNoLoteAtual(Sim sim)
        {
            Lot.LotMetrics metrica = default(Lot.LotMetrics);
            if (!TentarObterMetricasLote(sim, ref metrica))
                return 0;

            return metrica.FridgeCount;
        }

        public static int ContarAnimaisNoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null ? lote.GetPetsCount() : 0;
        }

        public static int ContarZumbisNoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null ? lote.NumZombiesOnLot() : 0;
        }

        public static bool HaLadraoNoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.IsBurglarOnLot();
        }

        public static bool HaPoliciaNoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.IsPoliceOnLot();
        }

        public static bool HaFogoNoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.IsFireOnLot();
        }

        public static bool LoteTemEstacionamentoValido(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.HasValidStreetParking();
        }

        public static bool LoteEstaEmHorarioDeFuncionamento(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.IsOpenVenue();
        }

        public static bool LoteEhApartamento(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.IsApartmentLot;
        }

        public static bool LoteEhCasaFlutuante(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            return lote != null && lote.IsHouseboatLot();
        }

        public static List<Sim> ConjuntoDeSimsNoLote(Lot lote)
        {
            List<Sim> lista = new List<Sim>();
            if (lote == null) return lista;

            IEnumerable<Sim> simsNoLote = lote.GetSims();
            if (simsNoLote == null)
                return lista;

            foreach (Sim sim in simsNoLote)
            {
                if (sim == null) continue;
                lista.Add(sim);
            }

            return lista;
        }

        public static string SimsDoLoteEmTexto(Sim sim, int maximo)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return "sem sims";

            if (maximo <= 0)
                maximo = 6;

            List<Sim> sims = ConjuntoDeSimsNoLote(lote);
            if (sims.Count == 0)
                return "sem sims";

            int limite = sims.Count < maximo ? sims.Count : maximo;
            System.Text.StringBuilder texto = new System.Text.StringBuilder();
            int quantidadeAdicionada = 0;
            foreach (Sim simNoLote in sims)
            {
                if (quantidadeAdicionada >= limite)
                    break;

                string nome = ConsultaSim.ObterNomeSim(simNoLote);
                if (string.IsNullOrEmpty(nome))
                    nome = "sim";

                if (texto.Length > 0)
                    texto.Append(", ");

                texto.Append(nome);
                quantidadeAdicionada++;
            }

            if (sims.Count > limite)
                texto.Append(" (+").Append((sims.Count - limite).ToString()).Append(")");

            return texto.ToString();
        }

        public static int ContarSimsNoLote(Lot lote)
        {
            if (lote == null)
                return 0;

            return ConjuntoDeSimsNoLote(lote).Count;
        }

        public static string LoteAtualEmTexto(Sim sim)
        {
            if (sim == null || sim.LotCurrent == null)
                return "lote desconhecido";

            string nome = NomeLoteAtual(sim);
            string tipo = TipoDoLoteEmTexto(TipoDoLoteAtual(sim));
            return string.Format("{0} ({1})", nome, tipo);
        }

        public static List<Sim> ConjuntoDeSimsNoLoteAtual
        {
            get
            {
                Sim sim = ConsultaSim.SimAtivo;
                if (sim == null) return new List<Sim>();
                return ConsultaAmbiente.ConjuntoDeSimsNoLote(sim.LotCurrent);
            }
        }

        public static int ContarObjetosNoLoteAtual(Sim sim)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return 0;

            return (int)lote.CountObjects<GameObject>();
        }

        public static int ContarObjetosPorNomeNoLoteAtual(Sim sim, string trechoNoNomeDoTipo)
        {
            if (string.IsNullOrEmpty(trechoNoNomeDoTipo))
                return 0;

            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return 0;

            int total = 0;
            GameObject[] objetos = lote.GetObjects<GameObject>();
            if (objetos == null)
                return 0;

            foreach (GameObject objeto in objetos)
            {
                if (objeto == null)
                    continue;

                string nomeTipo = objeto.GetType().Name;
                if (string.IsNullOrEmpty(nomeTipo))
                    continue;

                if (nomeTipo.IndexOf(trechoNoNomeDoTipo, StringComparison.OrdinalIgnoreCase) >= 0)
                    total++;
            }

            return total;
        }

        public static int ContarTvsNoLoteAtual(Sim sim)
        {
            return ContarObjetosPorNomeNoLoteAtual(sim, "TV");
        }

        public static string LocalidadesProximasEmTexto(Sim sim, int maximo)
        {
            if (sim == null || sim.LotCurrent == null)
                return "sem localidades próximas";

            if (maximo <= 0)
                maximo = 3;

            Lot loteAtual = sim.LotCurrent;
            List<LotInfoProximo> lotesProximos = new List<LotInfoProximo>();

            foreach (Lot lote in LotManager.AllLots)
            {
                if (lote == null || lote.IsWorldLot || lote == loteAtual)
                    continue;

                float distancia = CalcularDistanciaEntreLotes(loteAtual, lote);
                lotesProximos.Add(new LotInfoProximo(lote, distancia));
            }

            lotesProximos.Sort(delegate (LotInfoProximo a, LotInfoProximo b)
            {
                return a.Distancia.CompareTo(b.Distancia);
            });

            int limite = lotesProximos.Count < maximo ? lotesProximos.Count : maximo;
            if (limite == 0)
                return "sem localidades próximas";

            System.Text.StringBuilder texto = new System.Text.StringBuilder();
            int quantidadeAdicionada = 0;
            foreach (LotInfoProximo loteProximo in lotesProximos)
            {
                if (quantidadeAdicionada >= limite)
                    break;

                Lot lote = loteProximo.Lote;
                string nome = string.IsNullOrEmpty(lote.Name) ? "sem nome" : lote.Name;
                string tipo = TipoDoLoteEmTexto(ObterTipoDoLote(lote));

                if (texto.Length > 0)
                    texto.Append(" | ");

                texto.Append(nome).Append(" (").Append(tipo).Append(")");
                quantidadeAdicionada++;
            }

            return texto.ToString();
        }

        public static float ScoreAmbienteAtual(Sim sim)
        {
            if (sim == null) return 0f;
            float? score = LeitorPorReflexaoUtil.LerNumero(sim, "EnvironmentScore", "CurrentEnvironmentScore");
            return score ?? 0f;
        }

        public static string AmbienteEmTexto(Sim sim)
        {
            float score = ScoreAmbienteAtual(sim);
            string qualidade = score > 50f ? "agradável" : score > 0f ? "neutro" : "desagradável";
            return string.Format("lote: {0} | ambiente: {1} ({2:F0}pt) | limpeza={3} | tvs_no_lote={4} | localidades_proximas={5}",
                LoteAtualEmTexto(sim),
                qualidade,
                score,
                EstadoLimpezaLoteEmTexto(sim),
                ContarTvsNoLoteAtual(sim),
                LocalidadesProximasEmTexto(sim, 3));
        }

        private static bool TentarObterMetricasLote(Sim sim, ref Lot.LotMetrics metrica)
        {
            Lot lote = sim != null ? sim.LotCurrent : null;
            if (lote == null)
                return false;

            try
            {
                lote.GetLotMetrics(ref metrica);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static float CalcularDistanciaEntreLotes(Lot origem, Lot destino)
        {
            if (origem == null || destino == null)
                return float.MaxValue;

            return (origem.Position - destino.Position).Length();
        }

        private static TipoDeLote ObterTipoDoLote(Lot lote)
        {
            if (lote == null)
                return TipoDeLote.Desconhecido;

            if (lote.IsCommunityLot)
                return TipoDeLote.Comunitario;

            if (lote.IsResidentialLot)
                return TipoDeLote.Residencial;

            return TipoDeLote.Trabalho;
        }

        private sealed class LotInfoProximo
        {
            public Lot Lote;
            public float Distancia;

            public LotInfoProximo(Lot lote, float distancia)
            {
                Lote = lote;
                Distancia = distancia;
            }
        }
    }
}
