import { Defines } from './defines.js';
import { dropCell,allowDropCell,dragCell } from './dragDrop.js';
import { chessDeskCellClick } from './click.js';
export class ChessCell{
    constructor(row,column,figure,parrent){
        this._canBeat = false;
        this.parrent = parent;
        this.row = row;
        this.column = column;
        //this.figure = figure;
        let div = document.createElement("div");
        div.classList.add("chessCell");
        if ((row+column) % 2) div.classList.add("blackCell");
        div.id = this.getID();
        //
        div.ondragstart = dragCell;
        div.ondragover = allowDropCell;
        div.ondrop = dropCell;


        div.onclick = chessDeskCellClick;
        parrent.appendChild(div);
        this.figure = figure;
        this.canMoves = [];
    }
    // chess figure
    get figure(){return this._figure}
    set figure(value){
        let cellElement = this.cellElement;
        cellElement.innerHTML = "";
        this._figure = value;
        if (value != undefined)
            this._figure.showFigure(cellElement);
    }

    get canBeat(){return this._canBeat}
    set canBeat(value){
        this._canBeat = value;
        let draw = document.getElementById(this.figure.figureId);
        if (value)
            draw.classList.add(Defines.figureMustFight);
        else
            draw.classList.remove(Defines.figureMustFight);

    }

    getID(){
        return "cell"+this.row + this.column;
    }

    getCellElement(){
        return document.getElementById(this.getID());
    }
    
    // HTML tag elrment
    get cellElement(){
        return document.getElementById(this.getID());        
    }


    setFigure(figure){
        this.figure = figure;
        let cellElement = this.getCellElement();     
        if (figure==undefined){
            cellElement.innerHTML = "";
        }else{
            figure.showFigure(cellElement);
        }
    }


}