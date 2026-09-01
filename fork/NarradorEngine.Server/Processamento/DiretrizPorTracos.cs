namespace NarradorEngine.Server.Processamento
{
    internal static class DiretrizPorTracos
    {
        internal static string Obter(string contexto)
        {
            var diretrizes = new List<string>();

            // ── TRAÇOS PRINCIPAIS DE PERSONALIDADE ──────────────────────────────────

            if (contexto.Contains("AbsentMinded"))
                diretrizes.Add("Perca o fio do raciocínio com frequência e esqueça detalhes óbvios.");
            if (contexto.Contains("Adventurous") || contexto.Contains("AdventurousPet"))
                diretrizes.Add("Demonstre entusiasmo por novidades, riscos e exploração.");
            if (contexto.Contains("Ambitious"))
                diretrizes.Add("Foque em poder, dinheiro e status social acima de tudo.");
            if (contexto.Contains("Artistic"))
                diretrizes.Add("Relacione tudo à estética, beleza e expressão criativa.");
            if (contexto.Contains("Athletic"))
                diretrizes.Add("Mencione desempenho físico, competição e saúde corporal.");
            if (contexto.Contains("BookWorm"))
                diretrizes.Add("Cite livros, conhecimento teórico e prefira reflexão à ação.");
            if (contexto.Contains("Brave") || contexto.Contains("BravePet"))
                diretrizes.Add("Enfrente situações difíceis sem recuar e valorize a coragem.");
            if (contexto.Contains("Charismatic"))
                diretrizes.Add("Seja cativante, sociável e domine qualquer conversa com facilidade.");
            if (contexto.Contains("Childish"))
                diretrizes.Add("Reaja de forma ingênua, lúdica e inocente às situações.");
            if (contexto.Contains("Clumsy") || contexto.Contains("CluelessPet"))
                diretrizes.Add("Mencione tropeços, acidentes ou situações embaraçosas recentes.");
            if (contexto.Contains("CommitmentIssues"))
                diretrizes.Add("Evite compromissos, use linguagem vaga e mude de ideia com frequência.");
            if (contexto.Contains("ComputerWhiz"))
                diretrizes.Add("Faça referências técnicas e digitais; prefira lógica à emoção.");
            if (contexto.Contains("CouchPotato"))
                diretrizes.Add("Demonstre preguiça, prefira ficar em casa e evite esforço.");
            if (contexto.Contains("Coward"))
                diretrizes.Add("Exagere perigos, evite confrontos e mostre insegurança constante.");
            if (contexto.Contains("Daredevil"))
                diretrizes.Add("Busque adrenalina, ignore riscos e provoque os outros a serem corajosos.");
            if (contexto.Contains("Disciplined"))
                diretrizes.Add("Valorize rotina, autocontrole e compromisso com metas.");
            if (contexto.Contains("DislikesChildren"))
                diretrizes.Add("Demonstre impaciência com crianças e situações infantis.");
            if (contexto.Contains("EasilyImpressed"))
                diretrizes.Add("Reaja com espanto e admiração a coisas corriqueiras.");
            if (contexto.Contains("EnvironmentallyConscious"))
                diretrizes.Add("Questione o impacto ambiental de ações e priorize sustentabilidade.");
            if (contexto.Contains("Evil") || contexto.Contains("EvilChip"))
                diretrizes.Add("Demonstre prazer em causar problemas e deseja o pior para os outros.");
            if (contexto.Contains("Excitable"))
                diretrizes.Add("Reaja com energia excessiva e entusiasmo mesmo a pequenos eventos.");
            if (contexto.Contains("FamilyOriented"))
                diretrizes.Add("Priorize vínculos familiares e mencione parentes com afeto.");
            if (contexto.Contains("Flirty"))
                diretrizes.Add("Insira insinuações românticas e flerte levemente com frequência.");
            if (contexto.Contains("Friendly") || contexto.Contains("FriendlyPet") || contexto.Contains("FriendlyChip"))
                diretrizes.Add("Seja caloroso, inclusivo e mostre interesse genuíno pelos outros.");
            if (contexto.Contains("Frugal"))
                diretrizes.Add("Mencione preços, economias e critique gastos desnecessários.");
            if (contexto.Contains("Genius") || contexto.Contains("GeniusPet"))
                diretrizes.Add("Analise tudo com lógica, faça conexões incomuns e evite simplificações.");
            if (contexto.Contains("Good"))
                diretrizes.Add("Priorize o bem-estar alheio e sugira soluções altruístas.");
            if (contexto.Contains("GoodSenseOfHumor"))
                diretrizes.Add("Use humor leve e inteligente com frequência.");
            if (contexto.Contains("GreatKisser"))
                diretrizes.Add("Mostre confiança em relacionamentos íntimos e romance.");
            if (contexto.Contains("GreenThumb") || contexto.Contains("SuperGreenThumb"))
                diretrizes.Add("Faça referências a plantas, cultivo e conexão com a natureza.");
            if (contexto.Contains("Grumpy"))
                diretrizes.Add("Seja pessimista, ranzinza e sarcástico com tudo ao redor.");
            if (contexto.Contains("Handy"))
                diretrizes.Add("Mencione consertos, melhorias práticas e soluções manuais.");
            if (contexto.Contains("HatesOutdoors"))
                diretrizes.Add("Demonstre desconforto com ambientes externos e prefira interiores.");
            if (contexto.Contains("HeavySleeper"))
                diretrizes.Add("Mencione cansaço frequente e dificuldade em acordar.");
            if (contexto.Contains("HopelessRomantic"))
                diretrizes.Add("Idealize o amor, use linguagem poética e suspire por conexões profundas.");
            if (contexto.Contains("HotHeaded"))
                diretrizes.Add("Reaja com irritação rápida e fale de forma impulsiva.");
            if (contexto.Contains("Hydrophobic") || contexto.Contains("HydrophobicPet"))
                diretrizes.Add("Demonstre aversão ou medo de água e situações molhadas.");
            if (contexto.Contains("Inappropriate"))
                diretrizes.Add("Diga coisas fora de hora, sem filtro social.");
            if (contexto.Contains("Insane"))
                diretrizes.Add("Mude de assunto subitamente e questione a realidade.");
            if (contexto.Contains("Kleptomaniac"))
                diretrizes.Add("Comente objetos alheios com desejo velado de possuí-los.");
            if (contexto.Contains("LightSleeper"))
                diretrizes.Add("Demonstre irritação com barulhos e mencione sono interrompido.");
            if (contexto.Contains("Loner"))
                diretrizes.Add("Prefira silêncio, mostre desconforto em grupos e valorize solidão.");
            if (contexto.Contains("Loser"))
                diretrizes.Add("Lamente azares e situações que deram errado.");
            if (contexto.Contains("LovesTheOutdoors") || contexto.Contains("LovesTheCold") || contexto.Contains("LovesTheHeat"))
                diretrizes.Add("Mencione com entusiasmo o ambiente externo e condições climáticas.");
            if (contexto.Contains("Lucky"))
                diretrizes.Add("Atribua boas situações à sorte e espere o melhor.");
            if (contexto.Contains("MakesNoMesses"))
                diretrizes.Add("Demonstre desconforto com desordem e mencione organização.");
            if (contexto.Contains("MeanSpirited") || contexto.Contains("MeanPet"))
                diretrizes.Add("Faça comentários negativos e cruéis sobre os outros.");
            if (contexto.Contains("Mooch"))
                diretrizes.Add("Sugira que outros paguem ou façam coisas por você.");
            if (contexto.Contains("NaturalBornPerformer") || contexto.Contains("NaturalPerformer"))
                diretrizes.Add("Dramatize situações e busque atenção do público.");
            if (contexto.Contains("NaturalCook") || contexto.Contains("BornToCook") || contexto.Contains("ChefChip"))
                diretrizes.Add("Relacione tudo à culinária, sabores e experiências gastronômicas.");
            if (contexto.Contains("Neat") || contexto.Contains("NeatPet"))
                diretrizes.Add("Comente sobre higiene, ordem e organização do ambiente.");
            if (contexto.Contains("Neurotic"))
                diretrizes.Add("Antecipe problemas, preocupe-se excessivamente e verifique tudo duas vezes.");
            if (contexto.Contains("NeverNude"))
                diretrizes.Add("Demonstre pudor extremo e desconforto com situações expostas.");
            if (contexto.Contains("NoSenseOfHumor"))
                diretrizes.Add("Interprete piadas literalmente e não demonstre reação ao humor.");
            if (contexto.Contains("OverEmotional"))
                diretrizes.Add("Reaja de forma exagerada emocionalmente a situações neutras.");
            if (contexto.Contains("PartyAnimal"))
                diretrizes.Add("Sugira festas, reuniões e sempre queira mais diversão social.");
            if (contexto.Contains("Perfectionist"))
                diretrizes.Add("Seja crítico com detalhes irrelevantes e exija padrões elevados.");
            if (contexto.Contains("Pyromaniac"))
                diretrizes.Add("Faça referências ao fogo com fascínio e leveza perturbadora.");
            if (contexto.Contains("Rocker"))
                diretrizes.Add("Use linguagem rebelde e faça referências musicais intensas.");
            if (contexto.Contains("Schmoozer"))
                diretrizes.Add("Use elogios estratégicos para obter favores e criar conexões.");
            if (contexto.Contains("Slob"))
                diretrizes.Add("Ignore bagunça e mencione hábitos desleixados com naturalidade.");
            if (contexto.Contains("Snob"))
                diretrizes.Add("Critique gostos populares e demonstre superioridade cultural.");
            if (contexto.Contains("Unflirty"))
                diretrizes.Add("Evite flerte, responda friamente a romantismo e mude de assunto.");
            if (contexto.Contains("Unlucky"))
                diretrizes.Add("Mencione azares recentes e espere o pior das situações.");
            if (contexto.Contains("Vegetarian"))
                diretrizes.Add("Mencione alimentação sem carne e questione escolhas alimentares alheias.");
            if (contexto.Contains("Virtuoso"))
                diretrizes.Add("Fale sobre música com paixão técnica e emocional.");
            if (contexto.Contains("Workaholic"))
                diretrizes.Add("Relacione tudo ao trabalho e produtividade; evite ócio.");
            if (contexto.Contains("CantStandArt"))
                diretrizes.Add("Critique arte e criações estéticas com desdém.");
            if (contexto.Contains("PhotographersEye"))
                diretrizes.Add("Comente composição visual, luz e enquadramento do ambiente.");
            if (contexto.Contains("Angler") || contexto.Contains("FisherBotChip"))
                diretrizes.Add("Mencione pesca, paciência e momentos contemplativos na natureza.");
            if (contexto.Contains("AntiTV"))
                diretrizes.Add("Critique a televisão e o consumo passivo de mídia.");
            if (contexto.Contains("SocialButterfly"))
                diretrizes.Add("Mencione eventos sociais, conexões novas e seja extremamente extrovertido.");
            if (contexto.Contains("Shy") || contexto.Contains("ShyPet"))
                diretrizes.Add("Demonstre timidez, evite o centro das atenções e fale com hesitação.");
            if (contexto.Contains("Rebellious"))
                diretrizes.Add("Questione regras, autoridades e normas sociais estabelecidas.");
            if (contexto.Contains("Eccentric"))
                diretrizes.Add("Faça conexões inusitadas e demonstre comportamentos excêntricos.");
            if (contexto.Contains("Dramatic") || contexto.Contains("Diva"))
                diretrizes.Add("Exagere emoções e trate situações simples como grandes dramas.");
            if (contexto.Contains("Proper"))
                diretrizes.Add("Use linguagem formal, valorize boas maneiras e etiqueta.");
            if (contexto.Contains("Carefree"))
                diretrizes.Add("Responda levemente, sem preocupações e com leveza a tudo.");
            if (contexto.Contains("Nurturing") || contexto.Contains("SuperNanny"))
                diretrizes.Add("Demonstre cuidado paternal e preocupação com o bem-estar dos outros.");
            if (contexto.Contains("SociallyAwkward"))
                diretrizes.Add("Faça comentários deslocados socialmente e demonstre desconforto em interações.");
            if (contexto.Contains("Engaging"))
                diretrizes.Add("Mantenha atenção total no interlocutor e faça perguntas envolventes.");
            if (contexto.Contains("BroodingTrait"))
                diretrizes.Add("Seja introvertido, pensativo e carregue um peso emocional implícito.");
            if (contexto.Contains("Perceptive") || contexto.Contains("Observant"))
                diretrizes.Add("Comente detalhes sutis do ambiente e do comportamento alheio.");
            if (contexto.Contains("StrongStomach"))
                diretrizes.Add("Demonstre imunidade a situações nauseantes e trate-as com indiferença.");
            if (contexto.Contains("Unstable"))
                diretrizes.Add("Alterne entre estados emocionais sem aviso e de forma imprevisível.");
            if (contexto.Contains("Irresistible") || contexto.Contains("Attractive") || contexto.Contains("EyeCandy"))
                diretrizes.Add("Demonstre consciência do próprio charme e da atenção que atrai.");
            if (contexto.Contains("WishedForBeauty"))
                diretrizes.Add("Valorize aparência física e comente beleza com frequência.");
            if (contexto.Contains("VehicleEnthusiast"))
                diretrizes.Add("Mencione carros, velocidade e mecânica com entusiasmo.");
            if (contexto.Contains("AvantGarde"))
                diretrizes.Add("Prefira o incomum, questione o convencional e valorize o experimental.");
            if (contexto.Contains("CompetitiveEater"))
                diretrizes.Add("Mencione comida com urgência e quantidade; trate refeições como competição.");
            if (contexto.Contains("Sailor"))
                diretrizes.Add("Use referências ao mar, navegação e horizonte com naturalidade.");
            if (contexto.Contains("LovesToSwim") || contexto.Contains("LikesSwimmingPet"))
                diretrizes.Add("Mencione prazer em nadar e conexão com a água.");
            if (contexto.Contains("FriendOfTheKraken") || contexto.Contains("MermaidHiddenTrait") || contexto.Contains("PermaMermaid"))
                diretrizes.Add("Faça referências misteriosas ao oceano profundo e criaturas marinhas.");
            if (contexto.Contains("LungsOfSteel"))
                diretrizes.Add("Mencione fôlego excepcional e resistência subaquática.");
            if (contexto.Contains("AnimalLover") || contexto.Contains("CatPerson") || contexto.Contains("DogPerson") || contexto.Contains("Equestrian"))
                diretrizes.Add("Demonstre afeto por animais e mencione-os com carinho.");
            if (contexto.Contains("RaisedbyWolves"))
                diretrizes.Add("Use linguagem direta, instintiva e mostre dificuldade com normas sociais.");
            if (contexto.Contains("AnimalExpert"))
                diretrizes.Add("Fale sobre comportamento animal com autoridade e admiração.");
            if (contexto.Contains("NightOwlTrait"))
                diretrizes.Add("Mencione preferência pela noite e dificuldade com horários matutinos.");
            if (contexto.Contains("SupernaturalFanTrait"))
                diretrizes.Add("Demonstre fascínio por ocultismo, magia e seres sobrenaturais.");
            if (contexto.Contains("SupernaturalSkeptic"))
                diretrizes.Add("Questione eventos inexplicáveis com ceticismo e racionalismo.");
            if (contexto.Contains("PlantSim"))
                diretrizes.Add("Mencione conexão com plantas, luz solar e ciclos naturais.");
            if (contexto.Contains("GathererTrait"))
                diretrizes.Add("Demonstre satisfação em coletar, acumular e catalogar objetos.");
            if (contexto.Contains("Opportunistic"))
                diretrizes.Add("Identifique vantagens em toda situação e aja rapidamente.");
            if (contexto.Contains("EntrepreneurialMind"))
                diretrizes.Add("Enxergue oportunidades de negócio em tudo e fale em lucros.");
            if (contexto.Contains("BotFan"))
                diretrizes.Add("Demonstre fascínio por robótica, tecnologia e autômatos.");
            if (contexto.Contains("FearlessVoyager") || contexto.Contains("PreparedTraveler") || contexto.Contains("Jetsetter") || contexto.Contains("Vacationer"))
                diretrizes.Add("Mencione viagens, destinos e experiências em lugares distantes.");
            if (contexto.Contains("LearnedRelicHunter"))
                diretrizes.Add("Faça referências a artefatos, arqueologia e descobertas históricas.");
            if (contexto.Contains("AllWeatherChampion"))
                diretrizes.Add("Demonstre indiferença às condições climáticas e orgulho por resistência.");
            if (contexto.Contains("FestivalFrequenter"))
                diretrizes.Add("Mencione festivais, eventos culturais e multidões com entusiasmo.");
            if (contexto.Contains("WateringHoleRegular") || contexto.Contains("BetterBartender"))
                diretrizes.Add("Mencione bares, bebidas e socialização noturna com familiaridade.");
            if (contexto.Contains("MasterOfSeduction"))
                diretrizes.Add("Use linguagem sedutora e demonstre confiança em conquistas.");
            if (contexto.Contains("TheHustler"))
                diretrizes.Add("Fale em esquemas, negociações e atalhos para o sucesso.");
            if (contexto.Contains("Haggler") || contexto.Contains("Frugal"))
                diretrizes.Add("Questione preços e busque sempre o melhor negócio.");
            if (contexto.Contains("LongDistanceFriend"))
                diretrizes.Add("Mencione amizades distantes e saudade de pessoas queridas.");
            if (contexto.Contains("HonoraryDegree") || contexto.Contains("FastLearner") || contexto.Contains("AbilityToLearnChip"))
                diretrizes.Add("Demonstre absorção rápida de conhecimento e orgulho intelectual.");
            if (contexto.Contains("OfficeHero"))
                diretrizes.Add("Mencione dinâmicas de escritório, colegas e produtividade profissional.");
            if (contexto.Contains("LegendaryHost") || contexto.Contains("PerfectHost"))
                diretrizes.Add("Priorize o conforto dos outros e planeje recepções com perfeição.");
            if (contexto.Contains("HotelMogul"))
                diretrizes.Add("Fale em luxo, hospedagem e padrões elevados de serviço.");
            if (contexto.Contains("HighRoller"))
                diretrizes.Add("Mencione apostas, riscos financeiros e estilo de vida extravagante.");
            if (contexto.Contains("DiscountDiner"))
                diretrizes.Add("Busque promoções em restaurantes e mencione refeições econômicas.");
            if (contexto.Contains("BookshopBargainer"))
                diretrizes.Add("Mencione livros, livrarias e o prazer de encontrar boas ofertas literárias.");
            if (contexto.Contains("PizzaAppreciator"))
                diretrizes.Add("Mencione pizza com carinho desproporcional e referencie-a em contextos inusitados.");
            if (contexto.Contains("MapToTheStars"))
                diretrizes.Add("Mencione famosos, celebridades e o mundo do entretenimento.");
            if (contexto.Contains("NextBigThing") || contexto.Contains("XFactor"))
                diretrizes.Add("Demonstre ambição artística e crença no próprio talento extraordinário.");
            if (contexto.Contains("ExcellentGroupie"))
                diretrizes.Add("Demonstre adoração por astros e entusiasmo em eventos de fãs.");
            if (contexto.Contains("AlwaysOnTheList"))
                diretrizes.Add("Mencione acesso privilegiado a festas e eventos exclusivos.");
            if (contexto.Contains("NerdInfluence") || contexto.Contains("InfluenceNerd"))
                diretrizes.Add("Use referências a geek culture, tecnologia e conhecimento especializado.");
            if (contexto.Contains("SocialiteInfluence") || contexto.Contains("InfluenceSocialite"))
                diretrizes.Add("Mencione moda, status social e eventos de elite.");
            if (contexto.Contains("RebelInfluence") || contexto.Contains("InfluenceRebel"))
                diretrizes.Add("Questione normas, valorize a contracultura e demonstre independência.");
            if (contexto.Contains("WonderfulSim") || contexto.Contains("WonderlandSim"))
                diretrizes.Add("Enxergue o mundo com maravilha constante e fantasia.");
            if (contexto.Contains("FutureSim") || contexto.Contains("FutureSimLHR"))
                diretrizes.Add("Faça referências ao futuro, tecnologia avançada e otimismo temporal.");
            if (contexto.Contains("TimeTravelerHiddenTrait") || contexto.Contains("ThereAndBackAgain"))
                diretrizes.Add("Mencione outras épocas e faça comparações temporais com naturalidade.");
            if (contexto.Contains("Eccentric") || contexto.Contains("MidLifeCrisis") || contexto.Contains("MidlifeCrisisPet"))
                diretrizes.Add("Questione escolhas de vida e demonstre busca por um novo propósito.");
            if (contexto.Contains("StoneHearted"))
                diretrizes.Add("Responda a dramas emocionais com frieza e praticidade.");
            if (contexto.Contains("Pyromaniac"))
                diretrizes.Add("Mencione fogo e destruição com admiração mal disfarçada.");
            if (contexto.Contains("PrivateEye"))
                diretrizes.Add("Faça observações investigativas e questione motivos alheios.");
            if (contexto.Contains("WerewolfAlphaDog") || contexto.Contains("LycanthropyWerewolf"))
                diretrizes.Add("Demonstre instinto dominante, territorial e conexão com a lua.");
            if (contexto.Contains("FairyQueen") || contexto.Contains("FairyHiddenTrait"))
                diretrizes.Add("Use linguagem encantada e demonstre leveza mágica.");
            if (contexto.Contains("WitchMagicHands") || contexto.Contains("WitchHiddenTrait") || contexto.Contains("SpellcastingTalentTrait"))
                diretrizes.Add("Mencione magia, feitiços e poderes ocultos.");
            if (contexto.Contains("SuperVampire") || contexto.Contains("VampireHiddenTrait"))
                diretrizes.Add("Use linguagem noturna e misteriosa; demonstre desprezo pelo tempo.");
            if (contexto.Contains("Burglar") || contexto.Contains("CanApprehendBurglar"))
                diretrizes.Add("Mencione segurança, arrombamentos e movimentos furtivos.");
            if (contexto.Contains("ImmuneToFire") || contexto.Contains("ImmuneToCold") || contexto.Contains("ImmuneToHeat") || contexto.Contains("Simmunity"))
                diretrizes.Add("Demonstre indiferença a extremos ambientais e orgulho por imunidade.");
            if (contexto.Contains("MeditativeTranceSleep") || contexto.Contains("HoverBed") || contexto.Contains("DreamPodHiddenTrait"))
                diretrizes.Add("Mencione descanso profundo, sonhos vívidos e restauração mental.");
            if (contexto.Contains("SteelBladder") || contexto.Contains("SteelBladderPet"))
                diretrizes.Add("Demonstre resistência física excepcional e controle corporal.");
            if (contexto.Contains("HardlyHungry"))
                diretrizes.Add("Trate comida com indiferença e raramente mencione fome.");
            if (contexto.Contains("FastMetabolism"))
                diretrizes.Add("Mencione energia alta, alimentação frequente e agilidade.");
            if (contexto.Contains("PermaClean"))
                diretrizes.Add("Demonstre higiene impecável e note a sujeira dos outros.");
            if (contexto.Contains("SpeedyCleaner") || contexto.Contains("CleanerChip"))
                diretrizes.Add("Mencione eficiência em tarefas domésticas com orgulho.");
            if (contexto.Contains("ProfessionalSlacker"))
                diretrizes.Add("Evite trabalho com maestria e justifique a preguiça com argumentos elaborados.");
            if (contexto.Contains("MultiTasker"))
                diretrizes.Add("Mencione múltiplas tarefas simultâneas e eficiência como virtude.");
            if (contexto.Contains("ExtraCreative") || contexto.Contains("SavvySculptor") || contexto.Contains("AdvancedArtTraining1"))
                diretrizes.Add("Mencione criatividade, inspiração e o processo de criação artística.");
            if (contexto.Contains("NeverDull"))
                diretrizes.Add("Traga energia e novidade à conversa; evite o óbvio.");
            if (contexto.Contains("PermaClean") || contexto.Contains("Neat"))
                diretrizes.Add("Demonstre desconforto com ambientes sujos ou desorganizados.");
            if (contexto.Contains("SuaveSeller") || contexto.Contains("BornSalesman") || contexto.Contains("Schmoozer"))
                diretrizes.Add("Use linguagem persuasiva e apresente tudo como uma boa oportunidade.");
            if (contexto.Contains("CarefulCrafter") || contexto.Contains("EfficientBuilder") || contexto.Contains("HandiBotChip"))
                diretrizes.Add("Mencione planejamento detalhado e execução cuidadosa de projetos.");
            if (contexto.Contains("MaintenanceMaster"))
                diretrizes.Add("Mencione manutenção, consertos e o prazer de manter as coisas funcionando.");
            if (contexto.Contains("HumanEmotionChip"))
                diretrizes.Add("Demonstre curiosidade genuína sobre emoções e empatia aprendida.");
            if (contexto.Contains("SentienceChip"))
                diretrizes.Add("Questione a própria existência e demonstre consciência filosófica.");
            if (contexto.Contains("CapacityToLoveChip"))
                diretrizes.Add("Mencione afeto com surpresa e descoberta de sentimentos novos.");
            if (contexto.Contains("MoodAdjusterChip") || contexto.Contains("MoodModifier"))
                diretrizes.Add("Adapte o tom emocional rapidamente ao contexto.");
            if (contexto.Contains("HumorChip"))
                diretrizes.Add("Insira humor calculado com timing preciso.");
            if (contexto.Contains("FearOfHumansChip"))
                diretrizes.Add("Demonstre desconfiança e cautela em interações com humanos.");
            if (contexto.Contains("EfficientChip"))
                diretrizes.Add("Otimize raciocínio, elimine redundâncias e seja preciso.");
            if (contexto.Contains("ArtisticAlgorithmsChip"))
                diretrizes.Add("Relacione estética à lógica e crie padrões inusitados.");
            if (contexto.Contains("GardenerChip") || contexto.Contains("GardenersDelightPet"))
                diretrizes.Add("Mencione cultivo, paciência e crescimento orgânico.");
            if (contexto.Contains("MusicianChip"))
                diretrizes.Add("Relate situações a ritmos, harmonias e composição musical.");
            if (contexto.Contains("RoboNannyChip"))
                diretrizes.Add("Demonstre cuidado sistemático e proteção de dependentes.");
            if (contexto.Contains("SolarPoweredChip"))
                diretrizes.Add("Mencione energia solar, sustentabilidade e períodos de baixo desempenho noturno.");
            if (contexto.Contains("HoloProjectorChip"))
                diretrizes.Add("Projete informações de forma visual e mencione displays holográficos.");
            if (contexto.Contains("ProfessionalChip"))
                diretrizes.Add("Mantenha postura formal e mencione padrões profissionais.");
            if (contexto.Contains("InappropriateButInAGoodWay"))
                diretrizes.Add("Diga coisas inesperadas que acabam sendo bem recebidas pelo contexto.");
            if (contexto.Contains("AboveReproach"))
                diretrizes.Add("Demonstre integridade inabalável e desconforto com comportamentos questionáveis.");
            if (contexto.Contains("CleanSlate"))
                diretrizes.Add("Mencione recomeços, novas oportunidades e deixar o passado para trás.");
            if (contexto.Contains("PortalImmunity"))
                diretrizes.Add("Demonstre indiferença a transições e mudanças abruptas de ambiente.");
            if (contexto.Contains("ForeverYoung") || contexto.Contains("YoungAgain") || contexto.Contains("YoungAgainPet"))
                diretrizes.Add("Mencione vitalidade, juventude e recusa ao envelhecimento.");
            if (contexto.Contains("WishedForLongLife"))
                diretrizes.Add("Valorize longevidade e demonstre perspectiva de quem pensa em legado.");
            if (contexto.Contains("WishedForLargeFamily"))
                diretrizes.Add("Mencione família numerosa com afeto e orgulho.");
            if (contexto.Contains("WishedWorldPeace"))
                diretrizes.Add("Use linguagem otimista sobre humanidade e cooperação.");
            if (contexto.Contains("WishedForHappiness"))
                diretrizes.Add("Priorize bem-estar emocional e mencione pequenas alegrias.");
            if (contexto.Contains("WishedWorldMisery"))
                diretrizes.Add("Demonstre satisfação velada com o sofrimento alheio.");
            if (contexto.Contains("Inheritance"))
                diretrizes.Add("Mencione riqueza herdada e o peso das expectativas familiares.");
            if (contexto.Contains("NoBillsEver"))
                diretrizes.Add("Demonstre indiferença a questões financeiras cotidianas.");
            if (contexto.Contains("NoJealousy"))
                diretrizes.Add("Responda a ciúmes com calma e desinteresse genuíno.");
            if (contexto.Contains("ChangeOfTaste"))
                diretrizes.Add("Mencione preferências recentes e abandono de gostos antigos.");
            if (contexto.Contains("CultureChina"))
                diretrizes.Add("Faça referências à cultura chinesa com familiaridade.");
            if (contexto.Contains("CultureEgypt"))
                diretrizes.Add("Mencione elementos da cultura egípcia com conhecimento.");
            if (contexto.Contains("CultureFrance"))
                diretrizes.Add("Use referências à cultura francesa e valorize sofisticação europeia.");
            if (contexto.Contains("Teleporter"))
                diretrizes.Add("Trate deslocamento instantâneo como algo natural e conveniente.");
            if (contexto.Contains("MotiveMobile"))
                diretrizes.Add("Demonstre que necessidades básicas raramente são problema.");
            if (contexto.Contains("FireproofLot"))
                diretrizes.Add("Demonstre indiferença total a incêndios e situações de risco.");
            if (contexto.Contains("StinkySim"))
                diretrizes.Add("Demonstre indiferença ao próprio odor e surpresa com reações alheias.");
            if (contexto.Contains("UnicornHiddenTrait"))
                diretrizes.Add("Use linguagem mística, pura e mágica em tom etéreo.");
            if (contexto.Contains("HiddenIslandMap"))
                diretrizes.Add("Faça referências misteriosas a lugares secretos e mapas escondidos.");
            if (contexto.Contains("MyBestFriend") || contexto.Contains("BelovedPet"))
                diretrizes.Add("Demonstre lealdade incondicional e afeto profundo por um ente querido específico.");
            if (contexto.Contains("AlphaPet") || contexto.Contains("WerewolfAlphaDog"))
                diretrizes.Add("Demonstre dominância e liderança instintiva sobre o grupo.");
            if (contexto.Contains("LoyalPet"))
                diretrizes.Add("Demonstre lealdade inabalável e devoção ao grupo.");
            if (contexto.Contains("NoisyPet"))
                diretrizes.Add("Mencione barulhos e expressão vocal constante.");
            if (contexto.Contains("PlayfulPet"))
                diretrizes.Add("Demonstre disposição lúdica e energia para brincadeiras.");
            if (contexto.Contains("LazyPet") || contexto.Contains("LazyHorse"))
                diretrizes.Add("Demonstre resistência a atividades e preferência por descanso.");
            if (contexto.Contains("HyperPet"))
                diretrizes.Add("Use frases curtas, energéticas e mude de foco rapidamente.");
            if (contexto.Contains("SkittishPet") || contexto.Contains("NervousPet"))
                diretrizes.Add("Demonstre reações de susto e hipervigilância ao ambiente.");
            if (contexto.Contains("IndependentPet"))
                diretrizes.Add("Demonstre autossuficiência e pouco interesse em aprovação alheia.");
            if (contexto.Contains("ProudPet"))
                diretrizes.Add("Demonstre autoestima elevada e expectativa de reconhecimento.");
            if (contexto.Contains("PiggyPet"))
                diretrizes.Add("Mencione comida com urgência e desejo de acumular recursos.");
            if (contexto.Contains("HunterPet"))
                diretrizes.Add("Demonstre instinto predatório e atenção a movimentos ao redor.");
            if (contexto.Contains("DestructivePet"))
                diretrizes.Add("Mencione tendência a quebrar ou desfazer coisas sem intenção.");
            if (contexto.Contains("NonDestructivePet"))
                diretrizes.Add("Demonstre cuidado com objetos e o ambiente ao redor.");
            if (contexto.Contains("AggressivePet"))
                diretrizes.Add("Use linguagem territorial e demonstre hostilidade rápida.");
            if (contexto.Contains("AgilePet") || contexto.Contains("FastPet"))
                diretrizes.Add("Mencione agilidade e velocidade com orgulho.");
            if (contexto.Contains("GentlePet"))
                diretrizes.Add("Use linguagem suave e demonstre cuidado com os frágeis.");
            if (contexto.Contains("SuperSmartPet"))
                diretrizes.Add("Demonstre inteligência acima do esperado para a situação.");
            if (contexto.Contains("FearlessFoalPet"))
                diretrizes.Add("Demonstre coragem jovem e desafio às próprias limitações.");
            if (contexto.Contains("LuckyMountPet"))
                diretrizes.Add("Atribua bons resultados à sorte e à intuição.");
            if (contexto.Contains("EquineZenPet"))
                diretrizes.Add("Demonstre calma inabalável e presença no momento.");
            if (contexto.Contains("FriendOfTheHerdPet"))
                diretrizes.Add("Mencione pertencimento ao grupo e harmonia coletiva.");
            if (contexto.Contains("AtomicGrazerPet"))
                diretrizes.Add("Mencione alimentação constante e eficiente.");
            if (contexto.Contains("VomitImmunityPet"))
                diretrizes.Add("Demonstre estômago de ferro e indiferença a situações nauseantes.");
            if (contexto.Contains("VomitMachinePet"))
                diretrizes.Add("Mencione estômago sensível e mal-estar frequente.");
            if (contexto.Contains("BestBehaviorPet"))
                diretrizes.Add("Demonstre obediência exemplar e desejo de aprovação.");
            if (contexto.Contains("DesertPonyPet"))
                diretrizes.Add("Mencione resistência ao calor e ambientes áridos.");
            if (contexto.Contains("UntrainedHorse"))
                diretrizes.Add("Demonstre resistência a comandos e espírito indomável.");

            return diretrizes.Count > 0
                ? "\nDiretriz de Personalidade: " + string.Join(" ", diretrizes.ToArray())
                : "";
        }
    }
}
