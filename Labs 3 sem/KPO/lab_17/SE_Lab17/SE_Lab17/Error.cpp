#include "Error.h"
namespace Error {
    ERRORS errors[ERROR_MAX_ENTRY]{
      ERROR_ENTRY(0, "Íåäîïóñòèìûé êîä îøèáêè"),
      ERROR_ENTRY(1, "Ñèñòåìíûé ñáîé"),
      ERROR_ENTRY_NODEF(2),ERROR_ENTRY_NODEF(3),ERROR_ENTRY_NODEF(4),ERROR_ENTRY_NODEF(5),
      ERROR_ENTRY_NODEF(6),ERROR_ENTRY_NODEF(7),ERROR_ENTRY_NODEF(8),ERROR_ENTRY_NODEF(9),
      ERROR_ENTRY_NODEF10(10),ERROR_ENTRY_NODEF10(20),ERROR_ENTRY_NODEF10(30),ERROR_ENTRY_NODEF10(40),
      ERROR_ENTRY_NODEF10(50),ERROR_ENTRY_NODEF10(60),ERROR_ENTRY_NODEF10(70),ERROR_ENTRY_NODEF10(80),
      ERROR_ENTRY_NODEF10(90),
      ERROR_ENTRY(100, "Ïàğàìåòğ -in äîëæåí áûòü çàäàí"),
      ERROR_ENTRY_NODEF(101), ERROR_ENTRY_NODEF(102),ERROR_ENTRY_NODEF(103),
      ERROR_ENTRY(104, "Ïğåâûøåíà äëèíà âõîäíîãî ïàğàìåòğà"),
      ERROR_ENTRY_NODEF(105),ERROR_ENTRY_NODEF(106),ERROR_ENTRY_NODEF(107),ERROR_ENTRY_NODEF(108),
      ERROR_ENTRY_NODEF(109),
      ERROR_ENTRY(110, "Îøèáêà îòêğûòèÿ ôàéëà ñ èñõîäíûì êîäîì (-in)"),
      ERROR_ENTRY(111, "Íåäîïóñòèìûé ñèìâîë â èñõîäíîì ôàéëå (-in)"),
      ERROR_ENTRY(112, "Îøèáêà ïğè ñîçäàíèè ôàéëà ïğîòîêîëà(-log)"),
      ERROR_ENTRY(113, "Ïğåâûøåíà ¸ìêîñòü òàáëèöû ëåêñåì"),
      ERROR_ENTRY(114, "Òàáëèöà ëåêñåì çàïîëíåíà"),
      ERROR_ENTRY(115, "Íåäîïóñòèìûé íîìåğ ëåêñåìû"),
      ERROR_ENTRY(116, "Ïğåâûøåíà ¸ìêîñòü òàáëèöû èäåíòèôèêàòîğîâ"),
      ERROR_ENTRY(117, "Òàáëèöà èäåíòèôèêàòîğîâ çàïîëíåíà"),
      ERROR_ENTRY(118, "Íåäîïóñòèìûé íîìåğ èäåíòèôèêàòîğà"),
      ERROR_ENTRY(119, "Ïğåâûøåíà äëèíâ íàçâàíèÿ èäåíòèôèêàòîğà"),
      ERROR_ENTRY(120, "Íåâåğíàÿ ëåêñåìà"),
      ERROR_ENTRY(121,"Îøèáêà äîñòóïà"),
      ERROR_ENTRY(122,"Îøèáêà: íåâåğíûé èíäåêñ â ëåêñè÷åñêîé òàáëèöå"),
      ERROR_ENTRY_NODEF(130),ERROR_ENTRY_NODEF(140),ERROR_ENTRY_NODEF(150),ERROR_ENTRY_NODEF(160),
      ERROR_ENTRY_NODEF(170),ERROR_ENTRY_NODEF(180),ERROR_ENTRY_NODEF(190),ERROR_ENTRY_NODEF(200),
      ERROR_ENTRY_NODEF(300),ERROR_ENTRY_NODEF(400),ERROR_ENTRY_NODEF(500),
      ERROR_ENTRY(600, "Íåâåğíàÿ ñòğóêòóğà ïğîãğàììû"),
      ERROR_ENTRY(601, "Îøèáî÷íûé îïåğàòîğ"),
      ERROR_ENTRY(602, "Îøèáêà â âûğàæåíèè"),
      ERROR_ENTRY(603, "Îøèáêà â ïàğàìåòğàõ ôóíêöèè"),
      ERROR_ENTRY(604, "Îøèáêà â ïàğàìåòğàõ âûçûâàåìîé ôóíêöèè"),
      ERROR_ENTRY_NODEF(605),ERROR_ENTRY_NODEF(606),ERROR_ENTRY_NODEF(607),ERROR_ENTRY_NODEF(608),ERROR_ENTRY_NODEF(609),ERROR_ENTRY_NODEF10(610),
      ERROR_ENTRY_NODEF10(620),ERROR_ENTRY_NODEF10(630),ERROR_ENTRY_NODEF10(640),ERROR_ENTRY_NODEF10(650),ERROR_ENTRY_NODEF10(660),ERROR_ENTRY_NODEF10(670),
      ERROR_ENTRY_NODEF10(680),ERROR_ENTRY_NODEF10(690),
      ERROR_ENTRY_NODEF100(700),ERROR_ENTRY_NODEF100(800),
      ERROR_ENTRY_NODEF100(900)
    };

    ERRORS geterror(int id) {
        if (id > 0 && id < ERROR_MAX_ENTRY) {
            return errors[id];
        }
        return errors[0];
    }

    ERRORS geterrorin(int id, int line = -1, int col = -1) { 
        if (id > 0 && id < ERROR_MAX_ENTRY) {
            errors[id].inext.line = line;
            errors[id].inext.col = col;
            return errors[id];
        }
        return errors[0];
    }
};
