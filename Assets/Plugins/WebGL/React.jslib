mergeInto(LibraryManager.library, {
  SaveLikeToReactExtern: function (npcName, liked) {
    window.dispatchReactUnityEvent("likeCount", UTF8ToString(npcName), liked);
  },
  CreateCharacterExtern: function (nickName) {
    window.dispatchReactUnityEvent("Create",UTF8ToString(nickName));
  }
});
