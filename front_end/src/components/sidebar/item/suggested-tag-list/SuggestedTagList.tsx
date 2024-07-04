import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Link from 'next/link';
import SuggestedTagItem from './SuggestedTagItem';

export interface ITag {
    tag: string;
}

const SuggestedTagList = () => {
    const tags: string[] = [
        ' List anime của studio TOEI ANIMATION',
        ' List anime của studio MAPPA',
        'List anime thể loại Action -Romance',
        'List anime thể loại Action - Comedy',
        'List anime Ghibli',
    ];
    return (
        <Box>
            {tags.map((tag, index) => (
                <SuggestedTagItem key={index} tag={tag} />
            ))}
        </Box>
    );
};

export default SuggestedTagList;
