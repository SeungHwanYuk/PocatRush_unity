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
  }
});
