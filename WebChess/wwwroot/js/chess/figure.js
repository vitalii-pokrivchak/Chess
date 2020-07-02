import {MoveState} from './moveState.js';
export class Figure{
    constructor(color){
        this.color = color;
    }
    showFigure(cellElement){
        return 0;
    }
    checkMove(rowPos,columnPos,rowDestination,columnDestination,board){
        return MoveState.cannot;
    }
    get direction(){return this.color*2-1;}
    getDraw(cellElement){
        let draw = SVG(cellElement);
        this.figureId = draw.node.id;
        return draw;    
    }

}