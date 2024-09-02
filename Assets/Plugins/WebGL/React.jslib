mergeInto(LibraryManager.library, {
  SaveLikeToReactExtern: function (npcName, liked) {
    window.dispatchReactUnityEvent("likeCount", UTF8ToString(npcName), liked);
  },
  CreateCharacterExtern: function (nickName) {
    window.dispatchReactUnityEvent("Create",UTF8ToString(nickName));
  },
  GameReadyExtern: function (gameReady) {
    window.dispatchReactUnityEvent("GameReady", UTF8ToString(gameReady));
  },
  WorldReadyExtern:function () {
    window.dispatchReactUnityEvent("WorldReady");
  },
  CharExpUpdateExtern: function (exp) {
    window.dispatchReactUnityEvent("ExpUpdate", exp);
  },
  kmResetExtern: function (km) {
    window.dispatchReactUnityEvent("kmReset", km);
  },
  kgResetExtern: function (kg) {
    window.dispatchReactUnityEvent("kgReset", kg);
  },
  minResetExtern: function (min) {
    window.dispatchReactUnityEvent("minReset", min);
  },
   HpUpdateExtern: function (newHp) {
    window.dispatchReactUnityEvent("HpUpdate", newHp);
  }
  
  // 쉼표 빼먹지 말것!
});
