import {Defines} from './defines.js';
export function chessDeskCellClick(event){
    if (this.classList.contains(Defines.cellSelected)) // DOM
         globalThis.playerDesk.chessDesk.clickToSameCell(this);
    else{
         if (this.classList.contains(Defines.chessCellCanMove))
             globalThis.playerDesk.chessDesk.clickToCanMoveCell(this);
         else
             globalThis.playerDesk.chessDesk.clickToAnOtherCell(this);
    }
}