public class Level
{
    private Block _startBlock;
    private Block _finishBlock;
    private int _blockCount;

    public Level(Block startBlock, Block finishBlock, int blockCount) {
        _startBlock = startBlock;
        _finishBlock = finishBlock;
        _blockCount = blockCount;
    }

    public Block StartBlock { get => _startBlock; set => _startBlock = value; }
    public Block FinishBlock { get => _finishBlock; set => _finishBlock = value; }
    public int BlockCount { get => _blockCount; set => _blockCount = value; }
}
