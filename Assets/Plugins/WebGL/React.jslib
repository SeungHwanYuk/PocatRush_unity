mergeInto(LibraryManager.library, {
  SaveLikeToReactExtern: function (npcName, liked) {
    window.dispatchReactUnityEvent("likeCount", UTF8ToString(npcName), liked);
  },
});
