protected class StateMachine{
   enum GameStates{MENU,PLAY,PAUSE,QUIT,DEAD,WIN};
   GameStates GameState;
   protected void Menu(){
      if (GameState==GameStates.PLAY){
         //Player starts the game.
         GameState=GameStates.PLAY;
      }else if (GameState==GameStates.QUIT) {
         //Player quits the game.
         GameState=GameStates.QUIT;
      }
   }
   protected void Playing(){
      if(GameState==GameStates.PAUSE){
         //Player pauses the game.
         GameState=GameStates.PAUSE;
      }else if (GameState==GameStates.DEAD) {
         //Player is dead
         GameState=GameStates.DEAD;
      }else if (GameState==GameStates.WIN) {
         //Player won the game
         GameState=GameStates.WIN;
      }
   }
   protected void Paused(){
      if(GameState==GameStates.PLAY){
         //Game is resumed.
         GameState=GameStates.PLAY;
      }else if (GameState==GameStates.QUIT) {
         //Finalize the game.
         GameState=GameStates.QUIT;
      }
   }
   enum PlayerStates{END,STOPPED,MOVING};
   PlayerStates PlayerState;
   protected void Player(){

   }
}
