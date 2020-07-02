import { FigureColor } from './figureColor.js';
import { MoveState } from './moveState.js';
import { Defines } from './defines.js';
import { Bishop } from './bishop.js';
import { Horse } from './horse.js';
import { King } from './king.js';
import { Pawn } from './pawn.js';
import { Queen } from './queen.js';
import { Rook } from './rook.js';
import { CanMoveDestination } from './canMoveDestination.js';
import { ChessCell } from './chessCell.js';
export class ChessDesk{
    constructor(deskElement){
        this.desk=[];
        this.selectedItem = undefined;
        let symbolsNumber = ['','a','b','c','d','e','f','g','h',''];
        for (let i in symbolsNumber){
            this.addDivElement(symbolsNumber[i],"gripDeskRow",deskElement)
        }
        this.addDivElement("1","gripDeskColumn",deskElement);
        this.desk.push(new ChessCell(0,0,new Rook(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,1,new Horse(FigureColor.black),deskElement)); 
        this.desk.push(new ChessCell(0,2,new Bishop(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,3,new Queen(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,4,new King(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,5,new Bishop(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,6,new Horse(FigureColor.black),deskElement));                             
        this.desk.push(new ChessCell(0,7,new Rook(FigureColor.black),deskElement));
        this.addDivElement("1","gripDeskColumn",deskElement);
        this.addDivElement("2","gripDeskColumn",deskElement);
        for (let i=0;i<8;i++) this.desk.push(new ChessCell(1,i,new Pawn(FigureColor.black),deskElement));
        this.addDivElement("2","gripDeskColumn",deskElement);
        for(let i=2;i<6;i++){
            this.addDivElement(i+1,"gripDeskColumn",deskElement); 
            for (let j=0;j<8;j++) this.desk.push(new ChessCell(i,j,undefined,deskElement));
            this.addDivElement(i+1,"gripDeskColumn",deskElement);           
        }
        this.addDivElement("7","gripDeskColumn",deskElement);
        for (let i=0;i<8;i++) this.desk.push(new ChessCell(6,i,new Pawn(FigureColor.white),deskElement));
        this.addDivElement("7","gripDeskColumn",deskElement);
        this.addDivElement("8","gripDeskColumn",deskElement);
        this.desk.push(new ChessCell(7,0,new Rook(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,1,new Horse(FigureColor.white),deskElement)); 
        this.desk.push(new ChessCell(7,2,new Bishop(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,3,new King(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,4,new Queen(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,5,new Bishop(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,6,new Horse(FigureColor.white),deskElement));                                            
        this.desk.push(new ChessCell(7,7,new Rook(FigureColor.white),deskElement));
        this.addDivElement("8","gripDeskColumn",deskElement);
        for (let i in symbolsNumber){
            this.addDivElement(symbolsNumber[i],"gripDeskRow",deskElement)
        }
    }
    canMovePositions = [];


    _currentPlayer = FigureColor.white;
    get currentPlayer(){return this._currentPlayer}
    set currentPlayer(value){
        this._currentPlayer = value;
        this.clearClassInDesk(Defines.chessCellCanMove);
        this.setHoverForCells();
    }

    _selectedCell = undefined;

    clearClassInDesk(className){
        let elements = document.getElementsByClassName(className);
        while (elements.length){
            elements[0].classList.remove(className);    
        }
    }


    clearSelectedCell() {
        this.clearClassInDesk(Defines.cellSelected);
        this.clearClassInDesk(Defines.chessCellDestinationMark);
        this.clearClassInDesk(Defines.figureMustFight);
    }

    setSelectedCell(cellElement){
        cellElement.classList.add(Defines.cellSelected);
        let cm = this.getCellById(cellElement.id).canMoves;
        for (let canMove of cm){
            if (canMove.moveState == MoveState.fight){
                canMove.cell.canBeat = true;
            }
            canMove.cell.cellElement.classList.add(Defines.chessCellDestinationMark);
        }
    }

    clickToSameCell(cellElement){
        this.clearSelectedCell();
    }
    clickToCanMoveCell(cellElement){
        this.clearSelectedCell();
        this.setSelectedCell(cellElement);
    }
    clickToAnOtherCell(cellElement){
        if (!cellElement.classList.contains(Defines.chessCellDestinationMark))
            this.clearSelectedCell();
        else
            this.moveFigure(cellElement);
    }



    // return cell by id
    getCellById(id){
        let row = Number(id[4]);
        let column = Number(id[5]);
        return this.getCell(row,column);
    }
    clearCanMovePositions(){
        let el = document.getElementsByClassName(Defines.chessCellDestinationMark);
        while (el.length){
            el[0].classList.remove(Defines.chessCellDestinationMark);    
        }
    }
    removeFigure(cell){
        cell.figure = undefined;
    }

    
    // move selected figure to destination cell
    moveFigure(cellElement){
        let selectedElement = document.getElementsByClassName(Defines.cellSelected)[0];
        this.clearSelectedCell();
        let cell = this.getCellById(selectedElement.id);
        let targetCell = this.getCellById(cellElement.id);
        if (targetCell.figure != undefined) this.removeFigure(targetCell);
        targetCell.figure = cell.figure;
        cell.figure = undefined;
        if (this.currentPlayer == FigureColor.white)
            this.currentPlayer = FigureColor.black;
        else
            this.currentPlayer = FigureColor.white;
        // Ajax
        let xhttp = new XMLHttpRequest();
        let msg = JSON.stringify({ "row": cell.row, "column": cell.column, "destinationRow": targetCell.row, "destinationColumn": targetCell.column });
        let fdPost = new FormData();
        fdPost.append("row", cell.row);
        fdPost.append('column', cell.column);
        fdPost.append('destinationRow', targetCell.row);
        fdPost.append('destinationColumn', targetCell.column);

        //fdPost.append("data", msg);
        xhttp.open("POST", "/Chess?handler=move", true);
        xhttp.timeout = 9000;
        ////xhttp.responseType = "json";
        //xhttp.setRequestHeader("Content-Type", 'application/json; charset=utf-8');
        xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        //xhttp.onload = function () {
        //    if (xhttp.status === 200) {
        //        //var userInfo = JSON.parse(xhttp.responseText);
        //    }
        //};
        xhttp.send(fdPost);

        //$.ajax({
        //    type: "POST",
        //    url: "/Chess?handler=move",
        //    beforeSend: function (xhr) {
        //        xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        //    },
        //    data: msg,
        //    contentType : "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (response) {
        //        //var dvItems = $("#dvPostItems");
        //        //dvItems.empty();
        //        //$.each(response, function (i, item) {
        //        //    var $tr = $('<li>').append(item).appendTo(dvItems);
        //        //});
        //        let a = 10;
        //    },
        //    failure: function (response) {
        //        alert(response);
        //    }
        //})

    }

 



    selectFigure(cellElement){
        // if exist selected figure
        let cell = getCellById(cellElement.id);
        if (cell == this.selectedItem)
        {
            // click to the same figure
            cellElement.classList.remove(Defines.cellSelected);
            this.clearCanMovePositions();    
        }else{
            // click to anathe figure or first figure
            if (this.selectedItem == undefined){
                // first click
                cellElement.classList.add(Defines.cellSelected);
                this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
                for (let cell of this.canMovePositions){
                    cell.getCellElement().classList.add(Defines.canMovePositions);
                }
            }else{

            }
             
            cellElement.classList.remove(Defines.cellSelected);
            cellElement.classList.add(Defines.cellSelected);    
        }
        


        cellElement.classList.add(Defines.cellSelected);
        this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
        for (let cell of this.canMovePositions){
            cell.getCellElement().classList
        }

    }
    addDivElement(html,className,owner){
        let gripDeskCell = document.createElement("div");
        gripDeskCell.innerHTML = html;
        gripDeskCell.style.userSelect = 'none';
        gripDeskCell.classList.add(className);//<div class="gripDeskRow">a</div>
        owner.appendChild(gripDeskCell);    
    }
    getCell(row,column){
        return this.desk[row*8+column];
    }
 
    getMovePositions(cell){
        let result = [];
        if (cell.figure == undefined) return result;
        for (let i=0;i<8;i++){
            for (let j=0;j<8;j++){
                let r = cell.figure.checkMove(cell.row,cell.column,i,j);
                if (r==MoveState.can || r == MoveState.fight){
                    result.push( new CanMoveDestination(this.getCell(i,j),r));
                }
            }
        }
        return result;    
    }
    setHoverForCells(){
        for (let cell of this.desk){
            cell.canMoves = this.getMovePositions(cell);
            if (cell.canMoves.length > 0) {
                cell.cellElement.classList.add(Defines.chessCellCanMove);
                cell.cellElement.draggable = true;
            }
            else {
                cell.cellElement.classList.remove(Defines.chessCellCanMove);
                cell.cellElement.draggable = false;
            }
        }
    }

}