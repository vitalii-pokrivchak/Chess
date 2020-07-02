import { FigureColor } from './chess/figureColor.js';
import { ChessDesk } from './chess/chessDesk.js';
import {init} from './chess/dragDrop.js';
class PlayerDesk{
    constructor(deskId){
        let deskElement = document.getElementById(deskId);
        this.chessDesk = new ChessDesk(deskElement);
    }
}
globalThis.playerDesk = new PlayerDesk("chessTable");
globalThis.playerDesk.chessDesk.currentPlayer = FigureColor.white;
init(playerDesk.chessDesk.desk,true);