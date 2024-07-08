import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import ImageMovie from '@/components/ui/ImageMovie';
import Grid from '@mui/material/Grid';
import Rating from '@/components/ui/Rating';
import Link from 'next/link';
import SelectHover from '@/components/ui/SelectHover';
import HoverInfor, { IHoverInfor } from '@/components/ui/HoverInfor';
import TextComing from '@/components/ui/TextComing';

export interface IUpcommingItem {
    img: string;
    views: string;
    rating: number;
    itemHover: IHoverInfor;
}
const UpcommingItem = ({ item, index }: { item: IUpcommingItem; index: number }) => {
    return (
        <Grid item key={index} xs={2.4}>
            <Box
                sx={{
                    marginX: '10px',
                    marginBottom: '20px',
                    position: 'relative',
                    '&:hover': {
                        [`& .classhover${index}`]: { display: 'flex' },
                    },
                }}
            >
                <Box
                    component={Link}
                    href={'/'}
                    sx={{
                        textDecoration: 'none',
                    }}
                >
                    <Box
                        sx={{
                            marginBottom: '10px',
                            position: 'relative',
                            [`& .classhover${index}`]: {
                                '& svg': {
                                    fontSize: '60px',
                                },
                            },
                        }}
                    >
                        <ImageMovie src={item.img} alt={item.itemHover.name} />
                        <Rating number={item.rating} />
                        <SelectHover className={`classhover${index}`} />
                        <TextComing />
                    </Box>
                    <Box sx={{ display: 'flex', alignItems: 'center', flexDirection: 'column' }}>
                        <Typography
                            sx={{
                                fontSize: '14px',
                                fontWeight: '400',
                                lineHeight: '20px',
                                color: '#fff',
                                whiteSpace: 'nowrap',
                                overflow: 'hidden',
                                textOverflow: 'ellipsis',
                                width: '100%',
                            }}
                        >
                            {item.itemHover.name}
                        </Typography>
                        <Typography
                            sx={{
                                fontSize: '12px',
                                fontWeight: '300',
                                lineHeight: '20px',
                                color: '#7d7d7d',
                            }}
                        >
                            {`Lượt xem: ${item.views}`}
                        </Typography>
                    </Box>
                </Box>
                <HoverInfor index={index} item={item.itemHover} />
            </Box>
        </Grid>
    );
};

export default UpcommingItem;
